namespace WeerEventsApi.Facade.Dto;

public class WeerberichtDto
{
    public required DateTime Moment { get; set; }
    public required string Bericht { get; set; }
}