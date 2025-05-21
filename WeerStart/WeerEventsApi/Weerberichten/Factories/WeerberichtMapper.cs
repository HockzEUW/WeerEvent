using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Weerberichten.Models;

namespace WeerEventsApi.Weerberichten.Factories;
public static class WeerberichtMapper {
    public static WeerberichtDto ConvertWeerberichtToWeerberichtDto(Weerbericht weerbericht) {
        return new WeerberichtDto {
            Moment = weerbericht.Moment,
            Bericht = weerbericht.Bericht
        };
    }
    public static Weerbericht ConvertWeerberichtDtoToWeerbericht(WeerberichtDto weerberichtDto) {
        return new Weerbericht {
            Moment = weerberichtDto.Moment,
            Bericht = weerberichtDto.Bericht
        };
    }
}