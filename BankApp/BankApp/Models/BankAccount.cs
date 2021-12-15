using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class BankAccount
    {
        public string IdentityNumber { get; set; }

        //Cari
        public CheckingAccount CheckingAccounts { get; set; }

        //Kısa vadeli hesap listesi
        public List<ShortDepositAccount> ShortDepositAccounts { get; set; }

        //Uzun vadeli hesap listesi
        public List<LongDepositAccount> LongDepositAccounts { get; set; }

        //Özel hesap listesi
        public List<SpecialDepositAccount> SpecialDepositAccounts { get; set; }

        public class ShortDepositAccount
        {
            public string AccountName { get; set; }
            public decimal Balance { get; set; }
            public int MinRequiredMoney { get; set; } = 5000;
            public int IncomeRatio { get; set; } = 15;
        }

        public class SpecialDepositAccount
        {
            public string AccountName { get; set; }
            public decimal Balance { get; set; }
            public int MinRequiredMoney { get; set; } = 5000;
            public int IncomeRatio { get; set; } = 15;
        }

        public class LongDepositAccount
        {
            public string AccountName { get; set; }
            public decimal Balance { get; set; }
            public int MinRequiredMoney { get; set; } = 10000;
            public int IncomeRatio { get; set; } = 17;
        }

        public class CheckingAccount
        {
            public string AccountName { get; set; }
            public decimal Balance { get; set; }
        }

        public void LoginAccount(BankAccount account, string identityNumber)
        {
            account.CheckingAccounts = new CheckingAccount();
            account.IdentityNumber = identityNumber;
            account.CheckingAccounts.Balance = 0;
            account.CheckingAccounts.AccountName = "Vadesiz Hesabım";
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
