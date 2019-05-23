
using System;
using System.Security.Cryptography;

namespace Produto.Shared
{
    public class Senha
    {
        public static byte[] MySalt
        {
            get { return System.Text.Encoding.UTF8.GetBytes("P@ssw0rd#1234qwer"); }
            private set { }
        }

        public static string Encriptar(string senha)
        {
            if (!string.IsNullOrEmpty(senha))
            {
                var _hmacSHA1 = new HMACSHA1(MySalt);
                var _password = System.Text.Encoding.UTF8.GetBytes(senha);
                return Convert.ToBase64String(_hmacSHA1.ComputeHash(_password));
            }
            else
            {
                return null;
            }
           
        }
    }
}
