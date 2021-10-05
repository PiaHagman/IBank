---
name: Mall för issues i projektarbete
about: Vad ska programmet kunna göra?
title: ''
labels: ''
assignees: ''

---

> Man ska kunna sätta in pengar på ett allkonto,
> men inte för mycket på en gång om man sätter in kontanter

**Skriv en ToDo lista för att lösa problemet**
> - [  ] Testa skapandet av kontot
> - [  ] Testa insättning av kontanter
> - [  ] Testa att insättningar högre än 12500 SEK inte är tillåtet vid ett och samma tillfälle 
> - [  ] Testa att totala insättningar under ett dygn inte får överstiga 12500 SEK 

**API förslag**
> Börja med en Account klass som har metoden InsertCash. Använd en ITime interface för att testa vad som händer inom 24h.
