using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using TestStack.White.Configuration;
using Squirrel.Automation.Helpers;
using System.Configuration;
using TestStack.White.UIItems;

namespace Squirrel.Automation.Extensions
{
    // This class contains additional wait function that are not provided by TestStack White
    public class Wait
    {
        private static readonly log4net.ILog _Logger = LogHelper.GetLogger("Wait");

        public static void For(TimeSpan timeSpan)
        {
            Thread.Sleep(timeSpan);
        }
        
        //implementation - Wait.Until(new Func<bool>(this.LoginButton.IsEnabled), TimeSpan.FromSeconds(20));
        public static bool Until(Func<bool> condition, TimeSpan timeout)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            bool result;
            do
            {
                try
                {
                    if (condition())
                    {
                        result = true;
                        return result;
                    }
                }
                catch
                {
                }
                Thread.Sleep(TimeSpan.FromMilliseconds(100.0));
            }
            while (stopwatch.Elapsed < timeout);
            result = false;
            return result;
        }

        public static bool UntilIsClickable(UIItem uiItem, int? timeoutSecs = null)
        {
            int busyTimeout = int.Parse(CoreAppXmlConfiguration.Instance.BusyTimeout().ToString());
            timeoutSecs = new int?(timeoutSecs ?? busyTimeout);

            _Logger.DebugFormat("Waiting {0} seconds until element is clickable.", new object[]
            {
                timeoutSecs
            });
            Stopwatch stopwatch = Stopwatch.StartNew();
            bool result;
            do
            {
                try
                {
                    uiItem.AutomationElement.GetClickablePoint();
                    bool flag = 1 == 0;
                    _Logger.Debug("Found clickable point. Returning true.");
                    result = true;
                    return result;
                }
                catch
                {
                }
                Thread.Sleep(TimeSpan.FromMilliseconds(100.0));
            }
            while (stopwatch.Elapsed < TimeSpan.FromSeconds((double)timeoutSecs));
            _Logger.Debug("Timed out waiting for clickable point. Returning false.");
            result = false;
            return result;
        }

        public static void SetTimeOut()
        {
            //Set BusyTimeout based on the value in app.config
            //If we want to perorm the custom action then we  hook our custom wait that performs
            //action after each This hook gets called every time after the above wait checks are performed.
            //In this hook you can wait for your conditions to finish. This is useful if your wait scenarios
            //are quite pervasive and you have put in this check at lot of places in your test.
            //https://github.com/TestStack/TestStack.docs/blob/master/_source/White/Advanced%20Topics/Waiting.md
            try
            {
                CoreAppXmlConfiguration.Instance.BusyTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["BusyTimeout"]);
                CoreAppXmlConfiguration.Instance.FindWindowTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["FindWindowTimeout"]);
            }
            catch (Exception e)
            {
                //_logger.Fatal("Error in Set-Timeout " + e.Message);
                Console.Write(e);
            }


        }
    }
}
