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
            account.DepositToAccount(firstDeposit);
            Assert.Equal(firstDeposit, account.GetBalance());

            double secondDeposit = 500;
            account.DepositToAccount(secondDeposit);
            Assert.Equal((firstDeposit + secondDeposit), account.GetBalance());

            double negativDeposit = -300;
            bool canInsertNegativDeposit = account.DepositToAccount(negativDeposit);

            Assert.False(canInsertNegativDeposit);
        }

        [Fact]
        public void WithdrawFunds_Test()
        {
            bool deposit = account.DepositToAccount(500);
            double withdrawal = 400;

            double balance = account.WithdrawFunds(withdrawal);
            Assert.Equal(100, balance);
        }
    }
}