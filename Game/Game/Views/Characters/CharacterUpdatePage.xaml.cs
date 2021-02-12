using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;
using Game.GameRules;

namespace Game.Views
{
    /// <summary>
    /// Item Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterUpdatePage : ContentPage
    {
        // maximum value for monster's attribute
        public int MaxAttributeValue = 9;

        // maximum value for monster's attribute
        public int MinAttributeValue = 0;

        // View Model for Item
        public readonly GenericViewModel<CharacterModel> ViewModel;

        // Empty Constructor for Tests
        public CharacterUpdatePage(bool UnitTest){ }

        /// <summary>
        /// Constructor that takes and existing data item
        /// </summary>
        public CharacterUpdatePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            this.ViewModel = data;

            LoadLevelPickerValues();

            UpdatePageBindingContext();
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // If name is not provived
            if (string.IsNullOrEmpty(ViewModel.Data.Name))
            {
                await DisplayAlert("Invalid", "Character must have a name.", "OK");
                return;
            }

            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = Services.ItemService.DefaultImageURI;
            }

            MessagingCenter.Send(this, "Update", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Cancel and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Load level values into the Picker
        /// </summary>
        public bool LoadLevelPickerValues()
        {
            for(var i = 1; i <= LevelTableHelper.MaxLevel; i++)
            {
                LevelPicker.Items.Add(i.ToString());
            }

            LevelPicker.SelectedIndex = -1;

            return true;
        }

        /// <summary>
        /// Catch the change to the picker for MaxHealth
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LevelPicker_ChangedIndex(object sender, EventArgs e)
        {
            // if the picker is not set, then set it
            if(LevelPicker.SelectedIndex == -1)
            {
                LevelPicker.SelectedIndex = ViewModel.Data.Level - 1;
                return;
            }

            var result = LevelPicker.SelectedIndex + 1;

            // Only roll again for health if the level changed
            if(result != ViewModel.Data.Level)
            {
                // Change the level
                ViewModel.Data.Level = result;

                // Roll for new HP
                ViewModel.Data.MaxHealth = RandomPlayerHelper.GetHealth(ViewModel.Data.Level);

                UpdateMaxHealthValue();
            }
        }

        /// <summary>
        /// Catch the result to the label for MaxHealth
        /// </summary>
        public void UpdateMaxHealthValue()
        {
            MaxHealthValue.Text = ViewModel.Data.MaxHealth.ToString();
        }

        /// <summary>
        /// Randomize Character Values and Items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RandomButton_Clicked(object sender, EventArgs e)
        {
            this.ViewModel.Data.Update(RandomPlayerHelper.GetRandomCharacter(20));

            UpdatePageBindingContext();

            return;
        }

        /// <summary>
        /// Update the page binding context
        /// </summary>
        public bool UpdatePageBindingContext()
        {
            // Temp store off the Level
            var data = this.ViewModel.Data;

            // Clear the Binding and reset it
            BindingContext = null;
            this.ViewModel.Data = data;
            this.ViewModel.Title = data.Name;

            BindingContext = this.ViewModel;

            // This resets the picker to the Character's level
            LevelPicker.SelectedIndex = ViewModel.Data.Level - 1;

            JobPicker.SelectedItem = ViewModel.Data.Job.ToString();

            return true;
        }

        #region AttributeButtons
        #region SetEnableStateAttributeButtons
        /// <summary>
        /// Walk each button and set the enabled to true or false
        /// </summary>
        /// <returns></returns>
        public bool SetEnableStateAttributeButtons()
        {
            AttackUpButton.IsEnabled = true;
            if (ViewModel.Data.Attack == MaxAttributeValue)
            {
                AttackUpButton.IsEnabled = false;
            }

            AttackDownButton.IsEnabled = true;
            if (ViewModel.Data.Attack == MinAttributeValue)
            {
                AttackDownButton.IsEnabled = false;
            }

            DefenseUpButton.IsEnabled = true;
            if (ViewModel.Data.Defense == MaxAttributeValue)
            {
                DefenseUpButton.IsEnabled = false;
            }

            DefenseDownButton.IsEnabled = true;
            if (ViewModel.Data.Defense == MinAttributeValue)
            {
                DefenseDownButton.IsEnabled = false;
            }

            SpeedUpButton.IsEnabled = true;
            if (ViewModel.Data.Speed == MaxAttributeValue)
            {
                SpeedUpButton.IsEnabled = false;
            }

            SpeedDownButton.IsEnabled = true;
            if (ViewModel.Data.Speed == MinAttributeValue)
            {
                SpeedDownButton.IsEnabled = false;
            }

            return true;
        }

        #endregion SetEnableStateAttributeButtons

        #region AttackButton
        /// <summary>
        /// Manage the Attack Up Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AttackUpButton_Clicked(object sender, EventArgs e)
        {
            ViewModel.Data.Attack++;

            if (ViewModel.Data.Attack > MaxAttributeValue)
            {
                ViewModel.Data.Attack = MaxAttributeValue;
            }

            UpdatePageBindingContext();
        }

        /// <summary>
        /// Manage the Attack Down Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AttackDownButton_Clicked(object sender, EventArgs e)
        {
            ViewModel.Data.Attack--;

            if (ViewModel.Data.Attack < MinAttributeValue)
            {
                ViewModel.Data.Attack = MinAttributeValue;
            }

            UpdatePageBindingContext();
        }
        #endregion AttackButton

        #region DefenseButton
        /// <summary>
        /// Manage the Defense Up Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DefenseUpButton_Clicked(object sender, EventArgs e)
        {
            ViewModel.Data.Defense++;

            if (ViewModel.Data.Defense > MaxAttributeValue)
            {
                ViewModel.Data.Defense = MaxAttributeValue;
            }

            UpdatePageBindingContext();
        }

        /// <summary>
        /// Manage the Defense Down Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DefenseDownButton_Clicked(object sender, EventArgs e)
        {
            ViewModel.Data.Defense--;

            if (ViewModel.Data.Defense < MinAttributeValue)
            {
                ViewModel.Data.Defense = MinAttributeValue;
            }

            UpdatePageBindingContext();
        }
        #endregion DefenseButton

        #region SpeedButton
        /// <summary>
        /// Manage the Speed Up Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SpeedUpButton_Clicked(object sender, EventArgs e)
        {
            ViewModel.Data.Speed++;

            if (ViewModel.Data.Speed > MaxAttributeValue)
            {
                ViewModel.Data.Speed = MaxAttributeValue;
            }

            UpdatePageBindingContext();
        }

        /// <summary>
        /// Manage the Speed Down Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SpeedDownButton_Clicked(object sender, EventArgs e)
        {
            ViewModel.Data.Speed--;

            if (ViewModel.Data.Speed < MinAttributeValue)
            {
                ViewModel.Data.Speed = MinAttributeValue;
            }

            UpdatePageBindingContext();
        }
        #endregion SpeedButton
        #endregion AttributeButtons
    }
}