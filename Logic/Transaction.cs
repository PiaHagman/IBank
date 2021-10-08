using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Transaction
    {
        public double Amount { get; }
        public DateTime Date { get; }

        public Transaction(double amount, DateTime date)
        {
            Amount = amount;
            Date = date;
        }
    }
}
