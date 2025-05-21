namespace WeerEventsApi.Weerberichten.Models;
public class Weerbericht {
    public required DateTime Moment { get; set; }
    public required string Bericht { get; set; }
}