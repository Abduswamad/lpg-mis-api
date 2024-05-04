namespace Gas.Model.CompanyManagement
{
    public class AddRoleModel
    {
        public string Rolename { get; set; } = string.Empty;

    }
    public class InsRoleModel
    {
        public int? Roleid { get; set; }
        public string Rolename { get; set; } = string.Empty;

    }

    public class UpdateRoleModel
    {
        public int? Roleid { get; set; }
        public string Rolename { get; set; } = string.Empty;

    }

    public class GetRoleModel
    {
        public int? Roleid { get; set; }
        public string Rolename { get; set; } = string.Empty;
        public bool? IsActive { get; set; }

    }


    public class RequestRoleStatusModel
    {
        public int Roleid { get; set; }
        public bool Isactive { get; set; }
    }

}
