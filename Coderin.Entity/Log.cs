using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class Log : EntityBase
    {
        public string TableName { get; set; }
        public string ProcessType { get; set; }
        public System.Guid UserId { get; set; }
        public string Name { get; set; }

        public virtual User User { get; set; }
    }
}
