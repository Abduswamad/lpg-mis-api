namespace Gas.Domain.ModelSettings
{
    public class SettingsModel
    {
        public DBConnectionModel DBConnection { get; set; } = new ();
        public string ContentRootPath { get; set; } = string.Empty;
    }
    public class DBConnectionModel
    {
        public string GasDB { get; set; } = string.Empty;        

    }


}
