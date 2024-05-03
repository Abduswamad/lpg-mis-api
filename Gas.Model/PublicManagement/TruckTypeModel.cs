namespace Gas.Model.PublicManagement
{
    public class AddTrucktypeModel
    {
        public string Trucktypename { get; set; } = string.Empty;

    }
    public class InsTrucktypeModel
    {
        public int? Trucktypeid { get; set; }
        public string Trucktypename { get; set; } = string.Empty;

    }

    public class UpdateTrucktypeModel
    {
        public int? Trucktypeid { get; set; }
        public string Trucktypename { get; set; } = string.Empty;

    }

    public class GetTrucktypeModel
    {
        public int? Trucktypeid { get; set; }
        public string Trucktypename { get; set; } = string.Empty;
        public bool? IsActive { get; set; }

    }


    public class RequestTrucktypeStatusModel
    {
        public int Trucktypeid { get; set; }
        public bool Isactive { get; set; }
    }

}
