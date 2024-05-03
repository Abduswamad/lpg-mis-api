namespace Gas.Model.CompanyManagement
{
    public class AddStaffroleModel
    {
        public List<StaffroledataModel> Roles { get; set; } = new List<StaffroledataModel>();
        public int Staffid { get; set; }
    }
    public class StaffroledataModel
    {
        public int Roleid { get; set; }

    }
    public class InsStaffroleModel
    {
        public int Roleid { get; set; }
        public int Staffid { get; set; }

    }

    public class UpdateStaffroleModel
    {
        public int Roleid { get; set; }
        public int Staffid { get; set; }

    }

    public class GetStaffroleModel
    {
        public int? Roleid { get; set; }
        public int? Staffid { get; set; }
        public bool? Isactive { get; set; }

    }


    public class RequestStaffroleStatusModel
    {
        public int Roleid { get; set; }
        public bool Isactive { get; set; }
        public int? Staffid { get; set; }
    }

}
