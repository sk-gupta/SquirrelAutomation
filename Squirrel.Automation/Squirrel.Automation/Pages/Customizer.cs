using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.Finders;
using System.Windows.Automation;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.TabItems;
using Squirrel.Automation.Test_Data;
using Squirrel.Automation.Tests;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using Squirrel.Automation.Extensions;

namespace Squirrel.Automation.Pages
{
    public class Customizer : MainPage
    {
        public Customizer(Window window) : base(window)
        { }

        private Window _customizerDialog;

        private SearchCriteria _customizerTabs = SearchCriteria.ByAutomationId("12320").AndControlType(ControlType.Tab);
        //private static readonly SearchCriteria SystemConfigTab = SearchCriteria.ByText("System Config").AndControlType(ControlType.Tab);
        private SearchCriteria _customizerWindow = SearchCriteria.ByText("  Customizer").AndControlType(ControlType.Window);

        #region System Config tab
        private SearchCriteria _maximizedCheckBox = SearchCriteria.ByAutomationId("30200");
        private SearchCriteria _confirmCommitCheckBox = SearchCriteria.ByAutomationId("30201");

        private SearchCriteria _systemRadioButton = SearchCriteria.ByAutomationId("30231");
        private SearchCriteria _userRadioButton = SearchCriteria.ByAutomationId("30232");
        private SearchCriteria _systemFontButton = SearchCriteria.ByText("  Customizer").AndControlType(ControlType.Window);
        private SearchCriteria _storeDBSettingsLocalCheckBox = SearchCriteria.ByText("  Customizer").AndControlType(ControlType.Window);
        private SearchCriteria _copySeetingToLocalSystemCheckBox = SearchCriteria.ByText("  Customizer").AndControlType(ControlType.Window);
        public SearchCriteria _closeButton = SearchCriteria.ByAutomationId("Close").AndControlType(ControlType.Button);
        #endregion


        public void SelectACustomizerTab(string tabName)
        {
            if (_customizerDialog == null)
            {
                _customizerDialog = GetCustomizerDialog();
            }
            Tab customizerTabs = _customizerDialog.Get<Tab>(_customizerTabs);
            customizerTabs.SelectTabPage(tabName);
        }

        public Window GetCustomizerDialog()
        {
            List <Window> window = TestSetUp._application.GetWindows();

            foreach(Window win in window)
            {
                if (win.Title == TestData.CustomizerDialog)
                {
                    _customizerDialog = win;
                }
            }
            return _customizerDialog;
        }

        #region System Config tab

        public void UpdateSystemConfig()
        {
            SelectACustomizerTab(TestData.SystemConfigTab);
            var maximizedCheckBox = _customizerDialog.Get<CheckBox>(_maximizedCheckBox);
            var confirmCommitCheckBox = _customizerDialog.Get<CheckBox>(_confirmCommitCheckBox);
            Functions.SelectCheckBox(maximizedCheckBox);
            Functions.UnSelectCheckBox(maximizedCheckBox);
            Functions.SelectCheckBox(maximizedCheckBox);
            Functions.SelectCheckBox(confirmCommitCheckBox);
            Functions.UnSelectCheckBox(confirmCommitCheckBox);
            Functions.SelectCheckBox(confirmCommitCheckBox);
            Functions.SelectRadioButton(_customizerDialog.Get<RadioButton>(_systemRadioButton));
        }
        
        #endregion

        public void NavigateThroughtTabs()
        {
            SelectACustomizerTab(TestData.SystemConfigTab);
            SelectACustomizerTab(TestData.LanguageTab);
        }
        
        public void CloseCustomizerDialog()
        {
            Functions.ClickOnElement(_customizerDialog.Get<Button>(_closeButton));
        }
    }
}
