using Game.GameRules;
using Game.Models;
using Game.ViewModels;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

            UpdatePageBindingContext();

            this.ViewModel.Title = "Create Character";
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
                await DisplayAlert("Invalid", "Character must have a name.", "OK");
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
        /// Loads each possible character level into the level picker so it can be selected
        /// </summary>
        /// <returns>true</returns>
        public bool LoadLevelPickerValues()
        {
            //add each level from 1 to the maxLevel
            for (int i = 0; i < LevelTableHelper.MaxLevel; i++)
            {
                LevelPicker.Items.Add((i + 1).ToString());
            }

            //set the default selected value equal to the default character level
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
        /// Set the text for speed equal to the new value of the stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Speed_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            SpeedValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Set the text for attack equal to the new value of the stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Attack_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            AttackValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Set the text for defense equal to the new value of the stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Defense_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            DefenseValue.Text = String.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// When the level picker is changed updated the character's level and recalculate the max health
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void LevelPicker_Changed(object sender, EventArgs e)
        {
            if (LevelPicker.SelectedIndex == -1)
            {
                LevelPicker.SelectedIndex = ViewModel.Data.Level - 1;
                return;
            }

            var result = LevelPicker.SelectedIndex + 1;

            if (result != ViewModel.Data.Level)
            {
                ViewModel.Data.Level = result;
                ViewModel.Data.MaxHealth = RandomPlayerHelper.GetHealth(ViewModel.Data.Level);
                UpdateHealthValue();
            }
        }

        /// <summary>
        /// updates the value for the health text to be what the character's max health is
        /// </summary>
        /// <returns>true</returns>
        public bool UpdateHealthValue()
        {
            HealthValue.Text = ViewModel.Data.MaxHealth.ToString();
            return true;
        }

        /// <summary>
        /// randomizes the data stored in the characterModel being created
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

            AddItemsToDisplay();

            return true;
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

            //Add the item to the slot item is supposed to go            
            switch (data.Location)
            {
                case ItemLocationEnum.Head:
                    ViewModel.Data.AddItem(ItemLocationEnum.Head, data.Id);
                    break;
                case ItemLocationEnum.Feet:
                    ViewModel.Data.AddItem(ItemLocationEnum.Feet, data.Id);
                    break;
                case ItemLocationEnum.Finger:
                    ViewModel.Data.AddItem(ItemLocationEnum.Finger, data.Id);
                    break;
                case ItemLocationEnum.LeftFinger:
                    ViewModel.Data.AddItem(ItemLocationEnum.LeftFinger, data.Id);
                    break;
                case ItemLocationEnum.Necklass:
                    ViewModel.Data.AddItem(ItemLocationEnum.Necklass, data.Id);
                    break;
                case ItemLocationEnum.OffHand:
                    ViewModel.Data.AddItem(ItemLocationEnum.OffHand, data.Id);
                    break;
                case ItemLocationEnum.PrimaryHand:
                    ViewModel.Data.AddItem(ItemLocationEnum.PrimaryHand, data.Id);
                    break;
                case ItemLocationEnum.RightFinger:
                    ViewModel.Data.AddItem(ItemLocationEnum.RightFinger, data.Id);
                    break;
                case ItemLocationEnum.Unknown:
                    ViewModel.Data.AddItem(ItemLocationEnum.Unknown, data.Id);
                    break;
            }

            AddItemsToDisplay();

            ClosePopup();
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


        /// <summary>
        /// Sets data on the popup page and makes visible
        /// </summary>
        /// <param name="data">the item that was clicked on</param>
        /// <param name="location">the location that 'data' was equipped in</param>
        /// <returns></returns>
        public bool ShowPopup(ItemModel data, ItemLocationEnum location)
        {
            PopupItemSelector.IsVisible = true;

            // Make a fake item for None
            var NoneItem = new ItemModel
            {
                Id = null, // will use null to clear the item
                Guid = "None", // how to find this item amoung all of them
                ImageURI = "icon_cancel.png",
                Name = "None",
                Description = "None",
                //the location that the NoneItem will be equipped into
                //this needs to be set for the popup to know where to equip the none item if selected
                Location = location
            };

            List<ItemModel> itemList = new List<ItemModel>
            {
                NoneItem
            };

            // Add the rest of the items to the list
            itemList.AddRange(ItemIndexViewModel.Instance.GetLocationItems(location));                      //TODO MAKE SURE YOU CANT ADD ITEMS ALREADY EQUIPPED

            // Populate the list with the items
            PopupLocationItemListView.ItemsSource = itemList;
            return true;
        }


        /// <summary>
        /// Creates a stack item to return to the flexbox
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout GetItemToDisplay(ItemLocationEnum location)
        {
            var data = ViewModel.Data.GetItemByLocation(location);
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
            ItemButton.Clicked += (sender, args) => ShowPopup(data, location);

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
        /// Show the Items the Charcter has
        /// </summary>
        public void AddItemsToDisplay()
        {
            var FlexList = ItemBox.Children.ToList();
            foreach (var data in FlexList)
            {
                ItemBox.Children.Remove(data);
            }

            //Add space for each of the places that can hold item
            ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.Head));
            ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.Necklass));
            ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.PrimaryHand));
            ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.OffHand));
            ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.RightFinger));
            ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.LeftFinger));
            ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.Feet));
            ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.Unknown));
        }
    }
}