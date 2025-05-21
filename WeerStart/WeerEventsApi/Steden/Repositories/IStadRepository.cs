using WeerEventsApi.Steden.Models;

namespace WeerEventsApi.Steden.Repositories;

public interface IStadRepository
{
    IEnumerable<Stad> GetSteden();
}