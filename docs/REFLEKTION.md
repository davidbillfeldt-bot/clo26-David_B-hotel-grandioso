# Reflektion — Hotel Grandioso

## Vad jag har byggt
Jag har byggt ett program som hanterar bokningar och avbokningar och kan visa vilka rum Hotel Grandioso har att erbjuda.

## Vad som gick bra
Lättast kändes UML-diagrammet, samt början av konsolmenyn eftersom vi gjort en liknande meny tidigare.

## Vad som var svårt
Jag tyckte det var lite svårt att veta när jag skulle använda List<> och när jag skulle använda ett enskilt objekt. Jag bad AI förklara som om jag vore fem år gammal, och då förstod jag konceptet bättre. Jag förstod då att "ett"-sidan får en lista och "många"-sidan får ett objekt + id.

## Vad jag har lärt mig
Under arbetet har jag lärt mig hur Code First fungerar, där jag börjat med att skriva klasserna och låter dem skapa databasen. Jag har också använt migrationer som en ritning över tabellerna för att bygga upp databasen, och jag har lagt till seed-data så att rummen skapas automatiskt. Jag har strukturerat koden med ett Repository för att samla all databashantering på ett enda ställe som menyn kommunicerar med. Jag har också sett till att totalpriset räknas ut utifrån vilka datum och vilket rum som angavs, så att det alltid stämmer.

## Vad jag hade gjort annorlunda
Hade velat gå för VG-delen också men kände att det var bättre att ta det mer långsamt och förstå G-delen grundligt istället för att stressa igenom för att hinna VG-delen också.
