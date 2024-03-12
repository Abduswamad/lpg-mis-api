using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.PublicManagement
{
    public class AddCylindercategoryModel
    {
        public string Cylindercategoryname { get; set; } = string.Empty;

    }
    public class InsCylindercategoryModel
    {
        public int? Cylindercategoryid { get; set; }
        public string Cylindercategoryname { get; set; } = string.Empty;

    }

    public class UpdateCylindercategoryModel
    {
        public int? Cylindercategoryid { get; set; }
        public string Cylindercategoryname { get; set; } = string.Empty;

    }

    public class GetCylindercategoryModel
    {
        public int? Cylindercategoryid { get; set; }
        public string Cylindercategoryname { get; set; } = string.Empty;
        public bool? IsActive { get; set; }

    }


    public class RequestCylindercategoryStatusModel
    {
        public int Cylindercategoryid { get; set; }
        public bool Isactive { get; set; }
    }

}
