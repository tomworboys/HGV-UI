using BoDi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;
using OpenQA.Selenium;
using RegressionPackUITests.Pages.Dashboard;
using RegressionPackUITests.POCO;
using System;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace RegressionPackUITests.Utils
{
    [Binding]
    public sealed class Hooks
    {
        private static IConfiguration config;
        private readonly IObjectContainer objectContainer;
        private readonly ScenarioContext scenarioContext;
        private readonly ITestOutputHelper output;
        static readonly ITestOutputHelper outputHelper;
        public static IWebDriver driver;

        
        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext, ITestOutputHelper output)
        {
            this.objectContainer = objectContainer;
            this.scenarioContext = scenarioContext;
            this.output = output;
        }

        [BeforeTestRun]        
        public static void Init()
        {
            config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json")
                .Build();

            ExecutionConfig.BaseUrl = config.GetValue<string>("TestExecutionConfig:baseUrl");
            ExecutionConfig.Driver = config.GetValue<string>("TestExecutionConfig:browserName");
            ExecutionConfig.Environment = config.GetValue<string>("TestExecutionConfig:environment");
            ExecutionConfig.Username = config.GetValue<string>("TestExecutionConfig:username");
            ExecutionConfig.Password = config.GetValue<string>("TestExecutionConfig:password");
        }

        [BeforeScenario]
        public void DriverSetup()
        {
            var localDriver = new LocalDriver();

            switch (ExecutionConfig.Environment.ToLower())
            {
                case "local":
                    driver = localDriver.SetLocalDriver(ExecutionConfig.Driver);
                    break;                
                default:
                    throw new Exception($"Runsettings parameter: {ExecutionConfig.Environment} is not recognised. Please review");
            }

            if (ExecutionConfig.Driver.ToLower() == "chrome"
                || ExecutionConfig.Driver.ToLower() == "ie"
                || ExecutionConfig.Driver.ToLower() == "firefox"
                || ExecutionConfig.Driver.ToLower() == "edge")
            {                
                driver.Manage().Window.Maximize();
                driver.Url = ExecutionConfig.BaseUrl;
                
                //Login Step
                Pages.Login.LoginPage loginPage = new Pages.Login.LoginPage(driver);
                DashboardPage dashboardPage = new DashboardPage(driver);
                loginPage.EnterUserName(ExecutionConfig.Username);
                loginPage.EnterPassWord(ExecutionConfig.Password);
                dashboardPage.WaitForSearchBar();
                
            }

            this.objectContainer.RegisterInstanceAs(driver);
            
        }        

        [AfterScenario]
        [AfterTestRun]
        public static void TearDown()
        {
            try
            {
                driver.Quit();
                driver.Dispose();
            }
            catch (WebDriverException)
            {
                outputHelper.WriteLine("Driver Failed to start");
            }
            catch (NullReferenceException)
            {
                outputHelper.WriteLine("Browser Failed to start");
            }
            
        }



    }
}
