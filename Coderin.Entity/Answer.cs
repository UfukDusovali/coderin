using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class Answer : EntityBase
    {
        public Answer()
        {
            this.Comments = new List<Comment>();
        }

        public System.Guid QuestionId { get; set; }
        public System.Guid UserId { get; set; }
        public string Name { get; set; }
        public string NameUrl { get; set; }
        public int Vote { get; set; }
        public Nullable<bool> IsCheck { get; set; }
        public string AnswerBody { get; set; }

        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<UserBehaviour> UserBehaviours { get; set; }
    }
}
