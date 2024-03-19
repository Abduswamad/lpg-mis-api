using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.StoreManagement
{
 

    public class GetCylinderstatusModel
    {
        public int? Cylinderstatusid { get; set; }
        public string Cylinderstatusname { get; set; } = string.Empty;
        public bool? IsActive { get; set; }

    }



}
