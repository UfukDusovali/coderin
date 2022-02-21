using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class Question : EntityBase
    {
        public Question()
        {
            this.Answers = new List<Answer>();
            this.TagQuestions = new List<TagQuestion>();
            this.UserBehaviours = new List<UserBehaviour>();
            this.FollowQuestions = new List<FollowQuestion>();
        }

        public System.Guid UserId { get; set; }
        public string Name { get; set; }
        public string NameUrl { get; set; }
        public string QuestionBody { get; set; }
        public int Vote { get; set; }
        public int Views { get; set; }
        

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<TagQuestion> TagQuestions { get; set; }
        public virtual ICollection<UserBehaviour> UserBehaviours { get; set; }
        public virtual ICollection<FollowQuestion> FollowQuestions { get; set; }
    }
}
