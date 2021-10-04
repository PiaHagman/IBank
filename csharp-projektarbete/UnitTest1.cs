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
        public void createNewAccount_Test()
        {
            Account account = new Account();

            bool couldCreateNewAccount = account.NewAccount("Kalle", 18);

            Assert.True(couldCreateNewAccount);
        }
    }
}