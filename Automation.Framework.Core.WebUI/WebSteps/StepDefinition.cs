using TechTalk.SpecFlow;

namespace Automation.Framework.Core.WebUI.WebSteps;

[Binding]
public class StepDefinition
{
    [Given(@"User is on the login page")]
    public void GivenUserIsOnTheLoginPage()
    {
      Console.WriteLine("Hello to Login Page");
    }
}