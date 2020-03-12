using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace RegressionPackUITests.Utils
{
    [Binding]
    public class CustomExpectedConditions
    {
        private CustomExpectedConditions() { }

        public static Func<IWebDriver, bool> VisibilityOfElement(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return element != null && element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            };
        }

        public static Func<IWebDriver, bool> PresenceOfElement(IWebElement element)
        {
            var dataspec = element.GetAttribute("data-spec");
            return (driver) =>
            {
                try
                {
                    driver.FindElement(By.CssSelector("*[data-spec='" + dataspec + "']"));
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            };
        }

        public static Func<IWebDriver, bool> InvisibilityOfElement(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return element != null && element.Displayed ? !element.Displayed : true;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            };
        }

        public static Func<IWebDriver, bool> CountChanges(IList<IWebElement> elements, int count)
        {
            return (driver) =>
            {
                try
                {
                    var elementCount = elements.Count;
                    return elementCount == count;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            };
        }

        public static Func<IWebDriver, bool> UrlContains(string expectedUrl) => (driver) => driver.Url.Contains(expectedUrl);

        public static Func<IWebDriver, bool> ExpectedClass(IWebElement element, string className)
        {
            return (driver) =>
            {
                try
                {
                    return element.GetAttribute("class").Contains(className);
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            };
        }
    }
}
