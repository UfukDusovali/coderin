using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class UserProTitle : EntityBase
    {
        public string Name { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid ProTitleId { get; set; }

        public virtual ProTitle ProTitle { get; set; }
        public virtual User User { get; set; }
    }
}
