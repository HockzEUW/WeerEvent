using WeerEventsApi.Metingen;

namespace WeerEventsApi.Logging.Observer;

public interface IObserver {
    void Update(Meting meting);
}