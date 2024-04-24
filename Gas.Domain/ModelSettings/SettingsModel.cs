namespace Gas.Domain.ModelSettings
{
    public class SettingsModel
    {
        public DBConnectionModel DBConnection { get; set; } = new ();
        public string ContentRootPath { get; set; } = string.Empty;
        public EmailingModel Email { get; set; } = new EmailingModel();
        public JWTKeyModel Jwt { get; set; } = new JWTKeyModel ();
        public SystemFeature SystemFeatures { get; set; } = new SystemFeature();
    }
    public class DBConnectionModel
    {
        public string GasDB { get; set; } = string.Empty;       

    }
    public class JWTKeyModel
    {
        public string Key { get; set; } = string.Empty;

    }

    public class EmailingModel
    {
        public string SenderEmail { get; set; } = string.Empty;
        public string SenderPassword{ get; set; } = string.Empty;
        public string Host{ get; set; } = string.Empty; 
        public string PortalURL{ get; set; } = string.Empty; 
        public string Subject { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public int Port{ get; set; }

    }


    public class SystemFeature
    {
        public bool SendEmail { get; set; } = true;

    }

}
