using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class Tag : EntityBase
    {
        public Tag()
        {
            this.ProTitles = new List<ProTitle>();
            this.TagQuestions = new List<TagQuestion>();
        }

        public string Name { get; set; }
        public System.Guid UserId { get; set; }
        public bool IsProTag { get; set; }

        public virtual ICollection<ProTitle> ProTitles { get; set; }
        public virtual ICollection<TagQuestion> TagQuestions { get; set; }
    }
}
