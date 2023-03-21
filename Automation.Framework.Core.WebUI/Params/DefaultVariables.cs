using Automation.Framework.Core.WebUI.WebAbstractions;

namespace Automation.Framework.Core.WebUI.Params;

public class DefaultVariables: IDefaultVariables
{
    private string Results =>
        GetSolutionDirectory() + "\\AutomationRunner\\Results\\Reports" +
        DateTime.Now.ToString("yyyyMMdd hhmmss");

    public string Log =>
        Results + "\\log.txt";

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