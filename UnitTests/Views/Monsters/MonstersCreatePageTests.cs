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
    public class MonsterCreatePageTests : MonsterCreatePage
    {
        App app;
        MonsterCreatePage page;

        public MonsterCreatePageTests() : base(true) { }
        
        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            //page = new MonsterCreatePage(new GenericViewModel<MonsterModel>(new MonsterModel()));
            page = new MonsterCreatePage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void MonsterCreatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void MonsterCreatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_Save_Clicked_Null_Image_Should_Pass()
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
        public void MonsterCreatePage_OnBackButtonPressed_Valid_Should_Pass()
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
        //public void MonsterCreatePage_Attack_OnStepperAttackChanged_Default_Should_Pass()
        //{
        //    // Arrange
        //    var data = new MonsterModel();
        //    var ViewModel = new GenericViewModel<MonsterModel>(data);

        //    //page = new MonsterCreatePage(ViewModel);
        //    double oldAttack = 0.0;
        //    double newAttack = 1.0;

        //    var args = new ValueChangedEventArgs(oldAttack, newAttack);

        //    // Act
        //    //page.Attack_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(false); // Got to here, so it happened...
        //}

        //This test is unneeded as buttons are used for the update page instead of steppers
        //[Test]
        //public void MonsterCreatePage_Speed_OnStepperValueChanged_Default_Should_Pass()
        //{
        //    // ArSpeed
        //    var data = new MonsterModel();
        //    var ViewModel = new GenericViewModel<MonsterModel>(data);

        //    //page = new MonsterCreatePage(ViewModel);
        //    double oldSpeed = 0.0;
        //    double newSpeed = 1.0;

        //    var args = new ValueChangedEventArgs(oldSpeed, newSpeed);

        //    // Act
        //    //page.Speed_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(false); // Got to here, so it happened...
        //}

        //This test is unneeded as buttons are used for the update page instead of steppers
        //[Test]
        //public void MonsterCreatePage_Defense_OnStepperDefenseChanged_Default_Should_Pass()
        //{
        //    // Arrange
        //    var data = new MonsterModel();
        //    var ViewModel = new GenericViewModel<MonsterModel>(data);

        //    //page = new MonsterCreatePage(ViewModel);
        //    double oldDefense = 0.0;
        //    double newDefense = 1.0;

        //    var args = new ValueChangedEventArgs(oldDefense, newDefense);

        //    // Act
        //    //page.Defense_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(false); // Got to here, so it happened...
        //}

        [Test]
        public void MonsterCreatePage_RandomButton_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.RandomButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_ClosePopup_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ClosePopup();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_ClosePopup_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ClosePopup_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_ShowPopup_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ShowPopup(new ItemModel());

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_OnPopupItemSelected_Clicked_Default_Should_Pass()
        {
            // Arrange

            var data = new ItemModel();

            var selectedMonsterChangedEventArgs = new SelectedItemChangedEventArgs(data, 0);

            // Act
            page.OnPopupItemSelected(null, selectedMonsterChangedEventArgs);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

            [Test]
        public void MonsterCreatePage_OnPopupItemSelected_Clicked_Null_Should_Fail()
        {
            // Arrange

            var selectedMonsterChangedEventArgs = new SelectedItemChangedEventArgs(null, 0);

            // Act
            page.OnPopupItemSelected(null, selectedMonsterChangedEventArgs);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_Item_ShowPopup_Default_Should_Pass()
        {
            // Arrange

            var item = page.GetItemToDisplay();

            // Act
            var itemButton = item.Children.FirstOrDefault(m => m.GetType().Name.Equals("Button"));

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        {
            // Arrange
            var StackItem = page.GetItemToDisplay();
            var dataImage = StackItem.Children[0];

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_RandomButton_Clicked_Vaid_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.ImageURI = null;

            // Act
            page.RandomButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        #region ButtonUpDown
        [Test]
        public void MonsterCreatePage_AttackDownButton_Clicked_Valid_1_Should_Pass()
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
        public void MonsterCreatePage_AttackUpButton_Clicked_Valid_1_Should_Pass()
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
        public void MonsterCreatePage_DefenseDownButton_Clicked_Valid_1_Should_Pass()
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
        public void MonsterCreatePage_DefenseUpButton_Clicked_Valid_1_Should_Pass()
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
        public void MonsterCreatePage_SpeedDownButton_Clicked_Valid_1_Should_Pass()
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
        public void MonsterCreatePage_SpeedUpButton_Clicked_Valid_1_Should_Pass()
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
        public void MonsterCreatePage_AttackDownButton_Clicked_Invalid_0_Should_Fail()
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
        public void MonsterCreatePage_AttackUpButton_Clicked_Invalid_10_Should_Fail()
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
        public void MonsterCreatePage_DefenseDownButton_Clicked_Invalid_0_Should_Fail()
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
        public void MonsterCreatePage_DefenseUpButton_Clicked_Invalid_10_Should_Fail()
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
        public void MonsterCreatePage_SpeedDownButton_Clicked_Invalid_0_Should_Fail()
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
        public void MonsterCreatePage_SpeedUpButton_Clicked_Invalid_10_Should_Fail()
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
    }
}