using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Logic
{
    public class Account
    {
        private string _name;
        private int _accountnumber;
        private List<Transaction> allTransactions = new List<Transaction>();


        public bool NewAccount(string name, int age) //TODO Lägg till dounle initialBalance,
                                                     //så behöver vi inte sätta in pengar först varje gång.
                                                     //Vi behöver då kalla på metoden DepositToAccount() så att insättningen verkligen görs.
                                                        
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

        
        public bool DepositToAccount(double deposit, IDate date)
        {
            if (deposit <= 0 || MaxDepositsPerDayAreExceeded (deposit, date))
            {
                return false;
            }

            var newDeposit = new Transaction(deposit, date);  
            allTransactions.Add(newDeposit);
            
            return true;
        }

        public bool WithdrawFunds(double withdrawal, IDate date)
        {
            if ((GetBalance() - withdrawal) < 0)
            {
                return false;
            }

            var newWithdrawel = new Transaction( -withdrawal, date);  //Vad ska jag göra för att detta ska funka?
            allTransactions.Add(newWithdrawel);
            
            return true;
        }

        public bool MaxDepositsPerDayAreExceeded(double deposit, IDate date)
        {
            double maxDepositsPerDay = 15000;
            double totalDepositsToday= 0;

            foreach (var transaction in allTransactions)
            {
                if (transaction.Date == date && transaction.Amount > 0)
                {
                    totalDepositsToday += transaction.Amount;
                }

                if (totalDepositsToday + deposit > maxDepositsPerDay)
                {
                    return true;
                }

            }
            return false;
        }


        public int GetBankAccountNumber()
        {
            return _accountnumber;
        }


        public double GetBalance()
        {
            double balance = 0;

            foreach (var transaction in allTransactions)
            {
                balance += transaction.Amount;
            }
            return balance;

        }
    }
}
