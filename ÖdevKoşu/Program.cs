using System;

namespace ÖdevKoşu
{
    class Program
    {
        static void Main(string[] args)
        {
            Login();
            KullanicidanAdimBoyuAl(out int adimBoyu);
            KullanicidanKosuSaatiAl(out int saat);
            KullanicidanKosuDakikaAl(out int dakika);
            //KullanicidanAdimSayisiAl(out int adimSayisi);  Bu metod başka bir metot içinde kullanıldığı için burda çalıştırmaya  gerek yok 
            Console.WriteLine("Toplam kattettiğiniz mesafe: " + MesafeHesapla(saat, dakika, adimBoyu) + "metredir.");
            Logout();
            Console.ReadLine();

        }

        private static int KullanicidanAdimSayisiAl(out int adimSayisi)
        {
            Console.WriteLine("Lütfen 1 dakikada attığınız adım sayısını giriniz.");
            bool sayiMi = int.TryParse(Console.ReadLine(), out adimSayisi);
            if (sayiMi)
            {
                return adimSayisi;
            }
            else
            {
                Console.WriteLine("Yanlış ya da uygun aralıkta olmayan bir giriş yaptınız");
                return KullanicidanAdimSayisiAl(out adimSayisi);
            }
        }

        private static void Logout()
        {
            Console.WriteLine("Programı Kullandığınız için teşekkür ederiz , Sağlıcakla Kalın!");
        }

        private static int MesafeHesapla(int saat, int dakika, int adimBoyu)
        {
            int sure = ((saat * 60) + dakika);
            int mesafe = 0;
            KullanicidanAdimSayisiAl(out int adimSayisi);
            Console.WriteLine("Kaç dakika arayla temponuz düşüyor. Hep aynı tempoda ilerliyorsanız 0 giriniz");
            int azalanTempoDakika = Convert.ToInt32(Console.ReadLine());
            if (azalanTempoDakika == 0)
            {
                return mesafe = adimSayisi * sure * adimBoyu / 100;
            }
            else
            {
                Console.WriteLine("Belirttiğiniz süre periyodunda temponuz kaç adım düşüyor.");
                int adimSayisiAzalması = Convert.ToInt32(Console.ReadLine());

                while (sure >= azalanTempoDakika)
                {
                    mesafe = mesafe + ((azalanTempoDakika * adimSayisi) * adimBoyu);
                    sure = sure - azalanTempoDakika;
                    adimSayisi = adimSayisi - adimSayisiAzalması;
                }
            }
            return (mesafe + (adimSayisi * sure * adimBoyu)) / 100;
        }

        private static int KullanicidanAdimBoyuAl(out int adimBoyu)
        {
            Console.WriteLine("Lütfen koşu yaptığınız esnadaki bir adımınızın ortalama boyunu  cm cinsinden giriniz. ");
            bool adimMi = int.TryParse(Console.ReadLine(), out adimBoyu);
            if (adimMi)
            {
                if (adimBoyu < 20 || adimBoyu > 200)
                {
                    Console.WriteLine("Yanlış ya da uygun aralıkta olmayan bir giriş yaptınız");
                    return KullanicidanAdimBoyuAl(out adimBoyu);
                }
                else
                {
                    return adimBoyu;
                }
            }
            Console.WriteLine("Yanlış ya da uygun aralıkta olmayan bir giriş yaptınız");
            return KullanicidanAdimBoyuAl(out adimBoyu);
        }

        private static int KullanicidanKosuDakikaAl(out int dakika)
        {
            Console.WriteLine("Lütfen koşu yaptığınız süre saat kısmından sonra kaç dakika");

            bool dakikaMi = int.TryParse(Console.ReadLine(), out dakika);
            if (dakikaMi)
            {
                if (dakika < 0 || dakika >= 60)
                {
                    Console.WriteLine("Yanlış ya da uygun aralıkta olmayan bir giriş yaptınız");
                    return KullanicidanKosuDakikaAl(out dakika);
                }
                else
                    return dakika;
            }
            else
            {
                Console.WriteLine("Yanlış ya da uygun aralıkta olmayan bir giriş yaptınız");
                return KullanicidanKosuDakikaAl(out dakika);
            }
        }

        private static int KullanicidanKosuSaatiAl(out int saat)
        {
            Console.WriteLine("Lütfen koşu yaptığınız süre kaç saat girebilir misiz?(sadece saat kısmını giriniz dakikasını birazdan soracağım");

            bool saatMi = int.TryParse(Console.ReadLine(), out saat);
            if (saatMi)
            {
                if (saat < 0)
                {
                    Console.WriteLine("Yanlış ya da uygun aralıkta olmayan bir giriş yaptınız");
                    return KullanicidanKosuSaatiAl(out saat);
                }
                else
                    return saat;
            }
            else
            {
                Console.WriteLine("Yanlış ya da uygun aralıkta olmayan bir giriş yaptınız");
                return KullanicidanKosuSaatiAl(out saat);
            }
        }

        private static void Login()
        {
            Console.WriteLine("Lütfen hitap edebilmem için isminizi girer misiniz?");
            string isim = Console.ReadLine();
            Console.WriteLine("Merhaba " + isim + "!,\nŞimdi gireceğin bilgilerle bir antremanda kaç metre koşmuşsun ona bakalım.");
        }
    }
}
