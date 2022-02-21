using Coderin.Base;
using System;
using System.Collections.Generic;

namespace Coderin.Entity
{
    public partial class ErrorLog : EntityBase
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string CustomMesaj { get; set; }
        public string Name { get; set; }

    }
}
