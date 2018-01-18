using Squirrel.Automation.Helpers;
using System;
using TestStack.White;
using TestStack.White.Configuration;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using NUnit.Framework;
using System.Windows.Automation;
using TestStack.White.WindowsAPI;
using System.Threading;
using NUnit.Framework.Interfaces;
using System.IO;
using Squirrel.Automation.Test_Data;
using System.Drawing.Imaging;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.Factory;

namespace Squirrel.Automation.Extensions
{
    public class Functions
    {
        private static Window _Window = Tests.TestSetUp.MainWindow;

        Functions()
        { }

        private static readonly log4net.ILog _Logger = LogHelper.GetLogger("Common Functions");
        //public static readonly int MonthsForProcurementDetails = ConfigurationManager.GetSection.Equals  AppSettings["MonthsForProcurementDetails"];
        //NameValueCollection PostSetting = ConfigurationManager.GetSection("BlogGroup/PostSetting") as NameValueCollection ;

        private AutomationElement _automationElement;

        public static void ClickOnElement(IUIItem uiItem)
        {
            try
            {
                _Logger.Info("Clicking on " + uiItem);
                uiItem.Click();
            }
            catch (Exception e)
            {
                _Logger.Info("Unable to click on " + uiItem);
                _Logger.Fatal(e);
                throw new Exception();
            }
        }

        public static void EnterText(string data, UIItem uiItem)
        {
            try
            {
                _Logger.Info("Entering " + data);
                uiItem.Enter(data);
                _Logger.Info(data + " entered");
            }
            catch (Exception e)
            {
                _Logger.Info("Unable to enter " + data);
                _Logger.Fatal("Error occured in SendTextInTextBox " + e.Message);
                //e.Message.ToString();
                //throw new Exception();
            }
        }

        //visible on the screen
        public static void WaitTillUIItemVisible(IUIItem uiItem, int? timeoutSecs = null)
        {
            int busyTimeout = int.Parse(CoreAppXmlConfiguration.Instance.BusyTimeout().TotalSeconds.ToString());
            timeoutSecs = new int?(timeoutSecs ?? busyTimeout);

            _Logger.DebugFormat("Waiting {0} seconds until element is visible.", new object[]
           {
                timeoutSecs
           });

            try
            {
                _Window.WaitTill(delegate () { return uiItem.Visible; }, TimeSpan.FromSeconds((double)timeoutSecs));
            }
            catch (Exception e)
            {
                _Logger.ErrorFormat("UIItem : " + uiItem + " Not visible after waiting for {0} seconds " + e.Message, timeoutSecs);
                throw e;
            }
        }

        //uiitem enabled or not
        public static void WaitTillUIItemEnabled(IUIItem uiItem, int? timeoutSecs = null)
        {
            string s = CoreAppXmlConfiguration.Instance.BusyTimeout().Seconds.ToString();
            int busyTimeout = int.Parse(s);
            timeoutSecs = new int?(timeoutSecs ?? busyTimeout);

            _Logger.DebugFormat("Waiting {0} seconds until element is enabled.", new object[]
           {
                timeoutSecs
           });

            try
            {
                _Window.WaitTill(delegate () { return uiItem.Enabled; }, TimeSpan.FromSeconds((double)timeoutSecs));
            }
            catch (Exception e)
            {
                _Logger.ErrorFormat("UIItem : " + uiItem + " Not enabled after waiting for {0} seconds " + e.Message, timeoutSecs);
            }
        }

        //that indicates whether the element has keyboard focus
        public static void WaitTillUIItemFocused(IUIItem uiItem, int? timeoutSecs = null)
        {
            int busyTimeout = int.Parse(CoreAppXmlConfiguration.Instance.BusyTimeout().ToString());
            timeoutSecs = new int?(timeoutSecs ?? busyTimeout);

            _Logger.DebugFormat("Waiting {0} seconds until element has keyboard focus.", new object[]
           {
                timeoutSecs
           });

            try
            {
                _Window.WaitTill(delegate () { return uiItem.IsFocussed; }, TimeSpan.FromSeconds((double)timeoutSecs));
            }
            catch (Exception e)
            {
                _Logger.ErrorFormat("UIItem : " + uiItem + " Not has keyboard focus after waiting for {0} seconds " + e.Message, timeoutSecs);
            }
        }

        public static void SelectCheckBox(CheckBox checkBox)
        {
            if (checkBox.IsSelected == false && checkBox.Checked == false)
            {
                checkBox.Select();
            }
           // Assert.That(checkBox.IsSelected, Is.True);
            //Assert.That(checkBox.Checked, Is.True);
        }

        public static void UnSelectCheckBox(CheckBox checkBox)
        {
            if (checkBox.IsSelected == true && checkBox.Checked == true)
            {
                checkBox.UnSelect();
            }
            //Assert.That(checkBox.IsSelected, Is.False);
            //Assert.That(checkBox.Checked, Is.False);
        }

