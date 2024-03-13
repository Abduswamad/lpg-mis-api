using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.CompanyManagement
{
    public class AddAccessoryModel
    {
        public string Accessoryname { get; set; } = string.Empty;
        public int? Superdealer { get; set; }
        public int? Accessorybrand { get; set; }

    }
    public class InsAccessoryModel
    {
        public int? Accessoryid { get; set; }
        public string Accessoryname { get; set; } = string.Empty;
        public int? Superdealer { get; set; }
        public int? Accessorybrand { get; set; }

    }

    public class UpdateAccessoryModel
    {
        public int? Accessoryid { get; set; }
        public string Accessoryname { get; set; } = string.Empty;
        public int? Superdealer { get; set; }
        public int? Accessorybrand { get; set; }

    }

    public class GetAccessoryModel
    {
        public int? Accessoryid { get; set; }
        public string Accessoryname { get; set; } = string.Empty;
        public int? Superdealer { get; set; }
        public int? Accessorybrand { get; set; }
        public bool? IsActive { get; set; }

    }


    public class RequestAccessoryStatusModel
    {
        public int Accessoryid { get; set; }
        public bool Isactive { get; set; }
    }

}
