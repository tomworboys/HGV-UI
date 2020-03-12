using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using RegressionPackUITests.Utils;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace RegressionPackUITests.Pages.Supplier
{
    [Binding]
    class SupplierDashboard
    {
        private IWebDriver driver { get; }

        private WaitHelper WaitHelper => new WaitHelper(this.driver);

        //Create Depot User Page
        public SupplierDashboard(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /*
        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement Harvey { get; set; }
        */

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement PendingEstimateTab { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement QueriedEstimateTab { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement ApprovedEstiamteTab { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement OpenTab { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement PendingTab { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement QueriedTab { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement ConfirmedTab { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement SchedulesTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class='table table-bordered table-hover table-status table-select table-sort ng-scope']//tbody")]
        private IWebElement ResultsTable { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='icon-cvl icon-cvl-add']")]
        private IWebElement CreateOrderBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'hamshallcvl@intercounty-contracts.com')]")]
        private IWebElement AssertSupplierOnDashboard { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'SAPPHIRE HAMS HALL')]")]
        private IWebElement AssertSupplierNameOnDashboard { get; set; }
    }
}