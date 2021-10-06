using System;
using System.Reflection;

namespace Logic
{
    public class Account
    {
        private string _name;
        private int _age;
        private int _accountnumber;
        private double _balance;

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

        
        public bool DepositToAccount(double deposit)
        {
            if (deposit <= 0)
            {
                return false;
            }

            _balance += deposit;
            return true;
        }

        public bool WithdrawFunds(double withdrawal)
        {
            if ((_balance - withdrawal) < 0)
            {
                return false;
            }
            
            _balance -= withdrawal;
            return true;
        }

        public int GetBankAccountNumber()
        {
            return _accountnumber;
        }


        public double GetBalance()
        {
            return _balance;
        }

        public bool WithdrawBankCharges(double bankCharges)
        {
            _balance -= bankCharges;

            return true;
        }
    }
}
