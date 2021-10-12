# Inneh�llsf�rteckning

1. [BankApp](#bankapp)

2. [Features](#features)

3. [Implementerade](#implemented-features)

4. [Framtida](#future-feautures)

5. [Tester](#tests)

6. [F�rslag p� test](#test-example)

# [BankApp](#bankapp)
En nytt bankf�retag, iBank, som bara finns online ska 
starta upp och de beh�ver utveckla en backend som sk�ter 
kontohanteringen p� ett s�kert s�tt. 
Det finns olika sorts [bank](https://en.wikipedia.org/wiki/Bank)konton. 
## [Features](#features)
### [Implementerade](#implemented-features)
>- [X] Interface IBank som st�ller krav p� metoder f�r uttag, ins�ttning och saldoretur
>- [X] Basklass Account
>- [X] Investeringssparkonto som �rver av Account
>- [X] L�nekonto som �rver av Account
>- [X] Kreditkonto som �rver av Account
>- [X] Sparkonto som �rver av Account
>- [X] `class Transaction` som anv�nds av alla konton

### [Framtida](#future-feautures)
- [ ] Implementera en interaktion med anv�ndare genom en ConsoleApp.
- [ ]  Skapa en kontohistorik genom att att spara till fil alla transaktioner mellan testerna
## [Tester](#tests)
V�ra tester �r baserade p� [XUnit](https://xunit.net/) och vi har arbetat enligt 
TDD (Test Driven Development). 

[![TDD-cycle](https://bitbar.com/wp-content/uploads/2020/02/tdd-cycle.png)](https://bitbar.com/blog/reaping-the-benefits-of-tdd-for-mobile-app-testing-development/)

### [F�rslag p� test](#test-example)
    [Fact]
    public void RealDate_Test()
    {
    var realDate = new RealDate();
    Assert.Equal(DateTime.Today, realDate.Today());
    }

    [Heading IDs](#heading-ids)

| Test                                  | Beskrivning       |
| -----------                            | -----------       |
|`CreateNewAccount_Tests()`            | Testar att skapa ett ny konto            |
|`DepositToAccount_Test()`               | Testar att det g�r att s�tta in pengar p� kontot  | 
|`WithdrawFunds_Test()`        | Testar att det g�r att ta ut pengar fr�n kontot |
|`WithdrawBankChanges_Test()`  | Testar att dra bankavgifter