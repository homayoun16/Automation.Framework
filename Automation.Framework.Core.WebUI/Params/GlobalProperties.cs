using Automation.Framework.Core.WebUI.WebAbstractions;
using Microsoft.Extensions.Configuration;

namespace Automation.Framework.Core.WebUI.Params;

public class GlobalProperties: IGlobalProperties
{
    private IDefaultVariables _idefaultVariables;
    private ILogging _iLogging;

    public string BrowserType { get; set; }
    public string BrowserVersion { get; set; }
    public string GridHubUrl { get; set; }
    public string Region { get; set; }
    public bool StepScreenShot { get; set; }
    public string ExtentReportPortalUrl { get; set; }
    public bool ExtentReportToPortal { get; set; }
    public string LogLevel { get; set; }
    public string DataSetLocation { get; set; }
    public string DownloadedLocation { get; set ;}


    public GlobalProperties(IDefaultVariables idDefaultVariables, ILogging logging)
    {
        _idefaultVariables = idDefaultVariables;
        _iLogging = logging;
        Configuration();
    }

    public void Configuration()
    {
        IConfiguration builder = null;
        try
        {
            builder = new ConfigurationBuilder()
                .SetBasePath(_idefaultVariables.Resources)
                .AddJsonFile("frameworkSettings.json").Build();
        }
        catch (FileNotFoundException fn)
        {
            _iLogging.Error("FrameworkSettings.json does not exist." + fn.Message);
            System.Environment.Exit(0);
        }

        BrowserType = string.IsNullOrEmpty(builder["BrowserType"]) ? "chrome" : builder["BrowserType"];
        BrowserVersion = builder["BrowserVerion"];
        GridHubUrl = string.IsNullOrEmpty(builder["GridUrl"]) ? _idefaultVariables.GridHubUrl : builder["GridUrl"];
        Region = builder["Region"];
        //  StepScreenShot = builder["StepScreenShot"].ToLower().Equals("on");
        StepScreenShot = builder["StepScreenShot"].ToLower().Equals("on") ? true : false;

        /*if (builder["StepScreenShot"].ToLower().Equals("on"))
        {
            StepScreenShot = true;
        }
        else
        {
            StepScreenShot = false;
        }*/
        ExtentReportToPortal = builder["ExtentReportToPortal"].ToLower().Equals("on") ? true : false;
        ExtentReportPortalUrl = builder["ExtentReportPortalUrl"];
        LogLevel = builder["LogLevel"];
        DataSetLocation = string.IsNullOrEmpty(builder["DataSetLocation"])
            ? _idefaultVariables.FilePath
            : builder["DataSetLocation"];
        DownloadedLocation = string.IsNullOrEmpty(builder["DataSetLocation"])
            ? _idefaultVariables.FilePath
            : builder["DownloadedLocation"];

        if (string.IsNullOrEmpty(Region))
        {
            _iLogging.Error("User has not provided application environment information.");
            System.Environment.ExitCode.Equals(0);
        }

        _iLogging.SetLogLevel(LogLevel);

        IConfiguration applicationBuilder = null;
        try
        {
            applicationBuilder = new ConfigurationBuilder()
                .SetBasePath(_idefaultVariables.Resources)
                .AddJsonFile("applicationRegion.json").Build();
            applicationBuilder.GetSection(Region);

        }
        catch (FileNotFoundException fn)
        {
            _iLogging.Error("applicationRegion.json does not exist." + fn.Message);
            System.Environment.Exit(0);
        }
        
        _iLogging.Debug("***********************************************************************************");
        _iLogging.Information("**********************************************************************************");
        _iLogging.Information("Configuration | RUN PARAMETERS");
        _iLogging.Information("**********************************************************************************");
        _iLogging.Information("Configuration|BROWSER TYPE: "+ BrowserType);
        _iLogging.Information("Configuration|BROWSER VERSION: "+ BrowserVersion);
        _iLogging.Information("Configuration|GRID HUB URL: "+ GridHubUrl);
        _iLogging.Information("Configuration|REGION: "+ Region);
        _iLogging.Information("Configuration|STEP SCREENSHOT: "+ StepScreenShot);
        _iLogging.Information("Configuration|EXTENT REPORT PORTAL URL: "+ ExtentReportPortalUrl);
        _iLogging.Information("Configuration|EXTENT REPORT LOCALLY: "+ builder["ExtentReportToPortal"]);
        _iLogging.Information("Configuration|LOG LEVEL: "+ LogLevel);
        _iLogging.Information("Configuration|DATA SET LOCATION: "+ DataSetLocation);
        _iLogging.Information("Configuration|DOWNLOADED LOCATION: "+ DownloadedLocation);
        _iLogging.Debug("***********************************************************************************");
        _iLogging.Debug("***********************************************************************************");

    }
}