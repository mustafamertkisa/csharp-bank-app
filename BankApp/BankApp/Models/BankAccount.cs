using System;
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

        public AccEnum cariName;

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

            cariName = account.CheckingAccounts.AccountName;
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
            }
        }

        public void DepositMoney(BankAccount account, string amount)
        {
            var money = 0;
            int.TryParse(amount, out money);
            account.CheckingAccounts.Balance += money;
        }

        public void WithdrawMoney(BankAccount account, string amount)
        {
            var money = 0;
            int.TryParse(amount, out money);
            account.CheckingAccounts.Balance -= money;
        }

        public void ShowAccountList()
        {
            foreach (int index in accountList)
            {
                Console.WriteLine(index);
            }
        }

        public void ShowAccountInfo()
        {
            Console.WriteLine(cariName);
        }
    }
}