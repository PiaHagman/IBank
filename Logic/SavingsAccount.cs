using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SavingsAccount : Account
    {
        private List<Transaction> _savingsAccountTransactions;

        public SavingsAccount(List<Transaction> allTransactions) : base(allTransactions)
        {
            _savingsAccountTransactions = allTransactions;
        }
        public override bool WithdrawFunds(double withdrawal, IDate date)
        {
            var bankCharges = 0.01 * withdrawal;

            if ((GetBalance() - withdrawal) < 0)
            {
                return false;
            }

            if (_savingsAccountTransactions.Count > 5)
            {
                WithdrawBankCharges(bankCharges, date);

                var newWithDrawlWithBankCharges = new Transaction(-withdrawal, date.Today());
                _savingsAccountTransactions.Add(newWithDrawlWithBankCharges);

                return true;
            }

            var newWithdrawel = new Transaction(-withdrawal, date.Today());  
            _savingsAccountTransactions.Add(newWithdrawel);


            return true;
        }

        
    }
}
