using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class Chat : EntityBase
    {
        public Chat()
        {
            this.Messages = new List<Message>();
        }

        public System.Guid UserId { get; set; }
        public System.Guid ChatId { get; set; }
        public string Subject { get; set; }
        public string Name { get; set; }
        
        public virtual User User { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
