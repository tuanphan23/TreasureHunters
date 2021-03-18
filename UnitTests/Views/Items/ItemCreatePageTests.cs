using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;

namespace UnitTests.Views
{
    [TestFixture]
    public class ItemCreatePageTests : ItemCreatePage
    {
        App app;
        ItemCreatePage page;

        public ItemCreatePageTests() : base(true) { }
        
        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new ItemCreatePage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void ItemCreatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ItemCreatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_Save_Clicked_Null_Image_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.ImageURI = null;

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        //This test is unneeded as buttons are used for the update page instead of steppers
        //[Test]
        //public void ItemCreatePage_Value_OnStepperValueChanged_Default_Should_Pass()
        //{
        //    // Arrange

        //    page = new ItemCreatePage();
        //    double oldValue = 0.0;
        //    double newValue = 1.0;

        //    var args = new ValueChangedEventArgs(oldValue, newValue);

        //    // Act
        //    //page.Value_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(false); // Got to here, so it happened...
        //}

        //This test is unneeded as buttons are used for the update page instead of steppers
        //[Test]
        //public void ItemCreatePage_Range_OnStepperValueChanged_Default_Should_Pass()
        //{
        //    // Arrange

        //    page = new ItemCreatePage();
        //    double oldRange = 0.0;
        //    double newRange = 1.0;

        //    var args = new ValueChangedEventArgs(oldRange, newRange);

        //    // Act
        //    //page.Range_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(false); // Got to here, so it happened...
        //}

        //This test is unneeded as buttons are used for the update page instead of steppers
        //[Test]
        //public void ItemCreatePage_Damage_OnStepperDamageChanged_Default_Should_Pass()
        //{
        //    // Arrange
        //    page = new ItemCreatePage();
        //    double oldDamage = 0.0;
        //    double newDamage = 1.0;

        //    var args = new ValueChangedEventArgs(oldDamage, newDamage);

        //    // Act
        //    //page.Damage_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(false); // Got to here, so it happened...
        //}

        [Test]
        public void ItemCreatePage_ValueDownButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Value = 1;

            // Act
            page.ValueDownButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_ValueUpButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Value = 1;

            // Act
            page.ValueUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_SetEnableStateAttributeButtons_Test_Should_Pass()
        {
            //Arrange

            //Act
            var result = page.SetEnableStateAttributeButtons();

            //Reset

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ItemCreatePage_SaveClicked_Valid_Information_Should_Pass()
        {
            // Arrange
            page.FindByName<Picker>("AttributePicker").SelectedIndex = 1;
            page.FindByName<Picker>("LocationPicker").SelectedIndex = 1;
            page.FindByName<Entry>("Name").Text = "Mike";

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true);
        }
    }
}