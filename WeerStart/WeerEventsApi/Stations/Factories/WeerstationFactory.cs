using WeerEventsApi.Logging;
using WeerEventsApi.Logging.Observer;
using WeerEventsApi.Stations.Models;
using WeerEventsApi.Steden.Models;

namespace WeerEventsApi.Stations;

public static class WeerstationFactory {
    public static List<Weerstation> CreateWeerstations(IEnumerable<Stad> steden, IMetingLogger logger, IObserver weerbericht) {
        Random rnd = new();
        List<Stad> stedenList = steden.ToList();
        List<Weerstation> weerstations = new();
        const int AantalWeerstations = 12;

        var constructors = new Func<Stad, Weerstation>[]
        {
            s => new LuchtdrukStation(s, logger),
            s => new NeerslagStation(s, logger),
            s => new TemperatuurStation(s, logger),
            s => new WindStation(s, logger)
        };

        for (int i = 0; i < AantalWeerstations; i++) {
            var stad = stedenList[rnd.Next(stedenList.Count)];
            var ctor = constructors[rnd.Next(constructors.Length)];
            var station = ctor(stad);
            station.RegisterObserver((IObserver)logger);
            station.RegisterObserver(weerbericht);
            weerstations.Add(station);
        }

        return weerstations;
    }
}