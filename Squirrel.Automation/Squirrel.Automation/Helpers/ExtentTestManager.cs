using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Squirrel.Automation.Helpers
{
    //Thread-safe manager for ExtentTests:
    public class ExtentTestManager 
    {
        private static ThreadLocal<ExtentTest> _test;
        private static ExtentReports _extent = ExtentManager.Instance;

        public ExtentTestManager()
        { }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest GetTest()
        {
            return _test.Value;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateTest(string name, string description = null)
        {
            if (_test == null)
                _test = new ThreadLocal<ExtentTest>();

            var t = _extent.CreateTest(name, description);
            _test.Value = t;

            return t;
        }
    }
}