        public static void SelectRadioButton(RadioButton radioButton)
        {
            try
            {
                if (radioButton.IsSelected == false)
                {
                    radioButton.Select();
                }
            }
            catch (AutomationException ex)
            {
                _Logger.Error(ex);
            }
            //Assert.That(radioButton.IsSelected, Is.True);
        }

        public static void CheckUncheckTristateCheckBox(CheckBox checkBox)
        {
            if (checkBox.State == ToggleState.Indeterminate)
            {
                checkBox.State = ToggleState.On;
            }
            //Assert.That(checkBox.State, Is.EqualTo(ToggleState.On));
            checkBox.State = ToggleState.On;
            checkBox.State = ToggleState.Off;
            //Assert.That(checkBox.State, Is.EqualTo(ToggleState.Off));
        }

        public static void SelectDropDownOption(ComboBox comboBox, string option)
        {
            try
            {
                ListBox dropdown =  SquirrelUIItemExtension.GetChildElement<ListBox>(comboBox);
                bool optionPresent = false;
                var dropdownOptions = dropdown.Items;

                foreach(ListItem options in dropdownOptions)
                {
                    if (options.Text.Equals(option))
                    {
                        optionPresent = true;
                        if (comboBox.SelectedItem != options)
                        {
                            comboBox.Select(option);
                        }
                    }
                }

                if (optionPresent == false)
                {
                    throw new AutomationException("The value " + option + "is not present in the drop-down", Debug.Details(comboBox.AutomationElement));
                }
            }
            catch (AutomationException ex)
            {
                _Logger.Error(ex);
                throw ex;
            }
            //Assert.That(radioButton.IsSelected, Is.True);
        }

        public void CopyTextFromTextBox(Window window, TextBox textBox)
        {
            var attachedKeyboard = window.Keyboard;
            attachedKeyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
            attachedKeyboard.Enter("ac");
            attachedKeyboard.LeaveKey(KeyboardInput.SpecialKeys.CONTROL);
        }

        public static void ClearTextBox(Window window, TextBox textBox)
        {
            if (textBox.Text == "")
                return;
            else
            {
                //textBox.SetValue(string.Empty);
                var attachedKeyboard = window.Keyboard;
                attachedKeyboard.HoldKey(KeyboardInput.SpecialKeys.CONTROL);
                attachedKeyboard.Enter("a");
                attachedKeyboard.LeaveKey(KeyboardInput.SpecialKeys.CONTROL);
                attachedKeyboard.PressSpecialKey(KeyboardInput.SpecialKeys.BACKSPACE);
                //CoreAppXmlConfiguration.Instance.BusyTimeout;
            }
        }

        private void PerformIfValid(System.Action action)
        {
            var startTime = DateTime.Now;
            var busyTimeout = CoreAppXmlConfiguration.Instance.BusyTimeout / 1000;
            while (DateTime.Now.Subtract(startTime).TotalSeconds < busyTimeout)
            {
                if (Enabled && !IsOffScreen)
                {
                    action();
                    return;
                }
                Thread.Sleep(500);
            }

            string message = null;
            if (!Enabled)
                message = "element not enabled";
            else if (IsOffScreen)
                message = "element is offscreen";

            throw new AutomationException(string.Format("Cannot perform action on {0}, {1}", this, message), Debug.Details(_automationElement));
        }

        public virtual bool Enabled
        {
            get { return _automationElement.Current.IsEnabled; }
        }

        public virtual bool IsOffScreen
        {
            get { return _automationElement.Current.IsOffscreen; }
        }

        //complete
        public static void SetText(UIItem uiItem, string value)
        {
            AutomationElement.AutomationElementInformation current = uiItem.AutomationElement.Current;
            AutomationException ex2;
            try
            {
                if (!current.IsEnabled)
                {
                    ex2 = new AutomationException("The control is not enabled.", Debug.Details(uiItem.AutomationElement));
                    _Logger.Error(ex2);
                    throw ex2;
                }

                current = uiItem.AutomationElement.Current;
                if (!current.IsKeyboardFocusable)
                {
                    ex2 = new AutomationException("The control is not focusable.", Debug.Details(uiItem.AutomationElement));
                    _Logger.Error(ex2);
                    throw ex2;
                }

                uiItem.Enter(value);
            }
            catch (AutomationException ex)
            {
                _Logger.ErrorFormat("Can not enter text in Textbox : " + uiItem + ex);
                throw ex;

            }
        }

        public static string CaptureScreen(TestStatus status, string fileName)
        {
            var testDir = TestContext.CurrentContext.TestDirectory;
            var parentTesttDir = Path.GetFullPath(Path.Combine(testDir, @"../../"));
            string screenshotPath = parentTesttDir + TestData.ArtifactsPath + fileName; //
            ImageFormat imageFormat = ImageFormat.Png;
            Desktop.TakeScreenshot(screenshotPath, imageFormat);
            return screenshotPath;
        }

        public static Window GetModelWindow(Window parentWindow, string windowName)
        {
            return parentWindow.ModalWindow(windowName, InitializeOption.NoCache);
        }

    }
}
