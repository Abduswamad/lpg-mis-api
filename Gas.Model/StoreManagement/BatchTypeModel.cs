namespace Gas.Model.StoreManagement
{
    public class GetBatchtypeModel
    {
        public int? Batchtypeid { get; set; }
        public string Batchtypename { get; set; } = string.Empty;
        public bool? IsActive { get; set; }

    }

}
