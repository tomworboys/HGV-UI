using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Linq;
using TechTalk.SpecFlow;

namespace RegressionPackUITests.Utils
{
    [Binding]
    class HelperMethods
    {
        private readonly IWebDriver driver;

        public HelperMethods(IWebDriver driver) => this.driver = driver;

        public void NavigateTo(string url)
        {
            try
            {
                this.driver.Navigate().GoToUrl(url);
            }
            catch (WebDriverException)
            {
                if (this.driver.Url != url)
                {
                    throw;
                }
            }
        }

        public bool IsElementPresent(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ScrollToElement(IWebElement element)
        {
            var js = this.driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void HoverOverElement(IWebElement element)
        {
            var action = new Actions(this.driver);
            action.MoveToElement(element).Perform();
        }

        public void ObscuredElementClick(IWebElement element)
        {
            var currentUrl = this.driver.Url;
            var attempts = 0;
            while (this.driver.Url.Equals(currentUrl) && attempts <= 5)
            {
                attempts++;
                try
                {
                    Thread.Sleep(1000);
                    element.Click();
                }
                catch (Exception e)
                {
                    if (attempts == 5)
                    {
                        throw e;
                    }
                }
            }
        }

        public void ClearTextAndSendKeys(IWebElement element, string text)
        {
            while (element.GetAttribute("value") != "")
            {
                element.SendKeys(Keys.Backspace);
            }
            element.SendKeys(text);
        }

        public void JavascriptClick(IWebElement element)
        {
            var js = this.driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", element);
        }
        public void JavascriptClear(IWebElement element)
        {
            var js = this.driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].value = '';", element);
        }

        public bool IsSelected(IWebElement element) => element.GetAttribute("class").Contains("selected");

        public string GetText(IWebElement element) => element.GetAttribute("innerHTML");

        public bool HasClass(IWebElement element, string className) => element.GetAttribute("class").Split(' ').Contains(className);
    }
}
