namespace WeerEventsApi.Facade.Dto;

public class WeerstationDto
{
    public required StadDto Stad { get; set; }
    public required IEnumerable<MetingDto> Metingen { get; set; }
}