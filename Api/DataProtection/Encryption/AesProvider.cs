using System;
using System.IO;
using System.Security.Cryptography;

namespace Api.DataProtection.Encryption
{
    public static class AesProvider
    {
        private static readonly string _aesKey = "z+x7Re1OtPBgQgpSUPaqeD9VDm6adk8gay2LGqlu7jc=";
        private static readonly string _aesIv = "bsxnWolsAyO7kCfWuyrnqg==";

        public static string EncryptAes(string plainString)
        {
            try
            {
                byte[] encryptedString;

                using AesCryptoServiceProvider aes = CreateAesCryptoServiceProvider();

                ICryptoTransform enc = aes.CreateEncryptor(aes.Key, aes.IV);

                using MemoryStream ms = new();
                using CryptoStream cs = new(ms, enc, CryptoStreamMode.Write);

                using (StreamWriter sw = new(cs))
                    sw.Write(plainString);

                encryptedString = ms.ToArray();

                return Convert.ToBase64String(encryptedString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string DecryptAes(string encryptedString)
        {
            try
            {
                string plainString = null;
                byte[] cipher = Convert.FromBase64String(encryptedString);

                using AesCryptoServiceProvider aes = CreateAesCryptoServiceProvider();

                ICryptoTransform dec = aes.CreateDecryptor(aes.Key, aes.IV);

                using MemoryStream ms = new(cipher);
                using CryptoStream cs = new(ms, dec, CryptoStreamMode.Read);

                using StreamReader sr = new(cs);
                plainString = sr.ReadToEnd();

                return plainString;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private static AesCryptoServiceProvider CreateAesCryptoServiceProvider()
        {
            AesCryptoServiceProvider aes = new();

            aes.Key = Convert.FromBase64String(_aesKey);
            aes.IV = Convert.FromBase64String(_aesIv);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            return aes;
        }
    }
}

