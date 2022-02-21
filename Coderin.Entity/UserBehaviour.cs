using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class UserBehaviour : EntityBase
    {
        public string Name { get; set; }
        public Nullable<System.Guid> FollowedId { get; set; }
        public Nullable<System.Guid> UserId { get; set; }
        public Nullable<System.Guid> CommentId { get; set; }
        public Nullable<System.Guid> QuestionId { get; set; }
        public Nullable<System.Guid> AnswerId { get; set; }
        public Nullable<System.Guid> TagId { get; set; }
        public Nullable<bool> Saw { get; set; }
        public short BehaviourStatus { get; set; }

        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual Answer Answer { get; set; }
        public virtual Comment Comment { get; set; }
        
    }
}
