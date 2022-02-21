using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class Follow : EntityBase
    {
        public System.Guid FollowingId { get; set; }
        public System.Guid FollowerId { get; set; }

        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
