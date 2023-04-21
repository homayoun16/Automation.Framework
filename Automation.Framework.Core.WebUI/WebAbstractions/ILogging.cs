namespace Automation.Framework.Core.WebUI.WebAbstractions;

public interface ILogging
{
    void Debug(string msg);

    public void Error(string msg);


    public void Warning(string msg);


    public void Information(string msg);

    public void SetLogLevel(string loglevel);

}