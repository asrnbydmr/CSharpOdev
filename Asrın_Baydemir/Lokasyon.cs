using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Asrın_Baydemir
{
    internal class Lokasyon : ILokasyon
    {
        // YHavalimani yapısı oluşturulur.
        public struct YHavalimani
        {
            public string UlkeAdi;
            public string BolgeAdi;
            public string HavalimaniAdi;
        }

        // YLokasyon yapısı oluşturulur.
        public struct YLokasyon
        {
            public string KalkisYeri;
            public string VarisYeri;
            public DateTime UcusTarihi;
            public TimeSpan UcusSaati;
        }

        // Havalimanı bilgilerini tutacak liste tanımlanır.
        private List<YHavalimani> Havalimanlari = new List<YHavalimani>();

        // Yurtiçi uçuş bilgilerini tutacak liste tanımlanır.
        private List<YHavalimani> YurticiUcus = new List<YHavalimani>();

        // Yurtdışı uçuş bilgilerini tutacak liste tanımlanır.
        private List<YHavalimani> YurtdisiUcus = new List<YHavalimani>();

        // Yurtdışı uçuş için ülke bilgilerini tutacak liste tanımlanır.
        private ArrayList UlkeListesi = new ArrayList();

        // Yurtdışı uçuş için havalimanı bilgilerini tutacak liste tanımlanır.
        private List<YHavalimani> HavalimaniListesi = new List<YHavalimani>();

        // Lokasyon bilgilerini tutacak liste tanımlanır.
        private YLokasyon MusteriLokasyon = new YLokasyon();

        // DosyaOkuma sınıfından bir nesne tanımlanır.
        private DosyaOkuma DosyaOkuma = new DosyaOkuma();

        // Kontrol yapıları ve sıra bilgilerini ekrana yazdırmak için integer tipinde değişkenler tanımlanır.
        private int Sayac = 1, YSecim = 0, Secim = 0, UlkeSayac = 1;

        // Uçuş tipini belirlemek için değişken tanımlanır.
        public int UcusTipi;

        // Havalimanı bilgilerinin oluşturulacağı metod tanımlanır.
        private void HavalimaniListesiOlustur()
        {
            // Havalimanlari listesine veriler eklenir.
            Havalimanlari = DosyaOkuma.HavalimaniBilgisi(@"Havalimani\havalimani.txt");

            // Yurtiçi ve yurtdışı uçuşları belirlemek için döngü kurulur.
            foreach (var Havalimani in Havalimanlari)
            {
                // Veri yurtiçi uçuşa uyuyor ise YurticiUcus listesine eklenir.
                if (Havalimani.UlkeAdi == "Türkiye")
                    YurticiUcus.Add(Havalimani);

                // Veri yurtdışı uçuşa uyuyor ise YurtdisiUcus listesine eklenir.
                else
                    YurtdisiUcus.Add(Havalimani);
            }
        }

        // Lokasyon bilgilerinin oluşturulacağı metod tanımlanır.
        public void LokasyonOlustur()
        {
            // HavalimaniListesiOlustur metodu çağrılır.
            HavalimaniListesiOlustur();

            // Uçuş tipini belirlemek için değişken tanımlanır.
            UcusTipi = UcusTipiBelirle();

            // Uçuş tipi yurtiçi ise bu sorgu bloğu çalışır.
            if (UcusTipi == 1)
            {
                MusteriLokasyon.KalkisYeri = KalkisYeriSec(1);
                MusteriLokasyon.VarisYeri = VarisYeriSec(1, MusteriLokasyon.KalkisYeri);
            }

            // Uçuş tipi yurtdışı ise bu sorgu bloğu çalışır.
            if (UcusTipi == 2)
            {
                MusteriLokasyon.KalkisYeri = KalkisYeriSec(2);
                MusteriLokasyon.VarisYeri = VarisYeriSec(2, MusteriLokasyon.KalkisYeri);
            }

            // Tarih seçimi için TarihSecim metodu çağrılır.
            TarihSecim();

            // Saat seçimi için SaatSecim metodu çağrılır.
            SaatSecim();
        }

        // Uçuş tipi seçeneğini kontrol etmek için metod tanımlanır.
        private bool UcusTipiKontrol(int UcusTipi)
        {
            // UcusTipi değişkeni 1 veya 2 değil ise false değer döndürür.
            if (UcusTipi != 1 && UcusTipi != 2)
                return false;

            // UcusTipi değişkeni 1 veya 2 ise true değer döndürür.
            return true;
        }

        // Uçuş tipini belirlemek için metod tanımlanır.
        private int UcusTipiBelirle()
        {
            // Uçuş tipini belirlemek için değişken tanımlanır.
            int UcusTipi;

            // Koşullar sağlanana kadar dönen bir döngü tanımlanır.
            while (true)
            {
                // Kullanıcıdan uçuş tipi belirlemesi istenir.
                Console.WriteLine("Uçuş Yapmak İçin Uçuş Tipi Seçiniz: ");
                Console.WriteLine("1) Yurtiçi");
                Console.WriteLine("2) Yurtdışı");
                Console.Write("Seçim: ");

                // Girilen değer UcusTipi değişkenine aktarılır.
                UcusTipi = Convert.ToInt32(Console.ReadLine());

                // Girilen değer şartlara uygun ise döngü durdurulur.
                if (UcusTipiKontrol(UcusTipi))
                    break;
            }

            // Uçuş tipi geri döndürülür.
            return UcusTipi;
        }

        // Yurtiçi uçuşlar için Yurtici metodu tanımlanır.
        private void Yurtici(int Kod, string KalkisYeri)
        {
            Console.Clear();
            Console.Write("Yurtiçi Uçuşlar Getiriliyor:");
            Thread.Sleep(1000);
            Console.WriteLine();

            // Kalkış yeri için bu blok çalışır.
            if (Kod == 1)
            {
                foreach (var Havalimani in YurticiUcus)
                {
                    Console.WriteLine(Sayac + ") " + Havalimani.BolgeAdi + " - " + Havalimani.HavalimaniAdi);
                    Sayac++;
                }
            }

            // Varış yeri için bu blok çalışır.
            if (Kod == 2)
            {
                foreach (var Havalimani in YurticiUcus)
                {
                    if (Havalimani.HavalimaniAdi == KalkisYeri)
                        YSecim = Sayac;

                    Console.WriteLine(Sayac + ") " + Havalimani.BolgeAdi + " - " + Havalimani.HavalimaniAdi);
                    Sayac++;
                }
            }
        }

        // Yurtdışı uçuşlar için Yurtdisi metodu tanımlanır.
        private void Yurtdisi(int Kod, string KalkisYeri)
        {
            string UlkeAdi = String.Empty;

            Console.Clear();
            Console.Write("Yurtdışı Uçuşlar Getiriliyor:");
            Thread.Sleep(1000);
            Console.WriteLine();

            /*
                * Yurtdışı uçuşlarda ilk önce ülke belirlenir.
                * Ülke seçimine göre havalimanı listesi ekrana yazdırılır. 
            */

            UlkeSayac = 1;

            UlkeListesi.Clear();
            HavalimaniListesi.Clear();

            // Ekrana ülke adlarını yazar.
            foreach (var Havalimani in YurtdisiUcus)
            {
                if(!UlkeListesi.Contains(Havalimani.UlkeAdi))
                {
                    Console.WriteLine(UlkeSayac + ") " + Havalimani.UlkeAdi);
                    UlkeListesi.Add(Havalimani.UlkeAdi);

                    UlkeSayac++;
                }
            }

            // Ülke seçimi için döngü kurulur ve şartlar sağlandığında döngü durdurulur.
            while (true)
            {
                Console.Write("Ülke Seçiniz: ");
                int UlkeSecim = Convert.ToInt32(Console.ReadLine());

                if (UlkeSecim > 0 && UlkeSecim < UlkeSayac)
                {
                    UlkeAdi = UlkeListesi[UlkeSecim - 1].ToString();

                    Console.WriteLine();
                    break;
                }
            }

            // Havalimanı listesine havalimanları eklenir.
            foreach (YHavalimani Havalimani in Havalimanlari)
            {
                if (Havalimani.UlkeAdi == UlkeAdi)
                    HavalimaniListesi.Add(Havalimani);
            }

            // Kalkış yeri için bu blok çalışır.
            if (Kod == 1)
            {
                foreach (var Havalimani in HavalimaniListesi)
                {
                    Console.WriteLine(Sayac + ") " + Havalimani.BolgeAdi + " - " + Havalimani.HavalimaniAdi);
                    Sayac++;
                }
            }

            // Varış yeri için bu blok çalışır.
            if (Kod == 2)
            {
                foreach (var Havalimani in HavalimaniListesi)
                {
                    if (Havalimani.HavalimaniAdi == KalkisYeri)
                        YSecim = Sayac;

                    Console.WriteLine(Sayac + ") " + Havalimani.BolgeAdi + " - " + Havalimani.HavalimaniAdi);
                    Sayac++;
                }
            }
        }

        // Kalkış yerinin seçilmesi için metod tanımlanır.
        private string KalkisYeriSec(int UcusTipi)
        {
            string Deger = String.Empty;

            Sayac = 1;

            // Yurtiçi uçuşu ise bu blok çalışır.
            if (UcusTipi == 1)
                Yurtici(1, "");

            // Yurtdışı uçuşu ise bu blok çalışır.
            if (UcusTipi == 2)
                Yurtdisi(1, "");

            Secim = 0;

            // Kalkış yeri seçimi için döngü kurulur ve şartlar sağlandığında döngü durdurulur.
            while (true)
            {
                Console.Write("Kalkış Yeri Seçiniz: ");
                Secim = Convert.ToInt32(Console.ReadLine());

                bool Kontrol = false;

                // Yurtiçi uçuşu ise bu kod bloğu çalışır.
                if (UcusTipi == 1)
                {
                    if(Secim > 0 && Secim < Sayac)
                        Kontrol = true;
                }

                // Yurtdışı uçuşu ise bu kod bloğu çalışır.
                if (UcusTipi == 2)
                {
                    if (Secim > 0 && Secim < UlkeSayac)
                        Kontrol = true;
                }

                // Seçilen havalimanı değeri Deger değişkenine aktarılır.
                if (Kontrol)
                {
                    if (UcusTipi == 1)
                    {
                        Deger = YurticiUcus[Secim - 1].HavalimaniAdi;
                        break;
                    }

                    if (UcusTipi == 2)
                    {
                        Deger = HavalimaniListesi[Secim - 1].HavalimaniAdi;
                        break;
                    }
                }
            }

            // Deger değişkeninin değeri geri döndürülür.
            return Deger;
        }

        // Varış yerinin seçilmesi için metod tanımlanır.
        private string VarisYeriSec(int UcusTipi, string KalkisYeri)
        {
            string Deger = String.Empty;

            Sayac = 1;
            YSecim = 0;

            // Yurtiçi uçuşu ise bu blok çalışır.
            if (UcusTipi == 1)
            {
                Yurtici(2, KalkisYeri);
            }

            // Yurtdışı uçuşu ise bu blok çalışır.
            if (UcusTipi == 2)
            {
                Yurtdisi(2, KalkisYeri);
            }

            Secim = 0;

            // Varış yeri seçimi için döngü kurulur ve şartlar sağlandığında döngü durdurulur.
            while (true)
            {
                Console.Write("Varış Yeri Seçiniz: ");
                Secim = Convert.ToInt32(Console.ReadLine());

                bool Kontrol = false;

                // Yurtiçi uçuşu ise bu kod bloğu çalışır.
                if (UcusTipi == 1)
                {
                    if (Secim > 0 && Secim < Sayac)
                        Kontrol = true;
                }

                // Yurtdışı uçuşu ise bu kod bloğu çalışır.
                if (UcusTipi == 2)
                {
                    if (Secim > 0 && Secim < UlkeSayac)
                        Kontrol = true;
                }

                // Kalkış yeri ile varış yeri aynı olamayacağı için veriler kontrol edilir.
                if (Secim != YSecim)
                {
                    // Seçilen havalimanı değeri Deger değişkenine aktarılır.
                    if (Kontrol)
                    {
                        if (UcusTipi == 1)
                        {
                            Deger = YurticiUcus[Secim - 1].HavalimaniAdi;
                            break;
                        }

                        if (UcusTipi == 2)
                        {
                            Deger = HavalimaniListesi[Secim - 1].HavalimaniAdi;
                            break;
                        }
                    }
                }

                // Ekrana hata mesajı yazdırılır.
                else
                {
                    Console.WriteLine("Varış Yeri Kalkış Yeri ile Aynı Olamaz.");
                }
            }

            // Deger değişkeninin değeri geri döndürülür.
            return Deger;
        }

        // Bu metod rastgele tarihler oluşturur ve Tarihler dizisine ekler. Dizi küçükten büyüğe sıralanır ve geri döndürülür.
        private DateTime[] TarihOlustur()
        {
            DateTime[] Tarihler = new DateTime[14];

            int SimdiTarih = DateTime.Now.Year;

            Random Random = new Random();

            for (int i = 0; i < Tarihler.Length;)
            {
                DateTime RandomDate = new DateTime(Random.Next(SimdiTarih, SimdiTarih + 1), Random.Next(1, 13), Random.Next(1, 29));

                if((Tarihler.Contains(RandomDate) == false) && (RandomDate.Year == DateTime.Now.Year) && (RandomDate.Month > DateTime.Now.Month))
                {
                    Tarihler[i] = RandomDate;
                    i++;
                } 
            }

            Array.Sort(Tarihler, (D1, D2) => D1.CompareTo(D2));

            return Tarihler;
        }

        // Bu metod tarihleri ekrana yazdırır ve kullanıcı seçimini kontrol eder. Kullanıcı seçimi kurallara uygun ise UcusTarihi alanına aktarılır.
        private void TarihSecim()
        {
            Console.Clear();
            Console.Write("Aktif Tarihler Getiriliyor:");
            Thread.Sleep(1000);
            Console.WriteLine();

            DateTime[] Tarihler = TarihOlustur();

            int Sayac = 1;

            foreach (var Tarih in Tarihler)
            {
                Console.WriteLine(Sayac + ") " + Tarih.ToString("dd/MM/yyyy"));
                Sayac++;
            }

            while (true)
            {
                Console.Write("Tarih Seçiniz: ");
                int Secim = Convert.ToInt32(Console.ReadLine());

                if (Secim > 0 && Secim < Sayac)
                {
                    MusteriLokasyon.UcusTarihi = Tarihler[Secim - 1];
                    break;
                }
            }
        }

        // Bu metod rastgele saatler oluşturur ve Saatler dizisine ekler. Dizi küçükten büyüğe sıralanır ve geri döndürülür.
        private TimeSpan[] SaatOlustur()
        {
            TimeSpan[] Saatler = new TimeSpan[20];
            Random Random = new Random();

            for (int i = 0; i < Saatler.Length;)
            {
                int[] SecilenDakika = { 0, 30 };
                int DakikaSayi = Random.Next(0, 2);

                int Saat = Random.Next(0, 24);
                int Dakika = SecilenDakika[DakikaSayi];
                int Saniye = Random.Next(0, 0);

                TimeSpan Zaman = new TimeSpan(Saat, Dakika, Saniye);

                bool Kontrol = true;

                foreach (var Nesne in Saatler)
                {
                    if (Nesne.Hours == Saat && Nesne.Minutes == Dakika)
                        Kontrol = false;
                }

                if (Kontrol)
                {
                    Saatler[i] = Zaman;
                    i++;
                }
            }

            Array.Sort(Saatler);

            return Saatler;
        }

        // Bu metod saatleri ekrana yazdırır ve kullanıcı seçimini kontrol eder. Kullanıcı seçimi kurallara uygun ise UcusSaati alanına aktarılır.
        private void SaatSecim()
        {
            Console.Clear();
            Console.Write("Aktif Saatler Getiriliyor:");
            Thread.Sleep(1000);
            Console.WriteLine();

            TimeSpan[] Saatler = SaatOlustur();

            int Sayac = 1;

            foreach (var Saat in Saatler)
            {
                Console.WriteLine(Sayac + ") " + Saat.ToString("hh\\:mm"));
                Sayac++;
            }

            while (true)
            {
                Console.Write("Saat Seçiniz: ");
                int Secim = Convert.ToInt32(Console.ReadLine());

                if (Secim > 0 && Secim < Sayac)
                {
                    MusteriLokasyon.UcusSaati = Saatler[Secim - 1];
                    break;
                }
            }
        }

        // Lokasyon bilgileri ekrana yazdırılır.
        public void LokasyonYazdir()
        {
            Console.WriteLine("Kalkış Yeri: " + MusteriLokasyon.KalkisYeri);
            Console.WriteLine("Varış Yeri: " + MusteriLokasyon.VarisYeri);
            Console.WriteLine("Uçuş Tarihi: " + MusteriLokasyon.UcusTarihi.ToString("dd/MM/yyyy"));
            Console.WriteLine("Uçuş Saati: " + MusteriLokasyon.UcusSaati.ToString("hh\\:mm"));
        }
    }
}
