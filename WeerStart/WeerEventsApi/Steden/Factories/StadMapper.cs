using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Steden.Models;

namespace WeerEventsApi.Steden.Factories; 
public static class StadMapper {
    public static StadDto ConvertStadToStadDto(Stad stad) {
        return new StadDto {
            Naam = stad.Naam,
            Beschrijving = stad.Beschrijving,
            GekendVoor = stad.GekendVoor
        };
    }

    public static Stad ConvertStadDtoToStad(StadDto stadDto) {
        return new Stad {
            Naam = stadDto.Naam,
            Beschrijving = stadDto.Beschrijving,
            GekendVoor = stadDto.GekendVoor
        };
    }
}
