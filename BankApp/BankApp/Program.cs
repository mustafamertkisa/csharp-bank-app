using BankApp.Models;
using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("^^ Hoşgeldiniz ^^ \n Giriş yapmak için TC Kimlik Numaranızı giriniz:");
            var identityNumber = Console.ReadLine();
            var acc = new BankAccount();
            acc.LoginAccount(acc, identityNumber);
            Console.WriteLine("#######################################");
            Console.WriteLine("İşlem yapmak için bir sayı tuşlayın.");
            Console.WriteLine("#######################################");
            ShowDialogMenu(0);
            var menuKey = Console.ReadLine();
            while (menuKey != "9")
            {
                ShowDialogMenu(int.Parse(menuKey));
                if (menuKey == "1")
                {
                    Console.WriteLine("\n1 = Kısa Vadeli Hesap [Yıllık kâr oranı: %15 | Min gereken tutar: 5000 TL]\n********************\n"+"2 = Uzun Vadeli Hesap [Yıllık kâr oranı: %17 | Min gereken tutar: 10000 TL]\n********************\n" + "3 = Özel Hesap [Yıllık kâr oranı: %10 | Min gereken tutar: 0 TL]");
                    var amount = Console.ReadLine(); //Burada amount'u hesap türü tercihi olarak almaktayız
                    MakeOperation(acc, int.Parse(menuKey), amount);
                    ShowDialogMenu(0);
                }
                else if (menuKey == "2" || menuKey == "3")
                {
                    var amount = Console.ReadLine();
                    MakeOperation(acc, int.Parse(menuKey), amount);
                    Console.WriteLine("#######################################");
                    Console.WriteLine($"Bakiyeniz: {acc.CheckingAccounts.Balance} TL");
                    Console.WriteLine("#######################################");
                    ShowDialogMenu(0);
                }
                else if (menuKey == "4")
                {
                    var amount = "AccList";
                    MakeOperation(acc, int.Parse(menuKey), amount);
                    ShowDialogMenu(0);
                }
                else if (menuKey == "5")
                {
                    var amount = "AccInfo";
                    MakeOperation(acc, int.Parse(menuKey), amount);
                    ShowDialogMenu(0);
                }
                else if (menuKey == "6")
                {
                    var amount = "history";
                    MakeOperation(acc, int.Parse(menuKey), amount);
                    ShowDialogMenu(0);
                }
                else if (menuKey == "7")
                {
                    var amount = "draw";
                    MakeOperation(acc, int.Parse(menuKey), amount);
                    ShowDialogMenu(0);
                }
                menuKey = Console.ReadLine();
            }
        }

        public static void ShowDialogMenu(int menuKey)
        {
            switch (menuKey)
            {
                case 0:
                    Console.WriteLine("\n1 = Hesap Açma\n********************\n"+"2 = Para Yatırma\n********************\n"+"3 = Para Çekme\n********************\n"+"4 = Hesap Listesi\n********************\n"+"5 = Hesap Durum\n******************** \n"+"6 = Hesap İşlem Kayıtları\n********************\n"+"7 = Çekiliş");
                    break;
                case 1:
                    Console.WriteLine("#######################################");
                    Console.WriteLine("Hesap türü seçiniz:");
                    Console.WriteLine("#######################################");
                    break;
                case 2:
                    Console.WriteLine("#######################################");
                    Console.WriteLine("Yatırmak istediğiniz tutarı giriniz:");
                    Console.WriteLine("#######################################");
                    break;
                case 3:
                    Console.WriteLine("#######################################");
                    Console.WriteLine("Çekmek istediğiniz tutarı giriniz:");
                    Console.WriteLine("#######################################");
                    break;
                case 4:
                    Console.WriteLine("#######################################");
                    Console.WriteLine("Hesap listesi:");
                    Console.WriteLine("#######################################");
                    break;
                case 5:
                    Console.WriteLine("#######################################");
                    Console.WriteLine("Hesap durum:");
                    Console.WriteLine("#######################################");
                    break;
                case 6:
                    Console.WriteLine("#######################################");
                    Console.WriteLine("Hesap işlem kayıtları:");
                    Console.WriteLine("#######################################");
                    break;
                case 7:
                    Console.WriteLine("#######################################");
                    Console.WriteLine("Çekiliş:");
                    Console.WriteLine("#######################################");
                    break;
                default:
                    break;
            }
        }

        public static void MakeOperation(BankAccount acc, int menuKey, string amount)
        {
            switch (menuKey)
            {
                case 1:
                    if (amount == "1" && acc.CheckingAccounts.Balance >= 5000)
                    {
                        Console.WriteLine("Oluşturacağınız hesabınıza aktarmak istediğiniz tutarı giriniz:");
                        var startAmount = Console.ReadLine();
                        acc.CreateAccount(acc, amount, startAmount);
                        Console.WriteLine("#######################################");
                        Console.WriteLine("Kısa Vadeli hesap oluşturuldu.");
                        Console.WriteLine("#######################################");
                        break;
                    } 
                    else if (amount == "2" && acc.CheckingAccounts.Balance >= 10000)
                    {
                        Console.WriteLine("Oluşturacağınız hesabınıza aktarmak istediğiniz tutarı giriniz:");
                        var startAmount = Console.ReadLine();
                        acc.CreateAccount(acc, amount, startAmount);
                        Console.WriteLine("#######################################");
                        Console.WriteLine("Uzun Vadeli hesap oluşturuldu.");
                        Console.WriteLine("#######################################");
                        break;
                    }
                    else if (amount == "3" && acc.CheckingAccounts.Balance >= 0)
                    {
                        Console.WriteLine("Oluşturacağınız hesabınıza aktarmak istediğiniz tutarı giriniz:");
                        var startAmount = Console.ReadLine();
                        acc.CreateAccount(acc, amount, startAmount);
                        Console.WriteLine("#######################################");
                        Console.WriteLine("Özel hesap oluşturuldu.");
                        Console.WriteLine("#######################################");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("#######################################");
                        Console.WriteLine("Hata! Lütfen bakiyenizi kontrol ediniz.");
                        Console.WriteLine($"Bakiyeniz: {acc.CheckingAccounts.Balance} TL");
                        Console.WriteLine("#######################################");
                    }
                    break;
                case 2:
                    acc.DepositMoney(acc, amount);
                    Console.WriteLine("#######################################");
                    Console.WriteLine("Bakiye eklendi.");
                    Console.WriteLine("#######################################");
                    break;
                case 3:
                    if (acc.CheckingAccounts.Balance < int.Parse(amount))
                    {
                        Console.WriteLine("#######################################");
                        Console.WriteLine("Yetersiz bakiye.");
                        Console.WriteLine("#######################################");
                        break;
                    }
                    acc.WithdrawMoney(acc, amount);
                    break;
                case 4:
                    acc.ShowAccountList();
                    break;
                case 5:
                    Console.WriteLine("Kâr tutarı hesaplamak istediğiniz vade sürenizi (gün) giriniz:");
                    int creditTime = Convert.ToInt32(Console.ReadLine());
                    acc.ProfitAmount(acc, creditTime);
                    acc.ShowAccountInfo();
                    break;
                case 6:
                    acc.TransactionHistory();
                    break;
                case 7:
                    acc.MakeDraw();
                    break;
                default:
                    break;
            }
        }
    }
}