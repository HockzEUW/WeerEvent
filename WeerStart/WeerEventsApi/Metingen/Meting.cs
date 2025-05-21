using WeerEventsApi.Steden.Models;

namespace WeerEventsApi.Metingen;
public class Meting {
    public required DateTime Moment { get; set; }
    public required int Waarde { get; set; }
    public required string Eenheid { get; set;  }
    public required Stad Locatie { get; set; }
}