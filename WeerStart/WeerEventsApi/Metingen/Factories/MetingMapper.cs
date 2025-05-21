using WeerEventsApi.Facade.Dto;

namespace WeerEventsApi.Metingen.Factories; 
public static class MetingMapper {
    public static MetingDto ConvertMetingToMetingDto(Meting meting) {
        return new MetingDto {
            Moment = meting.Moment,
            Waarde = meting.Waarde,
            Eenheid = meting.Eenheid,
            StadNaam = meting.Locatie.Naam
        };
    }
}
