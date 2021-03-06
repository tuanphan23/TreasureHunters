﻿using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.Models;
using Game.ViewModels;
using Game.GameRules;
using System.Linq;
using System.Collections.Generic;

namespace Game.Views
{
    /// <summary>
    /// Create Character
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
    public partial class MonsterCreatePage : ContentPage
    {
        // maximum value for monster's attribute
        public int MaxAttributeValue = 10;

        // maximum value for monster's attribute
        public int MinAttributeValue = 0;

        // The Character to create
        public GenericViewModel<MonsterModel> ViewModel = new GenericViewModel<MonsterModel>();

        // Hold the current location selected
        public ItemLocationEnum PopupLocationEnum = ItemLocationEnum.Unknown;

        // Empty Constructor for UTs
        public MonsterCreatePage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public MonsterCreatePage()
        {
            InitializeComponent();

            this.ViewModel.Data = RandomPlayerHelper.GetRandomMonster(1);
            this.ViewModel.Title = this.ViewModel.Data.Name;

            BindingContext = ViewModel;

            UpdatePageBindingContext();
        }

        /// <summary>
        /// Redo the Binding to cause a refresh
        /// </summary>
        /// <returns></returns>
        public bool UpdatePageBindingContext()
        {
            // Temp store off the Level
            var data = this.ViewModel.Data;

            // Clear the Binding and reset it
            BindingContext = null;
            this.ViewModel.Data = data;
            this.ViewModel.Title = data.Name;

            BindingContext = this.ViewModel;

            DifficultyPicker.SelectedItem = ViewModel.Data.Difficulty.ToString();

            AddItemsToDisplay();

            SetEnableStateAttributeButtons();

            return true;
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
                await DisplayAlert("Invalid", "Monster must have a name.", "OK");
                return;
            }

            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = new MonsterModel().ImageURI;
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
        /// Randomize Character Values and Items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RandomButton_Clicked(object sender, EventArgs e)
        {
            this.ViewModel.Data.Update(RandomPlayerHelper.GetRandomMonster(1));

            UpdatePageBindingContext();

            return;
        }

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

        /// <summary>
        /// Show the Items the Monster has
        /// </summary>
        public void AddItemsToDisplay()
        {
            var FlexList = ItemBox.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemBox.Children.Remove(data);
            }

            ItemBox.Children.Add(GetItemToDisplay());
        }

        /// <summary>
        /// Select item from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnPopupItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            ItemModel data = args.SelectedItem as ItemModel;
            if (data == null)
            {
                return;
            }

            ViewModel.Data.UniqueItem = data.Id;

            AddItemsToDisplay();

            ClosePopup();
        }

        /// <summary>
        /// Creates a stack item to return to the flexbox
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout GetItemToDisplay()
        {
            var data = ViewModel.Data.GetItem(ViewModel.Data.UniqueItem);
            if (data == null)
            {
                // Show the Default Icon for the Location
                data = new ItemModel { Location = ItemLocationEnum.Unknown, ImageURI = "icon_cancel.png", Name = "Click to Add" };
            }

            // Hookup the Image Button to show the Item picture
            var ItemButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ImageMediumStyle"],
                Source = data.ImageURI
            };

            // Add a event to the user can click the item and see more
            ItemButton.Clicked += (sender, args) => ShowPopup(data);

            // Add the Display Text for the item
            var ItemLabel = new Label
            {
                Text = data.Name,
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };

            // Put the Image Button and Text inside a layout
            var ItemStack = new StackLayout
            {
                Padding = 3,
                Style = (Style)Application.Current.Resources["ItemImageBox"],
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    ItemButton,
                    ItemLabel
                },
            };

            return ItemStack;
        }

        /// <summary>
        /// Sets data on the popup page and makes visible
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ShowPopup(ItemModel data)
        {
            PopupItemSelector.IsVisible = true;

            // Make a fake item for None
            var NoneItem = new ItemModel
            {
                Id = null, // will use null to clear the item
                Guid = "None", // how to find this item amoung all of them
                ImageURI = "icon_cancel.png",
                Name = "None",
                Description = "None"
            };

            List<ItemModel> itemList = new List<ItemModel>
            {
                NoneItem
            };

            // Add the rest of the items to the list
            itemList.AddRange(ItemIndexViewModel.Instance.Dataset);

            // Populate the list with the items
            PopupLocationItemListView.ItemsSource = itemList;
            return true;
        }

        /// <summary>
        /// When user click on close, close the popup view and show the scrollview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClosePopup_Clicked(object sender, EventArgs e)
        {
            ClosePopup();
        }

        /// <summary>
        /// Close the popup
        /// </summary>
        public void ClosePopup()
        {
            PopupItemSelector.IsVisible = false;
        }
    }
}
