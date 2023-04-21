using Automation.Framework.Core.WebUI.Params;
using Automation.Framework.Core.WebUI.WebAbstractions;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Automation.Framework.Core.WebUI.Reporting;

public class Logging: ILogging
{
    private LoggingLevelSwitch _loggingLevelSwitch;
    private IDefaultVariables _idefaultVariables;

    public Logging(IDefaultVariables idefaultVariables)
    {
        //DefaultVariables defaultVariables = new DefaultVariables();
        _idefaultVariables = idefaultVariables;
        _loggingLevelSwitch = new LoggingLevelSwitch(LogEventLevel.Debug);
        Log.Logger = new LoggerConfiguration().MinimumLevel.ControlledBy(_loggingLevelSwitch)
            .WriteTo.File(_idefaultVariables.Log,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .Enrich.WithThreadId().CreateLogger();

    }

    public void SetLogLevel(string loglevel)
    {
        switch (loglevel.ToLower())
        {
            case "debug":
                _loggingLevelSwitch.MinimumLevel = LogEventLevel.Debug;
                break;
            
            case "error":
                _loggingLevelSwitch.MinimumLevel = LogEventLevel.Error;
                
                break;
            
            case "warning":
                _loggingLevelSwitch.MinimumLevel = LogEventLevel.Warning;
                break;
            
            case "information":
                _loggingLevelSwitch.MinimumLevel = LogEventLevel.Information;
                break;
            
            case "fata":
                _loggingLevelSwitch.MinimumLevel = LogEventLevel.Fatal;
                break;
        }
        
        
        
        
            
    }

    public void Debug(string msg)
    {
        Log.Logger.Debug(msg);
    }

    public void Error(string msg)
    {
        Log.Logger.Error(msg);
    }

    public void Warning(string msg)
    {
        Log.Logger.Warning(msg);

    }

    public void Information(string msg)
    {
        Log.Logger.Information(msg);

    }

   

}