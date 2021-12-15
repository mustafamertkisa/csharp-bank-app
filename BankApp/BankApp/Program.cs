using BankApp.Models;
using System;

namespace BankApp
{
    public enum AccEnum
    {
        KisaVadeli = 1,
        UzunVadeli = 2,
        Ozel = 3,
        Cari = 4
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("# Hoşgeldiniz # \n Giriş yapmak için TC Kimlik Numaranızı giriniz:");
            var identityNumber = Console.ReadLine();
            var acc = new BankAccount();
            acc.LoginAccount(acc, identityNumber);
            Console.WriteLine("İşlem yapmak için bir sayı tuşlayın.");
            ShowDialogMenu(0);
            var menuKey = Console.ReadLine();
            while (menuKey != "9")
            {
                ShowDialogMenu(int.Parse(menuKey));
                if (menuKey == "1")
                {
                    Console.WriteLine("1 = Kısa Vadeli Hesap \n ******************** \n " +
                     "2 = Uzun Vadeli Hesap \n ******************** \n " +
                     "3 = Özel Hesap \n ******************** \n " +
                     "4 = Cari Hesap \n ******************** \n ");

                    var amount = Console.ReadLine();
                    MakeOperation(acc, int.Parse(menuKey), amount);
                   
                    ShowDialogMenu(0);
                }
                else if (menuKey == "2" || menuKey == "3")
                {
                    var amount = Console.ReadLine();
                    MakeOperation(acc, int.Parse(menuKey), amount);
                    Console.WriteLine($"Bakiyeniz: {acc.CheckingAccounts.Balance}");
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
                    Console.WriteLine("1 = Hesap Açma \n ******************** \n " +
                      "2 = Para Yatırma \n ******************** \n " +
                      "3 = Para Çekme \n ******************** \n " +
                      "4 = Hesap Listesi \n ******************** \n " +
                      "5 = Hesap İşlem Kayıtları \n ******************** \n " +
                      "6 = Çekiliş");
                    break;
                case 1:
                    Console.WriteLine("Hesap Açma");
                    break;
                case 2:
                    Console.WriteLine("Yatırmak istediğiniz tutarı giriniz:");
                    break;
                case 3:
                    Console.WriteLine("Çekmek istediğiniz tutarı giriniz:");
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
                    acc.DepositMoney(acc, amount);
                    Console.WriteLine("Bakiye eklendi.");
                    break;
                case 2:
                    acc.DepositMoney(acc, amount);
                    Console.WriteLine("Bakiye eklendi.");
                    break;
                case 3:
                    if (acc.CheckingAccounts.Balance < int.Parse(amount))
                    {
                        Console.WriteLine("Yetersiz bakiye.");
                        break;
                    }
                    acc.WithdrawMoney(acc, amount);
                    break;
                default:
                    break;

            }
        }
    }
}