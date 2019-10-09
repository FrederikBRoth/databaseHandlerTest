using System;
using System.Collections.Generic;

namespace pleeweasse.Models
{
    public partial class UserChat
    {
        public UserChat()
        {
            Chat = new HashSet<Chat>();
        }

        public string UserChatChatId { get; set; }
        public string UserChatUserId { get; set; }

        public virtual User UserChatUser { get; set; }
        public virtual ICollection<Chat> Chat { get; set; }
    }
}
