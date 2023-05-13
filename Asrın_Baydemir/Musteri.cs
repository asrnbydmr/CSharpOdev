using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Asrın_Baydemir
{
    // Musteri sınıfı IMusteri arabirimini kalıtım ile alır.
    internal class Musteri : IMusteri
    {
        /*
            * IUcak arabirimdeki alanlar sınıfta tanımlanır.
        */
        public Int64 TC { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Int16 Yas { get; set; }
        public Int64 Telefon { get; set; }
        public Boolean Cinsiyet { get; set; }
        public Boolean Engelli { get; set; }
        public Boolean Yasli { get; set; }

        // Musteri sınıfının kurucu metodu tanımlanır.
        public Musteri()
        {
            // MusteriOlustur metodu çağrılır.
            MusteriOlustur();
        }

        // Kullanıcıdan müşteri bilgilerini almak için bir metod tanımlanır.
        private void MusteriOlustur()
        {
            // Türkiye Cumhuriyeti Kimlik Numarası bilgisi almak ve doğruluğunu kontrol etmek için INT64Kontrol methodu çağrılır.
            INT64Kontrol("Türkiye Cumhuriyeti Kimlik Numaranızı Giriniz: ", "Türkiye Cumhuriyeti Kimlik Numarası", 0);

            // Ekrana Adınızı Giriniz: yazdırılır.
            Console.Write("Adınızı Giriniz: ");

            // Kullanıcının girdiği değer Ad değişkenine aktarılır.
            Ad = Console.ReadLine();

            // Ekrana Soyadınızı Giriniz: yazdırılır.
            Console.Write("Soydınızı Giriniz: ");

            // Kullanıcının girdiği değer Soyad değişkenine aktarılır.
            Soyad = Console.ReadLine().ToUpper();

            // Yaş bilgisi almak ve doğruluğunu kontrol etmek için INT16Kontrol methodu çağrılır.
            INT16Kontrol("Doğum Yılınızı Giriniz: ", "Yaş");

            // Telefon Numarası bilgisi almak ve doğruluğunu kontrol etmek için INT64Kontrol methodu çağrılır.
            INT64Kontrol("Telefon Numaranızı Giriniz: ", "Telefon Numarası", 1);

            // Cinsiyet bilgisi almak ve doğruluğunu kontrol etmek için CEKontrol methodu çağrılır.
            CEKontrol("Cinsiyetinizi Giriniz (e, k): ", 'e', 'k', 0);

            // Engelli bilgisi almak ve doğruluğunu kontrol etmek için CEKontrol methodu çağrılır.
            CEKontrol("Engelli Durumunuzu Giriniz (e, h): ", 'e', 'h', 1);

            // Müşterinin yaşlı olup olmadığını kontrol etmek için YasliKontrol methodu çağrılır.
            YasliKontrol();

            // Bilgiler ekrana yazdırılır.
            MusteriYazdir();

            // Bilgilerin kontrolü sağlanır.
            MusteriBilgiGuncelle();
        }

        // Girilen değerin INT64 tipinde olup olmadığını ve 11 haneli olup olmadığını kontrol eden method tanımlanır.
        private void INT64Kontrol(string SoruMetin, string HataMetin, int Degisken)
        {
            // Temp adında bir değişken tanımlanır.
            string Temp = String.Empty;

            // Koşullar sağlanana kadar dönen bir döngü tanımlanır.
            while (true)
            {
                // Ekrana soru metni yazdırılır ve kullanıcının girdiği değer Temp değişkenine aktarılır.
                Console.Write(SoruMetin);
                Temp = Console.ReadLine();

                // Girilen değerin INT64 sınıfına ait olup olmadığı kontrol edilir.
                if (!Int64.TryParse(Temp, out long INT64))
                {
                    // Ekrana hata metni yazdırılır.
                    Console.WriteLine(HataMetin + " Rakamlardan Oluşmaktadır.");
                }

                // Girilen değerin karakter sayısı kontrol edilir.
                else if (Temp.Length != 11)
                {
                    // Ekrana hata metni yazdırılır.
                    Console.WriteLine(HataMetin + " 11 Haneden Oluşmaktadır.");
                }

                // Girilen veri doğru ise bu blok çalıştırılır.
                else
                {
                    // T.C. Kimlik Numarası için sorgular çalıştırıldı ise T.C. Kimlik Numarası algortima kontrolü yapılır.
                    if (Degisken == 0)
                    {
                        // Gerçek bir T.C. Kimlik Numarası girildi ise TC değişkenine değer atanır ve döngü durdurulur.
                        if (KimlikNoKontrol.KimlikKontrol(Temp))
                        {
                            TC = Convert.ToInt64(Temp);
                            break;
                        }
                        // Gerçek bir T.C. Kimlik Numarası girilmedi ise hata mesajı yazdırılır. 
                        else
                        {
                            Console.WriteLine("Gerçek T.C. Kimlik Numarası Giriniz.");
                        }
                    }
                    // Telefon için sorgular çalıştırıldı ise Telefon değişkenine değer atanır ve döngü durdurulur.
                    if (Degisken == 1)
                    {
                        Telefon = Convert.ToInt64(Temp);
                        break;
                    }
                }
            }
        }

        // Girilen değerin INT16 tipinde olup olmadığını ve 11 haneli olup olmadığını kontrol eden method tanımlanır.
        private void INT16Kontrol(string SoruMetin, string HataMetin)
        {
            // Temp adında bir değişken tanımlanır.
            string Temp = String.Empty;

            // Koşullar sağlanana kadar dönen bir döngü tanımlanır.
            while (true)
            {
                // Ekrana soru metni yazdırılır ve kullanıcının girdiği değer Temp değişkenine aktarılır.
                Console.Write(SoruMetin);
                Temp = Console.ReadLine();

                // Girilen değerin INT16 sınıfına ait olup olmadığı kontrol edilir.
                if (!Int16.TryParse(Temp, out short INT16))
                {
                    // Ekrana hata metni yazdırılır.
                    Console.WriteLine(HataMetin + " Rakamlardan Oluşmaktadır.");
                }

                // Girilen değerin doğru olup olmadığı kontrol edilir.
                else if (!(Convert.ToInt16(Temp) >= Convert.ToInt16(DateTime.Now.Year - 100) && Convert.ToInt16(Temp) <= Convert.ToInt16(DateTime.Now.Year)))
                {
                    // Ekrana hata metni yazdırılır.
                    Console.WriteLine(HataMetin + " 0 ile 100 Arasında Olmalıdır. Doğum Yılınızı Giriniz.");
                }

                // Girilen veri doğru ise ataması gerçekleştirilir ve döngü durdurulur.
                else
                {
                    // Bugünün tarihinden girilen tarih çıkarılır.
                    Yas = Convert.ToInt16(Convert.ToInt16(DateTime.Now.Year) - Convert.ToInt16(Temp));
                    break;
                }
            }
        }

        // Cinsiyet ve Engelli değişkenleri için girilen değerin doğru olup olmadığını kontrol eden method tanımlanır.
        private void CEKontrol(string SoruMetin, char Karakter1, char Karakter2, int Degisken)
        {
            // Temp adında bir değişken tanımlanır.
            string Temp = String.Empty;

            // Koşullar sağlanana kadar dönen bir döngü tanımlanır.
            while (true)
            {
                // Ekrana soru metni yazdırılır ve kullanıcının girdiği değer Temp değişkenine aktarılır.
                Console.Write(SoruMetin);
                Temp = Console.ReadLine().ToLower();

                /*
                    * Girilen veri Karakter1 değişkenine eşit olup olmadığı kontrol edilir.
                    * Girilen koda göre değişken ataması gerçekleştirilir ve döngü durdurulur.
                */
                if (Temp == Karakter1.ToString())
                {
                    if (Degisken == 0)
                        Cinsiyet = true;
                    if (Degisken == 1)
                        Engelli = true;

                    break;
                }

                /*
                    * Girilen veri Karakter2 değişkenine eşit olup olmadığı kontrol edilir.
                    * Girilen koda göre değişken ataması gerçekleştirilir ve döngü durdurulur.
                */
                else if (Temp == Karakter2.ToString())
                {
                    if (Degisken == 0)
                        Cinsiyet = false;
                    if (Degisken == 1)
                        Engelli = false;

                    break;
                }
                else
                {
                    // Ekrana Hata Metni Yazdırılır.
                    Console.WriteLine("{0} veya {1} Seçeneklerinden Bir Tanesini Seçiniz.", Karakter1, Karakter2);
                }
            }
        }

        // Müşterinin yaşlı olup olmadığını kontrol eden bir method tanımlanır.
        private void YasliKontrol()
        {
            // Yas değişkeninin değeri 60 ile 100 arasında ise Yasli değişkenine true değer atanır.
            if (Yas >= 60 && Yas <= 100)
                Yasli = true;
            // Yas değişkeninin değeri 60 ile 100 arasında değil ise Yasli değişkenine false değer atanır.
            else
                Yasli = false;
        }

        // Müşteri bilgilerini ekrana yazdırmak için bir metod tanımlanır.
        public void MusteriYazdir()
        {
            // Müşteri bilgileri ekrana yazdırılır.
            Console.WriteLine();
            Console.Clear();
            Console.WriteLine("Türkiye Cumhuriyeti Kimlik Numaranız: " + TC);
            Console.WriteLine("Adınız: " + Ad);
            Console.WriteLine("Soyadınız: " + Soyad);
            Console.WriteLine("Yaşınız: " + Yas);
            Console.WriteLine("Telefon Numaranız: 0" + Telefon);
            string CinsiyetMetin = Cinsiyet ? "Erkek" : "Kadın";
            Console.WriteLine("Cinsiyetiniz: " + CinsiyetMetin);
            string EngelliMetin = Engelli ? "Var" : "Yok";
            Console.WriteLine("Engelli Durumunuz: " + EngelliMetin);
            Console.WriteLine();
        }

        // Müşteri bilgilerini güncellemek için bir metod tanımlanır.
        private void MusteriBilgiGuncelle()
        {
            // Temp adında bir değişken tanımlanır.
            string Temp = String.Empty;

            // Koşullar sağlanana kadar dönen bir döngü tanımlanır.
            while (true)
            {
                // Ekrana soru metni yazdırılır ve kullanıcının girdiği değer Temp değişkenine aktarılır.
                Console.Write("Bilgileri Değiştirmek İster Misiniz? (e, h): ");
                Temp = Console.ReadLine().ToLower();

                /*
                    * Girilen veri e karakterine eşit ise müşteri bilgileri tekrar alınır ve döngü sonlandırılır.
                    * Girilen veri h karakterine eşit ise müşteri bilgileri tekrar alınmaz ve döngü sonlandırılır.
                    * Farkklı karakter girilir ise hata metni yazdırılır.
                */
                if (Temp == "e")
                {
                    Console.Clear();
                    MusteriOlustur();
                    break;
                }
                else if (Temp == "h")
                {
                    Console.Clear();
                    break;
                }
                else
                    Console.WriteLine("e veya h Seçeneklerinden Bir Tanesini Seçiniz.");
            }
        }
    }
}
