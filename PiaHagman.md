# Projektarbete C#
*IBank, oktober 2021*<br>
*Pia Hagman och Sofiia Löf*

## Planering
Planeringen av vårt projekt gick smidigt. Direkt vi blev tilldelande uppgiften och varandra satte vi oss 
ner och började fila på våra issues i GitHub. Vi var båda motiverade att komma igång och 
hade föreberett oss genom att läsa i Yellow Book. Därav hade vi
både en ganska god initial bild av hur vi ville bygga vårt program.
Vår plan var att först utveckla ett generell klass `Account.cs`, knutet till en IBank, som har alla de 
grundförutsättnignar som IBanken kräver. Vi tänkte utfrån de tester vi skulle behöva göra på ett sådant konto
och skapade på så sätt [issue #5 - #12](https://github.com/PiaHagman/csharp-projektarbete/projects/1). 
Dessa issues delade vi upp mellan oss för att göra var och en. Efter detta planerade vi att utveckla de specifika kontona
[issue #13 - #16](https://github.com/PiaHagman/csharp-projektarbete/projects/1) tillsammans, genom parprogrammering.
Utöver ovan lade vi till ett antal tester vi ville göra om tid fanns över.  

### Möjliga förbättringar till nästa projekt
Vi hade redan gjort alla våra issues när vi gick igenom på lektionen att det kan vara bra om alla issues ser ut på samma
sätt och att man jobbar enligt en specifik mall. Efter lektionen uppdaterade vi några av våra issues så att de 
gick mer i linje med den mall du föreslog. Men vi valde att inte lägga allt för mycket tid på detta utan att istället 
ta med oss det som en lärdom till framtida projekt. <br>
<br>
När vi gjorde våra tester namngav vi dem med ett nummer. Men eftersom vi intitalt hade gjort några issues som vi slängt,
så stämde inte dessa nummer med det #-nummer som den per automatik får, och som vi sedan hänvisar till i våra commits.
Detta är såklart inte optimalt och är ganska förvirrande. För framtida projekt kommer vi inte ha med nummer i 
namnet på issues.

## Implementering
När vi satte oss ner för att börja programmera hade vi glädje av att vi gjort en såpass bra planering. Vi visste precis vart vi skulle 
börja, vilka tester vi skulle lösa och i vilken ordning.
I början var det en liten utmaning att veta när och hur vi skulle göra Pull 
Request, men ganska snart hittade vi ett arbetssätt som vi följde:

- Skapa lokal branch med namn motvarande aktuell issue
- Comitta vid varje Red, Green, Refactor
- Vid löst issue göra Pull Request till remote master
- Om konflikter, lösa dessa lokalt och sedan uppdatera PR
- Merga in remote master in i lokal master

För att lära oss så mycket som möjligt om hur det fungerar med GitHub gjorde vi de flesta Pull Requests tillsammans. På så sätt löste vi också de flesta konflikter tillsammans om/när dessa uppstod. Såklart blev det fel några gånger. 
Exempelvis glömde vi att skapa en branch när vi jobbade mot 
[issue #13](https://github.com/PiaHagman/csharp-projektarbete/issues/13), så denna gjorde vi direkt i master. Vi 
upptäckte det halvvägs igenom och beslöt så att fortsätta och låta det bli en lärdom för framtiden. 

### Lösningar och beslut
Många av våra lösningar och beslut grundar sig på motsvarande lösningar i Inlämningsuppgift 2. Det kändes 
exempelvis självklart att implementera en`IDate`, `MockDate`och `RealDate` för att kunna resa i tiden och
på så sätt testa vårt program. Vi valde också att göra enligt vår planering och skapa `Account.cs` som övriga implementerade
konton ärver från. Det kändes mest effektivt eftersom alla kontotyper skulle ha samma grundförutsättningar. 
<br> <br>
Eftersom vi inte skapade några nya kontotyper som *inte* ärver av `Account.cs` så fyller IBank i nuläget inte en så stor funktion. 
Om vi däremot skulle skapa nya kontotyper, som inte ärver av `Account.cs`, finns IBank där som en kravställare 
på vad en kontotyp måste innehålla för att få vara ett konto. 
 <br> <br>
Ganska tidigt i processen implementerade vi också en ny klass `Transaction.cs` som håller koll på våra transaktioner i en lista. 
Detta gjorde vi för att på sikt kunna hantera en kontohistorik med insättningar och uttag och inte bara ha ett saldo att hämta.
Initialt hade vi en variabel för saldo `private double _balance` och en public metod för att kunna hämta saldot `GetBalance()`.
När vi skapade `Transaction.cs` så förändrade vi i `GetBalance()`och då kände vi att varabeln var överflödig. Med lite distans så 
kanske den ändå borde ha funnits kvar för att på så sätt ha en *privat* variabel som inte kan ändras utifrån. 
 <br> <br>
I vår `CreditAccount` valde vi att overrida `GetBalance()` så att den inte kan bli mindre än noll. Den summa vi överskrider saldot med
dras istället från kreditsaldot. Detta för att krediten inte per automatik ska betalas om någon gör en insättning till kontot.
Detta skulle vi behöva komplettetera med att finna en metod som kräver betalning av krediten en gång per månad.  
### Möjliga förbättringar
Det finns såklart massor av förbättringar av detta relativt enkla program. Både saker vi är medvetna om, och 
saker vi i dagsläget inte ser på grund av kunskapsluckor. Vi har exempelvis ett antal framtida implementeringar som
vi inte hunnit med. Vi skulle vilja kunna spara ner kontohistorik till en fil och därmed kunna spara och
ladda upp information mellan testerna. Vi skulle också vilja utveckla metoder för att kunna plocka ut information från 
kontohistoriken, såsom uttag, insättningar och bankavgifter. I samband med det skulle vi också lägga till en notering till varje 
transaktion, så att man ser vad som är vad. 
 <br> <br>
 Det skulle också vara väldigt roligt att koppla en ConsoleApp till detta. En ATM som knyter 
backend-koden till en frontend-funktion.
 <br> <br>
När det gäller samarbetet ser jag dock inget behov av förbättring. Det har 
fungerat strålande från början till slut tycker jag. Vi har båda varit lika delaktiga, och det känns som att vi är på ungefär 
samma nivå kunskapsmässigt, varför vi båda bidragit med lösningar och idéer.

## Sammantagen känsla av projektet
Detta har för mig varit den hittills mest givande inlämningsuppgiften. Jag är väldigt nöjd över att vi
på så pass kort tid lyckats leverera en relativt färdig, om än enkel, lösning på en backendlösning 
för en bank. Möjligheten till lite repetition, som byggts på med nya kunskaper i forma av *arv*, 
har gjort att det känts som att vi behärskat arbetet från start. Vi har inte känt oss helt "lost" 
vilket har varit bra för 
självkänslan. Detta i kombination med mycket ny erfarenhet av samarbete inom programmering genom
GitHub har gjort att jag känner mig mer rustad för framtida större utmaningar.   