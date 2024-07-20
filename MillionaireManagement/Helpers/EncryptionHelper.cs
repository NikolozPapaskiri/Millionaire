using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace MillionaireManagement.Helpers
{
    public static class EncryptionHelper
    {
        // Key and IV are used for AES encryption and decryption.
        // These should be securely generated and stored.
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("your-encryption-key"); // Replace with your key
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("your-iv-vector"); // Replace with your IV

        /// <summary>
        /// Encrypts a plain text string using AES encryption.
        /// </summary>
        /// <param name="plainText">The text to be encrypted.</param>
        /// <returns>The encrypted text as a base64 string.</returns>
        public static string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                //Create an encryptor object
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key,aes.IV);

                //Use a memory stream to hld the encrypted data
            }
        }

    }
}
