using System;
using c_storemanagement;

namespace c_storemanagement
{
    class Program
    {
        static void Main(string[] args)
        {
            SatisTemsilcisi satisTemsilcisi = new SatisTemsilcisi { Ad = "Tarık", Soyad = "Hamarat", SatisMiktari = 0, Sifre = "1234" };
            Magaza magaza = new Magaza(satisTemsilcisi);

           
            magaza.UrunEkle(new Urun { Beden = "M", Renk = "Mavi", Sezon = "İlkbahar", Fiyat = 100, Cinsiyet = "Erkek" });
            magaza.UrunEkle(new Urun { Beden = "S", Renk = "Yeşil", Sezon = "Yaz", Fiyat = 200, Cinsiyet = "Kadın" });
            magaza.UrunEkle(new Urun { Beden = "L", Renk = "Kırmızı", Sezon = "Sonbahar", Fiyat = 150, Cinsiyet = "Erkek" });

            Console.WriteLine("Lütfen şifrenizi girin:");
            string girilenSifre = Console.ReadLine();

            if (girilenSifre == satisTemsilcisi.Sifre)
            {
                Console.WriteLine($"Hoşgeldin {satisTemsilcisi.Ad} {satisTemsilcisi.Soyad}");

                bool devam = true;
                while (devam)
                {
                    Console.WriteLine("Yapmak istediğiniz işlemi seçin:");
                    Console.WriteLine("1-Ürün Sat");
                    Console.WriteLine("2-Ürün Ekle");
                    Console.WriteLine("3-Ürün Sil");
                    Console.WriteLine("4-Ürün Güncelle");
                    Console.WriteLine("5-Çıkış");
                    int secim = int.Parse(Console.ReadLine());

                    switch (secim)
                    {
                        case 1: 
                            Console.WriteLine("Satılacak ürünün ID'sini girin:");
                            int satisId = int.Parse(Console.ReadLine());
                            Urun satilanUrun = magaza.UrunSat(satisId);
                            if (satilanUrun != null)
                            {
                                Console.WriteLine("Ürün başarıyla satıldı.");
                            }
                            else
                            {
                                Console.WriteLine("Ürün bulunamadı.");
                            }
                            break;

                        case 2: 
                            Urun yeniUrun = new Urun();
                            Console.WriteLine("Ürün bedeni:");
                            yeniUrun.Beden = Console.ReadLine();
                            Console.WriteLine("Ürün rengi:");
                            yeniUrun.Renk = Console.ReadLine();
                            Console.WriteLine("Ürün sezonu:");
                            yeniUrun.Sezon = Console.ReadLine();
                                                       Console.WriteLine("Ürün fiyatı:");
                            yeniUrun.Fiyat = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("Ürün cinsiyeti:");
                            yeniUrun.Cinsiyet = Console.ReadLine();

                            magaza.UrunEkle(yeniUrun);
                            Console.WriteLine("Ürün başarıyla eklendi.");
                            break;

                        case 3: 
                            Console.WriteLine("Silinecek ürünün ID'sini girin:");
                            int silinecekId = int.Parse(Console.ReadLine());
                            if (magaza.UrunSil(silinecekId))
                            {
                                Console.WriteLine("Ürün başarıyla silindi.");
                            }
                            else
                            {
                                Console.WriteLine("Ürün bulunamadı.");
                            }
                            break;

                        case 4: 
                            Console.WriteLine("Güncellenecek ürünün ID'sini girin:");
                            int guncellenecekId = int.Parse(Console.ReadLine());
                            Urun guncellenecekUrun = magaza.UrunBul(guncellenecekId);
                            if (guncellenecekUrun != null)
                            {
                                Console.WriteLine("Yeni ürün bedeni:");
                                guncellenecekUrun.Beden = Console.ReadLine();
                                Console.WriteLine("Yeni ürün rengi:");
                                guncellenecekUrun.Renk = Console.ReadLine();
                                Console.WriteLine("Yeni ürün sezonu:");
                                guncellenecekUrun.Sezon = Console.ReadLine();
                                Console.WriteLine("Yeni ürün fiyatı:");
                                guncellenecekUrun.Fiyat = decimal.Parse(Console.ReadLine());
                                Console.WriteLine("Yeni ürün cinsiyeti:");
                                guncellenecekUrun.Cinsiyet = Console.ReadLine();

                                Console.WriteLine("Ürün başarıyla güncellendi.");
                            }
                            else
                            {
                                Console.WriteLine("Ürün bulunamadı.");
                            }
                            break;

                        case 5: 
                            devam = false;
                            break;

                        default:
                            Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Hatalı şifre!");
            }
        }
    }
}
