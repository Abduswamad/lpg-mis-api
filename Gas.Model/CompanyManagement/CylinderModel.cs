using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.CompanyManagement
{
    public class AddCylinderModel
    {
        public string Cylindername { get; set; } = string.Empty;
        public int? Superdealer { get; set; }
        public int? Cylindercategory { get; set; }
        public int? Cylindercompany { get; set; }

    }
    public class InsCylinderModel
    {
        public int? Cylinderid { get; set; }
        public string Cylindername { get; set; } = string.Empty;
        public int? Superdealer { get; set; }
        public int? Cylindercategory { get; set; }
        public int? Cylindercompany { get; set; }

    }

    public class UpdateCylinderModel
    {
        public int? Cylinderid { get; set; }
        public string Cylindername { get; set; } = string.Empty;
        public int? Superdealer { get; set; }
        public int? Cylindercategory { get; set; }
        public int? Cylindercompany { get; set; }

    }

    public class GetCylinderModel
    {
        public int? Cylinderid { get; set; }
        public string Cylindername { get; set; } = string.Empty;
        public int? Superdealer { get; set; }
        public int? Cylindercategory { get; set; }
        public int? Cylindercompany { get; set; }
        public bool? IsActive { get; set; }


    }


    public class RequestCylinderStatusModel
    {
        public int Cylinderid { get; set; }
        public bool Isactive { get; set; }
    }

}
