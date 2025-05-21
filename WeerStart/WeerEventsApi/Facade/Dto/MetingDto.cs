namespace WeerEventsApi.Facade.Dto;

public class MetingDto
{
    public required DateTime Moment { get; set; }
    public required int Waarde { get; set; }
    public required string Eenheid { get; set; }
    public required string StadNaam { get; set; }
}