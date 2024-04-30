using FluentAssertions.Primitives;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using TechTalk.SpecFlow;

namespace ReactSpecFlowTests.Drivers
{
    public class DriverScript
    {
        private IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public DriverScript(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public IWebDriver SetUp()
        {
            //intializing edge browser

            ChromeOptions options = new ChromeOptions();
            
            // To maximize the browser

            options.AddArgument("--start-maximized");
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalOption("useAutomationExtension", false);
            driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(90));
            
            _scenarioContext.Set(driver, "Webdriver");
            return driver;

        }
    }
}
