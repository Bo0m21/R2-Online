using System;
using System.Collections.Generic;
using System.Linq;

namespace Packets.Core.Utilities
{
    /// <summary>
    ///     Class for creating packet
    /// </summary>
    public class FormationPackage
    {
        private LinkedList<byte> _dataPackage;

        /// <summary>
        ///     Packet size
        /// </summary>
        public int Size => _dataPackage.Count;

        /// <summary>
        ///     Create a new instance
        /// </summary>
        public FormationPackage()
        {
            _dataPackage = new LinkedList<byte>();
        }

        /// <summary>
        ///     Create a new instance
        /// </summary>
        /// <param name="dataPackage"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        public FormationPackage(byte[] dataPackage, long offset = 0, long size = 0)
        {
            _dataPackage = new LinkedList<byte>();
            AddBytes(dataPackage, offset, size == 0 ? dataPackage.Length : size);
        }

        /// <summary>
        ///     Add byte
        /// </summary>
        /// <param name="b"></param>
        /// <param name="begin"></param>
        public void AddByte(byte b, bool begin = false)
        {
            if (begin)
            {
                _dataPackage.AddFirst(b);
            }
            else
            {
                _dataPackage.AddLast(b);
            }
        }

        public void AddBytes(byte[] bs, long offset = 0, long size = 0, bool begin = false)
        {
            if (!begin)
            {
                for (long i = offset; i < (size == 0 ? bs.Length : size); i++)
                {
                    AddByte(bs[i], begin);
                }
            }
            else
            {
                for (long i = (size == 0 ? bs.Length : size) - 1; i >= offset; i--)
                {
                    AddByte(bs[i], begin);
                }
            }
        }

        public void AddShort(short s, bool reverse = false, bool begin = false)
        {
            byte[] bytes = BitConverter.GetBytes(s);
            if (reverse)
            {
                Array.Reverse(bytes);
            }

            AddBytes(bytes, 0, bytes.Length, begin);
        }

        public void AddUShort(ushort s, bool reverse = false, bool begin = false)
        {
            byte[] bytes = BitConverter.GetBytes(s);
            if (reverse)
            {
                Array.Reverse(bytes);
            }

            AddBytes(bytes, 0, bytes.Length, begin);
        }

        public void AddInteger(int i, bool reverse = false, bool begin = false)
        {
            byte[] bytes = BitConverter.GetBytes(i);
            if (reverse)
            {
                Array.Reverse(bytes);
            }

            AddBytes(bytes, 0, bytes.Length, begin);
        }

        public void AddUInteger(uint ui, bool reverse = false, bool begin = false)
        {
            byte[] bytes = BitConverter.GetBytes(ui);
            if (reverse)
            {
                Array.Reverse(bytes);
            }

            AddBytes(bytes, 0, bytes.Length, begin);
        }

        public void AddLong(long f, bool reverse = false, bool begin = false)
        {
            byte[] bytes = BitConverter.GetBytes(f);
            if (reverse)
            {
                Array.Reverse(bytes);
            }

            AddBytes(bytes, 0, bytes.Length, begin);
        }

        public void AddULong(ulong ui, bool reverse = false, bool begin = false)
        {
            byte[] bytes = BitConverter.GetBytes(ui);
            if (reverse)
            {
                Array.Reverse(bytes);
            }

            AddBytes(bytes, 0, bytes.Length, begin);
        }

        public void AddFloat(float f, bool reverse = false, bool begin = false)
        {
            byte[] bytes = BitConverter.GetBytes(f);
            if (reverse)
            {
                Array.Reverse(bytes);
            }

            AddBytes(bytes, 0, bytes.Length, begin);
        }

        /// Добавление нулей в массив
        public void AddZeroBytes(int z, bool begin = false)
        {
            for (int i = 0; i < z; i++)
            {
                AddByte(0, begin);
            }
        }

        /// Чтение из пакета
        public byte ReadByte()
        {
            byte? first = _dataPackage.First?.Value;
            if (!first.HasValue)
            {
                throw new Exception("Package is empty");
            }

            _dataPackage.RemoveFirst();
            return first.Value;
        }

        public byte[] ReadBytes(int count)
        {
            byte[] data = new byte[count];

            for (int i = 0; i < count; i++) {
                data[i] = ReadByte();
            }

            return data;
        }

        public short ReadShort(bool reverse = false)
        {
            byte[] data = ReadBytes(2);
            if (reverse)
            {
                Array.Reverse(data);
            }

            return BitConverter.ToInt16(data);
        }

        public ushort ReadUShort(bool reverse = false)
        {
            byte[] data = ReadBytes(2);
            if (reverse)
            {
                Array.Reverse(data);
            }

            return BitConverter.ToUInt16(data);
        }

        public int ReadInteger(bool reverse = false)
        {
            byte[] data = ReadBytes(4);
            if (reverse)
            {
                Array.Reverse(data);
            }

            return BitConverter.ToInt32(data);
        }

        public uint ReadUInteger(bool reverse = false)
        {
            byte[] data = ReadBytes(4);
            if (reverse)
            {
                Array.Reverse(data);
            }

            return BitConverter.ToUInt32(data);
        }

        public long ReadLong(bool reverse = false)
        {
            byte[] data = ReadBytes(8);
            if (reverse)
            {
                Array.Reverse(data);
            }

            return BitConverter.ToInt64(data);
        }

        public ulong ReadULong(bool reverse = false)
        {
            byte[] data = ReadBytes(8);
            if (reverse)
            {
                Array.Reverse(data);
            }

            return BitConverter.ToUInt64(data);
        }

        public float ReadFloat(bool reverse = false)
        {
            byte[] data = ReadBytes(4);
            if (reverse)
            {
                Array.Reverse(data);
            }

            return BitConverter.ToSingle(data);
        }

        /// <summary>
        ///     Получение массива байт пакета
        /// </summary>
        /// <returns></returns>
        public byte[] GetBytes()
        {
            if (Size == 0)
            {
                return new byte[0];
            }

            return _dataPackage.ToArray();
        }
    }
}