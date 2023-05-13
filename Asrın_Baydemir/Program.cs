using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asrın_Baydemir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Konsol başlık ayarı için KonsolBaslikAyar metodu çağrılır.
            KonsolAyar.KonsolBaslikAyar("Uçak Rezervasyon Sistemi");

            // Giriş ekranı döngüsü için GirisEkrani sınıfından nesne olusturulur.
            GirisEkrani GirisEkrani = new GirisEkrani();

            // Ekrana hoşgeldiniz mesajı yazdırır.
            Console.WriteLine("Uçak Rezervasyon Sistemine Hoş Geldiniz.");

            // Rezervasyon sınıfından nesne olusturulur.
            Rezervasyon Rezervasyon = new Rezervasyon();

            // Program aniden kapanmaması için bir tuşa basmamızı bekler.
            Console.ReadKey();
        }
    }
}
