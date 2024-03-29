using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            //TODO S�tt datum till ett startdatum, �rsskifte
        }

        [Fact]
        public void CreateNewAccount_Test()
        {
            bool couldCreateNewAccount = account.NewAccount("Kalle", 18);
            Assert.True(couldCreateNewAccount);

            var exception = Assert.Throws<Exception>(() => account.NewAccount("Pelle", 16));
            Assert.Equal("Underaged! You can't create a bank account", exception.Message);

            int accountNumber = account.GetBankAccountNumber();
            Assert.True(accountNumber > 1000000 && accountNumber < 9999999);
        }

        [Fact]
        public void DepositToAccount_Test()
        {
            double firstDeposit = 300;
            account.DepositCashToAccount(firstDeposit, _mockDate);

            Assert.Equal(firstDeposit, account.GetBalance());

            double secondDeposit = 500;
            account.DepositCashToAccount(secondDeposit, _mockDate);

            Assert.Equal((firstDeposit + secondDeposit), account.GetBalance());

            double negativeDeposit = -300;

            var exception = Assert.Throws<Exception>(() => account.DepositCashToAccount(negativeDeposit, _mockDate));
            Assert.Equal("You can't insert negative deposit", exception.Message);
        

        }

        [Fact]
        public void WithdrawFunds_Test()
        {
            account.DepositCashToAccount(500, _mockDate);
            account.WithdrawFunds(400, _mockDate);

            double balance = account.GetBalance();
            Assert.Equal(100, balance);

            var exception = Assert.Throws<Exception>(() => account.WithdrawFunds(1000, _mockDate));
            Assert.Equal("Not enough funds on your balance, please try different amount", exception.Message);

            bool balanceCanBeZero = account.WithdrawFunds(withdrawal: 100, _mockDate);
            Assert.True(balanceCanBeZero);
        }

        [Fact]

        public void WithdrawBankChanges_Test()
        {
            account.DepositCashToAccount(300, _mockDate);
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
            bool acceptedDepositUpTo15000 = account.DepositCashToAccount(15000, _mockDate);
            Assert.True(acceptedDepositUpTo15000);

            var exception = Assert.Throws<Exception>(() => account.DepositCashToAccount(15001, _mockDate));
            Assert.Equal("Denied, deposit limit for a day is 15 000", exception.Message);

            Account account1 = new Account(new List<Transaction>());
            account1.DepositCashToAccount(8000, _mockDate);

            exception = Assert.Throws<Exception>(() => account1.DepositCashToAccount(8000, _mockDate));
            Assert.Equal("Denied, amount of deposits per day is exceeded", exception.Message);

            //fejka att det g�r en dag och att det d� g�r att s�tta in 8000 nya.
            _mockDate.SetDateTo(DateTime.Today + TimeSpan.FromDays(1));

            bool maxDepositNowSetToZero = account1.DepositCashToAccount(8000, _mockDate);
            Assert.True(maxDepositNowSetToZero);
        }

        [Fact]
        public void SavingsAccount_Test()
        {
            SavingsAccount savingsAccount = new SavingsAccount(new List<Transaction>());

             bool depositTest = savingsAccount.DepositCashToAccount(3000, _mockDate);

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

            //Testar att vi f�r 5 nya uttag vid �rsskiftet
            _mockDate.SetDateTo(DateTime.Today.AddYears(1));
            savingsAccount.WithdrawFunds(500, _mockDate);
            Assert.Equal(498, savingsAccount.GetBalance());
        }

        [Fact]
        public void InvestmentAccount_Tests()
        {
            InvestmentAccount investmentAccount = new InvestmentAccount(new List<Transaction>());

            bool depositTest = investmentAccount.DepositCashToAccount(3000, _mockDate);
            Assert.True(depositTest);
            Assert.Equal(3000, investmentAccount.GetBalance());

            bool canWithdrawFunds = investmentAccount.WithdrawFunds(1000, _mockDate);
            Assert.True(canWithdrawFunds);

            var exception = Assert.Throws<Exception>(() => investmentAccount.WithdrawFunds(1000, _mockDate));
            Assert.Equal("You already exceeded your amount of withdrawals this year", exception.Message);

            _mockDate.SetDateTo(DateTime.Today.AddYears(1));
            investmentAccount.WithdrawFunds(500, _mockDate);
            Assert.Equal(1500, investmentAccount.GetBalance());

            exception = Assert.Throws<Exception>(() => investmentAccount.WithdrawFunds(100, _mockDate));
            Assert.Equal("You already exceeded your amount of withdrawals this year", exception.Message);
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

            bool depositTest = creditAccount.DepositCashToAccount(1000, _mockDate);
            Assert.True(depositTest);
            Assert.Equal(1000, creditAccount.GetBalance());

            bool canWithdrawFunds = creditAccount.WithdrawFunds(2000, _mockDate);
            Assert.True(canWithdrawFunds);

            var exception = Assert.Throws<Exception>(() => creditAccount.WithdrawFunds(19001, _mockDate));
            Assert.Equal("Exceeded credit balance, your credit is 20 000", exception.Message);
        }

        [Fact]
        public void DebitAccount_Tests()
        {
            DebitAccount debitAccount = new DebitAccount(new List<Transaction>());

            debitAccount.DepositCashToAccount(5000, _mockDate);

            while (debitAccount.GetBalance()>0)
            {
                debitAccount.WithdrawFunds(100, _mockDate);
            }
            Assert.Equal(0, debitAccount.GetBalance());

            //simulerar att ins�ttning av l�n sker den 25 okt
            DateTime dayForSalary = new DateTime(2021, 10, 25, 00,00,00);
            _mockDate.SetDateTo(new DateTime(2021, 10, 25));

            if (_mockDate.Today() == dayForSalary)
            {
                debitAccount.TransferFromAccount(25000, _mockDate);
            }
           
            //Testar att det g�r att ta ut 500 kronor till
            Assert.True(debitAccount.WithdrawFunds(500, _mockDate));
            Assert.Equal(24500, debitAccount.GetBalance());
        }
    }
}