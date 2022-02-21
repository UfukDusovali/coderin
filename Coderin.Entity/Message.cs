using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class Message : EntityBase
    {
        public System.Guid SenderId { get; set; }
        public System.Guid ReceiverId { get; set; }
        public Nullable<System.Guid> ChatId { get; set; }
        public string MessageBody { get; set; }
        public string Name { get; set; }
        public bool IsRead { get; set; }
        public System.DateTime ReadDate { get; set; }
        public string ReadIP { get; set; }
        
        public virtual Chat Chat { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
