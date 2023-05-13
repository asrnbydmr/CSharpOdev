# C# Uçak Rezervasyon Sistemi Konsol Uygulamlası

Bu konsol örneği basit bir uçak rezervayon sistemi örneğidir. Uygulamanın içerisinde bulunan her bir sınıf ve interface için yorum satırı yazılmıştır. Uygulamanın çalışması için 2 dosya ve 3 belge gereklidir. Bu dosyalar ve belgeler otomatik olarak oluşturulmaktadır.

### Uygulama Klasör Yapısı
* Havalimani ve Ucak adlı klasör programın içerisinde oluşturulmaktadır.

##### Havalimani
* Havalimani adlı klasörün içerisinde havalimani.txt adlı belge bulunmaktadır. Bu belgenin içeriği havalimanı bilgilerini (ülke, şehir, havalimanı adı) tutmaktır.

##### Ucak
* Ucak adlı klasörün içerisinde yurtici.txt ve yurtdisi.txt adlı belge bulunmaktadır. Bu belgelerin içeriği yurtiçi ve yurtdışı uçuşu yapan uçakların bilgilerini tutmaktır.

### Uygulamada Bulunan Interfaceler
* ILokasyon => Lokasyon sınıfının kullanacağı metodu içerir.
* IMusteri => Musteri sınıfının kullanacağı alanları içerir.
* IRezervasyon => Rezervasyon sınıfının kullanacağı alanları içerir.
* IUcak => Ucak sınıfının kullanacağı alanları içerir.

#### ILokasyon
* void LokasyonOlustur()

#### IMusteri
* Int64 TC { get; set; }
* string Ad { get; set; }
* string Soyad { get; set; }
* Int16 Yas { get; set; }
* Int64 Telefon { get; set; }
* Boolean Cinsiyet { get; set; }
* Boolean Yasli { get; set; }
* Boolean Engelli { get; set; }

#### IRezervasyon
* Int32 BiletNo { get; set; }
* Ucak Ucak { get; set; }
* Lokasyon Lokasyon { get; set; }
* Musteri Musteri { get; set; }
* int IndirimOrani { get; set; }
* int Ucret { get; set; }

#### IUcak
* string Model { get; set; }
* string Kod { get; set; }
* int YolcuKapasitesi { get; set; }
* int BYolcuKapasitesi { get; set; }
* int EYolcuKapasitesi { get; set; }

### Uygulamada Bulunan Sınıflar
* DosyaOkuma => Belge içeriğini okumak için gerekli metodları içerir.
* GirisEkrani => Programa farklı bir dokunuş katmak için gerekli metodu içerir.
* KimlikNoKontrol => Türkiye Cumhuriyeti Kimlik Numarasının gerçek olup olmadığını kontrol etmek için gerekli metodu içerir.
* KonsolAyar => Konsol başlığının ve renk kombinasyonlarının değiştirilebilmesi için gerekli metodları içerir.
* Lokasyon => Program yükünün en çok üstüne olduğu sınıftır. Lokasyon bilgileri ile ilgili alanları ve bu alanlara girilen verilerin kontrol edilmesini sağlayan metodları içerir.
* Musteri => Müşteri bilgileri ile ilgili alanları ve bu alanlara girilen verilerin kontrol edilmesini sağlayan metodları içerir.
* Program => Programın asıl sınıfıdır. Main metodu dışında bir metod ve alan içermez.
* Rezervasyon => Rezervasyon bilgileri ile ilgili alanları ve bu alanlara girilen verilerin kontrol edilmesini, ücret bilgisinin oluşturulmasını sağlayan metodları içerir.
* Ucak => Uçak bilgileri ile ilgili alanları ve bu alanlar içerisinde bulunan listelere veri doldurulması için gerekli metodları içerir.
* VeriOlustur => Programın çalışması için gerekli olan dosyaları ve dosyaların içerisinde bulunan belgeleri oluşturmaya ve bu belgelere veri eklenmesi için gerekli metodları içerir.

#### DosyaOkuma
* public List<Ucak> UcakBilgisi(string DosyaYolu)
* public List<Lokasyon.YHavalimani> HavalimaniBilgisi(string DosyaYolu)

#### GirisEkrani
* public GirisEkrani()

#### KimlikNoKontrol
* public static bool KimlikKontrol(string KimlikNumarası)

