using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapsülleme__Encapsulation_2
{
    internal class Program
    {
        class BankaHesabi
        {
            private string hesapSahibi;
            private decimal bakiye;

            public string HesapSahibi
            {
                get { return hesapSahibi; }
                set
                {
                    if (!string.IsNullOrEmpty(value))
                        hesapSahibi = value;
                    else
                        Console.WriteLine("Hesap sahibi boş olamaz.");
                }
            }

            public decimal Bakiye
            {
                get { return bakiye; }
                private set // sadece sınıf içinden değiştirilebilir
                {
                    if (value >= 0)
                        bakiye = value;
                }
            }

            public BankaHesabi(string sahip, decimal baslangicBakiyesi)
            {
                HesapSahibi = sahip;
                Bakiye = baslangicBakiyesi;
            }

            public void ParaYatir(decimal miktar)
            {
                if (miktar > 0)
                {
                    Bakiye += miktar;
                    Console.WriteLine($"{miktar} TL yatırıldı.");
                }
            }

            public void ParaCek(decimal miktar)
            {
                if (miktar > 0 && miktar <= Bakiye)
                {
                    Bakiye -= miktar;
                    Console.WriteLine($"{miktar} TL çekildi.");
                }
                else
                {
                    Console.WriteLine("Yetersiz bakiye veya geçersiz miktar.");
                }
            }

            public void BilgiYazdir()
            {
                Console.WriteLine($"Hesap Sahibi: {HesapSahibi}, Bakiye: {Bakiye} TL");
            }
        }
        static void Main(string[] args)
        {
            BankaHesabi hesap = new BankaHesabi("Mehmet", 1000);
            hesap.BilgiYazdir();

            hesap.ParaYatir(500);
            hesap.ParaCek(300);
            hesap.ParaCek(1500); // Hatalı işlem
            hesap.BilgiYazdir();
        }
    }
}
