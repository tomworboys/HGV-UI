using OpenQA.Selenium;
using RegressionPackUITests.Utils;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace RegressionPackUITests.Pages.Dashboard
{
    [Binding]
    class DashboardPage
    {
        private IWebDriver driver { get; }

        private WaitHelper WaitHelper => new WaitHelper(this.driver);

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;            
            PageFactory.InitElements(driver, this);
        }

        /////////Dashboard buttons/////////
        
        [FindsBy(How = How.CssSelector, Using = "#txtSearchVehicle")]
        private IWebElement VehicleSearchBar { get; set; }
        

        [FindsBy(How = How.XPath, Using = "//div[@class='col-sm-4 col-xs-1']//a")]        
        private IWebElement HomeIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='icon-cvl icon-cvl-edit']")]
        private IWebElement ManageUsers { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='icon-cvl icon-cvl-attachment']")]
        private IWebElement TechnicalBulletins { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class='table table-bordered table-hover table-status table-select table-sort ng-scope']")]
        private IWebElement ResultsTable { get; set; }        

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-switch col-sm-3 ng-scope active']")]
        private IWebElement OpenTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-switch col-sm-3 ng-scope'][contains(text(),'Queried')]")]
        private IWebElement QueriedTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-switch col-sm-3 ng-scope'][contains(text(),'Pending')]")]
        private IWebElement PendingTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Pro-formas')]")]
        private IWebElement ProformasTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Awaiting Approval')]")]
        private IWebElement AwaitngApprovalTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Queried Estimates')]")]
        private IWebElement QueriedEstimatesTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Pending Estimates')]")]
        private IWebElement PendingEstimatesTab { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#impersonateUser")]
        private IWebElement ImpersonateUserBar { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary btn-lg col-md-2']")]
        private IWebElement GoBtn { get; set; }

        [FindsBy(How = How.LinkText, Using = "(Cancel)")]
        private IWebElement CancelBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='icon-cvl icon-cvl-add']")]
        private IWebElement CreateOrderBtn { get; set; }


        //////////Table sortation buttons//////////
        
        [FindsBy(How = How.XPath, Using = "//th[@class='date-created-header']")]        
        private IWebElement SubmittedQueriedTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//body//th[2]")]
        private IWebElement JobDateTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='sortable'][contains(text(),'Supplier')]")]
        private IWebElement SupplierTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Depot')]")]
        private IWebElement DepotTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Start Ref.')]")]
        private IWebElement StartRefTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'WIP Ref.')]")]
        private IWebElement WIPRefTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Reg No.')]")]
        private IWebElement RegNoTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//th[@class='cell-total text-right']//div[1]")]
        private IWebElement TotalTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//th[10]//div[1]")]
        private IWebElement DaysOldTab { get; set; }


        ///////Table search by customer and supplier///////
        
        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement AllCustomersBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "")]
        private IWebElement AllSuppliersBtn { get; set; }


        //////////Test steps/////////
        
        
        
        //Dashboad Navigation

        public DashboardPage WaitForSearchBar()
        {
            WaitHelper.WaitForElementToBeClickable(VehicleSearchBar);
            return new DashboardPage(driver);
        }

        public DashboardPage ClickHomeBtn()
        {
            WaitHelper.WaitForElementToBeClickable(HomeIcon);
            HomeIcon.Click();
            return new DashboardPage(driver);
        }
        public DashboardPage ClickManageUsersBtn()
        {
            WaitHelper.WaitForElementToBeClickable(ManageUsers);
            ManageUsers.Click();
            return new DashboardPage(driver);
        }
        public DashboardPage ClickTechnicalButtetinsBtn()
        {
            WaitHelper.WaitForElementToBeClickable(TechnicalBulletins);
            TechnicalBulletins.Click();
            return new DashboardPage(driver);
        }
        public DashboardPage ClickCreateOrder()
        {
            WaitHelper.WaitForElementToBeClickable(CreateOrderBtn);
            CreateOrderBtn.Click();
            return new DashboardPage(driver);
        }

        //Impersonate Users and Cancel button
        public DashboardPage ImpersonateUser(string enterUserDetails)
        {
            WaitHelper.WaitForElementToBeClickable(ImpersonateUserBar);
            ImpersonateUserBar.Click();
            ImpersonateUserBar.SendKeys(enterUserDetails);
            ImpersonateUserBar.SendKeys(Keys.ArrowDown);
            ImpersonateUserBar.SendKeys(Keys.Enter);
            return new DashboardPage(driver);
        }
        public DashboardPage ClickGoBtn()
        {
            WaitHelper.WaitForElementToBeClickable(GoBtn);
            GoBtn.Click();
            return new DashboardPage(driver);
        }
        public DashboardPage ClickCancelBtn()
        {
            WaitHelper.WaitForElementToBeClickable(CancelBtn);
            CancelBtn.Click();
            return new DashboardPage(driver);
        }

        //Wait for Results table to display
        public DashboardPage WaitForResultsTable()
        {
            WaitHelper.WaitForElementToBeVisible(ResultsTable);
            return new DashboardPage(driver);
        }

        //For Estimates
        public DashboardPage ClickAwaitingApprovalTab ()
        {
            WaitHelper.WaitForElementToBeClickable(AwaitngApprovalTab);
            AwaitngApprovalTab.Click();
            return new DashboardPage(driver);
        }
        public DashboardPage ClickQueriedEstimatesTab()
        {
            WaitHelper.WaitForElementToBeClickable(QueriedEstimatesTab);
            QueriedEstimatesTab.Click();
            return new DashboardPage(driver);
        }
        public DashboardPage ClickPendingEstimatesTab()
        {
            WaitHelper.WaitForElementToBeClickable(PendingEstimatesTab);
            PendingEstimatesTab.Click();
            return new DashboardPage(driver);
        }

        //Table: SortBy options
        public DashboardPage SortTableBySubmittedQueried()
        {
            WaitHelper.WaitForElementToBeClickable(SubmittedQueriedTab);
            SubmittedQueriedTab.Click();
            return new DashboardPage(driver);
        }
        public DashboardPage SortTableByJobDate()
        {
            WaitHelper.WaitForElementToBeClickable(JobDateTab);
            JobDateTab.Click();
            return new DashboardPage(driver);
        }
        public DashboardPage SortTableBySupplier()
        {
            WaitHelper.WaitForElementToBeClickable(SupplierTab);
            SupplierTab.Click();
            return new DashboardPage(driver);
        }
        public DashboardPage SortTableByDepot()
        {
            WaitHelper.WaitForElementToBeClickable(DepotTab);
            DepotTab.Click();
            return new DashboardPage(driver);
        }
        public DashboardPage SortTableByStarRef()
        {
            WaitHelper.WaitForElementToBeClickable(StartRefTab);
            StartRefTab.Click();
            return new DashboardPage(driver);
        }
        public DashboardPage SortTableByWIPRef()
        {
            WaitHelper.WaitForElementToBeClickable(WIPRefTab);
            WIPRefTab.Click();
            return new DashboardPage(driver);
        }
        public DashboardPage SortTableByRegNo()
        {
            WaitHelper.WaitForElementToBeClickable(RegNoTab);
            RegNoTab.Click();
            return new DashboardPage(driver);
        }
        public DashboardPage SortTableByTotal()
        {
            WaitHelper.WaitForElementToBeClickable(TotalTab);
            TotalTab.Click();
            return new DashboardPage(driver);
        }
        public DashboardPage SortTableByDaysOld()
        {
            WaitHelper.WaitForElementToBeClickable(DaysOldTab);
            DaysOldTab.Click();
            return new DashboardPage(driver);
        }


        // Organise Job types
        public DashboardPage SortTableByOpenJob()
        {
            WaitHelper.WaitForElementToBeClickable(OpenTab);
            OpenTab.Click();
            return new DashboardPage(driver);
        }
        public DashboardPage SortTableByOueriedJob()
        {
            WaitHelper.WaitForElementToBeClickable(QueriedTab);
            QueriedTab.Click();
            return new DashboardPage(driver);
        }
        public DashboardPage SortTableByPendingJob()
        {
            WaitHelper.WaitForElementToBeClickable(PendingTab);
            PendingTab.Click();
            return new DashboardPage(driver);
        }
        public DashboardPage SortTableByProformas()
        {
            WaitHelper.WaitForElementToBeClickable(ProformasTab);
            ProformasTab.Click();
            return new DashboardPage(driver);
        }

        // Sort by Customer or Supplier
        public DashboardPage AllCustomersDropDown()
        {
            WaitHelper.WaitForElementToBeClickable(AllCustomersBtn);
            AllCustomersBtn.Click();
            AllCustomersBtn.SendKeys("b");
            AllCustomersBtn.SendKeys(Keys.Enter);
            return new DashboardPage(driver);
        }
        public DashboardPage AllSuppliersDropDown()
        {
            WaitHelper.WaitForElementToBeClickable(AllSuppliersBtn);
            AllSuppliersBtn.Click();
            AllSuppliersBtn.SendKeys("1");
            AllSuppliersBtn.SendKeys(Keys.Enter);
            return new DashboardPage(driver);
        }
    }
}
