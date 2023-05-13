using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asrın_Baydemir
{
    internal interface IUcak
    {
        // Uçağın model bilgisini tutan değişken tanımlanır.
        string Model { get; set; }

        // Uçağın kod bilgisini tutan değişken tanımlanır.
        string Kod { get; set; }

        // Uçağın yolcu kapasitesi bilgisini tutan değişken tanımlanır.
        int YolcuKapasitesi { get; set; }

        // Uçağın iş sınıfı yolcu kapasitesi bilgisini tutan değişken tanımlanır.
        int BYolcuKapasitesi { get; set; }

        // Uçağın ekonomi sınıfı yolcu kapasitesi bilgisini tutan değişken tanımlanır.
        int EYolcuKapasitesi { get; set; }
    }
}
