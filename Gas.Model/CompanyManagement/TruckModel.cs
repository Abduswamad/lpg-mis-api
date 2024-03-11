using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.CompanyManagement
{
    public class AddTruckModel
    {
        public string Platenumber { get; set; } = string.Empty;
        public float? Weigthintones { get; set; }
        public int? Trucktype { get; set; }
        public int? Truckdriver { get; set; }
        public int? Superdealer { get; set; }

    }
    public class InsTruckModel
    {
        public int? Truckid { get; set; }
        public string Platenumber { get; set; } = string.Empty;
        public float? Weigthintones { get; set; }
        public int? Trucktype { get; set; }
        public int? Truckdriver { get; set; }
        public int? Superdealer { get; set; }

    }

    public class UpdateTruckModel
    {
        public int? Truckid { get; set; }
        public string Platenumber { get; set; } = string.Empty;
        public float? Weigthintones { get; set; }
        public int? Trucktype { get; set; }
        public int? Truckdriver { get; set; }
        public int? Superdealer { get; set; }

    }

    public class GetTruckModel
    {
        public int? Truckid { get; set; }
        public string Platenumber { get; set; } = string.Empty;
        public float? Weigthintones { get; set; }
        public int? Trucktype { get; set; }
        public int? Truckdriver { get; set; }
        public int? Superdealer { get; set; }
        public bool? IsActive { get; set; }


    }


    public class RequestTruckStatusModel
    {
        public int Truckid { get; set; }
        public bool Isactive { get; set; }
    }

}
