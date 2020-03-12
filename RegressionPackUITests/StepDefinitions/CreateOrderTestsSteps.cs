using OpenQA.Selenium;
using RegressionPackUITests.Utils;
using RegressionPackUITests.Pages.Dashboard;
using System;
using TechTalk.SpecFlow;

namespace RegressionPackUITests.StepDefinitions
{
    [Binding]
    public sealed class CreateOrderTestsSteps
    {

        private readonly IWebDriver driver;
        
        private HelperMethods HelperMethods => new HelperMethods(this.driver);

        private WaitHelper WaitHelper => new WaitHelper(this.driver);

        public CreateOrderTestsSteps(IWebDriver driver) => this.driver = driver;

        Pages.Dashboard.DashboardPage Dashboard => new DashboardPage(this.driver);
        Pages.CreateOrder.OrderForm OrderForm => new Pages.CreateOrder.OrderForm(this.driver);
        

        [Given(@"I go to CVLink page")]
        public void Given_I_Go_To_CVLink_Page()
        {
            
        }
        
        [When(@"I click Create Order")]
        public void When_I_Click_Create_Order()
        {
            
        }
        
        [Then(@"I will see the Create Order page")]
        public void Then_I_Will_See_The_Create_Order_Page()
        {
            
        }
    }
}
