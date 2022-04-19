using System.Collections.Generic;
using System.Threading;

namespace Server.Game.Services.Dataabse
{
    public class ItemUpdateModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
    }

    public enum DatabaseQueueType
    {
        UpdateCharacter,
        UpdateItems,
        UpdateItem
    }

    /// <summary>
    ///     Database queue service
    /// </summary>
    public class DatabaseQueueService
    {
        private readonly DatabaseService _databaseService;

        /// <summary>
        ///     Requests queue
        /// </summary>
        private Queue<(DatabaseQueueType, object)> _requestsQueue;

        public DatabaseQueueService(DatabaseService databaseService)
        {
            _databaseService = databaseService;

            _requestsQueue = new Queue<(DatabaseQueueType, object)>();

            //// Start task for handle messages
            //Task.Run(() => HandleMessages());
        }

        #region Request queue add

        public void UpdateItem(ItemUpdateModel itemUpdateModel)
        {
            _requestsQueue.Enqueue((DatabaseQueueType.UpdateItem, itemUpdateModel));
        }

        #endregion

        private void HandleMessages()
        {
            while (true)
            {
                try
                {
                    if (_requestsQueue.Count > 0)
                    {
                        var request = _requestsQueue.Dequeue();

                        if (request.Item1 is DatabaseQueueType.UpdateItem)
                        {
                            UpdateItemHandle((ItemUpdateModel)request.Item2);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine("ERRORORORORORORRORO " + ex.Message);
                }

                Thread.Sleep(1);
            }
        }

        #region Request queue handle

        private void UpdateItemHandle(ItemUpdateModel itemUpdateModel)
        {
            //_databaseService.UpdateItem(itemUpdateModel.Id, itemUpdateModel.Count);
        }

        #endregion

    }
}
