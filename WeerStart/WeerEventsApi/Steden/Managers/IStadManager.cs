using WeerEventsApi.Steden.Models;

namespace WeerEventsApi.Steden.Managers;

public interface IStadManager
{
    IEnumerable<Stad> GeefSteden();
}