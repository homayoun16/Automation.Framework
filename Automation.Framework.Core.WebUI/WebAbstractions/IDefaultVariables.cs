namespace Automation.Framework.Core.WebUI.WebAbstractions;

public interface IDefaultVariables
{
    public string Log
    {
        get;
    }

    public string Resources
    {
        get;
    }

    string? GridHubUrl { get; }
    
    string FilePath { get; }
}