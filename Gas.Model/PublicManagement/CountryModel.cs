namespace Gas.Model.PublicManagement
{
    public class AddCountryModel
    {
        public string Countryname { get; set; } = string.Empty;

    }
    public class InsCountryModel
    {
        public int? Countryid { get; set; }
        public string Countryname { get; set; } = string.Empty;

    }

    public class UpdateCountryModel
    {
        public int? Countryid { get; set; }
        public string Countryname { get; set; } = string.Empty;

    }

    public class GetCountryModel
    {
        public int? Countryid { get; set; }
        public string Countryname { get; set; } = string.Empty;
        public bool? IsActive { get; set; }

    }


    public class RequestCountryStatusModel
    {
        public int Countryid { get; set; }
        public bool Isactive { get; set; }
    }

}
