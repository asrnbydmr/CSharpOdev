using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asrın_Baydemir
{
    internal class KonsolAyar
    {
        // Konsol renklerini ayarlamak için metod tanımlanır. Bu metod iki değer (arkaplan ve yazı rengi) ile çalışır.
        public static void KonsolRenkAyari(string ArkaplanRengi, string YaziRengi)
        {
            // Renk değişimi için ekran temizlenir.
            Console.Clear();

            // Parametre olarak verilen metni ConsoleColor nesnesine dönüştürür ve arkaplan rengini değiştirir.
            Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), ArkaplanRengi);

            // Parametre olarak verilen metni ConsoleColor nesnesine dönüştürür ve yazi rengini değiştirir.
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), YaziRengi);
        }

        // Konsol başlığını ayarlamak için metod tanımlanır.Bu metod bir değer (başlık) ile çalışır.
        public static void KonsolBaslikAyar(string Baslik)
        {
            // Konsol başlığını değiştirir.
            Console.Title = Baslik;
        }
    }
}
