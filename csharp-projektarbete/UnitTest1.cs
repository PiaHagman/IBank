using System;
using Logic;
using Xunit;

namespace csharp_projektarbete
{
    public class UnitTest1
    {
        private Account account;
        public UnitTest1()
        {
            account = new Account();
        }

        [Fact]
        public void CreateNewAccount_Test()
        {
            bool couldCreateNewAccount = account.NewAccount("Kalle", 18);
            bool couldNotCreateNewAccount= account.NewAccount("Pelle", 16);

            Assert.True(couldCreateNewAccount);
            Assert.False(couldNotCreateNewAccount);

            int accountNumber = account.GetBankAccountNumber();

            Assert.True(accountNumber > 1000000 && accountNumber < 9999999);
        }

        [Fact]
        public void DepositToAccount_Test()
        {
            double firstDeposit = 300;

            Assert.Equal(firstDeposit, account.DepositToAccount(firstDeposit));

            double secondDeposit = 500;
            Assert.Equal((firstDeposit + secondDeposit), account.DepositToAccount(secondDeposit));
        }

        [Fact]
        public void WithdrawFunds_Test()
        {
            double deposit = account.DepositToAccount(500);
            double withdrawal = 400;

            double balance = account.WithdrawFunds(withdrawal);
            Assert.Equal(100, balance);
        }
    }
}