using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class ProTitle : EntityBase
    {
        public ProTitle()
        {
            this.UserProTitles = new List<UserProTitle>();
        }

        public string Name { get; set; }
        public System.Guid TagId { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual ICollection<UserProTitle> UserProTitles { get; set; }
    }
}
