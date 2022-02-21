using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class Photo : EntityBase
    {
        public System.Guid UserId { get; set; }
        public string Name { get; set; }
        public string PhotoPath { get; set; }

        public virtual User User { get; set; }
    }
}
