using System;
using System.Reflection;

namespace Logic
{
    public class Account
    {
        private string _name;
        private int _age;
        private int _accountnumber;

        public bool NewAccount(string name, int age)
        {
            int MinNumber = 1000000;
            int MaxNumber = 9999999;
            var rand = new Random();

            if (age < 18)
            {
                return false;
            }

            _name = name;
            _accountnumber = rand.Next(MinNumber, MaxNumber);
            return true;
        }

        private double Balance;
        public double DepositToAccount(double deposit)
        {
            Balance += deposit;
            return Balance;
        }

        public double WithdrawFunds(double withdrawal)
        {
            Balance -= withdrawal;
            return Balance;
        }

        public int GetBankAccountNumber()
        {
            return _accountnumber;
        }

        
    }
}
