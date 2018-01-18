using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace UITests
{
    public static class ItemSelectors
    {
        public static Application GetWPFGridApp()
        {
            return Application.Launch(
                new ProcessStartInfo(@"WPFGrid.exe")
                {
                    WorkingDirectory = @"..\..\..\WPFGrid\bin\Debug\",
                });
        }

        #region Main Window
        public static Window MainWindow(Application application)
        {
            return application.GetWindow("WPFGrid", InitializeOption.NoCache);
        }

        #region Buttons
        public static SearchCriteria AddButtonFinder = SearchCriteria.ByControlType(ControlType.Button).AndAutomationId("AddButton");
        public static SearchCriteria EditButtonFinder = SearchCriteria.ByControlType(ControlType.Button).AndAutomationId("EditButton");
        public static SearchCriteria DeleteButtonFinder = SearchCriteria.ByControlType(ControlType.Button).AndAutomationId("DeleteButton");
        #endregion

        #region Grids
        public static SearchCriteria MainGrid = SearchCriteria.ByAutomationId("MainGrid");

        #endregion

        #endregion

        #region Edit Modal Window
        public static Window EditModal(Application application)
        {
            return application.GetWindow("EditPerson", InitializeOption.NoCache);
        }

        #region Buttons
        public static SearchCriteria SaveButtonFinder = SearchCriteria.ByControlType(ControlType.Button).AndAutomationId("SaveButton");
        #endregion

        #region Textboxes
        public static SearchCriteria FirstNameTextboxFinder = SearchCriteria.ByAutomationId("FirstNameTextbox");
        public static SearchCriteria LastNameTextboxFinder = SearchCriteria.ByAutomationId("LastNameTextbox");
        #endregion

        #endregion

    }
}