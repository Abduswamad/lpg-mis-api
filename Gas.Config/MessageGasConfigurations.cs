namespace Gas.Config
{
    public static class MessageGasConfigurations
    {
        public static string EmailForPassword(string username, string loginPageUrl, string Password, string companyname)
        {
            string email = $@"
                <!DOCTYPE html>
                <html>
                <body>
                    <p>Dear {username},</p>
                    <p>We are pleased to inform you that your account has been created successfully. You have been provided with a temporary default password that you can use to access your account.</p><p> Please follow the steps below to get started:</p>
                    <ol>
                        <li>Visit the <a href=""{loginPageUrl}"">Login Page</a>.</li>
                        <li>Username: <b>{username}</b></li>
                        <li>Temporary Password: <b>{Password}</b></li>
                        <li>Change Your Password: Once you log in, you will be prompted to change your password. We highly recommend creating a strong, unique password to ensure the security of your account.</li>
                    </ol>
                    <p>Please ensure the security of your default password and do not share it with anyone.</p><p> If you have any questions or encounter any issues during the login process, please don't hesitate to contact our support team for assistance.</p>
                    <p><b>Best regards</b>,<br /><b>{companyname}</b><br/></p>
                </body>
                </html>
            ";
            return email;
        }

        public static string EmailForResetPassword(string username, string Password)
        {
            string email = $@"
                <!DOCTYPE html>
                <html>
                <body>
                    <p>Dear {username},</p>
                    <p>We are pleased to inform you that your Password has been Reseted successfully. You have been provided with a temporary default password that you can use to access your account.</p>
                    <ol>
                        <li>Username: <b>{username}</b></li>
                        <li>Temporary Password: <b>{Password}</b></li>
                        <li>Change Your Password: Once you log in, you will be prompted to change your password. We highly recommend creating a strong, unique password to ensure the security of your account. </li>
                    </ol>
                    <p>Please ensure the security of your default password and do not share it with anyone.</p><p> If you have any questions or encounter any issues during the login process, please don't hesitate to contact our support team for assistance.</p>
                    <p><b>Best regards</b>,<br/></p>
                </body>
                </html>
            ";
            return email;
        }
    }
}
