using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace RegressionPackUITests.Utils
{
    [Binding]
    class LocalDriver
    {
        public IWebDriver driver;

        public IWebDriver SetLocalDriver(string browser)
        {
            var workingDirectory = GetWorkingDirectory();

            var chromeOptions = new ChromeOptions();

            var internetExplorerOptions = new InternetExplorerOptions();
            internetExplorerOptions.IgnoreZoomLevel = true;
            internetExplorerOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;            
            
            
            switch (browser.ToLower())
            {
                case "chrome":
                    this.driver = new ChromeDriver(workingDirectory, chromeOptions);
                    break;
                case "ie":
                    this.driver = new InternetExplorerDriver(workingDirectory, internetExplorerOptions);
                    break;
                case "firefox":
                    this.driver = new FirefoxDriver(workingDirectory);
                    break;
                case "edge":
                    this.driver = new EdgeDriver(workingDirectory);
                    break;
                default:
                    throw new Exception($"Browser {browser} is not recognised. Please review.");
            }
            return this.driver;
        }

        private string GetWorkingDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }
}
