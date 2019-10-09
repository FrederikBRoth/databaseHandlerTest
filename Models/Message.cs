using System;
using System.Collections.Generic;

namespace pleeweasse.Models
{
    public partial class Message
    {
        public string MessageId { get; set; }
        public DateTime? MessageDatetime { get; set; }
        public string MessageText { get; set; }
        public string MessageChatId { get; set; }
        public string MessageUserId { get; set; }

        public virtual Chat MessageChat { get; set; }
        public virtual User MessageUser { get; set; }
    }
}
