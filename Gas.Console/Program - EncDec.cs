//using System;
//using System.Collections;
//using System.IO;
//using System.Security.Cryptography;
//using System.Text;

//class Program
//{
//    static void Main()
//    {
//        // The data to be encrypted
//        string originalData = "http://192.168.15.159:9002/Account";

//        // Generate a random encryption key and IV
//        // byte[] key = GenerateRandomKey();
//        byte[] key = Convert.FromBase64String("SypHKKp0pDBlm6HDQYvt9Zx2i12kKDUbrCPBP9jt/jA=");
//        string base64StringKey = Convert.ToBase64String(key);
//        Console.WriteLine("base64StringKey: " + base64StringKey);

//        // byte[] iv = GenerateRandomIV();
//        byte[] iv = Convert.FromBase64String("Mp1+wVOpPnih3xOfhoO0/Q==");
//        string base64Stringiv = Convert.ToBase64String(iv);
//        Console.WriteLine("base64Stringiv: " + base64Stringiv);


//        // Encrypt the data
//        byte[] encryptedData = EncryptData(originalData, key, iv);

//        // Decrypt the data
//        string decryptedData = DecryptData(encryptedData, key, iv);

//        // Display the original, encrypted, and decrypted data
//        Console.WriteLine("Original Data: " + originalData);
//        Console.WriteLine("Encrypted Data (Base64): " + Convert.ToBase64String(encryptedData));
//        Console.WriteLine("Decrypted Data: " + decryptedData);

//        Console.ReadKey();
//    }

//    static byte[] GenerateRandomKey()
//    {
//        using (Aes aesAlg = Aes.Create())
//        {
//            aesAlg.GenerateKey();
//            return aesAlg.Key;
//        }
//    }

//    static byte[] GenerateRandomIV()
//    {
//        using (Aes aesAlg = Aes.Create())
//        {
//            aesAlg.GenerateIV();
//            return aesAlg.IV;
//        }
//    }

//    static byte[] EncryptData(string data, byte[] key, byte[] iv)
//    {
//        using (Aes aesAlg = Aes.Create())
//        {
//            aesAlg.Key = key;
//            aesAlg.IV = iv;

//            // Create an encryptor to perform the stream transform
//            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

//            // Create the streams used for encryption
//            using (MemoryStream msEncrypt = new MemoryStream())
//            {
//                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
//                {
//                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
//                    {
//                        // Write all data to the stream
//                        swEncrypt.Write(data);
//                    }
//                    return msEncrypt.ToArray();
//                }
//            }
//        }
//    }

//    static string DecryptData(byte[] encryptedData, byte[] key, byte[] iv)
//    {
//        using (Aes aesAlg = Aes.Create())
//        {
//            aesAlg.Key = key;
//            aesAlg.IV = iv;

//            // Create a decryptor to perform the stream transform
//            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

//            // Create the streams used for decryption
//            using (MemoryStream msDecrypt = new MemoryStream(encryptedData))
//            {
//                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
//                {
//                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
//                    {
//                        // Read the decrypted bytes from the decrypting stream and place them in a string
//                        return srDecrypt.ReadToEnd();
//                    }
//                }
//            }
//        }
//    }
//}
