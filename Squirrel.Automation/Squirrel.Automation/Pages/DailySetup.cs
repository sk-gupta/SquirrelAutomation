using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Squirrel.Automation.Extensions;
using Squirrel.Automation;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White;
using TestStack.White.UIItems.WPFUIItems;
using System.Windows.Automation;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIA;
using Squirrel.Automation.Tests;
using TestStack.White.Factory;
using System.Threading;
using Squirrel.Automation.Test_Data;

namespace Squirrel.Automation.Pages
{
    public class DailySetup
    {
        protected Window _dailySetupwindow;
        private Window _squirrelSystemMessageWindow;

        public DailySetup(Window mainwindow)
        {
            _dailySetupwindow = mainwindow;
        }

        #region Seach Criteria
        
        private SearchCriteria _dailySetupPane = SearchCriteria.ByControlType(ControlType.Pane).AndByText("Daily Setup - Individual Links");
        private SearchCriteria _dailySetupCategories = SearchCriteria.ByControlType(ControlType.List);

        #region Toolbar
        protected SearchCriteria _newRecordButton = SearchCriteria.ByAutomationId("Item 32542");
        protected SearchCriteria _saveRecordButton = SearchCriteria.ByAutomationId("Item 32545");
        protected SearchCriteria _deleteRecordButton = SearchCriteria.ByAutomationId("Item 32543");
        protected SearchCriteria _explorerWindow = SearchCriteria.ByAutomationId("Item 32305");
        #endregion
        
        #region Squirrel System Message Dialogue
        private SearchCriteria _yesButton = SearchCriteria.ByAutomationId("1");
        private SearchCriteria _noButton = SearchCriteria.ByAutomationId("7");
        private SearchCriteria _cancelDialogueButton = SearchCriteria.ByAutomationId("2");
        private SearchCriteria _closeButton = SearchCriteria.ByAutomationId("Close");
        #endregion


        //public Window window = TestSetUp._mainWindow;


        #endregion


        public IUIItem[] GetAllSetupCategory()
        {
            var dailySetupPane = _dailySetupwindow.Get(_dailySetupPane);  //panel

            IUIItem[] dailySetupCategories = dailySetupPane.GetMultiple(_dailySetupCategories); //IUIItem[]
            
            return dailySetupCategories;

        }

      
        public void OptionsInASetupCategory(IUIItem[] allSetUpCategories, string categoryName, string categoryOption)
        {

            var element = allSetUpCategories.ElementAt(3).Get<ListBox>(SearchCriteria.All);  //listbox

            var item = element.Get(SearchCriteria.Indexed(1));  //hyperlink
        }

       
        public void GetSubSetupCategory(string CategoryName, string subCategoryName)
        {
            var dailySetupPane = _dailySetupwindow.Get(_dailySetupPane);

            Condition conditions = new AndCondition(
                new PropertyCondition(AutomationElement.NameProperty, CategoryName),
                new PropertyCondition(AutomationElement.ControlTypeProperty,
                    ControlType.Text)
                );

            AutomationElement  firstList = dailySetupPane.AutomationElement.FindFirst(TreeScope.Descendants, conditions);

            ListBox listBoxTest = SquirrelUIItemExtension.GetParentElement<ListBox>(firstList, dailySetupPane);
            listBoxTest.Get(SearchCriteria.ByControlType(ControlType.Hyperlink).AndByText(subCategoryName)).Click();
            
        }

        protected string GetRandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        protected string GetRandomNumber(int max)
        {
            Random random = new Random();
            return random.Next(max).ToString();
        }


        public void SaveAndExitForm()
        {
            //Functions.WaitTillUIItemVisible();
            Functions.ClickOnElement(_dailySetupwindow.Get<Button>(_saveRecordButton));
            Functions.ClickOnElement(_dailySetupwindow.Get<Button>(_explorerWindow));
            Wait.For(TimeSpan.FromSeconds(2));
            _squirrelSystemMessageWindow = Functions.GetModelWindow(_dailySetupwindow, TestData.SquirrelSystemMessageDialog);
            Functions.ClickOnElement(_squirrelSystemMessageWindow.Get<Button>(_yesButton));
        }


        public IEnumerable<ListBox> GetList(List< IUIItem> list, string listitem)
        {
           foreach (ListBox item in list)
            {
                foreach (ListItem item2 in item.Items)
                {
                    if (item2.Name.Equals(listitem))
                    {
                       yield return item;
                       break;
                    }
                }
            }
        }
    }
}
