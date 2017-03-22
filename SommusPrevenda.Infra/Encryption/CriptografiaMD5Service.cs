using SommusPreVenda.Domain.Interfaces.Encryption;
using System.Security.Cryptography;
using System.Text;
using System;

namespace SommusPrevenda.Infra.Encryption
{
    public class CriptografiaMD5Service : ICriptografiaMD5Service
    {
        public string CriptografaMD5(string texto)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, texto);

                return hash;
            }
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
        
    }
}
