namespace Gas.Model.PublicManagement
{
    public class AddDistrictModel
    {
        public string Districtname { get; set; } = string.Empty;
        public int? Districtregion { get; set; }
    }
    public class InsDistrictModel
    {
        public int? Districtid { get; set; }
        public string Districtname { get; set; } = string.Empty;
        public int? Districtregion { get; set; }
    }

    public class UpdateDistrictModel
    {
        public int? Districtid { get; set; }
        public string Districtname { get; set; } = string.Empty;
        public int? Districtregion { get; set; }

    }

    public class GetDistrictModel
    {
        public int? Districtid { get; set; }
        public string Districtname { get; set; } = string.Empty;
        public int? Districtregion { get; set; }
        public bool? IsActive { get; set; }

    }

    public class RequestDistrictStatusModel
    {
        public int Districtid { get; set; }
        public bool Isactive { get; set; }
    }

}
