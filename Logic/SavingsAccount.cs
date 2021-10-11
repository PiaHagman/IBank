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
            double totalWithdrawalsPerYear = 0;
            int dateYear = date.Year();

            if ((GetBalance() - withdrawal) < 0)
            {
                return false;
            }

            foreach (var transaction in _savingsAccountTransactions)
            {
                if (totalWithdrawalsPerYear >=5 && transaction.Date.Year == date.Year())
                {
                    WithdrawBankCharges(bankCharges, date);

                    var newWithDrawlWithBankCharges = new Transaction(-withdrawal, date.Today());
                    _savingsAccountTransactions.Add(newWithDrawlWithBankCharges);

                    return true;
                }

                if (transaction.Date.Year != date.Year())
                {
                    totalWithdrawalsPerYear=0;
                }

                totalWithdrawalsPerYear++;
            }
           
            var newWithdrawel = new Transaction(-withdrawal, date.Today());  
            _savingsAccountTransactions.Add(newWithdrawel);
            
            return true;
        }

        
    }
}
