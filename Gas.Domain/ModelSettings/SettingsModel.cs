namespace Gas.Domain.ModelSettings
{
    public class SettingsModel
    {
        public DBConnectionModel DBConnection { get; set; } = new ();
        public string ContentRootPath { get; set; } = string.Empty;
        public JWTKeyModel Jwt { get; set; } = new JWTKeyModel ();
    }
    public class DBConnectionModel
    {
        public string GasDB { get; set; } = string.Empty;       

    }
    public class JWTKeyModel
    {
        public string Key { get; set; } = string.Empty;

    }


}
