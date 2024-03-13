using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.PublicManagement
{
    public class AddCommonstreetModel
    {
        public string Commonstreetname { get; set; } = string.Empty;
        public int? Commonstreetward { get; set; }
    }
    public class InsCommonstreetModel
    {
        public int? Commonstreetid { get; set; }
        public string Commonstreetname { get; set; } = string.Empty;
        public int? Commonstreetward { get; set; }
    }

    public class UpdateCommonstreetModel
    {
        public int? Commonstreetid { get; set; }
        public string Commonstreetname { get; set; } = string.Empty;
        public int? Commonstreetward { get; set; }

    }

    public class GetCommonstreetModel
    {
        public int? Commonstreetid { get; set; }
        public string Commonstreetname { get; set; } = string.Empty;
        public int? Commonstreetward { get; set; }
        public bool? IsActive { get; set; }

    }

    public class RequestCommonstreetStatusModel
    {
        public int Commonstreetid { get; set; }
        public bool Isactive { get; set; }
    }

}
