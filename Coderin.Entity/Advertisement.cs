using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class Advertisement : EntityBase
    {
        public string Name { get; set; }
        public System.Guid UserId { get; set; }
        public System.Guid FotoId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public decimal Price { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        
        public virtual User User { get; set; }
    }
}
