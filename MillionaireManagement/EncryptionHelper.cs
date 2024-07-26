using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MillionaireManagement
{
    /// <summary>
    /// Provides methods for encrypting and decrypting strings.
    /// </summary>
    public static class EncryptionHelper
    {
        private static readonly string EncryptionKey = "your-encryption-key";

        /// <summary>
        /// Encrypts a plain text string.
        /// </summary>
        /// <param name="plainText">The plain text to encrypt.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(string plainText)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            using (Aes aes = Aes.Create())
            {
                using (Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x43, 0x87, 0x23, 0x72, 0x20, 0x65, 0x23, 0x24, 0x57, 0x67, 0x73, 0x39, 0x43, 0x45, 0x28, 0x93 }))
                {
                    aes.Key = key.GetBytes(32);
                    aes.IV = key.GetBytes(16);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(plainBytes, 0, plainBytes.Length);
                        cs.Close();
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// Decrypts an encrypted string.
        /// </summary>
        /// <param name="encryptedText">The encrypted string to decrypt.</param>
        /// <returns>The decrypted plain text string.</returns>
        public static string Decrypt(string encryptedText)
        {
            byte[] cipherBytes = Convert.FromBase64String(encryptedText);
            using (Aes aes = Aes.Create())
            {
                using (Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x43, 0x87, 0x23, 0x72, 0x20, 0x65, 0x23, 0x24, 0x57, 0x67, 0x73, 0x39, 0x43, 0x45, 0x28, 0x93 }))
                {
                    aes.Key = key.GetBytes(32);
                    aes.IV = key.GetBytes(16);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
    }
}
