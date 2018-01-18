using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using Squirrel.Automation.Extensions;
using TestStack.White.UIItems;
using TestStack.White.Factory;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WPFUIItems;
using Squirrel.Automation.Test_Data;

namespace Squirrel.Automation.Pages
{
    public class EmployeeSetup : DailySetup
    {

        public EmployeeSetup(Window window) : base(window)
        { }

        private Window _editBadgeWindow;

        #region Daily Setup Window elements
        private SearchCriteria _firstNameTextBox= SearchCriteria.ByAutomationId("902");
        private SearchCriteria _lastNameTextBox = SearchCriteria.ByAutomationId("903");
        private SearchCriteria _employeeNumberTextBox = SearchCriteria.ByAutomationId("901");
        private SearchCriteria _sINTextBox = SearchCriteria.ByAutomationId("904");
        private SearchCriteria _address1TextBox = SearchCriteria.ByAutomationId("907"); 
        private SearchCriteria _address2TextBox = SearchCriteria.ByAutomationId("908");
        private SearchCriteria _provinceTextBox = SearchCriteria.ByAutomationId("905");
        private SearchCriteria _cityTextBox = SearchCriteria.ByAutomationId("909");
        private SearchCriteria _leftHandedCheckBox = SearchCriteria.ByAutomationId("1000");
        private SearchCriteria _postalCodeTextBox = SearchCriteria.ByAutomationId("910");
        private SearchCriteria _phoneNumberTextBox = SearchCriteria.ByAutomationId("911");
        private SearchCriteria _birthDate = SearchCriteria.ByAutomationId("915");
        private SearchCriteria _firstDay = SearchCriteria.ByAutomationId("916");
        private SearchCriteria _lastDay = SearchCriteria.ByAutomationId("917");

        private SearchCriteria _addButton = SearchCriteria.ByAutomationId("1069");
        private SearchCriteria _deleteButton = SearchCriteria.ByAutomationId("1070");
        private SearchCriteria _editButton = SearchCriteria.ByAutomationId("1071");
        private SearchCriteria _reassignButton = SearchCriteria.ByAutomationId("1072");
        #endregion

        #region EditBadgeInformation
        private SearchCriteria _badgeNumber = SearchCriteria.ByAutomationId("901");
        private SearchCriteria _badgeName = SearchCriteria.ByAutomationId("903");
        private SearchCriteria _pOSAccessGroup = SearchCriteria.ByAutomationId("1030");
        private SearchCriteria _defaultScreen = SearchCriteria.ByAutomationId("1032");
        private SearchCriteria _defaultTab = SearchCriteria.ByAutomationId("1031");
        private SearchCriteria _securityGroup = SearchCriteria.ByAutomationId("1033");
        private SearchCriteria _oKButton = SearchCriteria.ByAutomationId("1");
        private SearchCriteria _cancelButton = SearchCriteria.ByAutomationId("2");

        //window Edit Badge Information
        #endregion

       
        public void AddNewRecord()
        {
            Functions.ClickOnElement(_dailySetupwindow.Get<Button>(_newRecordButton));
            Functions.ClickOnElement(_dailySetupwindow.Get<Button>(_addButton));
        }

        public void FillBadgeInformation()
        {
            _editBadgeWindow = Functions.GetModelWindow(_dailySetupwindow, TestData.EditBadgeInformationDialog);

            //Random random = new Random();
            //int number = random.Next();

            //StringBuilder builder = new StringBuilder();


            //Functions.EnterTextInTextBox(RandomNumber(10000), editBadgeWindow.Get(BadgeNumber));
            //Functions.EnterTextInTextBox(RandomString(10), editBadgeWindow.Get(BadgeName));

            Functions.SetText(_editBadgeWindow.Get<TextBox>(_badgeNumber), GetRandomNumber(10000));
            Functions.SetText(_editBadgeWindow.Get<TextBox>(_badgeName), GetRandomString(10));
            //select option from drop-down
            //ComboBox pOSAccessGroup = editBadgeWindow.Get<ComboBox>(POSAccessGroup);
            //ComboBox defaultScreen = editBadgeWindow.Get<ComboBox>(DefaultScreen);
            //ComboBox defaultTab = editBadgeWindow.Get<ComboBox>(DefaultTab);
            //ComboBox securityGroup = editBadgeWindow.Get<ComboBox>(SecurityGroup);

            //_editBadgeWindow.Get<ComboBox>(_pOSAccessGroup).Select(TestData.POSAccessGroup);

            var dropdown = _editBadgeWindow.Get<ComboBox>(_pOSAccessGroup);
            Functions.SelectDropDownOption(dropdown, "ss");

            _editBadgeWindow.Get<ComboBox>(_defaultScreen).Select(TestData.DefaultScreen);
            _editBadgeWindow.Get<ComboBox>(_defaultTab).Select(TestData.DefaultTab);
            _editBadgeWindow.Get<ComboBox>(_securityGroup).Select(TestData.SecurityGroup);
            Functions.ClickOnElement(_editBadgeWindow.Get<Button>(_oKButton));
        }

        public void FillEmployeeInformation()
        {
            Functions.SetText(GetTextBox(_firstNameTextBox), TestData.FirstName);
            Functions.SetText(GetTextBox(_lastNameTextBox), TestData.LastName);
            Functions.SetText(GetTextBox(_employeeNumberTextBox), GetRandomNumber(1000));
            Functions.SetText(GetTextBox(_cityTextBox), TestData.City);
            Functions.SetText(GetTextBox(_cityTextBox), TestData.City);

            //Functions.EnterTextInTextBox(TestData.LastName, dailySetupwindow.Get(LastNameTextBox));
            //Functions.EnterTextInTextBox(RandomNumber(1000), dailySetupwindow.Get(EmployeeNumberTextBox));
            //Functions.EnterTextInTextBox(TestData.City, dailySetupwindow.Get(CityTextBox));
            //Functions.EnterTextInTextBox(TestData.BirthDate, dailySetupwindow.Get(BirthDate));
        }

       private TextBox GetTextBox(SearchCriteria searchCriteria)
        {
            return _dailySetupwindow.Get<TextBox>(searchCriteria);
        }

        private ComboBox GetDropDown(SearchCriteria searchCriteria)
        {
            return _dailySetupwindow.Get<ComboBox>(searchCriteria);
        }
    }
}
