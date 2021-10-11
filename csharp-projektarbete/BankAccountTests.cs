using System;
using System.Collections.Generic;
using Logic;
using Xunit;

namespace csharp_projektarbete
{
    public class BankAccountTests
    {
        private Account account;
        private MockDate _mockDate;
       
        public BankAccountTests()
        {
            account = new Account(new List<Transaction>());
            _mockDate = new MockDate();
            //TODO Sätt datum till ett startdatum, årsskifte
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

        public void WithdrawBankChanges_Test()
        {
            account.DepositToAccount(300, _mockDate);
            var bankCharges = 300;
            bool canWithdrawBankCharges = account.WithdrawBankCharges(bankCharges, _mockDate);

            Assert.True(canWithdrawBankCharges);

            account.WithdrawBankCharges(bankCharges, _mockDate);
            Assert.True(canWithdrawBankCharges);

            Assert.Equal(-300, account.GetBalance());
        }

        [Fact]

        public void MaxDepositPerDayAndTime_Test()
        {
            bool acceptedDepositUpTo15000 = account.DepositToAccount(15000, _mockDate);
            Assert.True(acceptedDepositUpTo15000);

            bool deniedDepositOver15000 = account.DepositToAccount(15001, _mockDate);
            Assert.False(deniedDepositOver15000);

            Account account1 = new Account(new List<Transaction>());
            account1.DepositToAccount(8000, _mockDate);

            bool exceededMaxDepositForADay = account1.DepositToAccount(8000, _mockDate);
            Assert.False(exceededMaxDepositForADay);

            //fejka att det går en dag och att det då går att sätta in 8000 nya.
            _mockDate.SetDateTo(DateTime.Today + TimeSpan.FromDays(1));

            bool maxDepositNowSetToZero = account1.DepositToAccount(8000, _mockDate);
            Assert.True(maxDepositNowSetToZero);
        }

        [Fact]
        public void SavingsAccount_Test()
        {
            SavingsAccount savingsAccount = new SavingsAccount(new List<Transaction>());

             bool depositTest = savingsAccount.DepositToAccount(3000, _mockDate);

             Assert.True(depositTest);
             Assert.Equal(3000, savingsAccount.GetBalance());

             savingsAccount.WithdrawFunds(500, _mockDate);
             savingsAccount.WithdrawFunds(300, _mockDate);
             savingsAccount.WithdrawFunds(200, _mockDate);
             savingsAccount.WithdrawFunds(300, _mockDate);
             savingsAccount.WithdrawFunds(500, _mockDate);
             savingsAccount.WithdrawFunds(200, _mockDate);
            
             //Testar att 6:e uttag debiteras med 1% charges
             Assert.Equal(998, savingsAccount.GetBalance());

            //Testar att vi får 5 nya uttag vid årsskiftet
            _mockDate.SetDateTo(DateTime.Today.AddYears(1));
            savingsAccount.WithdrawFunds(500, _mockDate);
            Assert.Equal(498, savingsAccount.GetBalance());
        }

        [Fact]
        public void InvestmentAccount_Tests()
        {
            InvestmentAccount investmentAccount = new InvestmentAccount(new List<Transaction>());

            bool depositTest = investmentAccount.DepositToAccount(3000, _mockDate);
            Assert.True(depositTest);
            Assert.Equal(3000, investmentAccount.GetBalance());

            bool canWithdrawFunds = investmentAccount.WithdrawFunds(1000, _mockDate);
            Assert.True(canWithdrawFunds);

            bool cantWithdrawFunds = investmentAccount.WithdrawFunds(1000, _mockDate);
            Assert.False(cantWithdrawFunds);

            _mockDate.SetDateTo(DateTime.Today.AddYears(1));
            investmentAccount.WithdrawFunds(500, _mockDate);
            Assert.Equal(1500, investmentAccount.GetBalance());

            bool cantWithdrawFundsAnotherYear = investmentAccount.WithdrawFunds(100, _mockDate);
            Assert.False(cantWithdrawFundsAnotherYear);
        }

        [Fact]
        public void RealDate_Test()
        {
            var realDate = new RealDate();

            Assert.Equal(DateTime.Today, realDate.Today());
        }

        [Fact]
        public void CreditAccount_Tests()
        {
            CreditAccount creditAccount = new CreditAccount(new List<Transaction>());

            bool depositTest = creditAccount.DepositToAccount(1000, _mockDate);
            Assert.True(depositTest);
            Assert.Equal(1000, creditAccount.GetBalance());

            bool canWithdrawFunds = creditAccount.WithdrawFunds(2000, _mockDate);
            Assert.True(canWithdrawFunds);

            bool canWithdrawCreditFunds = creditAccount.WithdrawFunds(19001, _mockDate);
            Assert.False(canWithdrawCreditFunds);
        }

        [Fact]
        public void DebitAccount_Tests()
        {
            DebitAccount debitAccount = new DebitAccount(new List<Transaction>());

            debitAccount.DepositToAccount(5000, _mockDate);

            while (debitAccount.GetBalance()>0)
            {
                debitAccount.WithdrawFunds(100, _mockDate);
            }
            Assert.Equal(0, debitAccount.GetBalance());
        }
    }
}