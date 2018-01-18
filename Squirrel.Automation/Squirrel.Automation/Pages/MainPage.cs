using System;
using System.IO;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using System.Threading;
using NUnit.Framework;
using TestStack.White.Factory;
using TestStack.White.Finder;
using System.Windows.Automation;
using System.Diagnostics;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowStripControls;
using Squirrel.Automation.Tests;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.TabItems;
using Squirrel.Automation.Extensions;
using Squirrel.Automation.Test_Data;

namespace Squirrel.Automation.Pages
{
    public class MainPage
    {
        public Window MainWindow;
        //public static SearchCriteria GeneralTab = SearchCriteria.ByControlType(ControlType.TabItem).AndAutomationId("UpdateTab");
        private SearchCriteria _dailySetup = SearchCriteria.ByText("Daily Setup");//      ByControlType(ControlType.Text).AndByText("Daily Setup");
        private SearchCriteria _closeButton = SearchCriteria.ByAutomationId("Close");
        private Window _squirrelSystemMessageWindow;


        public MainPage(Window window)
        {
            MainWindow = window;
        }

        //BaseSetUp baseSetup = new BaseSetUp();
        public Menu GetMenuItem(string menuName)
        {
            //Menu bar
            MenuBar menubar = MainWindow.MenuBar; //   Tests.  test_mainWindow.MenuBar;

            //Selecting and click menu items
            //Menu menuitem = menubar.MenuItem("Settings", "Preferences...");
            Menu menuItem = menubar.MenuItemBy(SearchCriteria.ByText(menuName));
            /// menuitem.Click(); 

            //Searching and selecting menu items
            //menubar.MenuItemBy(SearchCriteria.ByText("Tools"), SearchCriteria.ByText("Change language")).Click();   //level1, level2
            return menuItem;
        }

        public void GetSubMenuItem(Menu menuItem, string childMenuItem)
        {
            UIItemList<Menu> menuItems = menuItem.ChildMenus;

            foreach (Menu menu in menuItems)
            {
                if (menu.Name == childMenuItem)
                {
                    Functions.ClickOnElement(menu);
                }
            }
        }

        public void SelectTabInAWindow()
        {
            //Window optionsWindow = mainWindow.ModalWindow("Options");
            //Tab tab = optionsWindow.Get<Tab>(SearchCriteria.ByControlType(ControlType.Tab).AndIndex(0));
            //var tabitem = tab.GetElement(SearchCriteria.ByControlType(ControlType.TabItem).AndAutomationId("Update Tab"));
            //tab.SelectTabPage("UpdateTab");
            //TabPage
            //optionsWindow.Get(GeneralTab).Click();
        }

        public void CloseApplicationUsingMenu()
        {
            //click on X button
            Functions.WaitTillUIItemVisible(MainWindow.Get<Button>(_closeButton));
            Functions.ClickOnElement(MainWindow.Get<Button>(_closeButton));
        }

        public void CloseApplicationUsingX()
        {
            //click on file menu
            Menu fileMenu = GetMenuItem("File");

            //click on Exit SourceTree option
            GetSubMenuItem(fileMenu, "Exit");
        }

        public void ClickDailySetup()
        {
            IUIItem dailySetup = MainWindow.Get(_dailySetup);
            Functions.WaitTillUIItemEnabled(dailySetup);
            Functions.ClickOnElement(MainWindow.Get(_dailySetup));
        }


        public void ExitApp()
        {
            _squirrelSystemMessageWindow = Functions.GetModelWindow(MainWindow, TestData.SquirrelSystemMessageDialog);
            //Functions.ClickOnElement(_squirrelSystemMessageWindow.Get<Button>(_yesButton));
        }

    }
}
