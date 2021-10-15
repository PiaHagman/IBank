# Rapport
## Planering
Vi p�b�rjade planeringen tidigt (4/10) f�r att ha mer tid f�r diskussion och analys kring
vad ska testas i v�ran program och hur kan vi designa det. Vi blev �verens om att f�rst ska vi g�ra 
de issues som ing�r i projektet och sedan g�r de som vi �nskar att implementera och som �r passande till v�ran l�sning.
De issues som var "l�tta" best�mde vi att dela upp och g�ra varsin. De issues som kr�vde mer analys 
och k�ndes "sv�rare" har vi best�mt att l�sa genom parprogrammering f�r att b�da ska kunna
f�rst� och diskutera passande l�sningen. Exempel p� de sv�rare issues �r [issue #13](https://github.com/PiaHagman/csharp-projektarbete/issues/13), 
 [issue #14](https://github.com/PiaHagman/csharp-projektarbete/issues/14) och [issue #15](https://github.com/PiaHagman/csharp-projektarbete/issues/15).
Vi l�mnade det �ppet f�r flera ideer i fall det skulle dyka upp en bra f�rslag p� 
framtida tester som �r bra att ha med i v�rat projekt. Eftersom redan fr�n b�rjan kommunikation mellan oss fungerade
utan problem kunde vi enklet planera tiden f�r sj�lva implementering. Vi best�mde ocks� att om det dyker upp n�got problem med koden kan vi
kontakta varandra f�r att diskutera problemet. 

### Vad kan g�ras b�ttre
I v�rat projekt s� vore det bra att g�ra en issue-mall innan s� alla v�ran issues kunde vara 
utformad i samma stil. Eftersom vi tog reda p� att det g�r att g�ra en mall efter vi har redan planerat alla v�r issues,
  utformade vi n�gra enligt mallen och resten beh�llit i den ursprungliga stilen.

## Implementering 
Eftersom vi redan i planeringsfasen diskuterade vad vi vill testa och vilken l�sning �r passande s� gick implementeringen
utan n�gra st�rre problem. Vi arbetade enligt TDD d�r testfall skrivs f�rst och d�refter skrivs sj�lva koden. Som n�mndes tidigare delade vi 
upp n�gra issues f�r att b�da skulle ha m�jlighet att g�ra varsin och n�gra andra issues l�ste vi tillsammans.
F�r att kunna l�ra oss arbeta med git, best�mde vi att g�ra f�rsta n�gra Pull Requests tillsammans. P� det visset kunde vi b�da l�ra oss och 
g�ra PR r�tt under hela arbetet. 

Vi var �verens om att v�ran l�sningen ska implementeras med hj�lp av arv. Diskussion har lett till att vi best�mde att b�rja med `class Account`
som �r v�r `:base` klassen och som inneh�ller alla de metoder som kan �rvas fr�n andra kontona. Beslutet baserades p� 
att de alla klasser har liknande beteende d�r t.ex. metodena `WithdrawFunds` och `DepositCashToAccount` anv�nds av alla klasser.
I v�ran l�sning implementeras ocks� en `IDate` interface samt `MockDate` och `RealDate` klasser som 
g�r det m�jligt att ha koll p� nuvarande datum och �ndra den vi behov t.ex. n�r �rsskiftet skulle testas.
Detta beslut ans�g vi som l�mpligt eftersom vissa kontona, s� som `SavingsAccount` och `InvestmentAccount`,  hade vilkor som �r baserad p� datum.

F�r att kunna ha koll p� alla transaktioner samt spara de p� n�got s�tt medan programmet k�rs skapades en klass `Transaction`.
I varje konto skapas det en lista `List<Transaction>` f�r att kunna l�gga till alla genomf�rda transaktioner, med hj�lp av vilken kunde vi ha koll
bland annat p� om transaktion �r en ins�ttning eller ett uttag.

Vi har ocks� implementerad en `IBank` interface som ser till att alla metoder ska implementeras vid skapande av framtida klasser som har n�got
med bankkonto att g�ra. I v�ran l�sning �r det bara `Account` klassen som �rver fr�n denna intreface. Vi b�da har h�llit med att det k�nns �verfl�dig
f�r v�ran nuvarande l�sningen, men vi har beslutat att beh�lla den i fall det ska g�ras en vidare utveckling av projektet. 

### Vad kan g�ras b�ttre
- Vi ska ha mer koll p� att g�ra issue-branch varje g�ng vi ska l�sa en issue. Vi r�kade gl�mma att g�ra detta en g�ng 
som resulterade att alla �ndringar pushades direkt till master. 

- Inte gl�mma att ange issue-nummer p� varje commit som �r gjord till den specifika issue. 

- Vi diskuterade att det kan vara l�mplig att implementera i klassen `CreditAccount` n�got slags p�minelse till anv�ndare,
d�r om kreditet har anv�nts ska anv�ndare vara p�mind om att anv�nd krediten borde betalas tillbaks t.ex i slutet av m�nad.

- Vi har ocks� beslutat att det kan vara bra att m�jligg�ra en interaktion med anv�ndare, och ville implementera en ConsoleApp som hanterar denna interaktion.

- Vi diskuterade att det ocks� kan vara bra om programmet sparar alla transaktioner t.ex. till en fil f�r att sedan h�mta en kontohistorik och ha m�jlighet till att s�ka specifika transaktioner, ins�ttningar ellet uttag.

### Egen reflektion
Mest n�jd blev jag med v�rat samarbete. Vi redan i b�rjan kunde best�mma tydlig vad vi vill g�ra och hur vi vill g�ra detta. Arbetet har 
alltid g�tt framm�t och varje beslut var v�l genomt�nkt och diskuterat. B�da tog ansvaret f�r projektet och detta har lett till att processen har g�tt smidigt.
Jag har f�tt m�jlighet att diskutera fritt mina ideer och f�rslag och jag har alltid varit trevligt bem�tt av Pia. 
Kommunikation funkade utm�rkt d� jag alltid kunde skriva till Pia och jag har alltid f�tt svar inom kort. 
Sammanfattningsvis kan jag s�ga att det var j�ttetrevlig och inspirerande samarbete d�r jag fick l�ra mig mycket om git och soft skills
och samdigit kunde jag repetera det jag har l�rt mig hitills.
 Tack Pia! 
