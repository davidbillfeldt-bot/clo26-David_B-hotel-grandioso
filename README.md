# Hotel Grandioso — Inlämning 1

**Namn:** [ditt namn]

## Så kör du projektet

1. Forka repot på GitHub och klona din fork
2. Öppna `HotelGrandioso.slnx` i Visual Studio (eller öppna mappen i VS Code)
3. Tryck **F5** för att starta

Via terminalen:

```bash
dotnet run --project HotelGrandioso
```

## Databas

- Databas: [SQLite eller LocalDB]
- Migrationer: [hur du skapar och kör dem]

## UML-klassdiagram

```mermaid
classDiagram
    %% Ersätt med ditt eget klassdiagram
```

## GDPR

Utvärdera fälten i `Guest` ett i taget. Vad bygger du in, och varför?

- Id: Nyckel som databasen behöver och säger inget om personen.
- Name: Namn i bokningssyfte.
- Email: Lade till email då det kan vara bra att ha i bokningssyfte och få bekräftelse.
- HairColor: Behövs ej då det saknar syfte är även Dataminimering
- HeightCm: Behövs ej då det saknar syfte (om inte gästen är längre än sängarna kanske) även Dataminimering
- Religion: Syfte saknas definitivt och är känsliga personuppgifter enligt GDPR artikel 9.

## Designmönster

Beskriv det designmönster du använt (till exempel Repository), vad det gör och varför du valde det.

>

## Tekniker

- C# / .NET 10
- Entity Framework Core
