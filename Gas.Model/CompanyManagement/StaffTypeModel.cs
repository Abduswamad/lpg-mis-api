using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.CompanyManagement
{
    public class AddStafftypeModel
    {
        public string Stafftypename { get; set; } = string.Empty;

    }
    public class InsStafftypeModel
    {
        public int? Stafftypeid { get; set; }
        public string Stafftypename { get; set; } = string.Empty;

    }

    public class UpdateStafftypeModel
    {
        public int? Stafftypeid { get; set; }
        public string Stafftypename { get; set; } = string.Empty;

    }

    public class GetStafftypeModel
    {
        public int? Stafftypeid { get; set; }
        public string Stafftypename { get; set; } = string.Empty;
        public bool? IsActive { get; set; }

    }


    public class RequestStafftypeStatusModel
    {
        public int Stafftypeid { get; set; }
        public bool Isactive { get; set; }
    }

}
