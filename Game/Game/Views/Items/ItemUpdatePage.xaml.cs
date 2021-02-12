using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

namespace Game.Views
{
    /// <summary>
    /// Item Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemUpdatePage : ContentPage
    {
        // maximum value for Item's attribute
        public int MaxAttributeValue = 9;

        // maximum value for item's attribute
        public int MinAttributeValue = 0;

        // View Model for Item
        public readonly GenericViewModel<ItemModel> ViewModel;

        // Empty Constructor for Tests
        public ItemUpdatePage(bool UnitTest){ }

        /// <summary>
        /// Constructor that takes and existing data item
        /// </summary>
        public ItemUpdatePage(GenericViewModel<ItemModel> data)
        {
            InitializeComponent();

            this.ViewModel = data;
            ViewModel.Data.updatePercent();

            BindingContext = this.ViewModel;

            this.ViewModel.Title = "Update " + data.Title;

            //Need to make the SelectedItem a string, so it can select the correct item.
            LocationPicker.SelectedItem = data.Data.Location.ToString();
            AttributePicker.SelectedItem = data.Data.Attribute.ToString();
            TypePicker.SelectedItem = data.Data.DamageType.ToString();

            UpdatePageBindingContext();
        }

        /// <summary>
        /// Save calls to Update
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