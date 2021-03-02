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
using Game.GameRules;

namespace UnitTests.Views
{
    [TestFixture]
    public class CharacterCreatePageTests : CharacterCreatePage
    {
        App app;
        CharacterCreatePage page;

        public CharacterCreatePageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            //page = new CharacterCreatePage(new GenericViewModel<CharacterModel>(new CharacterModel()));
            page = new CharacterCreatePage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void CharacterCreatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CharacterCreatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Save_Clicked_Null_Image_Should_Pass()
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
        public void CharacterCreatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Attack_OnStepperAttackChanged_Default_Should_Pass()
        {
            // Arrange
            //var data = new CharacterModel();
            //var ViewModel = new GenericViewModel<CharacterModel>(data);

            page = new CharacterCreatePage();
            double oldAttack = 0.0;
            double newAttack = 1.0;

            var args = new ValueChangedEventArgs(oldAttack, newAttack);

            // Act
            page.Attack_OnStepperValueChanged(null, args);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Speed_OnStepperValueChanged_Default_Should_Pass()
        {
            // ArSpeed
            //var data = new CharacterModel();
            //var ViewModel = new GenericViewModel<CharacterModel>(data);

            page = new CharacterCreatePage();
            double oldSpeed = 0.0;
            double newSpeed = 1.0;

            var args = new ValueChangedEventArgs(oldSpeed, newSpeed);

            // Act
            page.Speed_OnStepperValueChanged(null, args);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Defense_OnStepperDefenseChanged_Default_Should_Pass()
        {
            // Arrange
            //var data = new CharacterModel();
            //var ViewModel = new GenericViewModel<CharacterModel>(data);

            page = new CharacterCreatePage();
            double oldDefense = 0.0;
            double newDefense = 1.0;

            var args = new ValueChangedEventArgs(oldDefense, newDefense);

            // Act
            page.Defense_OnStepperValueChanged(null, args);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_RandomButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data = new CharacterModel();

            // Act
            page.RandomButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClosePopup_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ClosePopup();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClosePopup_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ClosePopup_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ShowPopup_Default_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data = new CharacterModel();

            // Act
            page.ShowPopup(ItemLocationEnum.PrimaryHand);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnPopupItemSelected_Clicked_Default_Should_Pass()
        {
            // Arrange

            var data = new ItemModel();

            var selectedCharacterChangedEventArgs = new SelectedItemChangedEventArgs(data, 0);

            // Act
            page.OnPopupItemSelected(null, selectedCharacterChangedEventArgs);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnPopupItemSelected_Clicked_Null_Should_Fail()
        {
            // Arrange

            var selectedCharacterChangedEventArgs = new SelectedItemChangedEventArgs(null, 0);

            // Act
            page.OnPopupItemSelected(null, selectedCharacterChangedEventArgs);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Item_ShowPopup_Default_Should_Pass()
        {
            // Arrange

            var item = page.GetItemToDisplay(ItemLocationEnum.PrimaryHand);

            // Act
            var itemButton = item.Children.FirstOrDefault(m => m.GetType().Name.Equals("Button"));

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCratePage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        {
            // Arrange
            var item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.PrimaryHand);
            page.ViewModel.Data.Head = item.Id;
            var StackItem = page.GetItemToDisplay(ItemLocationEnum.PrimaryHand);
            var dataImage = StackItem.Children[0];

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_RandomButton_Clicked_Vaid_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.ImageURI = null;

            // Act
            page.RandomButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        #region popupDataSwitch
        [Test]
        public void CharacterCreatPage_OnPopupItemSelected_Head_Valid_Should_Pass()
        {
            //Arrange
            page.ViewModel.Data.Head = "";
            ItemModel item = new ItemModel();
            item.Location = ItemLocationEnum.Head;
            item.Id = "testId";
            SelectedItemChangedEventArgs args = new SelectedItemChangedEventArgs(item, 0);
            //Act
            page.OnPopupItemSelected(null, args);
            //Reset

            //Assert
            Assert.AreEqual(page.ViewModel.Data.Head, "testId");
        }

        [Test]
        public void CharacterCreatPage_OnPopupItemSelected_Feet_Valid_Should_Pass()
        {
            //Arrange
            page.ViewModel.Data.Feet = "";
            ItemModel item = new ItemModel();
            item.Location = ItemLocationEnum.Feet;
            item.Id = "testId";
            SelectedItemChangedEventArgs args = new SelectedItemChangedEventArgs(item, 0);
            //Act
            page.OnPopupItemSelected(null, args);
            //Reset

            //Assert
            Assert.AreEqual(page.ViewModel.Data.Feet, "testId");
        }

        [Test]
        public void CharacterCreatPage_OnPopupItemSelected_LeftFinger_Valid_Should_Pass()
        {
            //Arrange
            page.ViewModel.Data.LeftFinger = "";
            ItemModel item = new ItemModel();
            item.Location = ItemLocationEnum.LeftFinger;
            item.Id = "testId";
            SelectedItemChangedEventArgs args = new SelectedItemChangedEventArgs(item, 0);
            //Act
            page.OnPopupItemSelected(null, args);
            //Reset

            //Assert
            Assert.AreEqual(page.ViewModel.Data.LeftFinger, "testId");
        }

        [Test]
        public void CharacterCreatPage_OnPopupItemSelected_RightFinger_Valid_Should_Pass()
        {
            //Arrange
            page.ViewModel.Data.RightFinger = "";
            ItemModel item = new ItemModel();
            item.Location = ItemLocationEnum.RightFinger;
            item.Id = "testId";
            SelectedItemChangedEventArgs args = new SelectedItemChangedEventArgs(item, 0);
            //Act
            page.OnPopupItemSelected(null, args);
            //Reset

            //Assert
            Assert.AreEqual(page.ViewModel.Data.RightFinger, "testId");
        }

        [Test]
        public void CharacterCreatPage_OnPopupItemSelected_Necklass_Valid_Should_Pass()
        {
            //Arrange
            page.ViewModel.Data.Necklass = "";
            ItemModel item = new ItemModel();
            item.Location = ItemLocationEnum.Necklass;
            item.Id = "testId";
            SelectedItemChangedEventArgs args = new SelectedItemChangedEventArgs(item, 0);
            //Act
            page.OnPopupItemSelected(null, args);
            //Reset

            //Assert
            Assert.AreEqual(page.ViewModel.Data.Necklass, "testId");
        }

        [Test]
        public void CharacterCreatPage_OnPopupItemSelected_OffHand_Valid_Should_Pass()
        {
            //Arrange
            page.ViewModel.Data.OffHand = "";
            ItemModel item = new ItemModel();
            item.Location = ItemLocationEnum.OffHand;
            item.Id = "testId";
            SelectedItemChangedEventArgs args = new SelectedItemChangedEventArgs(item, 0);
            //Act
            page.OnPopupItemSelected(null, args);
            //Reset

            //Assert
            Assert.AreEqual(page.ViewModel.Data.OffHand, "testId");
        }

        [Test]
        public void CharacterCreatPage_OnPopupItemSelected_Finger_Valid_Should_Pass()
        {
            //Arrange
            ItemModel item = new ItemModel();
            item.Location = ItemLocationEnum.Finger;
            item.Id = "testId";
            SelectedItemChangedEventArgs args = new SelectedItemChangedEventArgs(item, 0);
            //Act
            page.OnPopupItemSelected(null, args);
            //Reset

            //Assert
            //nothing should have changed so if there are no errors this should pass
            Assert.AreEqual(0, 0);
        }

        [Test]
        public void CharacterCreatPage_OnPopupItemSelected_Unknown_Valid_Should_Pass()
        {
            //Arrange
            ItemModel item = new ItemModel();
            item.Location = ItemLocationEnum.Unknown;
            item.Id = "testId";
            SelectedItemChangedEventArgs args = new SelectedItemChangedEventArgs(item, 0);
            //Act
            page.OnPopupItemSelected(null, args);
            //Reset

            //Assert
            //nothing should have changed so if there are no errors this should pass
            Assert.AreEqual(0, 0);
        }

        [Test]
        public void CharacterCreatPage_OnPopupItemSelected_PrimaryHand_Valid_Should_Pass()
        {
            //Arrange
            page.ViewModel.Data.PrimaryHand = "";
            ItemModel item = new ItemModel();
            item.Location = ItemLocationEnum.PrimaryHand;
            item.Id = "testId";
            SelectedItemChangedEventArgs args = new SelectedItemChangedEventArgs(item, 0);
            //Act
            page.OnPopupItemSelected(null, args);
            //Reset

            //Assert
            Assert.AreEqual(page.ViewModel.Data.PrimaryHand, "testId");
        }
        #endregion

        [Test]
        public void CharacterCreatePage_UpdateHealthValue_ShouldPass()
        {
            //Arrange
            page.ViewModel.Data.MaxHealth = page.ViewModel.Data.MaxHealth + 10;
            //Act
            page.UpdateHealthValue();
            //Reset

            //Assert
            //no way to check if health text actually changed so if it got here it must have happened
            Assert.AreEqual(0, 0);
        }

        [Test]
        public void CharacterCreatePage_LevelPicker_Changed_IsValid_Should_Pass()
        {
            //Arrange
            page.ViewModel.Data.Level = 21;
            //Act
            page.LevelPicker_Changed(0, new EventArgs());
            //Reset
            page.ViewModel.Data.Level = 1;
            //Assert
            //no way to check if levelPicker value is correct so if it got here it must pass
            Assert.AreEqual(0, 0);
        }

        [Test]
        public void CharacterCreatePage_LevelPicker_Changed_Invalid_Should_Pass()
        {
            //Arrange
            page.ViewModel.Data.Level = 21;
            //Act
            page.LevelPicker_Changed(0, new EventArgs());
            //Reset
            page.ViewModel.Data.Level = -1;
            //Assert
            //no way to check if levelPicker value is correct so if it got here it must pass
            Assert.AreEqual(0, 0);
        }

    }
}