using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
   public  interface IBank
    {
        public bool NewAccount(string name, int age);
        public bool DepositToAccount(double deposit, IDate date);
        public bool WithdrawFunds(double withdrawal, IDate date);
        public bool WithdrawBankCharges(double bankCharges, IDate date);
        public double GetBalance();
    }
}
