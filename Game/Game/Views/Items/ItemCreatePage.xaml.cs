using Game.Models;
using Game.ViewModels;

using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// Create Item
    /// </summary>
    [DesignTimeVisible(false)] 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemCreatePage : ContentPage
    {
        // maximum value for Item's attribute
        public int MaxAttributeValue = 9;

        // maximum value for item's attribute
        public int MinAttributeValue = 0;

        // The item to create
        public GenericViewModel<ItemModel> ViewModel = new GenericViewModel<ItemModel>();

        // Empty Constructor for UTs
        public ItemCreatePage(bool UnitTest){}

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public ItemCreatePage()
        {
            InitializeComponent();

            this.ViewModel.Data = new ItemModel();

            BindingContext = this.ViewModel;

            this.ViewModel.Title = "Create";

            //Need to make the SelectedItem a string, so it can select the correct item.
            LocationPicker.SelectedItem = ViewModel.Data.Location.ToString();
            AttributePicker.SelectedItem = ViewModel.Data.Attribute.ToString();
            TypePicker.SelectedItem = ViewModel.Data.DamageType.ToString();

            UpdatePageBindingContext();
        }

        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // If name is not provived
            if (string.IsNullOrEmpty(ViewModel.Data.Name))
            {
                await DisplayAlert("Invalid", "Item must have a name.", "OK");
                return;
            }

            // If location is not provived
            if (ViewModel.Data.Location.ToString() == "Unknown")
            {
                await DisplayAlert("Invalid", "Item must have a location.", "OK");
                return;
            }

            // If attribute is not provived
            if (ViewModel.Data.Attribute.ToString() == "Unknown")
            {
                await DisplayAlert("Invalid", "Item must have a attribute.", "OK");
                return;
            }

            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = Services.ItemService.DefaultImageURI;
            }

            MessagingCenter.Send(this, "Create", ViewModel.Data);
            await Navigation.PopModalAsync();
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

            LocationPicker.SelectedItem = ViewModel.Data.Location.ToString();
            AttributePicker.SelectedItem = ViewModel.Data.Attribute.ToString();
            TypePicker.SelectedItem = ViewModel.Data.DamageType.ToString();

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
            ValueUpButton.IsEnabled = true;
            if (ViewModel.Data.Value == MaxAttributeValue)
            {
                ValueUpButton.IsEnabled = false;
            }

            ValueDownButton.IsEnabled = true;
            if (ViewModel.Data.Value == MinAttributeValue)
            {
                ValueDownButton.IsEnabled = false;
            }

            return true;
        }

        #endregion SetEnableStateAttributeButtons

        #region ValueButton
        /// <summary>
        /// Manage the Value Up Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ValueUpButton_Clicked(object sender, EventArgs e)
        {
            ViewModel.Data.Value++;

            if (ViewModel.Data.Value > MaxAttributeValue)
            {
                ViewModel.Data.Value = MaxAttributeValue;
            }

            UpdatePageBindingContext();
        }

        /// <summary>
        /// Manage the Value Down Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ValueDownButton_Clicked(object sender, EventArgs e)
        {
            ViewModel.Data.Value--;

            if (ViewModel.Data.Value < MinAttributeValue)
            {
                ViewModel.Data.Value = MinAttributeValue;
            }

            UpdatePageBindingContext();
        }
        #endregion ValueButton
        #endregion AttributeButtons
    }
}