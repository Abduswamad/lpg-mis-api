namespace Gas.Model.PublicManagement
{
    public class AddRegionModel
    {
        public string Regionname { get; set; } = string.Empty;
        public int? Regioncountry { get; set; }
    }
    public class InsRegionModel
    {
        public int? Regionid { get; set; }
        public string Regionname { get; set; } = string.Empty;
        public int? Regioncountry { get; set; }
    }

    public class UpdateRegionModel
    {
        public int? Regionid { get; set; }
        public string Regionname { get; set; } = string.Empty;
        public int? Regioncountry { get; set; }

    }

    public class GetRegionModel
    {
        public int? Regionid { get; set; }
        public string Regionname { get; set; } = string.Empty;
        public int? Regioncountry { get; set; }
        public bool? IsActive { get; set; }

    }


    public class RequestRegionStatusModel
    {
        public int Regionid { get; set; }
        public bool Isactive { get; set; }
    }

}
