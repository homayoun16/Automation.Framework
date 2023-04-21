using Automation.Framework.Core.WebUI.WebAbstractions;

namespace Automation.Framework.Core.WebUI.Params;

public class DefaultVariables: IDefaultVariables
{
    private string Results
    {
        get
        {
           return GetSolutionDirectory() + @"/AutomationRunner/Results/Reports" +
                DateTime.Now.ToString("yyyyMMdd hhmmss");
        }
    }


    public string Log
    {
        get
        {
           return Results + "/log.txt";
        }
    }
       

    public string Resources
    {
        get
        {
            return GetSolutionDirectory() + @"/AutomationRunner/Resources";
        }
    }

    public string? GridHubUrl
    {
        get
        {
            return "https://localhost:4444/wd/hub";
        }
        
    }

    public string FilePath
    {
        get
        {
            return GetSolutionDirectory() + @"AutomationRunner/DataSetLocation";
        }
    }

    private static string GetSolutionDirectory()
    {
        var solutionDirectory = AppDomain.CurrentDomain.BaseDirectory;

        while (!Directory.GetFiles(solutionDirectory, "*.sln").Any())
        {
            solutionDirectory = Directory.GetParent(solutionDirectory).FullName;

            if (solutionDirectory == null)
            {
                throw new Exception("Solution directory not found.");
            }
        }

        return solutionDirectory;
    }
}