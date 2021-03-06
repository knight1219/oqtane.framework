﻿using Oqtane.Core.Shared.Interfaces;
using System;

namespace Oqtane.Core.Shared.Models
{
    public class Tenant : IAuditable
    {
        public int TenantId { get; set; }
        public string Name { get; set; }
        public string DBConnectionString { get; set; }
        public string DBSchema { get; set; }
        public bool IsInitialized { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
