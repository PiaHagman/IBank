using System;
using System.Reflection;

namespace Logic
{
    public class Account
    {
        private string _name;
        private int _accountnumber;
        private double _balance;
        private double _totalDepositsSumToday = 0;

        public bool NewAccount(string name, int age)
        {
            int MinNumber = 1000000; //TODO borde vi ge MinNumber och MaxNumber någon access modifier?
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

        
        public bool DepositToAccount(double deposit, ITime time)
        {
            if (deposit <= 0 || deposit > 15000)
            {
                return false;
            }

            _balance += deposit;
            _totalDepositsSumToday += deposit;

            if (_totalDepositsSumToday > 15000)
            {
                _totalDepositsSumToday = 0;
                return false;
            }

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
    }
}
