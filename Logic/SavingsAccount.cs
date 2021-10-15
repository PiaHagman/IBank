using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SavingsAccount : Account
    {
        private readonly List<Transaction> _savingsAccountTransactions;
        private const int ALLOWED_WITHDRAWALS_PER_YEAR = 5;
        public SavingsAccount(List<Transaction> allTransactions) : base(allTransactions)
        {
            _savingsAccountTransactions = allTransactions;
        }
        public override bool WithdrawFunds(double withdrawal, IDate date)
        {
            var bankCharges = 0.01 * withdrawal;
            double totalWithdrawalsPerYear = 0;

            if ((GetBalance() - withdrawal) < 0)
            {
                throw new Exception("You exceeded your balance");
            }

            foreach (var transaction in _savingsAccountTransactions)
            {
                if (totalWithdrawalsPerYear >= ALLOWED_WITHDRAWALS_PER_YEAR && transaction.Date.Year == date.Today().Year && transaction.Amount<0)
                {
                    WithdrawBankCharges(bankCharges, date);

                    var newWithDrawlWithBankCharges = new Transaction(-withdrawal, date.Today());
                    _savingsAccountTransactions.Add(newWithDrawlWithBankCharges);

                    return true;
                }

                if (transaction.Date.Year != date.Today().Year)
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
