# Rapport
## Planering
Vi påbörjade planeringen tidigt (4/10) för att ha mer tid för diskussion och analys kring
vad ska testas i våran program och hur kan vi designa det. Vi blev överens om att först ska vi göra 
de issues som ingår i projektet och sedan gör de som vi önskar att implementera och som är passande till våran lösning.
De issues som var "lätta" bestämde vi att dela upp och göra varsin. De issues som krävde mer analys 
och kändes "svårare" har vi bestämt att lösa genom parprogrammering för att båda ska kunna
förstå och diskutera passande lösningen. Exempel på de svårare issues är [issue #13](https://github.com/PiaHagman/csharp-projektarbete/issues/13), 
 [issue #14](https://github.com/PiaHagman/csharp-projektarbete/issues/14) och [issue #15](https://github.com/PiaHagman/csharp-projektarbete/issues/15).
Vi lämnade det öppet för flera ideer i fall det skulle dyka upp en bra förslag på 
framtida tester som är bra att ha med i vårat projekt. Eftersom redan från början kommunikation mellan oss fungerade
utan problem kunde vi enklet planera tiden för själva implementering. Vi bestämde också att om det dyker upp något problem med koden kan vi
kontakta varandra för att diskutera problemet. 

### Vad kan göras bättre
I vårat projekt så vore det bra att göra en issue-mall innan så alla våran issues kunde vara 
utformad i samma stil. Eftersom vi tog reda på att det går att göra en mall efter vi har redan planerat alla vår issues,
  utformade vi några enligt mallen och resten behållit i den ursprungliga stilen.

## Implementering 
Eftersom vi redan i planeringsfasen diskuterade vad vi vill testa och vilken lösning är passande så gick implementeringen
utan några större problem. Vi arbetade enligt TDD där testfall skrivs först och därefter skrivs själva koden. Som nämndes tidigare delade vi 
upp några issues för att båda skulle ha möjlighet att göra varsin och några andra issues löste vi tillsammans.
För att kunna lära oss arbeta med git, bestämde vi att göra första några Pull Requests tillsammans. På det visset kunde vi båda lära oss och 
göra PR rätt under hela arbetet. 

Vi var överens om att våran lösningen ska implementeras med hjälp av arv. Diskussion har lett till att vi bestämde att börja med `class Account`
som är vår `:base` klassen och som innehåller alla de metoder som kan ärvas från andra kontona. Beslutet baserades på 
att de alla klasser har liknande beteende där t.ex. metodena `WithdrawFunds` och `DepositCashToAccount` används av alla klasser.
I våran lösning implementeras också en `IDate` interface samt `MockDate` och `RealDate` klasser som 
gör det möjligt att ha koll på nuvarande datum och ändra den vi behov t.ex. när årsskiftet skulle testas.
Detta beslut ansåg vi som lämpligt eftersom vissa kontona, så som `SavingsAccount` och `InvestmentAccount`,  hade vilkor som är baserad på datum.

För att kunna ha koll på alla transaktioner samt spara de på något sätt medan programmet körs skapades en klass `Transaction`.
I varje konto skapas det en lista `List<Transaction>` för att kunna lägga till alla genomförda transaktioner, med hjälp av vilken kunde vi ha koll
bland annat på om transaktion är en insättning eller ett uttag.

Vi har också implementerad en `IBank` interface som ser till att alla metoder ska implementeras vid skapande av framtida klasser som har något
med bankkonto att göra. I våran lösning är det bara `Account` klassen som ärver från denna intreface. Vi båda har hållit med att det känns överflödig
för våran nuvarande lösningen, men vi har beslutat att behålla den i fall det ska göras en vidare utveckling av projektet. 

### Vad kan göras bättre
- Vi ska ha mer koll på att göra issue-branch varje gång vi ska lösa en issue. Vi råkade glömma att göra detta en gång 
som resulterade att alla ändringar pushades direkt till master. 

- Inte glömma att ange issue-nummer på varje commit som är gjord till den specifika issue. 

- Vi diskuterade att det kan vara lämplig att implementera i klassen `CreditAccount` något slags påminelse till användare,
där om kreditet har använts ska användare vara påmind om att använd krediten borde betalas tillbaks t.ex i slutet av månad.

- Vi har också beslutat att det kan vara bra att möjliggöra en interaktion med användare, och ville implementera en ConsoleApp som hanterar denna interaktion.

- Vi diskuterade att det också kan vara bra om programmet sparar alla transaktioner t.ex. till en fil för att sedan hämta en kontohistorik och ha möjlighet till att söka specifika transaktioner, insättningar ellet uttag.

### Egen reflektion
Mest nöjd blev jag med vårat samarbete. Vi redan i början kunde bestämma tydlig vad vi vill göra och hur vi vill göra detta. Arbetet har 
alltid gått frammåt och varje beslut var väl genomtänkt och diskuterat. Båda tog ansvaret för projektet och detta har lett till att processen har gått smidigt.
Jag har fått möjlighet att diskutera fritt mina ideer och förslag och jag har alltid varit trevligt bemött av Pia. 
Kommunikation funkade utmärkt då jag alltid kunde skriva till Pia och jag har alltid fått svar inom kort. 
Sammanfattningsvis kan jag säga att det var jättetrevlig och inspirerande samarbete där jag fick lära mig mycket om git och soft skills
och samdigit kunde jag repetera det jag har lärt mig hitills.
 Tack Pia! 
