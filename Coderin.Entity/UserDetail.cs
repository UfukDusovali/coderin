using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class UserDetail : EntityBase
    {
        public string Name { get; set; }
        public System.Guid Avatar { get; set; }
        public bool Working { get; set; }
        public string CompanyName { get; set; }
        public bool Gender { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public System.Guid CountryId { get; set; }
        public System.Guid CityId { get; set; }
        public System.Guid TownId { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual Town Town { get; set; }
        public virtual User User { get; set; }
    }
}
