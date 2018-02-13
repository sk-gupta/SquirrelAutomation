using System;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using NUnit.Framework;
using Squirrel.Automation.Properties;
using TestStack.White.Factory;
using System.Diagnostics;
using Squirrel.Automation.Helpers;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using Squirrel.Automation.Extensions;
using System.IO;
using System.Threading;
using System.Configuration;
using Squirrel.Automation.Pages;

namespace Squirrel.Automation.Tests
{
    [TestFixture]
    public class TestSetUp : BaseSetUp
    {
        protected Application MainApplication;
        protected Window MainWindow;
        protected ExtentTest _test;
        private TestStatus _teststatus;
        private Status _logstatus;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            //TestParameters testparam = TestContext.Parameters;
            //string applicaionPath = ConfigurationManager.AppSettings["ApplicationPath"];
            //_application = RunApp(applicaionPath);
            //_mainWindow = GetMainWindow(_application);
            //_mainWindow.DisplayState = DisplayState.Maximized;
        }

        //Run the Application
        public Application RunApp(string path)
        {
            Application application = Application.Launch(new ProcessStartInfo(path));
            //if (application.Process != null)
            //{
            //    application.Process.WaitForExit();           //or any other statements for that matter
            //}
            //application.Process.WaitForExit();
            application = Application.Attach("SqExplor"); //SourceTree
            return application;
        }

        //Get the Main Window
        public static Window GetMainWindow(Application app)
        {
            Window window = app.GetWindow("Squirrel Back Office", InitializeOption.NoCache);
            //_mainWindow = Retry.For(() => _application.GetWindow("Sourcetree", InitializeOption.NoCache), TimeSpan.FromMinutes(1))
            window.DisplayState = DisplayState.Maximized;
            return window;
        }

      
        #region test
        #endregion
        //[OneTimeTearDown]
        public void BaseTearDown()
        {
            Console.WriteLine("tear down process started");
            if (MainWindow != null)
            {
                try
                {
                    MainWindow.Close();  // Closing the MainWindow "might" also close the Application.
                    MainWindow.Dispose(); // This is different from App to App how it handles the MainWindow Close and Dispose
                }
                finally
                {
                    MainWindow = null;
                }
            }
            if (MainApplication != null)
            {
                try
                {
                    MainApplication.Kill();
                    MainApplication.Dispose();
                }
                finally
                {
                    MainApplication = null;
                }
            }
        }

        [SetUp]
        public void BeforeTest()
        {
            string applicaionPath = ConfigurationManager.AppSettings["ApplicationPath"];
            MainApplication = RunApp(applicaionPath);
            MainWindow = GetMainWindow(MainApplication);
            MainWindow.DisplayState = DisplayState.Maximized;
            _test = ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name, "");
        }

        [TearDown]
        public void AfterTest()
        {
            GetTestStatus();
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            var outputMessage = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)
                    ? "Null"
                    : string.Format("{0}", TestContext.CurrentContext.Result.Message);
           
            var screenshot_path = Functions.CaptureScreen(_teststatus, TestContext.CurrentContext.Test.Name+ ".png");
            Wait.For(TimeSpan.FromSeconds(2));

            if (File.Exists(screenshot_path))
                _test.AddScreenCaptureFromPath(screenshot_path);   //TestContext.CurrentContext.GetType().ToString())
            else
                _test.AddScreenCaptureFromPath(@"C:\Users\sandeepkumar.gupta\Desktop\Desktop on 3 -Jan-17\updated slip.png");

            _test.Log(_logstatus, "Test status : " + _logstatus + "ed" + stacktrace + ", Output Message : "+outputMessage);

            //_extent.Flush();

            BaseTearDown();           
        }


        public void GetTestStatus()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            switch (status)
            {
                case TestStatus.Failed:
                    _logstatus = Status.Fail;
                    _teststatus = TestStatus.Failed;
                    break;
                case TestStatus.Inconclusive:
                    _logstatus = Status.Warning;
                    _teststatus = TestStatus.Inconclusive;
                    break;
                case TestStatus.Skipped:
                    _logstatus = Status.Skip;
                    _teststatus = TestStatus.Skipped;
                    break;
                default:
                    _logstatus = Status.Pass;
                    _teststatus = TestStatus.Passed;
                    break;
            }
        }
    }
}