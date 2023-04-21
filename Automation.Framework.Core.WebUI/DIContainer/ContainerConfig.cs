using Automation.Framework.Core.WebUI.Params;
using Automation.Framework.Core.WebUI.Reporting;
using Automation.Framework.Core.WebUI.WebAbstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Automation.Framework.Core.WebUI.DIContainer;

public class ContainerConfig
{
    public static IServiceProvider ConfigureService()
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IDefaultVariables, DefaultVariables>();
        serviceCollection.AddSingleton<ILogging, Logging>();
        serviceCollection.AddSingleton<IGlobalProperties, GlobalProperties>();
        return serviceCollection.BuildServiceProvider();
        
    }
}