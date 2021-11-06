using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace şifrelemeAlgoritması
{
    class Program
    {


        public static string Cyripto(string text,string sifreTxt)
        {
            int sifreXOR = passwordHash(sifreTxt);
            StringBuilder cyripto = new StringBuilder();
            foreach (char c in text.ToCharArray()) cyripto.Append((char)(((int)c ^ sifreXOR)+32));
            return cyripto.ToString();
        }
        public static int passwordHash(string text)
        {
            int sifreXOR = 0;
            foreach (char c in text.ToCharArray()) sifreXOR += (int)c;
            sifreXOR = sifreXOR % 64;
            return sifreXOR;
        }

        public static string SolveCyripto(string cyriptoText, string sifreTxt)
        {
            int sifreXOR = passwordHash(sifreTxt);
            StringBuilder Solved = new StringBuilder();
            foreach (char c in cyriptoText.ToCharArray()) Solved.Append((char)((((int)c) - 32) ^ sifreXOR));
            return Solved.ToString();
        }

       

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Şifrele(0)/Şifre Çöz(1)/Çıkış(2) : ");
                string input = Console.ReadLine();
                Console.WriteLine();
                if (input == "0")
                {
                    Console.Write("Lütfen Şifrelenecek Metini Giriniz: ");
                    input = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("Lütfen Şifrenizi Giriniz: ");
                    string sifre = Console.ReadLine();
                    Console.Clear();
                    string sifreliveri = Cyripto(input, sifre);
                    //sifreliveri = sifreliveri.Replace("\n","").Replace("\t", "").Replace("\r", "/00r0");
                    Console.WriteLine(sifreliveri);
                    Console.ReadLine();
                }
                else if (input == "1")
                {
                    Console.Write("Şifrelenmiş Metini Giriniz: ");
                    input = Console.ReadLine();
                    //input = input.Replace("/00n0", "\n").Replace("/00t0","\t").Replace("/00r0","\r");
                    Console.WriteLine();
                    Console.Write("Lütfen Şifrenizi Giriniz: ");
                    string sifre = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine(SolveCyripto(input, sifre));
                }
                else if (input == "2")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Hatalı Giriş Yaptınız.");
                }
            }

            Console.ReadKey();
        }
    }
}
