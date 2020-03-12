using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace RegressionPackUITests.Pages.Login
{
    [Binding]
    class LoginPage
    {
        private IWebDriver driver { get; }
        private WebDriverWait Wait { get; }
                
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#username")]
        private IWebElement UserName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#password")]
        private IWebElement PassWord { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#loginButton")]
        private IWebElement LoginButton { get; set; }
        

        public LoginPage EnterUserName(string emailAddress)
        {            
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#username")));
            UserName.Click();
            UserName.SendKeys(emailAddress);
            return new LoginPage(driver);
        }

        public LoginPage EnterPassWord(string passwordKey)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#password")));
            PassWord.Click();
            PassWord.SendKeys(passwordKey);
            PassWord.SendKeys(Keys.Enter);
            return new LoginPage(driver);
        }

        public LoginPage SubmitLogin()
        {
            LoginButton.Click();
            return new LoginPage(driver);
        }

    }
}
