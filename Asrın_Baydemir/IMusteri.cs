using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asrın_Baydemir
{
    internal interface IMusteri
    {
        // Müşterinin Türkiye Cumhuriyeti Kimlik Numarası bilgisini tutan değişken tanımlanır.
        Int64 TC { get; set; }

        // Müşterinin ad bilgisini tutan değişken tanımlanır.
        string Ad { get; set; }

        // Müşterinin soyad bilgisini tutan değişken tanımlanır.
        string Soyad { get; set; }

        // Müşterinin yaş bilgisini tutan değişken tanımlanır.
        Int16 Yas { get; set; }

        // Müşterinin telefon bilgisini tutan değişken tanımlanır.
        Int64 Telefon { get; set; }

        // Müşterinin cinsiyet bilgisini tutan değişken tanımlanır.
        Boolean Cinsiyet { get; set; }

        // Müşterinin yaşlı olup olmadığı bilgisini tutan değişken tanımlanır.
        Boolean Yasli { get; set; }

        // Müşterinin engelli olup olmadığı bilgisini tutan değişken tanımlanır.
        Boolean Engelli { get; set; }
    }
}
