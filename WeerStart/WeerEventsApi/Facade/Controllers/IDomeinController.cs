using WeerEventsApi.Facade.Dto;

namespace WeerEventsApi.Facade.Controllers;

public interface IDomeinController
{
    IEnumerable<StadDto> GeefSteden();
    
    IEnumerable<WeerstationDto> GeefWeerstations();

    IEnumerable<MetingDto> GeefMetingen();
    
    void DoeMetingen();
    
    WeerberichtDto GeefWeerbericht();
}