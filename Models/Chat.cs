using System;
using System.Collections.Generic;

namespace pleeweasse.Models
{
    public partial class Chat
    {
        public Chat()
        {
            Message = new HashSet<Message>();
        }

        public string ChatId { get; set; }
        public string ChatTopic { get; set; }
        public string ChatPassword { get; set; }
        public string UserChatUserId { get; set; }

        public virtual UserChat UserChat { get; set; }
        public virtual ICollection<Message> Message { get; set; }
    }
}
