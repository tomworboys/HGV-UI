using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace RegressionPackUITests.Utils
{
    [Binding]
    class WaitHelper
    {
        private readonly WebDriverWait wait;

        private readonly IWebDriver driver;

        public WaitHelper(IWebDriver driver)
        {
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            this.driver = driver;
        }

        public void WaitForElementToBeVisible(IWebElement webElement)
        {
            try
            {
                this.wait.Until(CustomExpectedConditions.VisibilityOfElement(webElement));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception($"Element {webElement.GetAttribute("data-spec")} is not visable on page {this.driver.Url}");
            }

        }
        public void WaitForElementToBePresent(IWebElement webElement)
        {
            try
            {
                this.wait.Until(CustomExpectedConditions.PresenceOfElement(webElement));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception($"Element {webElement.GetAttribute("data-spec")} is not present on page {this.driver.Url}");
            }
        }

        public void WaitForElementToNotBeVisible(IWebElement webElement)
        {
            try
            {
                this.wait.Until(CustomExpectedConditions.InvisibilityOfElement(webElement));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception($"Element {webElement.GetAttribute("data-spec")} which should be hidden is visable on page {this.driver.Url}");
            }
        }

        public void WaitForElementToBeClickable(IWebElement webElement)
        {
            try
            {
                this.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception($"Element {webElement.GetAttribute("data-spec")} is not clickable on page {this.driver.Url}");
            }
        }

        public void WaitForExpectedUrl(string expectedUrl)
        {
            try
            {
                this.wait.Until(CustomExpectedConditions.UrlContains(expectedUrl));
            }
            catch (Exception)
            {
                throw new Exception($"Actual driver url: {this.driver.Url} does not contain expected url: {expectedUrl}");
            }
        }

        public void WaitForExpectedClass(IWebElement webElement, string className)
        {
            try
            {
                this.wait.Until(CustomExpectedConditions.ExpectedClass(webElement, className));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception($"Element {webElement.GetAttribute("data-spec")} does not contain class {className} on page {this.driver.Url}");
            }
        }

        public void WaitUntilCountChanges(IList<IWebElement> elements, int count)
        {
            try
            {
                this.wait.Until(CustomExpectedConditions.CountChanges(elements, count));
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception($"The count for {elements[0].GetAttribute("data-spec")} does not match what was expected on page {this.driver.Url}. Actual Count: {elements.Count} Expected Count: {count}");
            }
        }
    }
}
