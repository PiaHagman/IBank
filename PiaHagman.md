# Projektarbete C#
*IBank, oktober 2021*<br>
*Pia Hagman och Sofiia L�f*

## Planering
Planeringen av v�rt projekt gick smidigt. Direkt vi blev tilldelande uppgiften och varandra satte vi oss 
ner och b�rjade fila p� v�ra issues i GitHub. Vi var b�da motiverade att komma ig�ng och 
hade f�reberett oss genom att l�sa i Yellow Book. D�rav hade vi
b�de en ganska god initial bild av hur vi ville bygga v�rt program.
V�r plan var att f�rst utveckla ett generell klass `Account.cs`, knutet till en IBank, som har alla de 
grundf�ruts�ttnignar som IBanken kr�ver. Vi t�nkte utfr�n de tester vi skulle beh�va g�ra p� ett s�dant konto
och skapade p� s� s�tt [issue #5 - #12](https://github.com/PiaHagman/csharp-projektarbete/projects/1). 
Dessa issues delade vi upp mellan oss f�r att g�ra var och en. Efter detta planerade vi att utveckla de specifika kontona
[issue #13 - #16](https://github.com/PiaHagman/csharp-projektarbete/projects/1) tillsammans, genom parprogrammering.
Ut�ver ovan lade vi till ett antal tester vi ville g�ra om tid fanns �ver.  

### M�jliga f�rb�ttringar till n�sta projekt
Vi hade redan gjort alla v�ra issues n�r vi gick igenom p� lektionen att det kan vara bra om alla issues ser ut p� samma
s�tt och att man jobbar enligt en specifik mall. Efter lektionen uppdaterade vi n�gra av v�ra issues s� att de 
gick mer i linje med den mall du f�reslog. Men vi valde att inte l�gga allt f�r mycket tid p� detta utan att ist�llet 
ta med oss det som en l�rdom till framtida projekt. <br>
<br>
N�r vi gjorde v�ra tester namngav vi dem med ett nummer. Men eftersom vi intitalt hade gjort n�gra issues som vi sl�ngt,
s� st�mde inte dessa nummer med det #-nummer som den per automatik f�r, och som vi sedan h�nvisar till i v�ra commits.
Detta �r s�klart inte optimalt och �r ganska f�rvirrande. F�r framtida projekt kommer vi inte ha med nummer i 
namnet p� issues.

## Implementering
N�r vi satte oss ner f�r att b�rja programmera hade vi gl�dje av att vi gjort en s�pass bra planering. Vi visste precis vart vi skulle 
b�rja, vilka tester vi skulle l�sa och i vilken ordning.
I b�rjan var det en liten utmaning att veta n�r och hur vi skulle g�ra Pull 
Request, men ganska snart hittade vi ett arbetss�tt som vi f�ljde:

- Skapa lokal branch med namn motvarande aktuell issue
- Comitta vid varje Red, Green, Refactor
- Vid l�st issue g�ra Pull Request till remote master
- Om konflikter, l�sa dessa lokalt och sedan uppdatera PR
- Merga in remote master in i lokal master

F�r att l�ra oss s� mycket som m�jligt om hur det fungerar med GitHub gjorde vi de flesta Pull Requests tillsammans. P� s� s�tt l�ste vi ocks� de flesta konflikter tillsammans om/n�r dessa uppstod. S�klart blev det fel n�gra g�nger. 
Exempelvis gl�mde vi att skapa en branch n�r vi jobbade mot 
[issue #13](https://github.com/PiaHagman/csharp-projektarbete/issues/13), s� denna gjorde vi direkt i master. Vi 
uppt�ckte det halvv�gs igenom och besl�t s� att forts�tta och l�ta det bli en l�rdom f�r framtiden. 

### L�sningar och beslut
M�nga av v�ra l�sningar och beslut grundar sig p� motsvarande l�sningar i Inl�mningsuppgift 2. Det k�ndes 
exempelvis sj�lvklart att implementera en`IDate`, `MockDate`och `RealDate` f�r att kunna resa i tiden och
p� s� s�tt testa v�rt program. Vi valde ocks� att g�ra enligt v�r planering och skapa `Account.cs` som �vriga implementerade
konton �rver fr�n. Det k�ndes mest effektivt eftersom alla kontotyper skulle ha samma grundf�ruts�ttningar. 
<br> <br>
Eftersom vi inte skapade n�gra nya kontotyper som *inte* �rver av `Account.cs` s� fyller IBank i nul�get inte en s� stor funktion. 
Om vi d�remot skulle skapa nya kontotyper, som inte �rver av `Account.cs`, finns IBank d�r som en kravst�llare 
p� vad en kontotyp m�ste inneh�lla f�r att f� vara ett konto. 
 <br> <br>
Ganska tidigt i processen implementerade vi ocks� en ny klass `Transaction.cs` som h�ller koll p� v�ra transaktioner i en lista. 
Detta gjorde vi f�r att p� sikt kunna hantera en kontohistorik med ins�ttningar och uttag och inte bara ha ett saldo att h�mta.
Initialt hade vi en variabel f�r saldo `private double _balance` och en public metod f�r att kunna h�mta saldot `GetBalance()`.
N�r vi skapade `Transaction.cs` s� f�r�ndrade vi i `GetBalance()`och d� k�nde vi att varabeln var �verfl�dig. Med lite distans s� 
kanske den �nd� borde ha funnits kvar f�r att p� s� s�tt ha en *privat* variabel som inte kan �ndras utifr�n. 
 <br> <br>
I v�r `CreditAccount` valde vi att overrida `GetBalance()` s� att den inte kan bli mindre �n noll. Den summa vi �verskrider saldot med
dras ist�llet fr�n kreditsaldot. Detta f�r att krediten inte per automatik ska betalas om n�gon g�r en ins�ttning till kontot.
Detta skulle vi beh�va komplettetera med att finna en metod som kr�ver betalning av krediten en g�ng per m�nad.  
### M�jliga f�rb�ttringar
Det finns s�klart massor av f�rb�ttringar av detta relativt enkla program. B�de saker vi �r medvetna om, och 
saker vi i dagsl�get inte ser p� grund av kunskapsluckor. Vi har exempelvis ett antal framtida implementeringar som
vi inte hunnit med. Vi skulle vilja kunna spara ner kontohistorik till en fil och d�rmed kunna spara och
ladda upp information mellan testerna. Vi skulle ocks� vilja utveckla metoder f�r att kunna plocka ut information fr�n 
kontohistoriken, s�som uttag, ins�ttningar och bankavgifter. I samband med det skulle vi ocks� l�gga till en notering till varje 
transaktion, s� att man ser vad som �r vad. 
 <br> <br>
 Det skulle ocks� vara v�ldigt roligt att koppla en ConsoleApp till detta. En ATM som knyter 
backend-koden till en frontend-funktion.
 <br> <br>
N�r det g�ller samarbetet ser jag dock inget behov av f�rb�ttring. Det har 
fungerat str�lande fr�n b�rjan till slut tycker jag. Vi har b�da varit lika delaktiga, och det k�nns som att vi �r p� ungef�r 
samma niv� kunskapsm�ssigt, varf�r vi b�da bidragit med l�sningar och id�er.

## Sammantagen k�nsla av projektet
Detta har f�r mig varit den hittills mest givande inl�mningsuppgiften. Jag �r v�ldigt n�jd �ver att vi
p� s� pass kort tid lyckats leverera en relativt f�rdig, om �n enkel, l�sning p� en backendl�sning 
f�r en bank. M�jligheten till lite repetition, som byggts p� med nya kunskaper i forma av *arv*, 
har gjort att det k�nts som att vi beh�rskat arbetet fr�n start. Vi har inte k�nt oss helt "lost" 
vilket har varit bra f�r 
sj�lvk�nslan. Detta i kombination med mycket ny erfarenhet av samarbete inom programmering genom
GitHub har gjort att jag k�nner mig mer rustad f�r framtida st�rre utmaningar.   