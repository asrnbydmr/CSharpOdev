using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asrın_Baydemir
{
    internal class DosyaOkuma
    {
        // Uçak bilgilerini geri döndüren bir metod tanımlanır.
        public List<Ucak> UcakBilgisi(string DosyaYolu)
        {
            // Ucak sınıfından bir liste tanımlanır.
            List<Ucak> UcakListe = new List<Ucak>();

            // Bu döngünün amacı; belirtilen belge yok ise belgenin ve verilerin sorunsuz şekilde oluşturulduğunu kontrol etmek içindir.
            while (true)
            {
                // Dosyanın var olup olmadığı kontrol edilir.
                if (File.Exists(DosyaYolu))
                {
                    // Dosyanın içerisindeki satırlar okunur.
                    string[] Satirlar = File.ReadAllLines(DosyaYolu);

                    // Verilerin listeye aktarılması için döngü tanımlanır.
                    for (int i = 0; i < Satirlar.Length; i++)
                    {
                        /*
                            * Dosya formatı CSV yani Virgül ile Ayrılmış Değer formatındadır.
                            * Her bir satırda 5 veri vardır ve bu veriler ',' ile ayrılmıştır.
                            * Split metodu ile Satırlar dizisindeki veriler ayrıştırılır ve Veriler dizisine eklenir.
                            * Split metoduna parametre olarak ',' işareti verilir. Split metodu ',' işaretine göre verileri ayrıştırır.
                        */
                        string[] Veriler = Satirlar[i].Split(',');

                        // Listeye eklenecek verilerin boş olup olmadığını kontrol etmek için sorgu tanımlanır.
                        if (Veriler[0] != null && Veriler[1] != null && Veriler[2] != null && Veriler[3] != null && Veriler[4] != null)
                        {
                            // Ucak sınıfından bir nesne oluşturulur.
                            Ucak Ucak = new Ucak();

                            // Veriler dizisindeki değerler sınıf değişkenlerinde karşılık gelen alanlara atanır.
                            Ucak.Model = Veriler[0];
                            Ucak.Kod = Veriler[1];
                            Ucak.YolcuKapasitesi = Convert.ToInt32(Veriler[2]);
                            Ucak.BYolcuKapasitesi = Convert.ToInt32(Veriler[3]);
                            Ucak.EYolcuKapasitesi = Convert.ToInt32(Veriler[4]);

                            // Nesne UcakListe listesine eklenir.
                            UcakListe.Add(Ucak);
                        }
                    }

                    // Döngü durdurulur.
                    break;
                }

                // Dosya yok ise oluşturulur.
                else
                {
                    VeriOlustur VeriOlustur = new VeriOlustur();
                    VeriOlustur.UcakBelgeOlustur();
                }
            }

            // Liste geri döndürülür.
            return UcakListe;
        }

        // Havalimanı bilgilerini geri döndüren bir metod tanımlanır.
        public List<Lokasyon.YHavalimani> HavalimaniBilgisi(string DosyaYolu)
        {
            // Lokasyon sınıfında bulunan Havalimani yapısından bir liste tanımlanır.
            List<Lokasyon.YHavalimani> HavalimaniListe = new List<Lokasyon.YHavalimani>();

            // Bu döngünün amacı; belirtilen belge yok ise belgenin ve verilerin sorunsuz şekilde oluşturulduğunu kontrol etmek içindir.
            while (true)
            {
                // Dosyanın var olup olmadığı kontrol edilir.
                if (File.Exists(DosyaYolu))
                {
                    // Dosyanın içerisindeki satırlar okunur.
                    string[] Satirlar = File.ReadAllLines(DosyaYolu);

                    // Verilerin listeye aktarılması için döngü tanımlanır.
                    for (int i = 0; i < Satirlar.Length; i++)
                    {
                        /*
                            * Dosya formatı CSV yani Virgül ile Ayrılmış Değer formatındadır.
                            * Her bir satırda 3 veri vardır ve bu veriler ',' ile ayrılmıştır.
                            * Split metodu ile Satırlar dizisindeki veriler ayrıştırılır ve Veriler dizisine eklenir.
                            * Split metoduna parametre olarak ',' işareti verilir. Split metodu ',' işaretine göre verileri ayrıştırır.
                        */
                        string[] Veriler = Satirlar[i].Split(',');

                        // Listeye eklenecek verilerin boş olup olmadığını kontrol etmek için sorgu tanımlanır.
                        if (Veriler[0] != null && Veriler[1] != null && Veriler[2] != null)
                        {
                            // Lokasyon sınıfında bulunan Havalimani yapısından bir nesne oluşturulur.
                            Lokasyon.YHavalimani Havalimani = new Lokasyon.YHavalimani();

                            // Veriler dizisindeki değerler yapı içerisinde bulunan değişkenlere karşılık gelen alanlara atanır.
                            Havalimani.UlkeAdi = Veriler[0];
                            Havalimani.BolgeAdi = Veriler[1];
                            Havalimani.HavalimaniAdi = Veriler[2];

                            // Nesne UcakListe listesine eklenir.
                            HavalimaniListe.Add(Havalimani);
                        }
                    }

                    // Döngü durdurulur.
                    break;
                }

                // Dosya yok ise oluşturulur.
                else
                {
                    VeriOlustur VeriOlustur = new VeriOlustur();
                    VeriOlustur.HavalimaniBelgeOlustur();
                }
            }

            // Liste geri döndürülür.
            return HavalimaniListe;
        }
    }
}
