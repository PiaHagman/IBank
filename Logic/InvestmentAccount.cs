using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class InvestmentAccount : Account
    {
        private readonly List<Transaction> _investmentAccountTransactions;
        public InvestmentAccount(List<Transaction> allTransactions) : base(allTransactions)
        {
            _investmentAccountTransactions = allTransactions;
        }

        public override bool WithdrawFunds(double withdrawal, IDate date)
        {
            double totalWithdrawalsPerYear = 0;

            if ((GetBalance() - withdrawal) < 0)
            {
                return false;
            }

            foreach (var transaction in _investmentAccountTransactions)
            {
                if (totalWithdrawalsPerYear>=1 && transaction.Date.Year == date.Year() && transaction.Amount < 0)
                {
                    return false;
                }

                if (transaction.Date.Year != date.Year())
                {
                    totalWithdrawalsPerYear = 0;
                }

                totalWithdrawalsPerYear++;
            }

            var newWithDrawlWithBankCharges = new Transaction(-withdrawal, date.Today());
            _investmentAccountTransactions.Add(newWithDrawlWithBankCharges);
            return true;
        }
    }
}
