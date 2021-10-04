using System;
using Logic;
using Xunit;

namespace csharp_projektarbete
{
    public class UnitTest1
    {
        [Fact]
        public void Test_AlwaysReturnTrue()
        {
            Assert.True(true);
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