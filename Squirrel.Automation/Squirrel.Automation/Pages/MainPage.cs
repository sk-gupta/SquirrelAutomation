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
        private Window _mainWindow;
        private Window _squirrelSystemMessageWindow;

        //public static SearchCriteria GeneralTab = SearchCriteria.ByControlType(ControlType.TabItem).AndAutomationId("UpdateTab");
        private SearchCriteria _dailySetup = SearchCriteria.ByText("Daily Setup");//      ByControlType(ControlType.Text).AndByText("Daily Setup");
        private SearchCriteria _closeButton = SearchCriteria.ByAutomationId("Close");
        private SearchCriteria _yesButton = SearchCriteria.ByAutomationId("1");

        #region Toolbar
        public static SearchCriteria _newRecordButton = SearchCriteria.ByAutomationId("Item 32542");
        public static SearchCriteria _saveRecordButton = SearchCriteria.ByAutomationId("Item 32545");
        public static SearchCriteria _deleteRecordButton = SearchCriteria.ByAutomationId("Item 32543");
        public static SearchCriteria _explorerWindow = SearchCriteria.ByAutomationId("Item 32305");
        #endregion
        
        public MainPage(Window window)
        {
            _mainWindow = window;
        }

        public Menu GetMenuItem(string menuName)
        {
            //Menu bar
            MenuBar menubar = _mainWindow.MenuBar;

            //Selecting and click menu items
            //Menu menuitem = menubar.MenuItem("Settings", "Preferences..."); or
            Menu menuItem = menubar.MenuItemBy(SearchCriteria.ByText(menuName));

            //Searching and selecting menu items
            //menubar.MenuItemBy(SearchCriteria.ByText("Tools"), SearchCriteria.ByText("Change language")).Click();   //level1, level2
            return menuItem;
        }

        public void GetSubMenuItem(Menu menuItem, string childMenuItem)
        {
            menuItem.SubMenu(childMenuItem).Click();
            Wait.For(TimeSpan.FromMilliseconds(100));

            //Use below code if above code doesn't work

            //UIItemList<Menu> menuItems = menuItem.ChildMenus;
            //foreach (Menu menu in menuItems)
            //{
            //    if (menu.Name == childMenuItem)
            //    {
            //        Functions.ClickOnElement(menu);
            //    }
            //}
        }
        
        public void CloseApplicationUsingMenu()
        {
            //click on X button
            Functions.WaitTillUIItemVisible(_mainWindow, _mainWindow.Get<Button>(_closeButton));
            Functions.ClickOnElement(_mainWindow.Get<Button>(_closeButton));
            Wait.For(TimeSpan.FromSeconds(1));
            ExitApp();
        }

        public void CloseApplicationUsingX()
        {
            //click on file menu
            Menu fileMenu = GetMenuItem("File");

            //click on Exit SourceTree option
            GetSubMenuItem(fileMenu, "Exit");
            Wait.For(TimeSpan.FromSeconds(1));
            ExitApp();
        }

        public void ClickDailySetup()
        {
            Functions.WaitTillUIItemVisible(_mainWindow,_mainWindow.Get(_dailySetup));
            IUIItem dailySetup = _mainWindow.Get(_dailySetup);
            Functions.WaitTillUIItemEnabled(_mainWindow,dailySetup);
            Functions.ClickOnElement(_mainWindow.Get(_dailySetup));
        }
        
        public void ExitApp()
        {
            _squirrelSystemMessageWindow = Functions.GetModelWindow(_mainWindow, TestData.SquirrelSystemMessageDialog);
            Functions.ClickOnElement(_squirrelSystemMessageWindow.Get<Button>(_yesButton));
        }
    }
}
