using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using RegressionPackUITests.Utils;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace RegressionPackUITests.Pages.ManageUsers
{
    [Binding]
    class ManageUsersPage
    {
        private IWebDriver driver { get; }

        private WaitHelper WaitHelper => new WaitHelper(this.driver);

        public ManageUsersPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Supplier')]")]
        private IWebElement SupplierTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Employee')]")]
        private IWebElement EmployeeTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Depot Client')]")]
        private IWebElement DepotTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Manager')]")]
        private IWebElement ManagerTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search...']")]
        private IWebElement UsersSearchBar { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Create suppli")]
        private IWebElement CreateCustomer { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Create employ")]
        private IWebElement CreateEmployer { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Create depot clie")]
        private IWebElement CreateDepotClient { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Create depot manag")]
        private IWebElement CreateDepotManager { get; set; }

        [FindsBy(How = How.XPath, Using = "//body//tbody//tr[1]")]
        private IWebElement SelectFirstTableItem { get; set; }

        [FindsBy(How = How.XPath, Using = "//tr[1]//td[4]//span[1]")]
        private IWebElement SelectFirstItem { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='icon-cvl icon-cvl-back']")]
        private IWebElement BackToDashboardPage { get; set; }

        ///User Tabs//
        public ManageUsersPage ClickSupplierTab()
        {
            WaitHelper.WaitForElementToBeClickable(SupplierTab);
            SupplierTab.Click();
            return new ManageUsersPage(driver);
        }
        public ManageUsersPage ClickEmployeeTab()
        {
            WaitHelper.WaitForElementToBeClickable(EmployeeTab);
            EmployeeTab.Click();
            return new ManageUsersPage(driver);
        }
        public ManageUsersPage ClickDepotClientTab()
        {
            WaitHelper.WaitForElementToBeClickable(DepotTab);
            DepotTab.Click();
            return new ManageUsersPage(driver);
        }
        public ManageUsersPage ClickManagerTab()
        {
            WaitHelper.WaitForElementToBeClickable(ManagerTab);
            ManagerTab.Click();
            return new ManageUsersPage(driver);
        }

        ///Search bar///
        public ManageUsersPage SearchForUser(string searchUser)
        {
            WaitHelper.WaitForElementToBeClickable(UsersSearchBar);
            UsersSearchBar.Click();
            UsersSearchBar.SendKeys(searchUser);
            UsersSearchBar.SendKeys(Keys.Enter);
            return new ManageUsersPage(driver);
        }

        ///Results table///
        public ManageUsersPage SelectFirstResult()
        {
            WaitHelper.WaitForElementToBeClickable(SelectFirstTableItem);
            SelectFirstTableItem.Click();
            return new ManageUsersPage(driver);
        }
        public ManageUsersPage SelectFirstUser()
        {
            WaitHelper.WaitForElementToBeClickable(SelectFirstItem);
            SelectFirstItem.Click();
            return new ManageUsersPage(driver);
        }        

    }
}
