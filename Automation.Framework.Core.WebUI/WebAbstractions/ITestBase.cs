using TechTalk.SpecFlow;

namespace Automation.Framework.Core.WebUI.WebAbstractions;

public interface ITestBase
{
    public void SetContext(FeatureContext featureContext);
    public FeatureContext GetContext();
    public void SetDataSet(string key, string value);
    public string GetDataSet(string key);

}