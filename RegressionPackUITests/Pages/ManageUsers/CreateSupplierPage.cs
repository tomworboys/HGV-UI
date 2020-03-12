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
    class CreateSupplierPage
    {
        private IWebDriver driver { get; }

        private WaitHelper WaitHelper => new WaitHelper(this.driver);

        public CreateSupplierPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#email")]
        private IWebElement EmailField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#supplier")]
        private IWebElement SupplierField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#startDate")]
        private IWebElement StartDateField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#reference")]
        private IWebElement ReferenceField { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='col-md-6']//div[1]//label[1]")]
        private IWebElement CreateOrderBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='well']//div[1]//label[2]")]
        private IWebElement ViewSchedulesBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group ng-scope']//label[3]")]
        private IWebElement SubmitOrderAsEstimateBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group']//label[1]")]
        private IWebElement ViewTechnicalBulletinesBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group']//label[2]")]
        private IWebElement ViewInvoiceBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group']//label[3]")]
        private IWebElement InspectionQualityCtrlBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//body//label[4]")]
        private IWebElement InspectionSupervisorSignOffBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='row form-group']//div[3]//label[1]")]
        private IWebElement LineItemsRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[3]//label[2]")]
        private IWebElement UploadProFormasRadioBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#password")]
        private IWebElement NewPasswordField { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Enabled')]")]
        private IWebElement EnabledRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='row']//label[2]")]
        private IWebElement DisabledRadioBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#agentId")]
        private IWebElement AddAgentField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#customerId")]
        private IWebElement AddLabourRateField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#LabourRateValue")]
        private IWebElement AddLabourRatePriceValue { get; set; }

        [FindsBy(How = How.LinkText, Using = "Cancel")]
        private IWebElement CancelBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary btn-lg btn-fixed']")]
        private IWebElement SaveBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='icon-cvl icon-cvl-back']")]
        private IWebElement BackToManageUsers { get; set; }


        ///Validation errors///        

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Email is required')]")]
        private IWebElement EmailIsRequiredError { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Supplier is required')]")]
        private IWebElement SupplierIsRequiredError { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Start Date is required')]")]
        private IWebElement StartDateIsRequiredError { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Reference is required')]")]
        private IWebElement ReferenceIsRequiredError { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Password is required')]")]
        private IWebElement PasswordIsRequiredError { get; set; }

        
        /// Invalid data checks ///

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Email is invalid')]")]
        private IWebElement EmailIsInvalid { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Supplier must be in the list')]")]
        private IWebElement SupplierMustBeInTheList { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Format must be 3 letters')]")]
        private IWebElement RefFormatMustBe3Letters { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Must be at least 6 characters')]")]
        private IWebElement PassMustBeAtLeast6Chars { get; set; }
    }
}
