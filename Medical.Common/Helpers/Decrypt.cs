using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Medical.Common.Helpers
{
    public static class Decrypt
    {
        public static string DecryptData(string encryptionKey, string encryptedData)
        {
            encryptedData = encryptedData.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(encryptedData);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new(encryptionKey, new byte[] {
                    0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
                });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using MemoryStream ms = new();
                using (CryptoStream cs = new(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                encryptedData = Encoding.Unicode.GetString(ms.ToArray());
            }
            return encryptedData;
        }
    }
}
