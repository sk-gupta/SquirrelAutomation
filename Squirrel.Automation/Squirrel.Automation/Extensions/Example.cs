using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using System.Threading;
using TestStack.White.UIItems.Finders;
using NUnit.Framework;

namespace UITests
{
    [TestFixture]
    public class Example
    {
        //[Test]
        public void UI_EditUser()
        {
            Application application = ItemSelectors.GetWPFGridApp();

            //Find the main window
            Window mainWindow = ItemSelectors.MainWindow(application);

            //Select Item to edit
            ListView mainGrid = mainWindow.Get<ListView>(ItemSelectors.MainGrid);

            //Select the first row
            mainGrid.Rows[0].Cells[0].Click();

            //click edit button
            mainWindow.Get<Button>(ItemSelectors.EditButtonFinder).Click();

            //Find modal window
            Window editModalWindow = ItemSelectors.EditModal(application);

            //set new person name
            editModalWindow.Get<TextBox>(ItemSelectors.FirstNameTextboxFinder).SetValue("Bob");
            editModalWindow.Get<TextBox>(ItemSelectors.LastNameTextboxFinder).SetValue("Norris");

            //sleep for demo
            Thread.Sleep(1500);

            //click save
            editModalWindow.Get<Button>(ItemSelectors.SaveButtonFinder).Click();

            //mainGrid.Rows[0].Cells[1].Text.Should().Be("Bob");
            //mainGrid.Rows[0].Cells[2].Text.Should().Be("Norris");

            //sleep for demo
            Thread.Sleep(1500);

            //close the app
            application.Kill();


        }

        public T getButtonElement<T>(T t, SearchCriteria searchCriteria) where T : IUIItem
        {
            Application application = ItemSelectors.GetWPFGridApp();
            Window mainWindow = ItemSelectors.MainWindow(application);
            return mainWindow.Get<T>(searchCriteria);
        }


        //[Test]
        public void UI_AddUser()
        {

            //Button button = getButtonElement(button, ItemSelectors.FirstNameTextboxFinder);

            Application application = ItemSelectors.GetWPFGridApp();

            //Find the main window
            Window mainWindow = ItemSelectors.MainWindow(application);

            //click add button
            mainWindow.Get<Button>(ItemSelectors.AddButtonFinder).Click();

            //Find modal window
            Window editModalWindow = ItemSelectors.EditModal(application);

            //set new person name
            editModalWindow.Get<TextBox>(ItemSelectors.FirstNameTextboxFinder).SetValue("Bob");
            editModalWindow.Get<TextBox>(ItemSelectors.LastNameTextboxFinder).SetValue("Norris");

            //sleep for demo
            Thread.Sleep(1500);

            //click save
            editModalWindow.Get<Button>(ItemSelectors.SaveButtonFinder).Click();

            //Check for result in grid
            ListView mainGrid = mainWindow.Get<ListView>(ItemSelectors.MainGrid);

           // mainGrid.Rows[mainGrid.Items.Count - 1].Cells[1].Text.Should().Be("Bob");
            //mainGrid.Rows[mainGrid.Items.Count - 1].Cells[2].Text.Should().Be("Norris");

            //sleep for demo
            Thread.Sleep(1500);

            //close the app
            application.Kill();
        }

        //[Test]
        public void UI_DeleteUser()
        {
            //Get the app
            Application application = ItemSelectors.GetWPFGridApp();

            //Find the main window
            Window mainWindow = ItemSelectors.MainWindow(application);

            //Get grid to interact with it
            ListView mainGrid = mainWindow.Get<ListView>(ItemSelectors.MainGrid);

            //Select a row
            mainGrid.Rows[0].Cells[0].Click();

            //Delete it
            mainWindow.Get<Button>(ItemSelectors.DeleteButtonFinder).Click();

            //Make sure it's gone
            //mainGrid.Rows.Count.Should().Equals(0);

            //sleep for demo
            Thread.Sleep(1500);

            //close the app
            application.Kill();
        }

        //[Test]
        public void UI_ButtonStates()
        {
            //Get the app
            Application application = ItemSelectors.GetWPFGridApp();

            //Find the main window
            Window mainWindow = ItemSelectors.MainWindow(application);

            //Get grid to interact with it
            ListView mainGrid = mainWindow.Get<ListView>(ItemSelectors.MainGrid);

            //Get buttons
            Button addButton = mainWindow.Get<Button>(ItemSelectors.AddButtonFinder);
            Button editButton = mainWindow.Get<Button>(ItemSelectors.EditButtonFinder);
            Button deleteButton = mainWindow.Get<Button>(ItemSelectors.DeleteButtonFinder);

            //Check initial states
            //editButton.Enabled.Should().BeFalse();
            //deleteButton.Enabled.Should().BeFalse();
            //addButton.Enabled.Should().BeTrue();

            //Select a row
            mainGrid.Rows[0].Cells[0].Click();

            //sleep for demo
            Thread.Sleep(1500);

            //Check new states
            //editButton.Enabled.Should().BeTrue();
            //deleteButton.Enabled.Should().BeTrue();
            //addButton.Enabled.Should().BeTrue();

            //close the app
            application.Kill();
        }
    }
}