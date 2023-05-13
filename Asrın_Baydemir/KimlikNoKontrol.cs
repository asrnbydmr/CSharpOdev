using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asrın_Baydemir
{
    internal class KimlikNoKontrol
    {
        // Türkiye Kimlik Numarasını Kontrol etmek için metod tanımlanır.
        public static bool KimlikKontrol(string KimlikNumarası)
        {
            // T.C. Kimlik Numarası belirli bir algoritma ile üretilir. Bu algoritmanın kontrolü için rakamlar diziye aktarılır.
            int[] Hane = new int[11];
            for (int i = 0; i < 11; i++)
            {
                Hane[i] = int.Parse(KimlikNumarası[i].ToString());
            }

            // T.C. Kimlik Numarasının ilk hanesi 0 olamaz. Bu durumun kontrolü yapılır.
            if (Hane[0] == 0)
            {
                return false;
            }

            // T.C. Kimlik Numarasının tek basamaklı hanelerinin (11. hane hariç) toplamı hesaplanır.
            int Toplam1 = Hane[0] + Hane[2] + Hane[4] + Hane[6] + Hane[8];

            // T.C. Kimlik Numarasının çift basamaklı hanelerinin (10. hane hariç) toplamı hesaplanır.
            int Toplam2 = Hane[1] + Hane[3] + Hane[5] + Hane[7];

            /*
                * T.C. Kimlik Numarasının tek basamaklı hanelerinin toplamı 7 ile çarpılır ve çift basamaklı hanelerinin toplamından çıkarılır.
                * Çıkan sonuç 10 sayısına bölünür ve kalan rakam Hesap değişkenine aktarılır.
            */
            int Hesap = ((Toplam1 * 7) - Toplam2) % 10;

            // Sonuç T.C. Kimlik Numarasının 10. hanesine eşit olmalıdır.
            if (Hesap != Hane[9])
            {
                return false;
            }

            /*
                * T.C. Kimlik Numarasının tek basamaklı hanelerinin toplamı, çift basamaklı hanelerinin toplamı ve T.C. Kimlik Numarasının 10. hanesi toplanır.
                * Çıkan sonuç 10 sayısına bölünür ve kalan rakam Hesap değişkenine aktarılır.
            */
            Hesap = (Toplam1 + Toplam2 + Hane[9]) % 10;

            // Sonuç T.C. Kimlik Numarasının 11. hanesine eşit olmalıdır.
            if (Hesap != Hane[10])
            {
                return false;
            }

            // Yukarıdaki sorgulardan herhangi birisi çalışır ise T.C. Kimlik Numarası yanlıştır.
            // Yukarıdaki sorgulardan herhangi birisi çalışmaz ise T.C. Kimlik Numarası doğrudur.
            // Sorguların şartları sağlandığında false değeri, sağlanmadığında true değeri döndürülür.
            return true;
        }
    }
}
