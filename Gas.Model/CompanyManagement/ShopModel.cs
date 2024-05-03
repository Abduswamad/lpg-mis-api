namespace Gas.Model.CompanyManagement
{
    public class AddShopModel
    {
        public string Shopname { get; set; } = string.Empty;
        public string Phonenumber { get; set; } = string.Empty;
        public int? Superdealer { get; set; }
        public int? Commonstreet { get; set; }

    }
    public class InsShopModel
    {
        public int? Shopid { get; set; }
        public string Shopname { get; set; } = string.Empty;
        public string Phonenumber { get; set; } = string.Empty;
        public int? Superdealer { get; set; }
        public int? Commonstreet { get; set; }

    }

    public class UpdateShopModel
    {
        public int? Shopid { get; set; }
        public string Shopname { get; set; } = string.Empty;
        public string Phonenumber { get; set; } = string.Empty;
        public int? Superdealer { get; set; }
        public int? Commonstreet { get; set; }

    }

    public class GetShopModel
    {
        public int? Shopid { get; set; }
        public string Shopname { get; set; } = string.Empty;
        public string Phonenumber { get; set; } = string.Empty;
        public int? Superdealer { get; set; }
        public int? Commonstreet { get; set; }
        public bool? IsActive { get; set; }

    }

    public class RequestShopStatusModel
    {
        public int Shopid { get; set; }
        public bool Isactive { get; set; }
    }

}
