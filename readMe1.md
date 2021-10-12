# Innehållsförteckning

1. [BankApp](#bankapp)

2. [Features](#features)

3. [Implementerade](#implemented-features)

4. [Framtida](#future-feautures)

5. [Tester](#tests)

6. [Förslag på test](#test-example)

# [BankApp](#bankapp)
En nytt bankföretag, iBank, som bara finns online ska 
starta upp och de behöver utveckla en backend som sköter 
kontohanteringen på ett säkert sätt. 
Det finns olika sorts [bank](https://en.wikipedia.org/wiki/Bank)konton. 
## [Features](#features)
### [Implementerade](#implemented-features)
>- [X] Interface IBank som ställer krav på metoder för uttag, insättning och saldoretur
>- [X] Basklass Account
>- [X] Investeringssparkonto som ärver av Account
>- [X] Lönekonto som ärver av Account
>- [X] Kreditkonto som ärver av Account
>- [X] Sparkonto som ärver av Account
>- [X] `class Transaction` som används av alla konton

### [Framtida](#future-feautures)
- [ ] Implementera en interaktion med användare genom en ConsoleApp.
- [ ]  Skapa en kontohistorik genom att att spara till fil alla transaktioner mellan testerna
## [Tester](#tests)
Våra tester är baserade på [XUnit](https://xunit.net/) och vi har arbetat enligt 
TDD (Test Driven Development). 

[![TDD-cycle](https://bitbar.com/wp-content/uploads/2020/02/tdd-cycle.png)](https://bitbar.com/blog/reaping-the-benefits-of-tdd-for-mobile-app-testing-development/)

### [Förslag på test](#test-example)
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
|`DepositToAccount_Test()`               | Testar att det går att sätta in pengar på kontot  | 
|`WithdrawFunds_Test()`        | Testar att det går att ta ut pengar från kontot |
|`WithdrawBankChanges_Test()`  | Testar att dra bankavgifter