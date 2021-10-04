using System;
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

        }
    }
}
