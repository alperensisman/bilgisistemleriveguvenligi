using System;
using System.Linq;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace TCPServer
{
    public class aes
    {

        public static string appPass = "DenizAlperen";
        public static string cleanDirty(string code)
        {
            string[] dirtyCharacters = { "==", "=", "/", "+" };
            string[] cleanCharacters = { "p2n3t4G5l6m", "s1l2a3s4h", "q1e2st3i4o5n", "T22p14nt2s" };

            for (int i = 0; i < dirtyCharacters.Length; i++)
            {
                code = code.Replace(dirtyCharacters[i], cleanCharacters[i]);
            }
            return code;
        }
        public static string makeDirty(string code)
        {
            string[] dirtyCharacters = { "==", "=", "/", "+" };
            string[] cleanCharacters = { "p2n3t4G5l6m", "s1l2a3s4h", "q1e2st3i4o5n", "T22p14nt2s" };
            for (int i = 0; i < dirtyCharacters.Length; i++)
            {
                code = code.Replace(cleanCharacters[i], dirtyCharacters[i]);
            }
            return code;
        }
        public static byte[] passwordHash(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(password);
            dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();

            foreach (byte ba in dizi)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            password= sb.ToString().Substring(0, 32);
            return Encoding.ASCII.GetBytes(password);
        }
        public static string Encryption(string message)
        {
            byte[] encrypted;
            byte[] ivBytes;
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.GenerateIV();
                ivBytes = aes.IV;
                aes.Key = passwordHash(appPass);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform enc = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, enc, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(message);
                        }

                        encrypted = ms.ToArray();
                    }
                }
            }

            string iv = cleanDirty(Convert.ToBase64String(ivBytes));
            string cipther = cleanDirty(Convert.ToBase64String(encrypted));
            return iv + cipther;
        }
        public static string Decryption(string message)
        {
            message = makeDirty(message);
            string iv = message.Substring(0, 24);
            message = message.Substring(24, message.Length - 24);

            byte[] cipher = Convert.FromBase64String(message);
            string decrypted = null;

            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.Key = passwordHash(appPass).Take(32).ToArray();
                aes.IV = Convert.FromBase64String(iv);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform dec = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(cipher))
                {
                    using (CryptoStream cs = new CryptoStream(ms, dec, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            decrypted = sr.ReadToEnd();
                        }
                    }
                }
            }

            return decrypted;
        }
    }
}
