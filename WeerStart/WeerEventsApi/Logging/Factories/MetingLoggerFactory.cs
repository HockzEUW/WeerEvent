namespace WeerEventsApi.Logging.Factories;

public static class MetingLoggerFactory
{
    public static IMetingLogger Create(bool decorateWithJson = false, bool decorateWithXml = false)
    {
        //Alle combinaties moeten mogelijk zijn (false,false | true,false | false,true | true,true)
        IMetingLogger logger = new MetingLogger();

        if (decorateWithXml)
            logger = new XMLLogger(logger);

        if (decorateWithJson)
            logger = new JSONLogger(logger);

        return logger;
    }
}