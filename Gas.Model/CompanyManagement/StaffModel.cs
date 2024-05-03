namespace Gas.Model.CompanyManagement
{
    public class AddStaffModel
    {
        public string Firstname { get; set; } = string.Empty;
        public string Staffidnumber { get; set; } = string.Empty;
        public string Middlename { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Staffemail { get; set; } = string.Empty;
        public string Staffusername { get; set; } = string.Empty;
        public string Phonenumber { get; set; } = string.Empty;
        public int? Staffgender { get; set; }
        public int? Stafftype { get; set; }
        public int? Commonstreet { get; set; }
        public int? Superdealer { get; set; }

    }
    public class InsStaffModel
    {
        public int? Staffid { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Staffidnumber { get; set; } = string.Empty;
        public string Middlename { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Staffemail { get; set; } = string.Empty;
        public string Staffusername { get; set; } = string.Empty;
        public string Phonenumber { get; set; } = string.Empty;
        public string Staffpassword { get; set; } = string.Empty;
        public int? Staffgender { get; set; }
        public int? Stafftype { get; set; }
        public int? Commonstreet { get; set; } 
        public int? Superdealer { get; set; }

    }

    public class UpdateStaffModel
    {
        public int? Staffid { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Staffidnumber { get; set; } = string.Empty;
        public string Middlename { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Staffemail { get; set; } = string.Empty;
        public string Staffusername { get; set; } = string.Empty;
        public string Phonenumber { get; set; } = string.Empty;
        public int? Staffgender { get; set; }
        public int? Stafftype { get; set; }
        public int? Commonstreet { get; set; }
        public int? Superdealer { get; set; }

    }

    public class GetStaffModel
    {
        public int? Staffid { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Staffidnumber { get; set; } = string.Empty;
        public string Middlename { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Staffemail { get; set; } = string.Empty;
        public string Staffusername { get; set; } = string.Empty;
        public string Phonenumber { get; set; } = string.Empty;
        public int? Staffgender { get; set; }
        public int? Stafftype { get; set; }
        public int? Commonstreet { get; set; }
        public int? Superdealer { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsFirstTime { get; set; }


    }

    public class RequestStaffpassChangeModel
    {
        public int Staffid { get; set; }
        public string Staffpassword { get; set; } = string.Empty;
        public string Oldpassword { get; set; } = string.Empty;
    }

    public class RequestStaffpassChangeOnLoginModel
    {
        public int? Staffid { get; set; }
        public string Staffusername { get; set; } = string.Empty;
        public string Staffpassword { get; set; } = string.Empty;
        public string Oldpassword { get; set; } = string.Empty;
    }

    public class RequestStaffResetpassChangeModel
    {
        public int Staffid { get; set; }
        public string Staffpassword { get; set; } = string.Empty;
    }


    public class RequestStaffStatusModel
    {
        public int Staffid { get; set; }
        public bool Isactive { get; set; }
    }

    public class RequestStaffLoginEntity
    {
        public string Staffusername { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
