using NUnit.Framework;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using System.Linq;

namespace UnitTests.Views
{
    [TestFixture]
    public class CharacterUpdatePageTests : CharacterUpdatePage
    {
        App app;
        CharacterUpdatePage page;

        public CharacterUpdatePageTests() : base(true) { }
        
        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new CharacterUpdatePage(new GenericViewModel<CharacterModel>(new CharacterModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void CharacterUpdatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CharacterUpdatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_Save_Clicked_Null_Image_Should_Pass()
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
        public void CharacterUpdatePage_Save_Clicked_With_Valid_Info_Should_Pass()
        {
            // Arrange
            page.FindByName<Entry>("Name").Text = "Mike";
            page.FindByName<Entry>("Image").Text = "Image1.png";

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void CharacterUpdatePage_OnBackButtonPressed_Valid_Should_Pass()
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
        //public void CharacterUpdatePage_Attack_OnStepperValueChanged_Default_Should_Pass()
        //{
        //     Arrange
        //    var data = new CharacterModel();
        //    var ViewModel = new GenericViewModel<CharacterModel>(data);

        //    page = new CharacterUpdatePage(ViewModel);
        //    double oldValue = 0.0;
        //    double newValue = 1.0;

        //    var args = new ValueChangedEventArgs(oldValue, newValue);

        //     Act
        //    page.Attack_OnStepperValueChanged(null, args);

        //     Reset

        //     Assert
        //    Assert.IsTrue(false); // Got to here, so it happened...
        //}

        //This test is unneeded as buttons are used for the update page instead of steppers
        //[Test]
        //public void CharacterUpdatePage_Defense_OnStepperValueChanged_Default_Should_Pass()
        //{
        //    // Arrange
        //    var data = new CharacterModel();
        //    var ViewModel = new GenericViewModel<CharacterModel>(data);

        //    page = new CharacterUpdatePage(ViewModel);
        //    double oldRange = 0.0;
        //    double newRange = 1.0;

        //    var args = new ValueChangedEventArgs(oldRange, newRange);

        //    // Act
        //    //page.Defense_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(false); // Got to here, so it happened...
        //}

        //This test is unneeded as buttons are used for the update page instead of steppers
        //[Test]
        //public void CharacterUpdatePage_Speed_OnStepperDamageChanged_Default_Should_Pass()
        //{
        //    // Arrange
        //    var data = new CharacterModel();
        //    var ViewModel = new GenericViewModel<CharacterModel>(data);

        //    page = new CharacterUpdatePage(ViewModel);
        //    double oldDamage = 0.0;
        //    double newDamage = 1.0;

        //    var args = new ValueChangedEventArgs(oldDamage, newDamage);

        //    // Act
        //    //page.Speed_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(false); // Got to here, so it happened...
        //}

        [Test]
        public void CharacterUpdatePage_Level_Changed_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);

            page = new CharacterUpdatePage(ViewModel);
            double oldDamage = 0.0;
            double newDamage = 1.0;

            var args = new ValueChangedEventArgs(oldDamage, newDamage);

            // Act
            page.LevelPicker_ChangedIndex(null, args);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_RandomButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.RandomButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ClosePopup_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ClosePopup();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_ClosePopup_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ClosePopup_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_OnPopupItemSelected_Clicked_Default_Should_Pass()
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
        public void CharacterUpdatePage_OnPopupItemSelected_Clicked_Null_Should_Fail()
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
        public void CharacterUpdatePage_Item_ShowPopup_Default_Should_Pass()
        {
            // Arrange

            var item = page.GetItemToDisplay(ItemLocationEnum.Head);

            // Act
            var itemButton = item.Children.FirstOrDefault(m => m.GetType().Name.Equals("Button"));

            page.ShowPopup(ItemLocationEnum.Head);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        {
            // Arrange
            var item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.Head);
            page.ViewModel.Data.Head = item.Id;
            var StackItem = page.GetItemToDisplay(ItemLocationEnum.Head);
            var dataImage = StackItem.Children[0];

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }


        #region ButtonUpDown
        [Test]
        public void CharacterUpdatePage_AttackDownButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Attack = 1;

            // Act
            page.AttackDownButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_AttackUpButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Attack = 1;

            // Act
            page.AttackUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_DefenseDownButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Defense = 1;

            // Act
            page.DefenseDownButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_DefenseUpButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Defense = 1;

            // Act
            page.DefenseUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_SpeedDownButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Speed = 1;

            // Act
            page.SpeedDownButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_SpeedUpButton_Clicked_Valid_1_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.Speed = 1;

            // Act
            page.SpeedUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_AttackDownButton_Clicked_Invalid_0_Should_Fail()
        {
            // Arrange
            page.ViewModel.Data.Attack = 0;

            // Act
            page.AttackDownButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_AttackUpButton_Clicked_Invalid_10_Should_Fail()
        {
            // Arrange
            page.ViewModel.Data.Attack = 10;

            // Act
            page.AttackUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_DefenseDownButton_Clicked_Invalid_0_Should_Fail()
        {
            // Arrange
            page.ViewModel.Data.Defense = 0;

            // Act
            page.DefenseDownButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_DefenseUpButton_Clicked_Invalid_10_Should_Fail()
        {
            // Arrange
            page.ViewModel.Data.Defense = 10;

            // Act
            page.DefenseUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_SpeedDownButton_Clicked_Invalid_0_Should_Fail()
        {
            // Arrange
            page.ViewModel.Data.Speed = 0;

            // Act
            page.SpeedDownButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterUpdatePage_SpeedUpButton_Clicked_Invalid_10_Should_Fail()
        {
            // Arrange
            page.ViewModel.Data.Speed = 10;

            // Act
            page.SpeedUpButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        #endregion ButtonUpDown

        #region UpdateHealth
        [Test]
        public void CharacterUpdatePage_UpdateHealthValue_Valid_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.UpdateMaxHealthValue();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        #endregion UpdateHealth

        #region RandomButton_Clicked
        [Test]
        public void CharacterUpdatePage_RandomButton_Clicked_Valid_Should_Pass()
        {
            // Arrange

            // Act
            page.RandomButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
        #endregion RandomButton_Clicked

        #region LevelPicker_Changed
        [Test]
        public void CharacterUpdatePage_LevelPicker_SelectedIndex_Neg1_Should_Return_Level()
        {
            // Arrange

            // Make a new Character to use for the Picker Tests
            page.ViewModel.Data = new CharacterModel()
            {
                Id = "test",
                Level = 10
            };

            var control = (Picker)page.FindByName("LevelPicker");
            control.SelectedIndex = -1;

            // Act
            page.LevelPicker_ChangedIndex(null, null);
            var result = control.SelectedIndex;

            // Reset

            // Assert
            Assert.AreEqual(10, result + 1);
        }

        [Test]
        public void CharacterUpdatePage_LevelPicker_SelectedIndex_No_Change_Should_Skip()
        {
            // Arrange

            // Make a new Character to use for the Picker Tests
            page.ViewModel.Data = new CharacterModel()
            {
                Id = "test",
                Level = 10
            };

            var control = (Picker)page.FindByName("LevelPicker");
            control.SelectedIndex = 10 - 1;

            // Act
            page.LevelPicker_ChangedIndex(null, null);
            var result = control.SelectedIndex;

            // Reset

            // Assert
            Assert.AreEqual(10, result + 1);
        }


        [Test]
        public void CharacterUpdatePage_LevelPicker_SelectedIndex_Change_Should_Update_Picker_To_Level()
        {
            // Arrange

            // Make a new Character to use for the Picker Tests
            page.ViewModel.Data = new CharacterModel()
            {
                Id = "test",
                Level = 1
            };

            var control = (Picker)page.FindByName("LevelPicker");
            control.SelectedIndex = 15;

            // Act
            page.LevelPicker_ChangedIndex(null, null);
            var result = control.SelectedIndex;

            // Reset

            // Assert
            Assert.AreEqual(16, result + 1);
        }
        #endregion LevelPicker_Changed


        #region popupDataSwitch
        [Test]
        public void CharacterUpdatePage_OnPopupItemSelected_Head_Valid_Should_Pass()
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
        public void CharacterUpdatePage_OnPopupItemSelected_Feet_Valid_Should_Pass()
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
        public void CharacterUpdatePage_OnPopupItemSelected_LeftFinger_Valid_Should_Pass()
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
        public void CharacterUpdatePage_OnPopupItemSelected_RightFinger_Valid_Should_Pass()
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
        public void CharacterUpdatePage_OnPopupItemSelected_Necklass_Valid_Should_Pass()
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
        public void CharacterUpdatePage_OnPopupItemSelected_OffHand_Valid_Should_Pass()
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
        public void CharacterUpdatePage_OnPopupItemSelected_Finger_Valid_Should_Pass()
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
        public void CharacterUpdatePage_OnPopupItemSelected_Unknown_Valid_Should_Pass()
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
        public void CharacterUpdatePage_OnPopupItemSelected_PrimaryHand_Valid_Should_Pass()
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
        public void CharacterUpdatePage_SetEnableStateAttributeButtons_IsValid()
        {
            //Arrange

            //Act
            var result = page.SetEnableStateAttributeButtons();
            //Reset

            //Assert side effects can't be tested due to protection level of xamrin object
            Assert.AreEqual(result, true);
        }

        [Test]
        public void CharacterCreatePage_LevelPicker_SelectedIndex_Invalid_Neg1_Should_Pass()
        {
            //Arrange
            var control = (Picker)page.FindByName("LevelPicker");

            // Act
            control.SelectedIndex = -1;
            var result = control.SelectedIndex;

            // Reset

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CharacterCreatePage_LevelPicker_SelectedIndex_Valid_Info_Should_Pass()
        {
            //Arrange
            var control = (Picker)page.FindByName("LevelPicker");

            // Act
            control.SelectedIndex = 2;
            var result = control.SelectedIndex;

            // Reset

            // Assert
            Assert.AreEqual(2, result);
        }
    }
}