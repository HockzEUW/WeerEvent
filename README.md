# :sun_behind_small_cloud: WeerEvent :sun_behind_small_cloud:
![DotNet Badge](https://img.shields.io/badge/.NET_9.0-8A2BE2)

Dit project is opgemaakt in het kader van een examenopdracht waar de focus lag op het ontwerp, met toepassing van volgende elementen: 
    
    Klassen & Objecten

        Overerving

        GRASP

    Design Patterns

        Facade

        Factory

        Decorator

        Observer

        Caching Proxy

    Mini Http Api



WeerEvent is een .NET applicatie die een weersvoorspelling maakt op basis van willekeurig gegenereerde metingen, welke geraadpleegd kunnen worden via zijn API.

# Installatie
Om een kopie van de applicatie te bekomen, kan je gebruiken maken van volgende tools:

SSH
```
git@github.com:HockzEUW/WeerEvent.git
```

HTTPS
```
https://github.com/HockzEUW/WeerEvent.git
```

# Build, Run & Test
Open de solution in Microsoft Visual Studio en start de applicatie (F5) om gebruik te maken van de API.
De terminal zal worden geopend waarna er calls gemaakt kunnen worden in de 'ApiCalls.http' file. 
Om metingen op te vragen, dient eerst de POST call aangeroepen te worden om metingen uit te voeren.

By default zal de applicatie naar console loggen wanneer de POST call is aangeroepen, en afhankelijk van de parameters in de methode `MetingLoggerFactory.Create(bool, bool)` in `program.cs` zal er respectievelijk naar JSON en/of XML gelogd worden.

# Domain Class Diagram
![WeerEventDCD](https://github.com/user-attachments/assets/d5294b0f-718f-43ef-8573-e6a310af452b)


# :warning: Known Issues 
<ins>Lege metingen</ins><br>
Wanneer de POST call om metingen uit te voeren nog niet werd aangeroepen en de metingen opgevraagd worden, krijgt de gebruiker een lege collectie te zien zonder instructies om eerst metingen uit te voeren.


<ins>Corrupte logfiles</ins><br>
Bij het uitvoeren van metingen, kunnen deze gelogd worden naar JSON en XML. Echter worden deze *niet helemaal* volgens de nodige structuur weggeschreven waardoor deze niet met hun standaard software bekeken kunnen worden.
Om de logs te bekijken, **gebruik** je dus best **een tekst editor** zoals kladblok of Notepad++.
