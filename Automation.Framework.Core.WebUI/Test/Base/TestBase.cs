using Automation.Framework.Core.WebUI.WebAbstractions;
using TechTalk.SpecFlow;

namespace Automation.Framework.Core.WebUI.Test.Base;

public class TestBase: ITestBase
{
    private FeatureContext _featureContext;
    private Dictionary<string, string> _dataSet;

    public TestBase()
    {
        _dataSet = new Dictionary<string, string>();
    }

    public void SetContext(FeatureContext featureContext)
    {
        _featureContext = featureContext;
    }

    public FeatureContext GetContext()
    {
        return _featureContext;
    }

    public void SetDataSet(string key, string value)
    {
        if (_dataSet.ContainsKey(key))
        {
            _dataSet[key] = value;
        }

        else
        {
            _dataSet.Add(key, value);
        }
    }

    public string GetDataSet(string key)
    {
        return _dataSet[key];
    }
}