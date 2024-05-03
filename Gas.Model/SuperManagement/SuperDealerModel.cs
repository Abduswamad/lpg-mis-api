namespace Gas.Model.PublicManagement
{
    public class AddSuperdealerModel
    {
        public string Superdealername { get; set; } = string.Empty;

    }
    public class InsSuperdealerModel
    {
        public int? Superdealerid { get; set; }
        public string Superdealername { get; set; } = string.Empty;

    }

    public class UpdateSuperdealerModel
    {
        public int? Superdealerid { get; set; }
        public string Superdealername { get; set; } = string.Empty;

    }

    public class GetSuperdealerModel
    {
        public int? Superdealerid { get; set; }
        public string Superdealername { get; set; } = string.Empty;
        public bool? IsActive { get; set; }

    }


    public class RequestSuperdealerStatusModel
    {
        public int Superdealerid { get; set; }
        public bool Isactive { get; set; }
    }


}
