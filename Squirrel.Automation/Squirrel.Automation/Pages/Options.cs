using System;
using System.IO;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using System.Threading;
//using NUnit.Framework;
using TestStack.White.Factory;
using TestStack.White.Finder;
using System.Windows.Automation;
using System.Diagnostics;
using TestStack.White.UIItems.Finders;

namespace Squirrel.Automation.Pages
{
    public class Options 
    {
        //public System.Collections.Generic.List<Window> optionsWindow = mainWindow.ModalWindows();  // mainWindow.ModalWindow("Options");
        private Window optionsWindow;

        #region Tabs
        //public static SearchCriteria UpdateTab = SearchCriteria.ByControlType(ControlType.TabItem).AndAutomationId("UpdateTab");
        public static SearchCriteria UpdateTab = SearchCriteria.ByControlType(ControlType.Text).AndByText("Updates");

        #endregion

        public Options(Window window)
        {
            optionsWindow = window.ModalWindow("Options");
        }

        public void ClickUpdateTab() //ClickAllTabsOneByOne
        {
            //Functions.ClickOnElement(optionsWindow.Get(UpdateTab));
            Thread.Sleep(2000);
        }
        
        public void ClickAllTabsOneByOne()
        {
            //var test = optionsWindow.Get<UIItemCollection>("yestghg");
            //int count = test.Length;
            //Console.WriteLine(count

        }

    }
}
