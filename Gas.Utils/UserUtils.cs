
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Gas.Utils
{
    public static class UserUtils
    {
        public static string ComputePasswordHash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string CapitalizeFirstLetter(string input)
        {
            // Create a TextInfo object for the current culture.
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            // Use ToTitleCase to capitalize the first letter.
            return textInfo.ToTitleCase(input);
        }
    }
}
