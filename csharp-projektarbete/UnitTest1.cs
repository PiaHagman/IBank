using System;
using Logic;
using Xunit;

namespace csharp_projektarbete
{
    public class UnitTest1
    {
        private Account account;
        private MockDate _mockDate;
        public UnitTest1()
        {
            account = new Account();
            _mockDate = new MockDate();
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
            account.DepositToAccount(firstDeposit, _mockDate);

            Assert.Equal(firstDeposit, account.GetBalance());

            double secondDeposit = 500;
            account.DepositToAccount(secondDeposit, _mockDate);

            Assert.Equal((firstDeposit + secondDeposit), account.GetBalance());

            double negativeDeposit = -300;
            bool canInsertNegativeDeposit = account.DepositToAccount(negativeDeposit, _mockDate);

            Assert.False(canInsertNegativeDeposit);
        }

        [Fact]
        public void WithdrawFunds_Test()
        {
            account.DepositToAccount(500, _mockDate);
            account.WithdrawFunds(400, _mockDate);

            double balance = account.GetBalance();
            Assert.Equal(100, balance);

            bool canExceedBalance = account.WithdrawFunds(1000, _mockDate);
            Assert.False(canExceedBalance);

            bool balanceCanBeZero = account.WithdrawFunds(withdrawal: 100, _mockDate);
            Assert.True(balanceCanBeZero);
        }


        [Fact]

        public void MaxDepositPerDayAndTime_Test()
        {
            bool acceptedDepositUpTo15000 = account.DepositToAccount(15000, _mockDate);
            Assert.True(acceptedDepositUpTo15000);

            bool deniedDepositOver15000 = account.DepositToAccount(15001, _mockDate);
            Assert.False(deniedDepositOver15000);

            Account account1 = new Account();
            account1.DepositToAccount(8000, _mockDate);

            bool exceededMaxDepositForADay = account1.DepositToAccount(8000, _mockDate);
            Assert.False(exceededMaxDepositForADay);

            //fejka att det går en dag och att det då går att sätta in 8000 nya.
          
           _mockDate.SetDateTo(DateTime.Today + TimeSpan.FromDays(1));

            bool maxDepositNowSetToZero = account1.DepositToAccount(8000, _mockDate);
            Assert.True(maxDepositNowSetToZero);

        }
    }
}