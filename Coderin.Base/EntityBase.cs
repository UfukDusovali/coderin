using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderin.Base
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.Guid CreatedBy { get; set; }
        public string CreatedIP { get; set; }
        public string CreatedMAC { get; set; }
        public string ModifiedMAC { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public System.Guid ModifiedBy { get; set; }
        public string ModifiedIP { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedADUsername { get; set; }
        public int AutoID { get; set; }
    }
}
