﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum AccEnum
{
    KisaVadeli = 1,
    UzunVadeli = 2,
    Ozel = 3,
    Cari = 4
}

namespace BankApp.Models
{
    public class BankAccount
    {
        public string IdentityNumber { get; set; }

        //Cari hesap
        public CheckingAccount CheckingAccounts { get; set; }

        //Kısa vadeli hesap
        public ShortDepositAccount ShortDepositAccounts { get; set; }

        //Uzun vadeli hesap
        public LongDepositAccount LongDepositAccounts { get; set; }

        //Özel hesap
        public SpecialDepositAccount SpecialDepositAccounts { get; set; }

        List<int> accountList = new List<int>(); //Hesap listesi

        //Cari hesap info
        public AccEnum checkingInfoName;
        public int checkingInfoNumber;
        public decimal checkingInfoBalance;

        //Kısa vadeli hesap info
        public AccEnum shortInfoName;
        public int shortInfoNumber;
        public decimal shortInfoBalance;
        public int shortInfoProfit;

        //Uzun vadeli hesap info
        public AccEnum longInfoName;
        public int longInfoNumber;
        public decimal longInfoBalance;
        public int longInfoProfit;

        //Özel hesap info
        public AccEnum specialInfoName;
        public int specialInfoNumber;
        public decimal specialInfoBalance;
        public int specialInfoProfit;

        //İşlem kayıtları & çekiliş
        List<string> historyList = new List<string>(); //İşlem kayıtlarının listesi
        List<int> drawList = new List<int>(); //Çekilişe katılacak hesapların listesi

        public class ShortDepositAccount
        {
            public AccEnum AccountName { get; set; }
            public decimal Balance { get; set; }
            public int MinRequiredMoney { get; set; }
            public int IncomeRatio { get; set; }
            public int AccountNumber { get; set; }
        }

        public class SpecialDepositAccount
        {
            public AccEnum AccountName { get; set; }
            public decimal Balance { get; set; }
            public int MinRequiredMoney { get; set; }
            public int IncomeRatio { get; set; }
            public int AccountNumber { get; set; }
        }

        public class LongDepositAccount
        {
            public AccEnum AccountName { get; set; }
            public decimal Balance { get; set; }
            public int MinRequiredMoney { get; set; }
            public int IncomeRatio { get; set; }
            public int AccountNumber { get; set; }
        }

        public class CheckingAccount
        {
            public AccEnum AccountName { get; set; }
            public decimal Balance { get; set; }
            public int AccountNumber { get; set; }
        }

        public void LoginAccount(BankAccount account, string identityNumber)
        {
            //Hesap no oluşturma
            Random rnd = new Random();
            int randomNo = rnd.Next(10000000, 99999999);

            account.CheckingAccounts = new CheckingAccount();
            account.IdentityNumber = identityNumber;
            account.CheckingAccounts.Balance = 0;
            account.CheckingAccounts.AccountName = AccEnum.Cari;
            account.CheckingAccounts.AccountNumber = randomNo;
            accountList.Add(account.CheckingAccounts.AccountNumber);

            checkingInfoName = account.CheckingAccounts.AccountName;
            checkingInfoNumber = account.CheckingAccounts.AccountNumber;
            checkingInfoBalance = account.CheckingAccounts.Balance;
        }

        public void CreateAccount(BankAccount account, string amount, string startAmount)
        {
            //Hesap no oluşturma
            Random rnd = new Random();
            int randomNo = rnd.Next(10000000, 99999999);

            if (amount == "1")
            {
                account.ShortDepositAccounts = new ShortDepositAccount();
                account.ShortDepositAccounts.AccountName = AccEnum.KisaVadeli;
                account.ShortDepositAccounts.Balance = Int32.Parse(startAmount);
                account.ShortDepositAccounts.IncomeRatio = 15;
                account.ShortDepositAccounts.MinRequiredMoney = 5000;
                account.ShortDepositAccounts.AccountNumber = randomNo;
                account.CheckingAccounts.Balance = account.CheckingAccounts.Balance - Int32.Parse(startAmount);
                accountList.Add(account.ShortDepositAccounts.AccountNumber);

                if (Int32.Parse(startAmount) >= 1000)
                {
                    drawList.Add(account.ShortDepositAccounts.AccountNumber); //Hesabın çekiliş listesine eklenmesi
                }

                shortInfoName = account.ShortDepositAccounts.AccountName;
                shortInfoNumber = account.ShortDepositAccounts.AccountNumber;
                shortInfoBalance = account.ShortDepositAccounts.Balance;
            }
            else if (amount == "2")
            {
                account.LongDepositAccounts = new LongDepositAccount();
                account.LongDepositAccounts.AccountName = AccEnum.UzunVadeli;
                account.LongDepositAccounts.Balance = Int32.Parse(startAmount);
                account.LongDepositAccounts.IncomeRatio = 17;
                account.LongDepositAccounts.MinRequiredMoney = 10000;
                account.LongDepositAccounts.AccountNumber = randomNo;
                account.CheckingAccounts.Balance = account.CheckingAccounts.Balance - Int32.Parse(startAmount);
                accountList.Add(account.LongDepositAccounts.AccountNumber);

                if (Int32.Parse(startAmount) >= 1000)
                {
                    drawList.Add(account.LongDepositAccounts.AccountNumber); //Hesabın çekiliş listesine eklenmesi
                }

                longInfoName = account.LongDepositAccounts.AccountName;
                longInfoNumber = account.LongDepositAccounts.AccountNumber;
                longInfoBalance = account.LongDepositAccounts.Balance;
            }
            else if (amount == "3")
            {
                account.SpecialDepositAccounts = new SpecialDepositAccount();
                account.SpecialDepositAccounts.AccountName = AccEnum.Ozel;
                account.SpecialDepositAccounts.Balance = Int32.Parse(startAmount);
                account.SpecialDepositAccounts.IncomeRatio = 10;
                account.SpecialDepositAccounts.MinRequiredMoney = 0;
                account.SpecialDepositAccounts.AccountNumber = randomNo;
                account.CheckingAccounts.Balance = account.CheckingAccounts.Balance - Int32.Parse(startAmount);
                accountList.Add(account.SpecialDepositAccounts.AccountNumber);

                if (Int32.Parse(startAmount) >= 1000)
                {
                    drawList.Add(account.SpecialDepositAccounts.AccountNumber); //Hesabın çekiliş listesine eklenmesi
                }

                specialInfoName = account.SpecialDepositAccounts.AccountName;
                specialInfoNumber = account.SpecialDepositAccounts.AccountNumber;
                specialInfoBalance = account.SpecialDepositAccounts.Balance;
            }
        }

