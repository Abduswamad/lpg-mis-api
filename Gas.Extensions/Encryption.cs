using System.Security.Cryptography;

namespace Gas.Extensions
{
    public static class Encryption
    {
        private static byte[] GenerateRandomKey()
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.GenerateKey();
                return aesAlg.Key;
            }
        }

        private static byte[] GenerateRandomIV()
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.GenerateIV();
                return aesAlg.IV;
            }
        }

        private static byte[] EncryptData(string data)
        {
            byte[] key = Convert.FromBase64String("SypHKKp0pDBlm6HDQYvt9Zx2i12kKDUbrCPBP9jt/jA=");

            byte[] iv = Convert.FromBase64String("Mp1+wVOpPnih3xOfhoO0/Q==");

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create an encryptor to perform the stream transform
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            // Write all data to the stream
                            swEncrypt.Write(data);
                        }
                        return msEncrypt.ToArray();
                    }
                }
            }
        }

        public static string DecryptData(string encrypted)
        {
            byte[] encryptedData = Convert.FromBase64String(encrypted);
            // Generate a random encryption key and IV
            byte[] key = Convert.FromBase64String("SypHKKp0pDBlm6HDQYvt9Zx2i12kKDUbrCPBP9jt/jA=");

            byte[] iv = Convert.FromBase64String("Mp1+wVOpPnih3xOfhoO0/Q==");

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                // Create a decryptor to perform the stream transform
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption
                using (MemoryStream msDecrypt = new MemoryStream(encryptedData))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream and place them in a string
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
