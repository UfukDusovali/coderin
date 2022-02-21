using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coderin.Base;

namespace Coderin.Entity
{
    public partial class FollowQuestion : EntityBase
    {
        public System.Guid FQuestionId { get; set; }
        public System.Guid FFollowerId { get; set; }

        public virtual User User { get; set; }
        public virtual Question Question { get; set; }
    }
}
