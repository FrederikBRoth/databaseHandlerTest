using System;
using System.Collections.Generic;

namespace pleeweasse.Models
{
    public partial class User
    {
        public User()
        {
            Message = new HashSet<Message>();
            UserChat = new HashSet<UserChat>();
        }

        public string UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }

        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<UserChat> UserChat { get; set; }
    }
}
