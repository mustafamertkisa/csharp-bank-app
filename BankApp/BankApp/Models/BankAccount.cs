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

        //Cari
        public CheckingAccount CheckingAccounts { get; set; }

        //Kısa vadeli hesap listesi
        public ShortDepositAccount ShortDepositAccounts { get; set; }

        //Uzun vadeli hesap listesi
        public LongDepositAccount LongDepositAccounts { get; set; }

        //Özel hesap listesi
        public SpecialDepositAccount SpecialDepositAccounts { get; set; }

        public class ShortDepositAccount
        {
            public AccEnum AccountName { get; set; }
            public decimal Balance { get; set; }
            public int MinRequiredMoney { get; set; }
            public int IncomeRatio { get; set; }
        }

        public class SpecialDepositAccount
        {
            public AccEnum AccountName { get; set; }
            public decimal Balance { get; set; }
            public int MinRequiredMoney { get; set; }
            public int IncomeRatio { get; set; }
        }

        public class LongDepositAccount
        {
            public AccEnum AccountName { get; set; }
            public decimal Balance { get; set; }
            public int MinRequiredMoney { get; set; }
            public int IncomeRatio { get; set; }
        }

        public class CheckingAccount
        {
            public AccEnum AccountName { get; set; }
            public decimal Balance { get; set; }
        }

        public void LoginAccount(BankAccount account, string identityNumber)
        {
            account.CheckingAccounts = new CheckingAccount();
            account.IdentityNumber = identityNumber;
            account.CheckingAccounts.Balance = 0;
            account.CheckingAccounts.AccountName = AccEnum.Cari;
        }

        public void CreateAccount(BankAccount account, string amount)
        {
            if (amount == "1")
            {
                account.ShortDepositAccounts = new ShortDepositAccount();
                account.ShortDepositAccounts.AccountName = AccEnum.KisaVadeli;
                account.ShortDepositAccounts.Balance = account.CheckingAccounts.Balance;
                account.ShortDepositAccounts.IncomeRatio = 15;
                account.ShortDepositAccounts.MinRequiredMoney = 5000;
            }
            else if (amount == "2")
            {
                account.LongDepositAccounts = new LongDepositAccount();
                account.LongDepositAccounts.AccountName = AccEnum.UzunVadeli;
                account.LongDepositAccounts.Balance = account.CheckingAccounts.Balance;
                account.LongDepositAccounts.IncomeRatio = 17;
                account.LongDepositAccounts.MinRequiredMoney = 10000;
            }
            else if (amount == "3")
            {
                account.SpecialDepositAccounts = new SpecialDepositAccount();
                account.SpecialDepositAccounts.AccountName = AccEnum.Ozel;
                account.SpecialDepositAccounts.Balance = account.CheckingAccounts.Balance;
                account.SpecialDepositAccounts.IncomeRatio = 10;
                account.SpecialDepositAccounts.MinRequiredMoney = 0;
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
    }
}
