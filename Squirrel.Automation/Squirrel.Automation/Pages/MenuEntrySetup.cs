using Squirrel.Automation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using Squirrel.Automation.Test_Data;

namespace Squirrel.Automation.Pages
{
    public class MenuEntrySetup : DailySetup
    {
        public MenuEntrySetup(Window window) : base(window)
        { }

        //private Window editBadgeWindow;
        //private Window choicesMessageDialog;
        //private Window menuEntryPriceDialog;
        //private Window squirrelCurrencyEditorDialog;

        #region Menu Entry Setup region
        private SearchCriteria _menuEntryNameTextBox = SearchCriteria.ByAutomationId("901");
        private SearchCriteria _barCodeUPCTextBox = SearchCriteria.ByAutomationId("903");   //unique
        private SearchCriteria _pluNumberTextBox = SearchCriteria.ByAutomationId("906");
        private SearchCriteria _recipeCostTextBox = SearchCriteria.ByAutomationId("902");
        private SearchCriteria _recipeCostEditorButton = SearchCriteria.ByAutomationId("32343");
        private SearchCriteria _openPriceCheckBox = SearchCriteria.ByAutomationId("1003");
        private SearchCriteria _openNameCheckBox = SearchCriteria.ByAutomationId("1002");
        private SearchCriteria _itemRadioOption = SearchCriteria.ByAutomationId("1051");
        private SearchCriteria _barPourCheckBox = SearchCriteria.ByAutomationId("1000");
        private SearchCriteria _comboRadioOption = SearchCriteria.ByAutomationId("1059");
        private SearchCriteria _departmentTextBox = SearchCriteria.ByAutomationId("911");
        private SearchCriteria _categoryTextBox = SearchCriteria.ByAutomationId("910");
        private SearchCriteria _cookTimeTextBox = SearchCriteria.ByClassName("MSMaskWndClass");
        private SearchCriteria _priceListDataGrid = SearchCriteria.ByAutomationId("1071");
        private SearchCriteria _regularDataItem = SearchCriteria.ByText("REGULAR         ");
        private SearchCriteria _happyHourDataItem = SearchCriteria.ByText("HAPPY HOUR      ");
        #endregion

        #region Choices message dialog
        private SearchCriteria _yesButton = SearchCriteria.ByAutomationId("1");
        private SearchCriteria _noButton = SearchCriteria.ByAutomationId("7");
        private SearchCriteria _closeButton = SearchCriteria.ByAutomationId("Close");
        #endregion

        #region Menu entry price dialog
        private SearchCriteria _oKButton = SearchCriteria.ByAutomationId("1");
        private SearchCriteria _cancelButton = SearchCriteria.ByAutomationId("2");
        private SearchCriteria _amountTextBox = SearchCriteria.ByAutomationId("904");
        private static SearchCriteria _AmountEditorButton = SearchCriteria.ByAutomationId("32343");
        #endregion

        #region Currency editor dialog
        private SearchCriteria _editorOKButton = SearchCriteria.ByAutomationId("1");
        private SearchCriteria _editorCancelButton = SearchCriteria.ByAutomationId("2");
        private SearchCriteria _editorCloseButton = SearchCriteria.ByAutomationId("Close");
        private SearchCriteria _editorAmountTextBox = SearchCriteria.ByAutomationId("30251");

        private SearchCriteria _zeroButton = SearchCriteria.ByAutomationId("30280");
        private SearchCriteria _oneButton = SearchCriteria.ByAutomationId("30281");
        private SearchCriteria _twoButton = SearchCriteria.ByAutomationId("30282");
        private SearchCriteria _threeButton = SearchCriteria.ByAutomationId("30283");
        private SearchCriteria _fourButton = SearchCriteria.ByAutomationId("30284");
        private SearchCriteria _fiveButton = SearchCriteria.ByAutomationId("30285");
        private SearchCriteria _sixButton = SearchCriteria.ByAutomationId("30286");
        private SearchCriteria _sevenButton = SearchCriteria.ByAutomationId("30287");
        private SearchCriteria _eightButton = SearchCriteria.ByAutomationId("30288");
        private SearchCriteria _nineButton = SearchCriteria.ByAutomationId("30289");
        private SearchCriteria _pointButton = SearchCriteria.ByAutomationId("30291");
        private SearchCriteria _plusMinusButton = SearchCriteria.ByAutomationId("30290");
        #endregion

        #region Menu entry information group
        private SearchCriteria _inhibitAlwaysCheckBox = SearchCriteria.ByAutomationId("1004");
        private SearchCriteria _displayReplacementEntryCheckBox = SearchCriteria.ByAutomationId("1005");
        private SearchCriteria _alternateNameTextBox = SearchCriteria.ByAutomationId("907");
        private SearchCriteria _onScreenNameTextBox = SearchCriteria.ByAutomationId("909");
        private SearchCriteria _taxGroupDropdown = SearchCriteria.ByAutomationId("1036");
        private SearchCriteria _printerRouterLetterDropdown = SearchCriteria.ByAutomationId("1037");
        private SearchCriteria _popUpGroupDropdown = SearchCriteria.ByAutomationId("1038");
        private SearchCriteria _callOrderTextBox = SearchCriteria.ByAutomationId("905");
        #endregion


        public void AddNewRecord()
        {
            Functions.ClickOnElement(_dailySetupwindow.Get<Button>(_newRecordButton));
        }

