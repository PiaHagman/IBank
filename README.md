# csharp-projektarbete
En nytt bankföretag, iBank, som bara finns online ska starta upp och de behöver utveckla en backend som sköter kontohanteringen på ett säkert sätt.
Det finns olika sorts bankkonto

Sparkonto som tillåter max 5 uttag om året (fler kan göras men då kostar det 1% av uttaget)
Lönekonto som tillåter obegränsat antal uttag
Kreditkonto som tillåter kredit över en viss gräns
Investeringskonto som tillåter ett uttag om året

Vilka regler gäller för bankkonton rent allmänt?
Man får inte ta ut mer pengar än vad som finns i kontot
Om kredit finns får man inte ta ut mer än krediten
Man får inte sätta ut minusvärden ( alltså sätta in -100:- )
Bankens egna avgifter tas ut även om kontot är på minus
Cash Insättningar på Max 15000 åt gången (annars kan man börja misstänka att det är pengatvätt), inga fler insättningar tillåts den dagen.
Tolka om kraven till en serie tester som ni sen börjar implementera enligt TDD.


Övergripande: skapa interface IBank med 3-4 metoder: 
- withdrawFunds() (testa att det går att ta ut pengar! Testa att det inte går att ta ut mer än saldot/krediten)
- depositToAccount() (testa att det går att sätta in pengar! Testa att det inte går att sätta in "minuspengar")
- getBalance() (testa att det går att få reda på saldot!)
- set bankAccountNumber (testa att alla kontonummer är unika!)
- testa att bankens egna avgifter tas ut även om saldot är på minus
- testa att max-insättning är på 15000 /dag

Fler tester knutna till punkterna i uppgiften. 

Övrigt. Enum, s 85 (ange om kontot är aktivt, fruset osv).
