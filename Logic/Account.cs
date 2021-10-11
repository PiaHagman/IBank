using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Logic
{
    public class Account :IBank
    {
        private string _name;
        private int _accountNumber;
        private readonly List<Transaction> _allTransactions;

        public Account(List<Transaction> allTransactions)
        {
            _allTransactions = allTransactions;
        }
        public bool NewAccount(string name, int age) //TODO Lägg till dounle initialBalance,
                                                     //så behöver vi inte sätta in pengar först varje gång.
                                                     //Vi behöver då kalla på metoden DepositToAccount() så att insättningen verkligen görs.
                                                        
        {
            int MinNumber = 1000000; 
            int MaxNumber = 9999999;

            var rand = new Random();

            if (age < 18)
            {
                return false;
            }

            _name = name;
            _accountNumber = rand.Next(MinNumber, MaxNumber);
            return true;
        }

        
        public bool DepositToAccount(double deposit, IDate date) //TODO Döp om till DepositCashToAccount samt skapa ny metod TransferFromAccount()
        {
            if (deposit <= 0 || deposit > 15000 || MaxDepositsPerDayAreExceeded (deposit, date))
            {
                return false;
            }

            var newDeposit = new Transaction(deposit, date.Today());  
            _allTransactions.Add(newDeposit);
            
            return true;
        }

        public virtual bool WithdrawFunds(double withdrawal, IDate date)
        {
            if ((GetBalance() - withdrawal) < 0)
            {
                return false;
            }

            var newWithdrawel = new Transaction( -withdrawal, date.Today());  //Todo - testa att det blir ett minussaldo som dras från balance
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
            double maxDepositsPerDay = 15000;
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
