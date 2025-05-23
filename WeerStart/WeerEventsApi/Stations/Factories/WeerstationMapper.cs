using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Metingen.Factories;
using WeerEventsApi.Stations.Models;

namespace WeerEventsApi.Stations.Factories;
public static class WeerstationMapper {
    public static WeerstationDto ConvertWeerstationToWeerstationDto(Weerstation weerstation) {
        return new WeerstationDto {
            Stad = new StadDto {
                Naam = weerstation.Locatie.Naam,
                Beschrijving = weerstation.Locatie.Beschrijving,
                GekendVoor = weerstation.Locatie.GekendVoor
            },
            Metingen = weerstation.Metingen.Select(m => MetingMapper.ConvertMetingToMetingDto(m))
        };
    }
}
