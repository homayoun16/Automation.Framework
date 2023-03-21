namespace Automation.Framework.Core.WebUI.CustomException;

public class AutomationException: Exception
{
    public AutomationException(string message) : base($"{message}")
    {
    }

    public AutomationException(ErrorItems items) : base($"{items}")
    {
    }
    
    public AutomationException(string message, ErrorItems items) : base($"{message}: {items}")
    {
    }
}