using Automation.Framework.Core.WebUI.DIContainer;
using Automation.Framework.Core.WebUI.Params;
using Automation.Framework.Core.WebUI.WebAbstractions;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace Automation.Framework.Core.WebUI.Runner;
[Binding]
public class SpecflowRunner
{
    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        ContainerConfig.ConfigureService().GetRequiredService<IGlobalProperties>();
       
    }
}