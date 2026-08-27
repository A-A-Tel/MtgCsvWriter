# Magic: The Gather CSV-schrijver

Dit programma haalt alle officiële sets op van Scryfall en slaat de relevante data op in een CSV.

## Benodigdheden

.NET 10 
<br>
Werkende internetverbinding
<br>
Toegang tot de Scryfall API

## Bouwen

Ga naar de projectfolder Clone de source code en run:
```shell
dotnet publish
```

Daarna is het uitvoerbaar bestand te vinden in:
```shell
%PROJECT_DIR%/MtgCsWriter/bin/Release/net10.0/%JOUW_SYSTEEM%/publish/MtgCsWriter(.exe)
```
Waarbij PROJECT_DIR de hoofdfolder is van het project en JOUW_SYSTEEM het relevantebestuuringssysteem is.
Op Windows komt er ook .exe achter de naam van het uitvoerbaar bestand.

## Uitvoeren

Nadat je het project hebt gebouwd, kun je het bestand uitvoeren op een manier die jij fijn vindt. Dit kan door er bijvoorbeeld op te dubbelklikken, of met een commando:
```shell
/pad/naar/uitvoerbaar/bestand
```

Na het uitvoeren zie je MTG-(datum).CSV verschijnen in de huidige folder.
