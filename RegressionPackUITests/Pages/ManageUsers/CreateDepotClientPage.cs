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
    class CreateDepotClientPage
    {
        private IWebDriver driver { get; }

        private WaitHelper WaitHelper => new WaitHelper(this.driver);

        //Create Depot User Page
        public CreateDepotClientPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /* TEMPLATE FindBy script
        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement Harvey { get; set; }
        */

        [FindsBy(How = How.CssSelector, Using = "#email")]
        private IWebElement DepotClientEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#reference")]
        private IWebElement ReferenceField { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='row form-group']//div[@class='col-md-6']//label[1]")]
        private IWebElement ApproveOrderBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='row form-group']//label[2]")]
        private IWebElement VeiwTechnicalBulletinsBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//body//label[3]")]
        private IWebElement ManageTechnicalBulletinsBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//body//label[4]")]
        private IWebElement ApproveEstimateBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//body//label[5]")]
        private IWebElement ViewInvoiceBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#password")]
        private IWebElement PasswordField { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Enabled')]")]
        private IWebElement EnabledRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='row']//label[2]")]
        private IWebElement DisabledRadioBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#depotId")]
        private IWebElement AddDepotField { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement CancelBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement SaveBtn { get; set; }



        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Email is required')]")]
        private IWebElement EmailIsRequiredError { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='control-error']")]
        private IWebElement ReferenceIsRequiredError { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Password is required')]")]
        private IWebElement PasswordIsRequiredErrror { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Email is invalid')]")]
        private IWebElement EmailIsInvalidError { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='control-error']")]
        private IWebElement RefFormatMustBe3Letters { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Must be at least 6 characters')]")]
        private IWebElement PassMustBeAtLeast6Chars { get; set; }
        

    }
}
