using BankApp.Models;
using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hoşgeldiniz. Giriş yapmak için TC kimlik numaranızı giriniz.");
            var identityNumber = Console.ReadLine();
            var acc = new BankAccount();
            acc.LoginAccount(acc, identityNumber);
            Console.WriteLine("İşlem yapmak için bir sayı tuşlayın.");
            ShowDialogMenu(0);
            var menuKey = Console.ReadLine();
            while(menuKey != "9")
            {
                ShowDialogMenu(int.Parse(menuKey));
                if (menuKey == "1" || menuKey == "2")
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
                    Console.WriteLine("1- Para yatırmak");
                    Console.WriteLine("2- Para çekmek");
                    //işlemler burada listelenecek
                    break;
                case 1:
                    Console.WriteLine("Yatırmak istediğiniz tutarı giriniz:");
                    break;
                case 2:
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
