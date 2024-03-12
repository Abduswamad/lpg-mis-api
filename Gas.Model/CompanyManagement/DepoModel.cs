using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Model.CompanyManagement
{
    public class AddDepoModel
    {
        public string Deponame { get; set; } = string.Empty;
        public string Housenumber { get; set; } = string.Empty;
        public int? Superdealer { get; set; }
        public int? Commonstreet { get; set; }

    }
    public class InsDepoModel
    {
        public int? Depoid { get; set; }
        public string Deponame { get; set; } = string.Empty;
        public string Housenumber { get; set; } = string.Empty;
        public int? Superdealer { get; set; }
        public int? Commonstreet { get; set; }

    }

    public class UpdateDepoModel
    {
        public int? Depoid { get; set; }
        public string Deponame { get; set; } = string.Empty;
        public string Housenumber { get; set; } = string.Empty;
        public int? Superdealer { get; set; }
        public int? Commonstreet { get; set; }

    }

    public class GetDepoModel
    {
        public int? Depoid { get; set; }
        public string Deponame { get; set; } = string.Empty;
        public string Housenumber { get; set; } = string.Empty;
        public int? Superdealer { get; set; }
        public int? Commonstreet { get; set; }
        public bool? IsActive { get; set; }


    }


    public class RequestDepoStatusModel
    {
        public int Depoid { get; set; }
        public bool Isactive { get; set; }
    }

}
