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
                using (MemoryStream ms = new MemoryStream())
                {
                    // Create a CryptoStream, which links the encryptor to the memory stream
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    // Use a StreamWriter to write the plaintext to the CryptoStream, which will encrypt it
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        // Write the plaintext to the stream
                        sw.Write(plainText);
                    }

                    // Convert the encrypted data from the memory stream to a base64 string
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// Decrypts an encrypted base64 string using AES encryption.
        /// </summary>
        /// <param name="cipherText">The encrypted text as a base64 string.</param>
        /// <returns>The decrypted plain text.</returns>
        public static string Decrypt(string plainText)
        {
            // Convert the base64 string to a byte array
            byte[] buffer = Convert.FromBase64String(plainText);

            // Create a new instamce of AES class
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;

                // Create a decryptor object
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                // Use a memory stream to hold the encrypted data
                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    // Create a CryptoStream, Whicch links the decryptor to the memory sttream
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    // Use a StreamReader ro read the decrypted data from the CryptoStream
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        // Read and return the decrypted data as a string
                        return sr.ReadToEnd();
                    }
                }
            }
        }

    }
}
