using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DebitAccount : Account
    {
        private readonly List<Transaction> _debitAccountTransactions;
        public DebitAccount(List<Transaction> allTransactions) : base(allTransactions)
        {
            _debitAccountTransactions = allTransactions;
        }


    }
}