#### KonsolAyar
* public static void KonsolRenkAyari(string ArkaplanRengi, string YaziRengi)
* public static void KonsolBaslikAyar(string Baslik)

#### Lokasyon
* public struct YHavalimani { public string UlkeAdi; public string BolgeAdi; public string HavalimaniAdi; }
* public struct YLokasyon { public string KalkisYeri; public string VarisYeri; public DateTime UcusTarihi; public TimeSpan UcusSaati; }
* private List<YHavalimani> Havalimanlari = new List<YHavalimani>();
* private List<YHavalimani> YurticiUcus = new List<YHavalimani>();
* private List<YHavalimani> YurtdisiUcus = new List<YHavalimani>();
* private ArrayList UlkeListesi = new ArrayList();
* private List<YHavalimani> HavalimaniListesi = new List<YHavalimani>();
* private YLokasyon MusteriLokasyon = new YLokasyon();
* private DosyaOkuma DosyaOkuma = new DosyaOkuma();
* private int Sayac = 1, YSecim = 0, Secim = 0, UlkeSayac = 1;
* public int UcusTipi;
* private void HavalimaniListesiOlustur()
* public void LokasyonOlustur()
* private bool UcusTipiKontrol(int UcusTipi)
* private int UcusTipiBelirle()
* private void Yurtici(int Kod, string KalkisYeri)
* private void Yurtdisi(int Kod, string KalkisYeri)
* private string KalkisYeriSec(int UcusTipi)
* private string VarisYeriSec(int UcusTipi, string KalkisYeri)
* private DateTime[] TarihOlustur()
* private void TarihSecim()
* private TimeSpan[] SaatOlustur()
* private void SaatSecim()
* public void LokasyonYazdir()

#### Musteri
* public Int64 TC { get; set; }
* public string Ad { get; set; }
* public string Soyad { get; set; }
* public Int16 Yas { get; set; }
* public Int64 Telefon { get; set; }
* public Boolean Cinsiyet { get; set; }
* public Boolean Engelli { get; set; }
* public Boolean Yasli { get; set; }
* public Musteri()
* private void MusteriOlustur()
* private void INT64Kontrol(string SoruMetin, string HataMetin, int Degisken)
* private void INT16Kontrol(string SoruMetin, string HataMetin)
* private void CEKontrol(string SoruMetin, char Karakter1, char Karakter2, int Degisken)
* private void YasliKontrol()
* public void MusteriYazdir()
* private void MusteriBilgiGuncelle()

#### Program
* KonsolAyar.KonsolBaslikAyar("Uçak Rezervasyon Sistemi");
* GirisEkrani GirisEkrani = new GirisEkrani();
* Console.WriteLine("Uçak Rezervasyon Sistemine Hoş Geldiniz.");
* Rezervasyon Rezervasyon = new Rezervasyon();
* Console.ReadKey();

#### Rezervasyon
* public Int32 BiletNo { get; set; }
* public Ucak Ucak { get; set; }
* public Lokasyon Lokasyon { get; set; }
* public Musteri Musteri { get; set; }
* public int IndirimOrani { get; set; }
* public int Ucret { get; set; }
* private Random Random = new Random();
* private int UcakTipi;
* public Rezervasyon()
* private void UcakBilgi(List<Ucak> UcusTipi)
* private bool IndirimKontrol()
* private int IndirimBelirle()
* private void UcretBelirle()

#### Ucak
* public string Model { get; set; }
* public string Kod { get; set; }
* public int YolcuKapasitesi { get; set; }
* public int BYolcuKapasitesi { get; set; }
* public int EYolcuKapasitesi { get; set; }
* public List<Ucak> YurticiUcakListesi;
* public List<Ucak> YurtdisiUcakListesi;
* private DosyaOkuma DosyaOkuma = new DosyaOkuma();
* public void YurticiUcakListesiTanimla()
* public void YurtdisiUcakListesiTanimla()

#### VeriOlustur
* private string[] Yurtici = new string[4];
* private string[] Yurtdisi = new string[5];
* private string[] Havalimani = new string[1279];
* private void DosyaOlustur(string DosyaAdi)
* private void BelgeOlustur(string DosyaAdi, string BelgeAdi, string[] Satirlar)
* private void YurticiEkle()
* private void YurtdisiEkle()
* private void HavalimaniEkle()
* public void UcakBelgeOlustur()
* public void HavalimaniBelgeOlustur()