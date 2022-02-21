using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class Category : EntityBase
    {
        public Category()
        {
            this.Categories1 = new List<Category>();
        }

        public System.Guid ParentId { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Category> Categories1 { get; set; }
        public virtual Category Category1 { get; set; }
    }
}
