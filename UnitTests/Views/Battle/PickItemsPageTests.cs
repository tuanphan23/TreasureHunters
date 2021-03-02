using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game;
using Game.Views;
using Xamarin.Forms.Mocks;
using Xamarin.Forms;
using Game.ViewModels;
using Game.Models;

namespace UnitTests.Views
{
    [TestFixture]
    public class PickItemsPageTests
    {
        App app;
        PickItemsPage page;

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            // For now, set the engine to the Koenig Engine, change when ready 
            BattleEngineViewModel.Instance.SetBattleEngineToKoenig();

            page = new PickItemsPage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void PickItemsPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PickItemsPage_CloseButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.CloseButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void PickItemsPage_GetItemToDisplay_Invalid_Null_Should_Fail()
        {
            //Arrange

            //Act
            StackLayout result = page.GetItemToDisplay(null);
            //Reset

            //Assert
            //if this is a new StackLayout then it should have no children
            Assert.AreEqual(0, result.Children.Count);
        }

        [Test]
        public void PickItemsPage_GetItemToDisplay_Invalid_EmptyItemId_Should_Fail()
        {
            //Arrange
            ItemModel item = new ItemModel();
            item.Id = "";
            //Act
            StackLayout result = page.GetItemToDisplay(item);
            //Reset

            //Assert
            //if this is a new StackLayout then it should have no children
            Assert.AreEqual(0, result.Children.Count);
        }

        [Test]
        public void PickItemsPage_GetItemToDisplay_Invalid_NullItemId_Should_Fail()
        {
            //Arrange
            ItemModel item = new ItemModel();
            item.Id = null;
            //Act
            StackLayout result = page.GetItemToDisplay(item);
            //Reset

            //Assert
            //if this is a new StackLayout then it should have no children
            Assert.AreEqual(0, result.Children.Count);
        }


        [Test]
        public void PickItemsPage_GetItemToDisplay_IsValid_DefaultItem_Should_Pass()
        {
            //Arrange
            ItemModel item = new ItemModel();
            //Act
            StackLayout result = page.GetItemToDisplay(item);
            //Reset

            //Assert
            //Should have one child
            Assert.AreEqual(1, result.Children.Count);
            //check for the right image
            Assert.AreEqual(item.ImageURI, (result.Children[0] as ImageButton).Source);
        }
    }
}