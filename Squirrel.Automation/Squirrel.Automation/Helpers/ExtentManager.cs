using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Squirrel.Automation.Helpers
{
    //thread-safe manager for ExtentReports:
    public class ExtentManager
    {
        private static readonly ExtentReports _instance = new ExtentReports();
       
        #region Singleton Pattern

        private static readonly object InstanceLocker = new object();
        private static ExtentReports instance;

        public static ExtentReports Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }
                lock (InstanceLocker)
                {
                    if (instance != null)
                    {
                        return instance;
                    }

                    instance = new ExtentReports();
                    Console.WriteLine("Extent Report is initialzed.");

                    return instance;
                }
            }
        }


        // private constructor so that the only way to get an instance is the static Instance property
        private ExtentManager()
        {
        }

        #endregion 
    }
}
