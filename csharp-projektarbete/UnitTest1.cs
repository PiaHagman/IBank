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

            double negativeDeposit = -300;
            bool canInsertNegativeDeposit = account.DepositToAccount(negativeDeposit);

            Assert.False(canInsertNegativeDeposit);
        }

        [Fact]
        public void WithdrawFunds_Test()
        {
            account.DepositToAccount(500);
            account.WithdrawFunds(400);

            double balance = account.GetBalance();
            Assert.Equal(100, balance);

            bool canExceedBalance = account.WithdrawFunds(1000);
            Assert.False(canExceedBalance);

            bool balanceCanBeZero = account.WithdrawFunds(withdrawal: 100);
            Assert.True(balanceCanBeZero);
        }


        [Fact]

        public void MaxDepositPerDayAndTime_Test()
        {
            bool AcceptedDepositUpTo15000 = account.DepositToAccount(15000);
            Assert.True(AcceptedDepositUpTo15000);

            bool deniedDepositOver15000 = account.DepositToAccount(15001);
            Assert.False(deniedDepositOver15000);
        }
    }
}