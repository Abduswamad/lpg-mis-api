using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.PublicManagement
{
    public class AddCylindercompanyModel
    {
        public string Cylindercompanyname { get; set; } = string.Empty;

    }
    public class InsCylindercompanyModel
    {
        public int? Cylindercompanyid { get; set; }
        public string Cylindercompanyname { get; set; } = string.Empty;

    }

    public class UpdateCylindercompanyModel
    {
        public int? Cylindercompanyid { get; set; }
        public string Cylindercompanyname { get; set; } = string.Empty;

    }

    public class GetCylindercompanyModel
    {
        public int? Cylindercompanyid { get; set; }
        public string Cylindercompanyname { get; set; } = string.Empty;
        public bool? IsActive { get; set; }

    }


    public class RequestCylindercompanyStatusModel
    {
        public int Cylindercompanyid { get; set; }
        public bool Isactive { get; set; }
    }

}
