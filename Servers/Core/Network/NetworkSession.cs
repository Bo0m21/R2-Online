﻿using Packets.Core.Utilities;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Core.Network
{
    /// <summary>
    /// TCP session is used to read and write data from the connected TCP client
    /// </summary>
    /// <remarks>Thread-safe</remarks>
    public class NetworkSession
    {
        /// <summary>
        /// Initialize the session with a given server
        /// </summary>
        /// <param name="server">TCP server</param>
        public NetworkSession(NetworkServer server)
        {
            Id = Guid.NewGuid();
            Server = server;
        }

        /// <summary>
        /// Session Id
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Server
        /// </summary>
        public NetworkServer Server { get; }

        /// <summary>
        /// Socket
        /// </summary>
        public Socket Socket { get; private set; }

        /// <summary>
        /// Number of bytes pending sent by the session
        /// </summary>
        public long BytesPending { get; private set; }

        /// <summary>
        /// Number of bytes sending by the session
        /// </summary>
        public long BytesSending { get; private set; }

        /// <summary>
        /// Number of bytes sent by the session
        /// </summary>
        public long BytesSent { get; private set; }

        /// <summary>
        /// Number of bytes received by the session
        /// </summary>
        public long BytesReceived { get; private set; }

        /// <summary>
        /// Option: receive buffer size
        /// </summary>
        public int OptionReceiveBufferSize
        {
            get => Socket.ReceiveBufferSize;
            set => Socket.ReceiveBufferSize = value;
        }

        /// <summary>
        /// Option: send buffer size
        /// </summary>
        public int OptionSendBufferSize
        {
            get => Socket.SendBufferSize;
            set => Socket.SendBufferSize = value;
        }

        /// <summary>
        /// Option: receive timeout in milliseconds
        /// </summary>
        /// <remarks>
        /// The default value is 0, which indicates an infinite time-out period. Specifying -1 also indicates an infinite time-out period.
        /// </remarks>
        public int OptionReceiveTimeout
        {
            get => Socket.ReceiveTimeout;
            set => Socket.ReceiveTimeout = value;
        }

        /// <summary>
        /// Option: send timeout in milliseconds
        /// </summary>
        /// <remarks>
        /// The default value is 0, which indicates an infinite time-out period. Specifying -1 also indicates an infinite time-out period.
        /// </remarks>
        public int OptionSendTimeout
        {
            get => Socket.SendTimeout;
            set => Socket.SendTimeout = value;
        }

        /// <summary>
        /// Option: linger state
        /// </summary>
        public LingerOption OptionLingerState
        {
            get => Socket.LingerState;
            set => Socket.LingerState = value;
        }

        #region Connect/Disconnect session

        /// <summary>
        /// Is the session connected?
        /// </summary>
        public bool IsConnected { get; private set; }

        /// <summary>
        /// Connect the session
        /// </summary>
        /// <param name="socket">Session socket</param>
        internal void Connect(Socket socket)
        {
            Socket = socket;

            // Setup buffers
            _receiveBuffer = new Buffer();
            _sendBufferMain = new Buffer();
            _sendBufferFlush = new Buffer();

            // Setup event args
            _receiveEventArg = new SocketAsyncEventArgs();
            _receiveEventArg.Completed += OnAsyncCompleted;
            _sendEventArg = new SocketAsyncEventArgs();
            _sendEventArg.Completed += OnAsyncCompleted;

            // Apply the option: keep alive
            if (Server.OptionKeepAlive)
            {
                Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            }

            // Apply the option: no delay
            if (Server.OptionNoDelay)
            {
                Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.NoDelay, true);
            }

            // Prepare receive & send buffers
            _receiveBuffer.Reserve(OptionReceiveBufferSize);
            _sendBufferMain.Reserve(OptionSendBufferSize);
            _sendBufferFlush.Reserve(OptionSendBufferSize);

            // Reset statistic
            BytesPending = 0;
            BytesSending = 0;
            BytesSent = 0;
            BytesReceived = 0;

            // Update the connected flag
            IsConnected = true;

            // Call the session connected handler
            OnConnected();

            // Call the session connected handler in the server
            Server.OnConnectedInternal(this);

            // Call the empty send buffer handler
            if (_sendBufferMain.IsEmpty)
            {
                OnEmpty();
            }

            // Try to receive something from the client
            TryReceive();
        }

        /// <summary>
        /// Disconnect the session
        /// </summary>
        /// <returns>'true' if the section was successfully disconnected, 'false' if the section is already disconnected</returns>
        public virtual bool Disconnect()
        {
            if (!IsConnected)
            {
                return false;
            }

            // Reset event args
            _receiveEventArg.Completed -= OnAsyncCompleted;
            _sendEventArg.Completed -= OnAsyncCompleted;

            try
            {
                try
                {
                    // Shutdown the socket associated with the client
                    Socket.Shutdown(SocketShutdown.Both);
                }
                catch (SocketException)
                {

                }

                // Close the session socket
                Socket.Close();

                // Dispose the session socket
                Socket.Dispose();
            }
            catch (ObjectDisposedException)
            {

            }

            // Update the connected flag
            IsConnected = false;

            // Update sending/receiving flags
            _receiving = false;
            _sending = false;

            // Clear send/receive buffers
            ClearBuffers();

            // Call the session disconnected handler
            OnDisconnected();

            // Call the session disconnected handler in the server
            Server.OnDisconnectedInternal(this);

            // Unregister session
            Server.UnregisterSession(Id);

            return true;
        }

        #endregion

        #region Send/Recieve data

        // Receive buffer
        private bool _receiving;
        private Buffer _receiveBuffer;
        private SocketAsyncEventArgs _receiveEventArg;
        private int _receiveThreadId;

        // Send buffer
        private readonly object _sendLock = new object();
        private bool _sending;
        private Buffer _sendBufferMain;
        private Buffer _sendBufferFlush;
        private SocketAsyncEventArgs _sendEventArg;
        private long _sendBufferFlushOffset;
        private int _sendThreadId;

        /// <summary>
        /// Send data to the client (synchronous)
        /// </summary>
        /// <param name="buffer">Buffer to send</param>
        /// <returns>Size of sent data</returns>
        public virtual long Send(byte[] buffer)
        {
            return Send(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Send data to the client (synchronous)
        /// </summary>
        /// <param name="buffer">Buffer to send</param>
        /// <param name="offset">Buffer offset</param>
        /// <param name="size">Buffer size</param>
        /// <returns>Size of sent data</returns>
        public virtual long Send(byte[] buffer, long offset, long size)
        {
            if (!IsConnected)
            {
                return 0;
            }

            if (size == 0)
            {
                return 0;
            }

            // Sent data to the client
            long sent = Socket.Send(buffer, (int)offset, (int)size, SocketFlags.None, out SocketError ec);

            if (sent > 0)
            {
                // Update statistic
                BytesSent += sent;
                Interlocked.Add(ref Server._bytesSent, size);

                // Call the buffer sent handler
                OnSent(sent, BytesPending + BytesSending);
            }

            // Check for socket error
            if (ec != SocketError.Success)
            {
                SendError(ec);
                Disconnect();
            }

            return sent;
        }

        /// <summary>
        /// Send text to the client (synchronous)
        /// </summary>
        /// <param name="text">Text string to send</param>
        /// <returns>Size of sent data</returns>
        public virtual long Send(string text)
        {
            return Send(Encoding.UTF8.GetBytes(text));
        }

        /// <summary>
        /// Send data to the client (asynchronous)
        /// </summary>
        /// <param name="buffer">Buffer to send</param>
        /// <returns>'true' if the data was successfully sent, 'false' if the session is not connected</returns>
        public virtual bool SendAsync(byte[] buffer)
        {
            return SendAsync(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Send data to the client (asynchronous)
        /// </summary>
        /// <param name="buffer">Buffer to send</param>
        /// <param name="offset">Buffer offset</param>
        /// <param name="size">Buffer size</param>
        /// <returns>'true' if the data was successfully sent, 'false' if the session is not connected</returns>
        public virtual bool SendAsync(byte[] buffer, long offset, long size)
        {
            if (!IsConnected)
            {
                return false;
            }

            if (size == 0)
            {
                return true;
            }

            lock (_sendLock)
            {
                // Detect multiple send handlers
                bool sendRequired = _sendBufferMain.IsEmpty || _sendBufferFlush.IsEmpty;

                // Fill the main send buffer
                _sendBufferMain.Append(buffer, offset, size);

                // Update statistic
                BytesPending = _sendBufferMain.Size;

                // Avoid multiple send handlers
                if (!sendRequired)
                {
                    return true;
                }
            }

            // Try to send the main buffer
            if (Thread.CurrentThread.ManagedThreadId == _sendThreadId)
            {
                ThreadPool.QueueUserWorkItem(_ => TrySend());
            }
            else
            {
                TrySend();
            }

            return true;
        }

        /// <summary>
        /// Send text to the client (asynchronous)
        /// </summary>
        /// <param name="text">Text string to send</param>
        /// <returns>'true' if the text was successfully sent, 'false' if the session is not connected</returns>
        public virtual bool SendAsync(string text)
        {
            return SendAsync(Encoding.UTF8.GetBytes(text));
        }

        /// <summary>
        /// Receive data from the client (synchronous)
        /// </summary>
        /// <param name="buffer">Buffer to receive</param>
        /// <returns>Size of received data</returns>
        public virtual long Receive(byte[] buffer)
        {
            return Receive(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Receive data from the client (synchronous)
        /// </summary>
        /// <param name="buffer">Buffer to receive</param>
        /// <param name="offset">Buffer offset</param>
        /// <param name="size">Buffer size</param>
        /// <returns>Size of received data</returns>
        public virtual long Receive(byte[] buffer, long offset, long size)
        {
            if (!IsConnected)
            {
                return 0;
            }

            if (size == 0)
            {
                return 0;
            }

            // Receive data from the client
            long received = Socket.Receive(buffer, (int)offset, (int)size, SocketFlags.None, out SocketError ec);

            if (received > 0)
            {
                // Update statistic
                BytesReceived += received;
                Interlocked.Add(ref Server._bytesReceived, received);

                // Call the buffer received handler
                FormationPackage formationPackage = new FormationPackage(buffer);
                do
                {
                    short packetSize = formationPackage.ReadShort();
                    OnReceived(formationPackage.ReadBytes(packetSize - 2), 0, packetSize - 2);
                } while (formationPackage.GetBytes().Length > 0);
            }

            // Check for socket error
            if (ec != SocketError.Success)
            {
                SendError(ec);
                Disconnect();
            }

            return received;
        }

        /// <summary>
        /// Receive text from the client (synchronous)
        /// </summary>
        /// <param name="size">Text size to receive</param>
        /// <returns>Received text</returns>
        public virtual string Receive(long size)
        {
            byte[] buffer = new byte[size];
            long length = Receive(buffer);
            return Encoding.UTF8.GetString(buffer, 0, (int)length);
        }

        /// <summary>
        /// Receive data from the client (asynchronous)
        /// </summary>
        public virtual void ReceiveAsync()
        {
            // Try to receive datagram
            if (Thread.CurrentThread.ManagedThreadId == _sendThreadId)
            {
                ThreadPool.QueueUserWorkItem(_ => TryReceive());
            }
            else
            {
                TryReceive();
            }
        }

        /// <summary>
        /// Try to receive new data
        /// </summary>
        private void TryReceive()
        {
            if (_receiving)
            {
                return;
            }

            if (!IsConnected)
            {
                return;
            }

            try
            {
                // Async receive with the receive handler
                _receiving = true;
                _receiveEventArg.SetBuffer(_receiveBuffer.Data, 0, (int)_receiveBuffer.Capacity);
                _receiveThreadId = Thread.CurrentThread.ManagedThreadId;

                if (!Socket.ReceiveAsync(_receiveEventArg))
                {
                    ProcessReceive(_receiveEventArg);
                }
            }
            catch (ObjectDisposedException)
            {

            }
        }

        /// <summary>
        /// Try to send pending data
        /// </summary>
        private void TrySend()
        {
            if (_sending)
            {
                return;
            }

            if (!IsConnected)
            {
                return;
            }

            // Swap send buffers
            if (_sendBufferFlush.IsEmpty)
            {
                lock (_sendLock)
                {
                    // Swap flush and main buffers
                    _sendBufferFlush = Interlocked.Exchange(ref _sendBufferMain, _sendBufferFlush);
                    _sendBufferFlushOffset = 0;

                    // Update statistic
                    BytesPending = 0;
                    BytesSending += _sendBufferFlush.Size;
                }
            }
            else
            {
                return;
            }

            // Check if the flush buffer is empty
            if (_sendBufferFlush.IsEmpty)
            {
                // Call the empty send buffer handler
                OnEmpty();
                return;
            }

            try
            {
                // Async write with the write handler
                _sending = true;
                _sendEventArg.SetBuffer(_sendBufferFlush.Data, (int)_sendBufferFlushOffset, (int)(_sendBufferFlush.Size - _sendBufferFlushOffset));
                _sendThreadId = Thread.CurrentThread.ManagedThreadId;

                if (!Socket.SendAsync(_sendEventArg))
                {
                    ProcessSend(_sendEventArg);
                }
            }
            catch (ObjectDisposedException)
            {

            }
        }

        /// <summary>
        /// Clear send/receive buffers
        /// </summary>
        private void ClearBuffers()
        {
            lock (_sendLock)
            {
                // Clear send buffers
                _sendBufferMain.Clear();
                _sendBufferFlush.Clear();
                _sendBufferFlushOffset = 0;

                // Update statistic
                BytesPending = 0;
                BytesSending = 0;
            }
        }

        #endregion

        #region IO processing

        /// <summary>
        /// This method is called whenever a receive or send operation is completed on a socket
        /// </summary>
        private void OnAsyncCompleted(object sender, SocketAsyncEventArgs e)
        {
            // Determine which type of operation just completed and call the associated handler
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Receive:
                    ProcessReceive(e);
                    break;
                case SocketAsyncOperation.Send:
                    ProcessSend(e);
                    break;
                default:
                    throw new ArgumentException("The last operation completed on the socket was not a receive or send");
            }
        }

        /// <summary>
        /// This method is invoked when an asynchronous receive operation completes
        /// </summary>
        private void ProcessReceive(SocketAsyncEventArgs e)
        {
            _receiving = false;

            if (!IsConnected)
            {
                return;
            }

            long size = e.BytesTransferred;

            // Received some data from the client
            if (size > 0)
            {
                // Update statistic
                BytesReceived += size;
                Interlocked.Add(ref Server._bytesReceived, size);

                // Call the buffer received handler
                FormationPackage formationPackage = new FormationPackage(_receiveBuffer.Data, 0, size);
                do
                {
                    short packetSize = formationPackage.ReadShort();
                    OnReceived(formationPackage.ReadBytes(packetSize - 2), 0, packetSize - 2);
                } while (formationPackage.GetBytes().Length > 0);

                // Reset the receive thread Id
                _receiveThreadId = 0;

                // If the receive buffer is full increase its size
                if (_receiveBuffer.Capacity == size)
                {
                    _receiveBuffer.Reserve(2 * size);
                }
            }

            // Try to receive again if the session is valid
            if (e.SocketError == SocketError.Success)
            {
                // If zero is returned from a read operation, the remote end has closed the connection
                if (size > 0)
                {
                    TryReceive();
                }
                else
                {
                    Disconnect();
                }
            }
            else
            {
                SendError(e.SocketError);
                Disconnect();
            }
        }

        /// <summary>
        /// This method is invoked when an asynchronous send operation completes
        /// </summary>
        private void ProcessSend(SocketAsyncEventArgs e)
        {
            _sending = false;

            if (!IsConnected)
            {
                return;
            }

            long size = e.BytesTransferred;

            // Send some data to the client
            if (size > 0)
            {
                // Update statistic
                BytesSending -= size;
                BytesSent += size;
                Interlocked.Add(ref Server._bytesSent, size);

                // Increase the flush buffer offset
                _sendBufferFlushOffset += size;

                // Successfully send the whole flush buffer
                if (_sendBufferFlushOffset == _sendBufferFlush.Size)
                {
                    // Clear the flush buffer
                    _sendBufferFlush.Clear();
                    _sendBufferFlushOffset = 0;
                }

                // Call the buffer sent handler
                OnSent(size, BytesPending + BytesSending);

                // Reset the send thread Id
                _sendThreadId = 0;
            }

            // Try to send again if the session is valid
            if (e.SocketError == SocketError.Success)
            {
                TrySend();
            }
            else
            {
                SendError(e.SocketError);
                Disconnect();
            }
        }

        #endregion

        #region Session handlers

        /// <summary>
        /// Handle client connected notification
        /// </summary>
        protected virtual void OnConnected() { }

        /// <summary>
        /// Handle client disconnected notification
        /// </summary>
        protected virtual void OnDisconnected() { }

        /// <summary>
        /// Handle buffer received notification
        /// </summary>
        /// <param name="buffer">Received buffer</param>
        /// <param name="offset">Received buffer offset</param>
        /// <param name="size">Received buffer size</param>
        /// <remarks>
        /// Notification is called when another chunk of buffer was received from the client
        /// </remarks>
        protected virtual void OnReceived(byte[] buffer, long offset, long size) { }

        /// <summary>
        /// Handle buffer sent notification
        /// </summary>
        /// <param name="sent">Size of sent buffer</param>
        /// <param name="pending">Size of pending buffer</param>
        /// <remarks>
        /// Notification is called when another chunk of buffer was sent to the client.
        /// This handler could be used to send another buffer to the client for instance when the pending size is zero.
        /// </remarks>
        protected virtual void OnSent(long sent, long pending) { }

        /// <summary>
        /// Handle empty send buffer notification
        /// </summary>
        /// <remarks>
        /// Notification is called when the send buffer is empty and ready for a new data to send.
        /// This handler could be used to send another buffer to the client.
        /// </remarks>
        protected virtual void OnEmpty() { }

        /// <summary>
        /// Handle error notification
        /// </summary>
        /// <param name="error">Socket error code</param>
        protected virtual void OnError(SocketError error) { }

        #endregion

        #region Error handling

        /// <summary>
        /// Send error notification
        /// </summary>
        /// <param name="error">Socket error code</param>
        private void SendError(SocketError error)
        {
            // Skip disconnect errors
            if (error == SocketError.ConnectionAborted ||
                error == SocketError.ConnectionRefused ||
                error == SocketError.ConnectionReset ||
                error == SocketError.OperationAborted ||
                error == SocketError.Shutdown)
            {
                return;
            }

            OnError(error);
        }

        #endregion
    }
}