using WeerEventsApi.Metingen;
using WeerEventsApi.Logging;
using WeerEventsApi.Steden.Models;

namespace WeerEventsApi.Stations.Models;

public abstract class Weerstation(Stad locatie, IMetingLogger logger, int min, int max, string eenheid) {
    public Stad Locatie { get; } = locatie;
    internal IMetingLogger Logger { get; } = logger;
    internal List<Meting> Metingen { get; } = new();
    internal int Min { get; } = min;
    internal int Max { get; } = max;
    internal string Eenheid { get; } = eenheid;
}

public class LuchtdrukStation(Stad locatie, IMetingLogger logger) 
    : Weerstation(locatie, logger, 940, 1060, "hPa") {
}

public class NeerslagStation(Stad locatie, IMetingLogger logger) 
    : Weerstation(locatie, logger, 0, 50, "mm/h") {
}

public class TemperatuurStation(Stad locatie, IMetingLogger logger) 
    : Weerstation(locatie, logger, -5, 40, "°C") {
}

public class WindStation(Stad locatie, IMetingLogger logger) 
    : Weerstation(locatie, logger, 0, 120, "km/h") {
}