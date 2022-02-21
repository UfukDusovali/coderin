using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class Country : EntityBase
    {
        public Country()
        {
            this.Cities = new List<City>();
            this.UserDetails = new List<UserDetail>();
        }

        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<UserDetail> UserDetails { get; set; }
    }
}
