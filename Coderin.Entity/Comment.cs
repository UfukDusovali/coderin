using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class Comment : EntityBase
    {
        public Comment()
        {
            this.Comments1 = new List<Comment>();
            this.UserBehaviours = new List<UserBehaviour>();
        }

        public Nullable<System.Guid> ParentId { get; set; }
        public System.Guid AnswerId { get; set; }
        public System.Guid UserId { get; set; }
        public string CommentBody { get; set; }
        public string Name { get; set; }

        public virtual Answer Answer { get; set; }
        public virtual ICollection<Comment> Comments1 { get; set; }
        public virtual Comment Comment1 { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<UserBehaviour> UserBehaviours { get; set; }
    }
}
