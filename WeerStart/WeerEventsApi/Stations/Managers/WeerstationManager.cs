using WeerEventsApi.Logging;
using WeerEventsApi.Metingen;
using WeerEventsApi.Stations.Models;

namespace WeerEventsApi.Stations.Managers; 
public class WeerstationManager : IWeerstationManager {
    private readonly List<Weerstation> _weerstations;
    private readonly IMetingLogger _logger;

    public WeerstationManager(List<Weerstation> weerstations, IMetingLogger logger) {
        _weerstations = weerstations;
    }

    public List<Meting> GeefMetingen() =>
        _weerstations.SelectMany(ws => ws.Metingen).ToList();

    public void VoerMetingUit() {
        foreach (var ws in _weerstations) {
            var meting = GenereerMeting(ws);
            ws.VoegMetingToe(meting);
        }
    }

    public Meting GenereerMeting(Weerstation ws) {
        DateTime moment = DateTime.Now;
        Random rnd = new();
        int waarde = rnd.Next(ws.Min, ws.Max + 1);
        return new Meting {
            Moment = moment,
            Waarde = waarde,
            Eenheid = ws.Eenheid,
            Locatie = ws.Locatie
        };
    }

    public List<Weerstation> GeefWeerstations() => _weerstations;
}