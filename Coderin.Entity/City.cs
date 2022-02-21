using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class City : EntityBase
    {
        public City()
        {
            this.Towns = new List<Town>();
            this.UserDetails = new List<UserDetail>();
        }

        public System.Guid CountryId { get; set; }
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Town> Towns { get; set; }
        public virtual ICollection<UserDetail> UserDetails { get; set; }
    }
}