        public void DepositMoney(BankAccount account, string amount)
        {
            var money = 0;
            int.TryParse(amount, out money);

            if (money >= 1000)
            {
                drawList.Add(account.CheckingAccounts.AccountNumber); //Hesabın çekiliş listesine eklenmesi
            }

            account.CheckingAccounts.Balance += money;
            checkingInfoBalance = account.CheckingAccounts.Balance;

            historyList.Add($"\n{account.CheckingAccounts.AccountNumber} numaralı hesaptan {money} TL tutarında yatırma işlemi yapılmıştır."); //Hesap işlem kaydı
        }

        public void WithdrawMoney(BankAccount account, string amount)
        {
            var money = 0;
            int.TryParse(amount, out money);

            if (money >= 1000)
            {
                drawList.Add(account.CheckingAccounts.AccountNumber); //Hesabın çekiliş listesine eklenmesi
            }

            account.CheckingAccounts.Balance -= money;
            checkingInfoBalance = account.CheckingAccounts.Balance;

            historyList.Add($"\n{account.CheckingAccounts.AccountNumber} numaralı hesaptan {money} TL tutarında çekim işlemi yapılmıştır."); //Hesap işlem kaydı
        }

        public void ShowAccountList()
        {
            foreach (int index in accountList)
            {
                Console.WriteLine(index);
            }
        }

        public void ProfitAmount(BankAccount account, int creditTime)
        {
            //Bakiye 0 olmadığı sürece hesabın kar oranına göre "anapara*faiz oranı*vade (gün)/36500" formülü ile kar tutarı hesaplamasını yapar
            if (shortInfoBalance > 0)
            {
                shortInfoProfit = Convert.ToInt32(account.ShortDepositAccounts.Balance) * account.ShortDepositAccounts.IncomeRatio * creditTime / 36500;
            }
            if (longInfoBalance > 0)
            {
                longInfoProfit = Convert.ToInt32(account.LongDepositAccounts.Balance) * account.LongDepositAccounts.IncomeRatio * creditTime / 36500;
            }
            if (specialInfoBalance > 0)
            {
                specialInfoProfit = Convert.ToInt32(account.SpecialDepositAccounts.Balance) * account.SpecialDepositAccounts.IncomeRatio * creditTime / 36500;
            }
        }

        public void ShowAccountInfo()
        {
            Console.WriteLine($"*** Cari Hesap Bilgileri *** \n Hesap adı: {checkingInfoName} \n Hesap numarası: {checkingInfoNumber} \n Hesap bakiyesi: {checkingInfoBalance} TL");
            Console.WriteLine("\n");
            Console.WriteLine($"*** Kısa Vadeli Hesap Bilgileri *** \n Hesap adı: {shortInfoName} \n Hesap numarası: {shortInfoNumber} \n Hesap bakiyesi: {shortInfoBalance} TL \n Kâr tutarı: {shortInfoProfit} TL");
            Console.WriteLine("\n");
            Console.WriteLine($"*** Uzun Vadeli Hesap Bilgileri *** \n Hesap adı: {longInfoName} \n Hesap numarası: {longInfoNumber} \n Hesap bakiyesi: {longInfoBalance} TL \n Kâr tutarı: {longInfoProfit} TL");
            Console.WriteLine("\n");
            Console.WriteLine($"*** Özel Hesap Bilgileri *** \n Hesap adı: {specialInfoName} \n Hesap numarası: {specialInfoNumber} \n Hesap bakiyesi: {specialInfoBalance} TL \n Kâr tutarı: {specialInfoProfit} TL");
        }

        public void TransactionHistory()
        {
            foreach (string index in historyList)
            {
                Console.WriteLine(index);
            }
        }

        public void MakeDraw()
        {
            int drawListCount = drawList.Count();

            if(drawListCount != 0) 
            {
                Random rnd = new Random();
                int winAccNum = rnd.Next(0, drawListCount);
                var winnerAcc = drawList.ElementAt(winAccNum);

                Console.WriteLine($"\n*** Çekilişimizi kazanan {winnerAcc} numaralı hesabımızı tebrik ederiz. ***");
                historyList.Add($"\nÇekilişi {winnerAcc} numaralı hesap kazanmıştır."); //Hesap işlem kaydı
                drawList.Clear();
            }
            else
            {
                Console.WriteLine("\nSon çekilişin ardından yeni bir çekiliş için yeterli işlem kaydı bulunmamaktadır!");
            }
        }
    }
}