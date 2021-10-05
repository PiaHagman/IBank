﻿using System;
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
            _balance += deposit;
            return true;
        }

        public double WithdrawFunds(double withdrawal)
        {
            _balance -= withdrawal;
            return _balance;
        }

        public int GetBankAccountNumber()
        {
            return _accountnumber;
        }


        public double GetBalance()
        {
            throw new NotImplementedException();
        }
    }
}
