using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;
using RegressionPackUITests.Utils;

namespace RegressionPackUITests.Pages.CreateOrder
{
    [Binding]
    class OrderForm
    {
        private readonly IWebDriver driver;

        private WaitHelper WaitHelper => new WaitHelper(this.driver);

        //Create Depot User Page
        public OrderForm(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#dateBooked")]
        private IWebElement DatePicker { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement Harvey1 { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement Harvey2 { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement Harvey3 { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement Harvey4 { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement Harvey5 { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement Harvey6 { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement Harvey7 { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement Harvey8{ get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement Harvey9 { get; set; }

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement Harvey00 { get; set; }

        public OrderForm ClickDatePicker()
        {
            WaitHelper.WaitForElementToBeClickable(DatePicker);
            DatePicker.Click();
            return new OrderForm(driver);
        }


    }
}
