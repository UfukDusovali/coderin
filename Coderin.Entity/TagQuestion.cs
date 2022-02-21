using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class TagQuestion : EntityBase
    {
        public System.Guid TagId { get; set; }
        public System.Guid QuestionId { get; set; }
        public string Name { get; set; }

        public virtual Question Question { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
