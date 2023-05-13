using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asrın_Baydemir
{
    internal class Rezervasyon : IRezervasyon
    {
        // Rezervasyon bilet numarası bilgisini tutan değişken tanımlanır.
        public Int32 BiletNo { get; set; }

        // Rezervasyon uçak bilgisini tutan değişken tanımlanır.
        public Ucak Ucak { get; set; }

        // Rezervasyon lokasyon bilgisini tutan değişken tanımlanır.
        public Lokasyon Lokasyon { get; set; }

        // Rezervasyon müşteri bilgisini tutan değişken tanımlanır.
        public Musteri Musteri { get; set; }

        // Rezervasyon indirim oranını tutan değişken tanımlanır.
        public int IndirimOrani { get; set; }

        // Rezervasyon ücret bilgisini tutan değişken tanımlanır.
        public int Ucret { get; set; }

        // Random sınıfından nesne tanımlanır.
        private Random Random = new Random();

        // Yurtiçi ve yurtdışı uçakları farklıdır. Bu bilgiyi tutmak için değişken tanımlanır.
        private int UcakTipi; 

        // Rezervasyon sınıfının kurucusu tanımlanır.
        public Rezervasyon()
        {
            // Bilet numarası tanımlanır.
            BiletNo = Random.Next(0, 1000);

            // Müşteri bilgilerini almak için Musteri adında nesne tanımlanır.
            Musteri = new Musteri();

            // Lokasyon bilgilerini almak için Lokasyon adında nesne tanımlanır.
            Lokasyon = new Lokasyon();
            Lokasyon.LokasyonOlustur();

            // Uçak bilgilerini almak için Ucak adında nesne oluşturulur.
            Ucak = new Ucak();

            // Yurtiçi uçuşu ise yurtiçi uçakların listesi oluşturulur.
            if (Lokasyon.UcusTipi == 1)
            {
                UcakTipi = 1;

                Ucak.YurticiUcakListesiTanimla();

                UcakBilgi(Ucak.YurticiUcakListesi);
            }

            // Yurtdışı uçuşu ise yurtdışı uçakların listesi oluşturulur.
            if (Lokasyon.UcusTipi == 2)
            {
                UcakTipi = 2;

                Ucak.YurtdisiUcakListesiTanimla();

                UcakBilgi(Ucak.YurtdisiUcakListesi);
            }
        }

        // Uçak bilgileri ve uçuş sınıfı bilgisi almak için metod tanımlanır.
        private void UcakBilgi(List<Ucak> UcusTipi)
        {
            // Rastgele uçak seçilir.
            int UcakIndex = Random.Next(0, UcusTipi.Count);
            Ucak SecilenUcak = UcusTipi[UcakIndex];

            // Kullanıcıya sınıf seçimi için seçenekler gösterilir.
            Console.Clear();
            Console.WriteLine("Sınıf Seçimleri: ");
            Console.WriteLine("1) İş Sınıfı");
            Console.WriteLine("2) Ekonomi Sınıfı");

            //Kullanıcıdan sınıf seçimi alınır.
            int SınıfSecim;
            while (true)
            {
                Console.Write("Seçim Yapınız: ");
                SınıfSecim = Convert.ToInt32(Console.ReadLine());

                if (SınıfSecim > 0 && SınıfSecim < 3)
                    break;
            }

            Console.Clear();

            // İş sınıfına veya ekonomi sınıfına göre yolcu sayısı alınır.
            int YolcuSayisi = 0;

            if (SınıfSecim == 1)
            {
                YolcuSayisi = SecilenUcak.BYolcuKapasitesi;
            }

            if (SınıfSecim == 2)
            {
                YolcuSayisi = SecilenUcak.EYolcuKapasitesi;
            }

            // Rastgele uçağın içerisi doldurulur.
            int Yuzde = Random.Next(1, 100);
            YolcuSayisi -= (YolcuSayisi * Yuzde) / 100;
            int Sayac = Random.Next(1, YolcuSayisi);

            // Boş koltuklar ekrana yazdırılır.
            List<string> BosKoltuklar = new List<string>();
            Console.WriteLine("Boş Koltuklar: ");
            int DonguSayac = 1;
            for (int i = 1; i <= YolcuSayisi; i = i + Sayac)
            {
                Console.WriteLine(DonguSayac + ") K - " + i);
                DonguSayac++;

                BosKoltuklar.Add("K - " + i);
            }

            // Koltuk seçimi bilgisi alınır.
            int KoltukSecim = 0;
            while (true)
            {
                Console.Write("Seçim Yapınız: ");
                KoltukSecim = Convert.ToInt32(Console.ReadLine());

                if (KoltukSecim > 0 && KoltukSecim < BosKoltuklar.Count + 1)
                    break;
            }

            // Bilgileri göstermek için ekran temizlenir.
            Console.Clear();

            // Ücret belirlemek için UcretBelirle metodu çağrılır.
            UcretBelirle();

            // Konsol ekranı renk ayarı yapılır.
            KonsolAyar.KonsolRenkAyari("Black", "Green");

            // Müşteri bilgileri ekrana yazdırılır.
            Console.WriteLine(" ~ Müşteri Bilgileri ~ ");
            Console.WriteLine("Türkiye Cumhuriyeti Kimlik Numarası: " + Musteri.TC);
            Console.WriteLine("Ad: " + Musteri.Ad);
            Console.WriteLine("Soyad: " + Musteri.Soyad);
            Console.WriteLine("Yaş: " + Musteri.Yas);
            Console.WriteLine("Telefon Numarası: 0" + Musteri.Telefon);
            string CinsiyetMetin = Musteri.Cinsiyet ? "Erkek" : "Kadın";
            Console.WriteLine("Cinsiyet: " + CinsiyetMetin);
            string EngelliMetin = Musteri.Engelli ? "Var" : "Yok";
            Console.WriteLine("Engelli Durumu: " + EngelliMetin);
            Console.WriteLine();

            // Lokasyon bilgileri ekrana yazdırılır.
            Console.WriteLine(" ~ Lokasyon Bilgileri ~ ");
            Lokasyon.LokasyonYazdir();
            Console.WriteLine();

            // Rezervasyon bilgileri ekrana yazdırılır.
            Console.WriteLine(" ~ Rezervayson Bilgileri ~ ");
            Console.WriteLine("Bilet Numarası: " + BiletNo);
            Console.WriteLine("Uçak Kodu: " + SecilenUcak.Kod);
            Console.WriteLine("Koltuk Numarası: " + BosKoltuklar[KoltukSecim - 1]);
            Console.WriteLine("Ücret: " + Ucret);
            Console.WriteLine();

            // Ekrana mesaj yazdırılır.
            Console.Write("İyi Günler Dileriz.");
        }

        // Müşteri engelli veya yaşlı ise indirim uygulanır değil ise indirim uygulanmaz. Bu metod bunun kontrol eder.
        private bool IndirimKontrol()
        {
            if ((Musteri.Engelli == true) || (Musteri.Yasli == true))
                return true;

            return false;
        }

        // Müşteriye verilecek indirim rastgele şekilde belirlenir. İndirim tutarı ücretten çıkarılır. Yeni ücret geri döndürülür.
        private int IndirimBelirle()
        {
            IndirimOrani = Random.Next(1, 100) / 100;

            int Indirim = Ucret * IndirimOrani;

            Ucret = Ucret - Indirim;

            return Ucret;
        }

        // Ücreti belirlemek için UcretBelirle metodu tanımlanır.
        private void UcretBelirle()
        {
            Ucret = Convert.ToInt32(Random.Next(1, 1000));

            if(IndirimKontrol())
                Ucret = IndirimBelirle();
        }
    }
}