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
        public CreditAccount(List<Transaction> allTransactions) : base(allTransactions)
        {
            _creditAccountTransactions = allTransactions;
        }

        public override bool WithdrawFunds(double withdrawal, IDate date)
        {
            return false;
        }
    }
}
