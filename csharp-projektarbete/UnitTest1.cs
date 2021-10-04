using System;
using Logic;
using Xunit;

namespace csharp_projektarbete
{
    public class UnitTest1
    {
        [Fact]
        public void DepositToAccount_Test()
        {

            Account account = new Account();
            double firstDeposit = 300;

            Assert.Equal(firstDeposit, account.DepositToAccount(firstDeposit));

            double secondDeposit = 500;
            Assert.Equal((firstDeposit + secondDeposit), account.DepositToAccount(secondDeposit));
        }

        [Fact]
        public void CreateNewAccount_Test()
        {
            Account account = new Account();

            bool couldCreateNewAccount = account.NewAccount("Kalle", 18);
            bool couldNotCreateNewAccount= account.NewAccount("Pelle", 16);

            Assert.True(couldCreateNewAccount);
            Assert.False(couldNotCreateNewAccount);

            int accountNumber = account.GetBankAccountNumber();

            Assert.True(accountNumber > 1000000 && accountNumber < 9999999);
        }
    }
}