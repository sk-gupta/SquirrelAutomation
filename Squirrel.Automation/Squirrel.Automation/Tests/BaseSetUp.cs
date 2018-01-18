using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using TestStack.White;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Squirrel.Automation.Helpers;
using NUnit.Framework.Interfaces;
using TestStack.White.Configuration;
using Squirrel.Automation.Extensions;

namespace Squirrel.Automation.Tests
{
    [SetUpFixture]
    public class BaseSetUp
    {
        protected ExtentReports _extent = ExtentManager.Instance;
        protected ExtentManager _extentManager;
        
        public BaseSetUp()
        {
        }

        [OneTimeSetUp]
        protected void Setup()
        {
            Wait.SetTimeOut();
            var testDir = TestContext.CurrentContext.TestDirectory;
            var reportDir = Path.GetFullPath(Path.Combine(testDir, @"../../Reports/"));
            var fileName = "AutomationReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportDir+fileName);
            _extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            _extent.Flush();
        }

        //[TestFixture]
        //public class TestInitializeWithNullValues : BaseSetUp
        //{
        //    [Test]
        //    public void TestNameNull()
        //    {
        //        //Assert.Throws(() => testNameNull());
        //    }
        //}

        //[SetUp]
        //public void BeforeTest()
        //{
        //    _test = ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name, "");
        //}

        //[TearDown]
        //public void AfterTest()
        //{
        //    var status = TestContext.CurrentContext.Result.Outcome.Status;
        //    var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
        //            ? ""
        //            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
        //    Status logstatus;


        //    switch (status)
        //    {
        //        case TestStatus.Failed:
        //            logstatus = Status.Fail;
        //            break;
        //        case TestStatus.Inconclusive:
        //            logstatus = Status.Warning;
        //            break;
        //        case TestStatus.Skipped:
        //            logstatus = Status.Skip;
        //            break;
        //        default:
        //            logstatus = Status.Pass;
        //            break;
        //    }

        //    _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
        //    _extent.Flush();
        //}
        
        
        
        //DefaultValues.Add("BusyTimeout", 5000);
        //    DefaultValues.Add("FindWindowTimeout", 30000);
        //    DefaultValues.Add("WaitBasedOnHourGlass", true);
        //    DefaultValues.Add("WorkSessionLocation", ".");
        //    DefaultValues.Add("UIAutomationZeroWindowBugTimeout", 5000);
        //    DefaultValues.Add("PopupTimeout", 5000);
        //    DefaultValues.Add("TooltipWaitTime", 3000);
        //    DefaultValues.Add("SuggestionListTimeout", 3000);
        //    DefaultValues.Add("HighlightTimeout", 1000);
        //    DefaultValues.Add("DefaultDateFormat", DateFormat.CultureDefault.ToString());
        //    DefaultValues.Add("DragStepCount", 1);
        //    DefaultValues.Add("InProc", false);
        //    DefaultValues.Add("ComboBoxItemsPopulatedWithoutDropDownOpen", true);
        //    DefaultValues.Add("RawElementBasedSearch", false);
        //    DefaultValues.Add("MaxElementSearchDepth", 10);
        //    DefaultValues.Add("DoubleClickInterval", 0);
        //    DefaultValues.Add("MoveMouseToGetStatusOfHourGlass", true);
        //    DefaultValues.Add("KeepOpenOnDispose", false);
    }
}
