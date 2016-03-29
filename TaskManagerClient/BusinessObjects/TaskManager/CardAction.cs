using System;

namespace SKBKontur.TaskManagerClient.BusinessObjects.TaskManager
{
    public class CardAction
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string CardId { get; set; }
        public User Initiator { get; set; }
        public User AddedUser { get; set; }

        public string Comment { get; set; }

        public string BoardId { get; set; }
        public string ListId { get; set; }
        public string FromListId { get; set; }
        public string ToListId { get; set; }
        public string CreatedCheckListId { get; set; }
        public ActionType Type { get; set; }
    }
}