        public void FillMenuEnteryDetails()
        {
            var menuEntrySetup = _dailySetupwindow.Get(_menuEntryNameTextBox);

            Functions.SetText(_dailySetupwindow.Get<TextBox>(_menuEntryNameTextBox), GetRandomString(TestData.LengthBarCodeUPC));
            Functions.SetText(_dailySetupwindow.Get<TextBox>(_barCodeUPCTextBox), GetRandomString(TestData.LengthBarCodeUPC));
            Functions.SetText(_dailySetupwindow.Get<TextBox>(_pluNumberTextBox), GetRandomNumber(TestData.MaxValuePLUNumber));
            Functions.SetText(_dailySetupwindow.Get<TextBox>(_recipeCostTextBox), TestData.RecipeCost);
            Functions.ClickOnElement(_dailySetupwindow.Get<Button>(_recipeCostEditorButton));

            var recipeCostEditorDialog = Functions.GetModelWindow(_dailySetupwindow, TestData.SquirrelCurrencyEditorDialog);

            var editorAmount = recipeCostEditorDialog.Get<TextBox>(_editorAmountTextBox);
            //var attachedKeyboard = dailySetupwindow.Keyboard;
            //textbox.RaiseClickEvent();
            // attachedKeyboard.HoldKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.BACKSPACE);
            //attachedKeyboard.Enter("a");
            //attachedKeyboard.LeaveKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.BACKSPACE);
            //attachedKeyboard.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.BACKSPACE);
            //HoldKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.BACKSPACE);
            Functions.ClearTextBox(_dailySetupwindow, editorAmount);

            //textbox.RaiseClickEvent(); 
            editorAmount.Text = "21";// textbox.Text = "";

            //WindowExtensions.SendTextInTextBox("", recipeCostEditor.Get(EditorAmountTextBox));
            Functions.ClickOnElement(recipeCostEditorDialog.Get<Button>(_oneButton));
            Functions.ClickOnElement(recipeCostEditorDialog.Get<Button>(_oKButton));

            _dailySetupwindow.Get<CheckBox>(_openNameCheckBox).Select();
            _dailySetupwindow.Get<CheckBox>(_barPourCheckBox).Select();
            //dailySetupwindow.Get<RadioButton>(ItemRadioOption).Select();
            Functions.SelectRadioButton(_dailySetupwindow.Get<RadioButton>(_itemRadioOption));
            _dailySetupwindow.Get<RadioButton>(_comboRadioOption).Select();
            _dailySetupwindow.Get<RadioButton>(_itemRadioOption).Select();


            var choicesMessageDialog = Functions.GetModelWindow(_dailySetupwindow, TestData.SquirrelSystemMessageDialog);

            Functions.ClickOnElement(choicesMessageDialog.Get<Button>(_yesButton));
            Functions.SetText(_dailySetupwindow.Get<TextBox>(_departmentTextBox), TestData.Department);
            Functions.SetText(_dailySetupwindow.Get<TextBox>(_categoryTextBox), TestData.Category);
            Functions.SetText(_dailySetupwindow.Get<TextBox>(_cookTimeTextBox), TestData.CookTime);

            ListViewRow regularDataItem = _dailySetupwindow.Get<ListViewRow>(_regularDataItem);
            regularDataItem.DoubleClick();

            var menuEntryPriceDialog = Functions.GetModelWindow(_dailySetupwindow, TestData.MenuEntryPriceDialog);

            Functions.SetText(menuEntryPriceDialog.Get<TextBox>(_amountTextBox), TestData.Amount);
            Functions.ClickOnElement(menuEntryPriceDialog.Get<Button>(_AmountEditorButton));

            var currencyEditorDialog = menuEntryPriceDialog.ModalWindow(TestData.SquirrelCurrencyEditorDialog); // GetModelWindow("Squirrel Currency Editor");
            //currencyEditorDialog.Get<TextBox>(EditorAmountTextBox).Text = "";

            Functions.SetText(currencyEditorDialog.Get<TextBox>(_editorAmountTextBox), TestData.EditorAmount);
            Functions.ClickOnElement(currencyEditorDialog.Get<Button>(_oneButton));
            Functions.ClickOnElement(currencyEditorDialog.Get<Button>(_editorOKButton));

            Functions.ClickOnElement(menuEntryPriceDialog.Get<Button>(_oKButton));

            _dailySetupwindow.Get<CheckBox>(_inhibitAlwaysCheckBox).Select();
            _dailySetupwindow.Get<CheckBox>(_inhibitAlwaysCheckBox).Select();

            Functions.SetText(_dailySetupwindow.Get<TextBox>(_alternateNameTextBox), TestData.AlternateName);
            Functions.SetText(_dailySetupwindow.Get<TextBox>(_onScreenNameTextBox), TestData.OnScreenName);

            _dailySetupwindow.Get<ComboBox>(_taxGroupDropdown).Select(TestData.TaxGroupValue);
            _dailySetupwindow.Get<ComboBox>(_printerRouterLetterDropdown).Select(TestData.PrinterRouterLetterValue);
            _dailySetupwindow.Get<ComboBox>(_popUpGroupDropdown).Select(TestData.PopUpGroupVaue);
            Functions.SetText(_dailySetupwindow.Get<TextBox>(_callOrderTextBox), TestData.CallOrder);
            Wait.For(TimeSpan.FromSeconds(2));
        }


        public void test()
        {
            ListView list = _dailySetupwindow.Get<ListView>(_nineButton);
        }

    }
}
