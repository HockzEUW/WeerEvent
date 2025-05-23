using WeerEventsApi.Logging.Observer;
using WeerEventsApi.Metingen;

public abstract class AbstractObservable {
    private List<IObserver> _observers = new();

    public void RegisterObserver(IObserver observer) {
        _observers.Add(observer);
    }

    protected void NotifyObservers(Meting meting) {
        foreach (var observer in _observers) {
            observer.Update(meting);
        }
    }
}