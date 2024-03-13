using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.PublicManagement
{
    public class AddWardModel
    {
        public string Wardname { get; set; } = string.Empty;
        public int? Warddistrict { get; set; }
    }
    public class InsWardModel
    {
        public int? Wardid { get; set; }
        public string Wardname { get; set; } = string.Empty;
        public int? Warddistrict { get; set; }
    }

    public class UpdateWardModel
    {
        public int? Wardid { get; set; }
        public string Wardname { get; set; } = string.Empty;
        public int? Warddistrict { get; set; }

    }

    public class GetWardModel
    {
        public int? Wardid { get; set; }
        public string Wardname { get; set; } = string.Empty;
        public int? Warddistrict { get; set; }
        public bool? IsActive { get; set; }

    }

    public class RequestWardStatusModel
    {
        public int Wardid { get; set; }
        public bool Isactive { get; set; }
    }

}
