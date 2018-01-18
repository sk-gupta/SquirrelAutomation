using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace Squirrel.Automation.Helpers
{
    public class LogHelper
    {
        public static ILog GetLogger([CallerFilePath]string filename = "")
        {
            return LogManager.GetLogger(filename);
        }

        //public static ILog GetLogger()
        //{
        //    return LogManager.GetLogger(new StackTrace().GetFrame(1).GetMethod().DeclaringType);
        //}
    }
}
