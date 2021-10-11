using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
   public class CreditAccount : Account
    {
        private readonly List<Transaction> _creditAccountTransactions;
        private double _creditBalance= 20000;

        public CreditAccount(List<Transaction> allTransactions) : base(allTransactions)
        {
            _creditAccountTransactions = allTransactions;
        }

        public override bool WithdrawFunds(double withdrawal, IDate date)
        {
            double currentBalance = GetBalance();

            if (currentBalance < withdrawal)
            {
               _creditBalance -= (withdrawal - currentBalance);

               if (_creditBalance < 0)
               {
                   return false;
               }
            }
            
            var newWithDrawlWithBankCharges = new Transaction(-withdrawal, date.Today());
            _creditAccountTransactions.Add(newWithDrawlWithBankCharges);

            return true;
        }

        public override double GetBalance()
        {
            double balance = 0;

            foreach (var transaction in _creditAccountTransactions)
            {
                balance += transaction.Amount;
            }

            if (balance < 0)
            {
                balance = 0;
            }
            return balance;
        }
    }
}
