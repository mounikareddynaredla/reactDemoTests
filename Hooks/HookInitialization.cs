using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using TechTalk.SpecFlow;
using ReactSpecFlowTests.Drivers;
using OpenQA.Selenium;
using ReactSpecFlowTests.Utils;

namespace ReactSpecFlowTests.Hooks
{
    [Binding]
    public sealed class HookInitialization
    {
        public static ScenarioContext _scenarioContext;
        public static ExtentTest test;
        public static ExtentReports extent;
        public static ExtentTest featureName;
        public static ExtentTest scenario;
        public static ExtentHtmlReporter htmlReporter;

        public HookInitialization(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]

        public void BeforeScenario()
        {
            // implement this logic before very scenario

            Console.WriteLine("open browser in hooks");

            DriverScript driverScript = new DriverScript(_scenarioContext);
            _scenarioContext.Set(driverScript, "driverscript");

            // get scenario name
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);

        }

        [AfterStep]
        
        public void InsertReportingSteps()
        {
            IWebDriver driver = _scenarioContext.Get<IWebDriver>("Webdriver");
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if(_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Pass("");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Pass("");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Pass("");
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Pass("");
            }

            if (_scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                }

                if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                }

                if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                }

                if (stepType == "And")
                {
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                }

            }

            }


            [AfterScenario]

        public void AfterScenario()
        {
            _scenarioContext.Get<IWebDriver>("Webdriver").Quit();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            featureName = extent.CreateTest<Feature>(featurecontext.FeatureInfo.Title);
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\net6.0", "");
            htmlReporter = new ExtentHtmlReporter(path + "\\ReportResults\\");
            htmlReporter.Config.ReportName = "Report.html";
            htmlReporter.Config.EnableTimeline = true;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            Console.WriteLine("Added Report");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
            Console.WriteLine("Report Complete");
            string path_name = Utilities.CurrentDateTime().Replace("/", "-");
            string pathvaiable = path_name.Replace(" ", "_").Replace(":", "_");
            string path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\net6.0", "");
            var newname = "Result_" + pathvaiable;
            var path_is = path + "\\ReportResults\\index.html";
            RenameFile(path_is, newname);
        }

        public static void RenameFile(string filePath, string newName)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            fileInfo.MoveTo(fileInfo.Directory.FullName + "\\" + newName + ".html");

        }
    }
}
