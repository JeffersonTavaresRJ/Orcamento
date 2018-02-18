using System;
using System.Security.Cryptography;
using System.Text;

namespace Project.Utility.UtilString
{
    public class Criptografia
    {
        public static string EncriptarSenha(string senha)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //converter a senha em bytes..
            byte[] senhaBytes = Encoding.UTF8.GetBytes(senha);

            //encriptografar senha em bytes..
            byte[] hash = md5.ComputeHash(senhaBytes);

            //retornar o hash da criptografia em string..
            return BitConverter.ToString(hash).Replace("-", string.Empty);

        }
    }
}
