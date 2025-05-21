using WeerEventsApi.Logging;
using WeerEventsApi.Stations.Models;
using WeerEventsApi.Steden.Models;

namespace WeerEventsApi.Stations;

public static class WeerstationFactory {
    public static List<Weerstation> CreateWeerstations(IEnumerable<Stad> steden, IMetingLogger logger) {
        Random rnd = new();
        List<Stad> stedenList = steden.ToList();
        List<Weerstation> stations = new();
        const int AantalWeerstations = 12;

        var constructors = new Func<Stad, IMetingLogger, Weerstation>[]
        {
            (s, l) => new LuchtdrukStation(s, l),
            (s, l) => new NeerslagStation(s, l),
            (s, l) => new TemperatuurStation(s, l),
            (s, l) => new WindStation(s, l)
        };

        for (int i = 0; i < AantalWeerstations; i++) {
            var stad = stedenList[rnd.Next(stedenList.Count)];
            var ctor = constructors[rnd.Next(constructors.Length)];
            stations.Add(ctor(stad, logger));
        }

        return stations;
    }
}