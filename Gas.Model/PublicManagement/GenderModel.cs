using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.PublicManagement
{
    public class AddGenderModel
    {
        public string Gendername { get; set; } = string.Empty;

    }
    public class InsGenderModel
    {
        public int? Genderid { get; set; }
        public string Gendername { get; set; } = string.Empty;

    }

    public class UpdateGenderModel
    {
        public int? Genderid { get; set; }
        public string Gendername { get; set; } = string.Empty;

    }

    public class GetGenderModel
    {
        public int? Genderid { get; set; }
        public string Gendername { get; set; } = string.Empty;
        public bool? IsActive { get; set; }

    }


    public class RequestGenderStatusModel
    {
        public int Genderid { get; set; }
        public bool Isactive { get; set; }
    }

}
