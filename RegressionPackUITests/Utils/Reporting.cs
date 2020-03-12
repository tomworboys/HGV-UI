using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using RegressionPackUITests.POCO;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace RegressionPackUITests.Utils
{
    [Binding]
    class Reporting
    {
        private readonly IWebDriver driver;
        private ExtentTest feature;
        private ExtentTest scenario;
        private static AventStack.ExtentReports.ExtentReports extent;
        private readonly ScenarioContext scenarioContext;
        private readonly FeatureContext featureContext;

        public Reporting(IWebDriver driver, ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            this.driver = driver;
            this.scenarioContext = scenarioContext;
            this.featureContext = featureContext;
        }

        [BeforeTestRun]
        public static void AttachReporter()
        {
            extent = new AventStack.ExtentReports.ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(GetReportsPath());
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Environment", ExecutionConfig.Environment);
            extent.AddSystemInfo("Browser/Device", ExecutionConfig.Driver);
        }

        [BeforeScenario]
        public void GetScenarioAndFeatureInfo()
        {
            var featureTags = this.featureContext.FeatureInfo.Tags;
            var featureTitle = this.featureContext.FeatureInfo.Title;

            var scenarioTags = this.scenarioContext.ScenarioInfo.Tags;
            var scenarioTitle = this.scenarioContext.ScenarioInfo.Title;

            this.feature = extent.CreateTest<Feature>(featureTitle).AssignCategory(featureTags);
            this.scenario = this.feature.CreateNode<Scenario>(scenarioTitle).AssignCategory(scenarioTags);
        }

        [AfterStep]
        public void GetStepsInfo()
        {
            var stepType = this.scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var stepName = this.scenarioContext.StepContext.StepInfo.Text;

            var screenshotPath = this.GetScreenshotHtmlPath();
            var screenshot = $"<a href=\"{screenshotPath}\"><img src=\"{screenshotPath}\" style=\"width:95%;height:95%\"></a>";

            string currentUrl;

            try
            {
                currentUrl = this.driver.Url;
            }
            catch (WebDriverException)
            {
                currentUrl = "Failed to Retrieve URL";
            }

            ExtentTest node = null;
                        

            switch (stepType)
            {

                case "Given":
                    node = scenario.CreateNode<Given>("Given: " + stepName);
                    break;
                case "When":
                    node = scenario.CreateNode<When>("When: " + stepName);
                    break;
                case "Then":
                    node = scenario.CreateNode<Then>("Then" + stepName);
                    break;
                case "And":
                    node = scenario.CreateNode<And>("And" + stepName);
                    break;
                    
            }

            if (scenarioContext.TestError != null)
            {
                this.TakeScreenshot();                
                node.Fail(this.scenarioContext.TestError.Message)
                    .Fail(this.GetInnerExceptionMessage())
                    .Log(Status.Info, screenshot)
                    .Log(Status.Info, currentUrl);
            }
            
        }

        [After]
        public static void FlushReport() => extent.Flush();

        public string GetInnerExceptionMessage()
        {
            try
            {
                return this.scenarioContext.TestError.InnerException.Message;
            }
            catch (NullReferenceException)
            {
                return "No inner exception message.";
            }
        }

        private string GetScreenshotWritePath()
        {
            var reportsPath = GetReportsPath();
            var folderExists = Directory.Exists(reportsPath + "Screenshots\\");

            if (!folderExists)
            {
                Directory.CreateDirectory(reportsPath + "Screenshots\\");
            }

            var stepText = this.scenarioContext.StepContext.StepInfo.Text.Replace("/", "-").Replace(@"\", "-");
            var screenshotPath = reportsPath + "Screenshots\\" + stepText + ".png";
            return screenshotPath;
        }

        private string GetScreenshotHtmlPath()
        {
            var stepText = this.scenarioContext.StepContext.StepInfo.Text.Replace("/", "-").Replace(@"\", "-");
            var screenshotPath = $"Screenshots/{stepText}.png";
            return screenshotPath;
        }

        private void TakeScreenshot()
        {
            try
            {
                ((ITakesScreenshot)this.driver).GetScreenshot().SaveAsFile(this.GetScreenshotWritePath());
            }
            catch (WebDriverException)
            {
                Debug.Print("Couldn't take a screenshot. Driver not available.");
            }
        }

        private static string GetReportsPath()
        {
            return Path.GetDirectoryName
                       (Path.GetDirectoryName
                       (Path.GetDirectoryName
                           (Assembly.GetExecutingAssembly().Location)))
                       .Replace("\\bin", "\\Reports\\") + ExecutionConfig.Driver + "\\";
        }
    }
}