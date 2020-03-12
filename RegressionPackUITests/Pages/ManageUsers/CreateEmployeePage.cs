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
    class CreateEmployeePage
    {
        private IWebDriver driver { get; }

        private WaitHelper WaitHelper => new WaitHelper(this.driver);

        public CreateEmployeePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /*
        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement Harvey { get; set; }
        */

        [FindsBy(How = How.CssSelector, Using = "#email")]
        private IWebElement EmployeeEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='row form-group ng-scope']//div[@class='col-md-6']//label[1]")]
        private IWebElement EmployeeRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='row form-group ng-scope']//label[2]")]
        private IWebElement AdminRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group ng-scope']//label[1]")]
        private IWebElement CreateOrderBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group']//label[1]")]
        private IWebElement ApproveOrderBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='row form-group']//label[2]")]
        private IWebElement ProcessOrderBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//body//label[3]")]
        private IWebElement ViewTechnicalBulletins { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement ApproiveEstimateBox { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement ViewInvoiceBox { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement EnabledRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement DisabledRadioBtn { get; set; }

        [FindsBy(How = How.LinkText, Using = "Cancel")]
        private IWebElement CancelBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary btn-lg btn-fixed']")]
        private IWebElement SaveBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='control-error ng-scope']")]
        private IWebElement EmailIsRequiredError { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='control-error ng-scope']")]
        private IWebElement EmailMustBeInTheListError { get; set; }



    }
}
