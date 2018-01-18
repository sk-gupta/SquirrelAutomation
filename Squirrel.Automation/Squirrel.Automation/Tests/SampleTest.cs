using System;
using System.IO;
using System.Threading;
using NUnit.Framework;
using TestStack.White.Factory;
using TestStack.White.Finder;
//using System.Windows.Automation;
using System.Diagnostics;
using TestStack.White.UIItems.WindowStripControls;
using System.Collections.Generic;
using Squirrel.Automation.Pages;
using TestStack.White.UIItems.MenuItems;
using Squirrel.Automation.Helpers;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Squirrel.Automation.Test_Data;
//using RelevantCodes.ExtentReports;
using Squirrel.Automation.Extensions;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Squirrel.Automation.Tests
{   
    [TestFixture]
    public class SampleTest : TestSetUp
    {
        private static readonly log4net.ILog _Logger = LogHelper.GetLogger("Test file logger");

        private MainPage _mainPage;
        private Options _optionsPage;
        private DailySetup DailySetup;
        private EmployeeSetup EmployeeSetupPage;
        private MenuEntrySetup MenuEntrySetup;
        private Customizer CustomizerPage;
        

        [SetUp]
        public void TestSetup()
        {
            _mainPage = new MainPage(MainWindow);
            DailySetup = new DailySetup(MainWindow);
            EmployeeSetupPage = new EmployeeSetup(MainWindow);
            MenuEntrySetup = new MenuEntrySetup(MainWindow);
            CustomizerPage = new Customizer(MainWindow);
            _Logger.Info("Setup method");
        }

        [TearDown]
        public void TestTearDown()
        {
            Console.WriteLine(TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void AddEmployeeRecord()
        {
            _test.Info("Launch DailySetup Window ");
            _mainPage.ClickDailySetup();

            _test.Info("Launch Employee Setup form ");
            DailySetup.GetSubSetupCategory("Employee", "Employee Setup");

            _test.Info("Launch badge informatio window");
            EmployeeSetupPage.AddNewRecord();

            _test.Info("Enter badge information for a employee");
            EmployeeSetupPage.FillBadgeInformation();

            _test.Info("Enter employee details");
            EmployeeSetupPage.FillEmployeeInformation();

            _test.Info("Save and Exit employee form");
            DailySetup.SaveAndExitForm();
        }
        
        [Test]
        public void AddMenuEntry()
        {
            _test.Info("Launch DailySetup Window ");
            _mainPage.ClickDailySetup();

            _test.Info("Launch Menu entry setup form ");
            DailySetup.GetSubSetupCategory("Menu Setup", "Menu Entry Setup");

            _test.Info("Create a new record ");
            MenuEntrySetup.AddNewRecord();

            _test.Info("Enter menu entry details ");
            MenuEntrySetup.FillMenuEnteryDetails();

            _test.Info("Save and Exit entry setup form");
            DailySetup.SaveAndExitForm();
        }
        
        [Test]
        public void SelectMenuItem ()
        {
            //UIItem uiitem = _mainWindow.Get(SearchCriteria.ByAutomationId("");
            ////var test = extent. ("OpenNewsApp", "This test case open and verifies the 'News' app");
            ////_test.Log(LogStatus.Info, "Execution of SearchNews test case started");
            ////test.Log(LogStatus.Info, "Clicking the search icon");
            Menu menuItem = _mainPage.GetMenuItem(TestData.ToolsMenu);
            _mainPage.GetSubMenuItem(menuItem, TestData.CustomizeSubMenu);
            Wait.For(TimeSpan.FromSeconds(1));
            //Thread.Sleep(3000);
            //optionsPage = new Options(_mainWindow);
            //optionsPage.ClickUpdateTab();
            //optionsPage.ClickAllTabsOneByOne();
        }

        [Test]
        public void UpdateSystemConfig()
        {
            Menu menuItem = _mainPage.GetMenuItem(TestData.ToolsMenu);
            _mainPage.GetSubMenuItem(menuItem, TestData.CustomizeSubMenu);
            //Functions.WaitTillUIItemVisible(_customizerPage.GetCustomizerDialog().Get(_customizerPage._closeButton));
            CustomizerPage.NavigateThroughtTabs();
            CustomizerPage.SelectACustomizerTab(TestData.SystemConfigTab);
            CustomizerPage.UpdateSystemConfig();
            CustomizerPage.CloseCustomizerDialog();
        }

        [Test]
        public void VeifyApplicationCloseUsingMenu()
        {
            _mainPage.CloseApplicationUsingMenu();
        }

        [Test]
        public void VeifyApplicationCloseUsingX()
        {
            _mainPage.CloseApplicationUsingX();
        }

        [Test]
        public void LoggerTest()
        {
            Console.WriteLine("start of the log");
            _Logger.Debug("lowest severity message");
            _Logger.Info("Severity level 2 - higher than debug");
            _Logger.Warn("Severity level3");
            //var i = 0;
            //try
            //{
               // var num = 1 / i;
            //}
            //catch (DivideByZeroException ex)
            //{
            //    //string err = ex.InnerException.Message.ToString();
            //    _logger.Info("OpenNewsApp Test Case Failed");
            //    _logger.Error( ex.Message, ex);
            //    //_logger.Error("Error level message", ex);
            //}
            _Logger.Fatal("Highest fatal");
            Console.WriteLine("end of the log");
        }
    }
}
