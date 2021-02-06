using Game.GameRules;
using Game.Models;
using Game.ViewModels;

using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// Create Character
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterCreatePage : ContentPage
    {
        // The character to create
        public GenericViewModel<CharacterModel> ViewModel = new GenericViewModel<CharacterModel>();

        // Empty Constructor for UTs
        public CharacterCreatePage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public CharacterCreatePage()
        {
            InitializeComponent();

            this.ViewModel.Data = new CharacterModel();

            LoadLevelPickerValues();

            BindingContext = this.ViewModel;

            this.ViewModel.Title = "Create Character";
        }

        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = Services.ItemService.DefaultImageURI;
            }

            MessagingCenter.Send(this, "Create", ViewModel.Data);
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Adds values to the level picker in character create page
        /// </summary>
        /// <returns>true if values were succesfully loaded</returns>
        public bool LoadLevelPickerValues()
        {
            for(int i = 0; i < 20; i++) //TODO: tie the loop to max level
            {
                LevelPicker.Items.Add((i + 1).ToString());
            }

            LevelPicker.SelectedIndex = ViewModel.Data.Level - 1;

            return true;
        }

        /// <summary>
        /// Cancel the Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Changes the display value for the health stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MaxHealth_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            HealthValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Changes the display value for the speed stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Speed_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            SpeedValue.Text = String.Format("{0}", e.NewValue);
        }
        void Attack_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            AttackValue.Text = String.Format("{0}", e.NewValue);
        }

        void Defense_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            DefenseValue.Text = String.Format("{0}", e.NewValue);
        }

        void LevelPicker_Changed(object sender, EventArgs e)
        {
            if(LevelPicker.SelectedIndex == -1)
            {
                LevelPicker.SelectedIndex = ViewModel.Data.Level - 1;
                return;
            }

            var result = LevelPicker.SelectedIndex + 1;

            if(result != ViewModel.Data.Level)
            {
                ViewModel.Data.Level = result;
                ViewModel.Data.MaxHealth = RandomPlayerHelper.GetHealth(ViewModel.Data.Level);
                UpdateHealthValue();
            }
        }

        public bool UpdateHealthValue()
        {
            HealthValue.Text = ViewModel.Data.MaxHealth.ToString();
            return true;
        }
    }
}