﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Domain.Entity.PublicManagement
{
    public class GenderEntity
    {
        public int? Gender_id { get; set; }
        public string Gender_name { get; set; } = string.Empty;
        public bool? Is_active { get; set; }
    }
}
