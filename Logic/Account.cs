using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Logic
{
    public class Account :IBank
    {
        private string _name;
        private int _accountNumber;
        private readonly List<Transaction> _allTransactions;
        private const int MAXIMUM_DEPOSIT = 15000;
        

        public Account(List<Transaction> allTransactions)
        {
            _allTransactions = allTransactions;
        }
        public bool NewAccount(string name, int age) //TODO Lägg till dounle initialBalance,
                                                     //så behöver vi inte sätta in pengar först varje gång.
                                                     //Vi behöver då kalla på metoden DepositToAccount() så att insättningen verkligen görs.
                                                        
        {
            int MinNumber = 1000000; //TODO gör till constanta
            int MaxNumber = 9999999;

            var rand = new Random();

            if (age < 18)
            {
                throw new Exception("Underaged! You can't create a bank account");
            }

            _name = name;
            _accountNumber = rand.Next(MinNumber, MaxNumber);
            return true;
        }

        
        public bool DepositCashToAccount(double deposit, IDate date) 
        {
            if (deposit <= 0)
            {
                throw new Exception("You can't insert negative deposit");
               
            } if (deposit > MAXIMUM_DEPOSIT)
            {
                throw new Exception("Denied, deposit limit for a day is 15 000");
            }
            if (MaxDepositsPerDayAreExceeded(deposit, date))
            {
                throw new Exception("Denied, amount of deposits per day is exceeded");
            }

            var newDeposit = new Transaction(deposit, date.Today());  
            _allTransactions.Add(newDeposit);
            
            return true;
        }

        public virtual void TransferFromAccount(double deposit, IDate date)
        {
            var newDeposit = new Transaction(deposit, date.Today());
            _allTransactions.Add(newDeposit);
        }

        public virtual bool WithdrawFunds(double withdrawal, IDate date)
        {
            if ((GetBalance() - withdrawal) < 0)
            {
                throw new Exception("You exceeded your balance");
            }

            var newWithdrawel = new Transaction( -withdrawal, date.Today());  
            _allTransactions.Add(newWithdrawel);
            
            return true;
        }

        public bool WithdrawBankCharges(double bankCharges, IDate date)
        {
            var newBankCharge = new Transaction(-bankCharges, date.Today());
            _allTransactions.Add(newBankCharge);

            return true;
        }

        public bool MaxDepositsPerDayAreExceeded(double deposit, IDate date)
        {
            double maxDepositsPerDay = 15000; //TODO gör till constant
            double totalDepositsToday= 0; 

            foreach (var transaction in _allTransactions)
            {
                if (transaction.Date == date.Today() && transaction.Amount > 0)
                {
                    totalDepositsToday += transaction.Amount;
                }


                if ((totalDepositsToday + deposit) > maxDepositsPerDay)
                {
                    return true;
                }

            }
            return false;
        }


        public int GetBankAccountNumber()
        {
            return _accountNumber;
        }


        public virtual double GetBalance()
        {
            double balance = 0;

            foreach (var transaction in _allTransactions)
            {
                balance += transaction.Amount;
            }
            return balance;

        }

        
    }
}
