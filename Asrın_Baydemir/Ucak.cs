using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asrın_Baydemir
{
    // Ucak sınıfı IUcak arabirimini kalıtım ile alır.
    internal class Ucak : IUcak
    {
        /*
            * IUcak arabirimdeki alanlar sınıfta tanımlanır.
        */
        public string Model { get; set; }
        public string Kod { get; set; }
        public int YolcuKapasitesi { get; set; }
        public int BYolcuKapasitesi { get; set; }
        public int EYolcuKapasitesi { get; set; }

        // Yurtiçinde kullanılan uçak bilgilerini tutacak liste tanımlanır.
        public List<Ucak> YurticiUcakListesi;

        // Yurtdışında kullanılan uçak bilgilerini tutacak liste tanımlanır.
        public List<Ucak> YurtdisiUcakListesi;

        // DosyaOkuma sınıfından bir nesne tanımlanır.
        private DosyaOkuma DosyaOkuma = new DosyaOkuma();

        // Yurtiçinde kullanılan uçak bilgilerinin oluşturulacağı metod tanımlanır.
        public void YurticiUcakListesiTanimla()
        {
            // YurticiUcakListesi listesine veriler eklenir.
            YurticiUcakListesi = DosyaOkuma.UcakBilgisi(@"Ucak\yurtici.txt");
        }

        // Yurtdışında kullanılan uçak bilgilerinin oluşturulacağı metod tanımlanır.
        public void YurtdisiUcakListesiTanimla()
        {
            // YurtdisiUcakListesi listesine veriler eklenir.
            YurtdisiUcakListesi = DosyaOkuma.UcakBilgisi(@"Ucak\yurtdisi.txt");
        }
    }
}
