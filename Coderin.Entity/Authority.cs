using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class Authority : EntityBase
    {
        public Authority()
        {
            this.Users = new List<User>();
        }

        public string Name { get; set; }
        public string AuthorityCode { get; set; }
        

        public virtual ICollection<User> Users { get; set; }
    }
}
