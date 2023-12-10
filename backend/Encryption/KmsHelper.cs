using System.Security.Cryptography;
using System.Text;

namespace backend.Encryption
{
    public class KmsHelper
    {

        private Aes aes;

        public KmsHelper()
        {
            aes = Aes.Create();
        }

        public async Task<byte[]> EncryptAsync(string clearText)
        {
            using MemoryStream output = new();
            using CryptoStream cryptoStream = new(output, aes.CreateEncryptor(), CryptoStreamMode.Write);
            await cryptoStream.WriteAsync(Encoding.Unicode.GetBytes(clearText));
            await cryptoStream.FlushFinalBlockAsync();
            return output.ToArray();
        }

        public async Task<string> DecryptAsync(byte[] encrypted)
        {
            using MemoryStream input = new(encrypted);
            using CryptoStream cryptoStream = new(input, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using MemoryStream output = new();
            await cryptoStream.CopyToAsync(output);
            return Encoding.Unicode.GetString(output.ToArray());
        }
    }
}

