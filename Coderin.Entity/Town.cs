using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class Town : EntityBase
    {
        public Town()
        {
            this.UserDetails = new List<UserDetail>();
        }

        public System.Guid CountryId { get; set; }
        public System.Guid CityId { get; set; }
        public string Name { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<UserDetail> UserDetails { get; set; }
    }
}
