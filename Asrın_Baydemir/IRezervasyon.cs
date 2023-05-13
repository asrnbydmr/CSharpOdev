using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asrın_Baydemir
{
    internal interface IRezervasyon
    {
        // Rezervasyon bilet numarası bilgisini tutan değişken tanımlanır.
        Int32 BiletNo { get; set; }

        // Rezervasyon uçak bilgisini tutan değişken tanımlanır.
        Ucak Ucak { get; set; }

        // Rezervasyon lokasyon bilgisini tutan değişken tanımlanır.
        Lokasyon Lokasyon { get; set; }

        // Rezervasyon müşteri bilgisini tutan değişken tanımlanır.
        Musteri Musteri { get; set; }

        // Rezervasyon indirim oranını tutan değişken tanımlanır.
        int IndirimOrani { get; set; }

        // Rezervasyon ücret bilgisini tutan değişken tanımlanır.
        int Ucret { get; set; }
    }
}
