using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asrın_Baydemir
{
    internal class GirisEkrani
    {
        // GirisEkrani sınıfının kurucusu tanımlanır.
        public GirisEkrani()
        {
            // Konsol renk ayarı için KonsolRenkAyari metodu çağrılır.
            KonsolAyar.KonsolRenkAyari("Black", "Green");

            // Giriş ekranı daha güzel gözükmesi için bir döngü kurulur.
            for (int i = 1; i <= 100; i++)
            {
                // Ekran temizlenir.
                Console.Clear();

                // Ekrana bilgi mesajı yazdırılır.
                Console.Write("Program Başlatılıyor: % " + i);

                /*
                    * Döngünün sade olmaması için koşullar belirtilir.
                    * Eğer sayaç 0 ile 10 arasında ise program 0.5 saniye bekletilir.
                    * Eğer sayaç 10 ile 50 arasında ise program 0.05 saniye bekletilir.
                    * Eğer sayaç 50 ise program 3 saniye bekletilir.
                    * Eğer sayaç 50 ile 100 arasında ise program 0.01 saniye bekletilir.
                */
                if (i > 0 && i < 10)
                {
                    Thread.Sleep(500);
                }

                if (i > 10 && i < 50)
                {
                    Thread.Sleep(50);
                }

                if (i == 50)
                {
                    Thread.Sleep(500);
                }

                if (i > 50 && i < 100)
                {
                    Thread.Sleep(10);
                }
            }

            // Döngü ile ilgili metin kalmaması için ekran temizlenir.
            Console.Clear();

            // Konsol renk ayarı için KonsolRenkAyari metodu çağrılır.
            KonsolAyar.KonsolRenkAyari("Black", "White");
        }
    }
}
