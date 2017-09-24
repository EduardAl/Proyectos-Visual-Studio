using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace ACOPEDH
{
    class Cifrado
    {
        public static String encriptar(string cadena)
        {
            string hashed = BCrypt.Net.BCrypt.HashPassword(cadena, BCrypt.Net.BCrypt.GenerateSalt());
            return (hashed);
        }
        public static bool desencriptar(String cadena, String password)
        {
            bool verify = BCrypt.Net.BCrypt.Verify(cadena, password);
            return verify;
        }
        public static string encriptar_B64(string cadena, string clave)
        {
            //Variables tipo byte que codifican las claves enviadas
            byte[] cadenaBytes = Encoding.UTF8.GetBytes(cadena);
            byte[] claveBytes = Encoding.UTF8.GetBytes(clave);
            RijndaelManaged rij = new RijndaelManaged();
            rij.Mode = CipherMode.ECB;
            rij.BlockSize = 256;
            rij.Padding = PaddingMode.Zeros;
            ICryptoTransform encriptador;
            encriptador = rij.CreateEncryptor(claveBytes, rij.IV);
            MemoryStream memStream = new MemoryStream();
            CryptoStream cifradoStream;
            cifradoStream = new CryptoStream(memStream, encriptador, CryptoStreamMode.Write);
            cifradoStream.Write(cadenaBytes, 0, cadenaBytes.Length);
            cifradoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memStream.ToArray();
            memStream.Close();
            cifradoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }
        public static string desencriptar_B64(string cadena, string clave)
        {
            byte[] cadenaBytes = Convert.FromBase64String(cadena);
            byte[] claveBytes = Encoding.UTF8.GetBytes(clave);
            RijndaelManaged rij = new RijndaelManaged();
            rij.Mode = CipherMode.ECB;
            rij.BlockSize = 256;
            rij.Padding = PaddingMode.Zeros;
            ICryptoTransform desencriptador;
            desencriptador = rij.CreateDecryptor(claveBytes, rij.IV);
            MemoryStream memStream = new MemoryStream(cadenaBytes);
            CryptoStream cifradoStream;
            cifradoStream = new CryptoStream(memStream, desencriptador, CryptoStreamMode.Read);
            StreamReader lectorStream = new StreamReader(cifradoStream);
            string resultado = lectorStream.ReadToEnd();
            memStream.Close();
            cifradoStream.Close();
            return resultado;
        }
        public static string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789@/!?";
            Byte[] randomBytes = new Byte[PasswordLength];
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < PasswordLength; i++)
            {
                Random randomObj = new Random();
                randomObj.NextBytes(randomBytes);
                chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
            }
            return new string(chars);
        }
    }
}
