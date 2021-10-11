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
            return true;
        }
    }
}
