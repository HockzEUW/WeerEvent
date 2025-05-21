using Microsoft.Extensions.WebEncoders.Testing;
using System.Text.Json;
using System.Xml.Linq;
using WeerEventsApi.Metingen;

namespace WeerEventsApi.Logging;

public class MetingLogger : IMetingLogger
{
    public virtual void LogInXml(Meting meting)
    {
        // Default: niets loggen
    }

    public virtual void LogInJson(Meting meting)
    {
        // Default: niets loggen
    }
}

// Decorator XML logging
public class XMLLogger : IMetingLogger
{
    private readonly IMetingLogger _inner;

    public XMLLogger(IMetingLogger inner)
    {
        _inner = inner;
    }

    public void LogInXml(Meting meting)
    {
        var xml = new XElement("Meting",
            new XElement("Moment", meting.Moment.ToString("G")),
            new XElement("Waarde", meting.Waarde),
            new XElement("Eenheid", meting.Eenheid)
        );
        File.AppendAllText("log.xml", xml + Environment.NewLine);

        _inner.LogInXml(meting);
    }

    public void LogInJson(Meting meting)
    {
        _inner.LogInJson(meting);
    }
}

// Decorator JSON logging
public class JSONLogger : IMetingLogger
{
    private readonly IMetingLogger _inner;

    public JSONLogger(IMetingLogger inner)
    {
        _inner = inner;
    }

    public void LogInXml(Meting meting)
    {
        _inner.LogInXml(meting);
    }

    public void LogInJson(Meting meting)
    {
        var options = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptTestEncoder.UnsafeRelaxedJsonEscaping }; //eerste property => mooie layout json | tweede property => graden celcius symbool printen (anders krijg je een unicode)
        var json = JsonSerializer.Serialize(new
        {
            Moment = meting.Moment,
            Eenheid = meting.Eenheid,
            Waarde = meting.Waarde,
            Locatie = new
            {
                meting.Locatie.Naam,
                meting.Locatie.Beschrijving,
                meting.Locatie.GekendVoor
            }
        }, options);
        File.AppendAllText("log.json", json + Environment.NewLine);
        _inner.LogInJson(meting);
    }
}