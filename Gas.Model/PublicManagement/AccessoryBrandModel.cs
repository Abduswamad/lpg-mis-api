using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.PublicManagement
{
    public class AddAccessorybrandModel
    {
        public string Accessorybrandname { get; set; } = string.Empty;

    }
    public class InsAccessorybrandModel
    {
        public int? Accessorybrandid { get; set; }
        public string Accessorybrandname { get; set; } = string.Empty;

    }

    public class UpdateAccessorybrandModel
    {
        public int? Accessorybrandid { get; set; }
        public string Accessorybrandname { get; set; } = string.Empty;

    }

    public class GetAccessorybrandModel
    {
        public int? Accessorybrandid { get; set; }
        public string Accessorybrandname { get; set; } = string.Empty;
        public bool? IsActive { get; set; }

    }


    public class RequestAccessorybrandStatusModel
    {
        public int Accessorybrandid { get; set; }
        public bool Isactive { get; set; }
    }

}
