using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_projektarbete
{
    class Account
    {
        private double Balance;
        public double DepositToAccount(double deposit)
        {
            Balance += deposit;
            return Balance;
        }
    }
}
