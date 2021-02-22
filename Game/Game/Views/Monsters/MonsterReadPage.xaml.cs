using System;
using System.ComponentModel;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

namespace Game.Views
{
    /// <summary>
    /// The Read Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterReadPage : ContentPage
    {
        // View Model for Item
        public readonly GenericViewModel<MonsterModel> ViewModel;

        // Empty Constructor for UTs
        public MonsterReadPage(bool UnitTest) { }

        /// <summary>
        /// Constructor called with a view model
        /// This is the primary way to open the page
        /// The viewModel is the data that should be displayed
        /// </summary>
        /// <param name="viewModel"></param>
        public MonsterReadPage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;
            this.ViewModel.Title = data.Data.Name;

            // Show the Character's Items
            AddItemsToDisplay();
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Update_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MonsterUpdatePage(ViewModel)));
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Calls for Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MonsterDeletePage(ViewModel)));
            await Navigation.PopAsync();
        }

        /// <summary>
        /// Adds the items to the flexbox
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
        /// Creates a stack item to return to the flexbox
        /// </summary>
        /// <param name="location"></param>
        /// <returns>ItemStack to display</returns>
        public StackLayout GetItemToDisplay()
        {
            //Default Image is the X
            var ImageSource = "icon_cancel.png";
            var ClickableButton = true;

            var data = ViewModel.Data.GetItem(ViewModel.Data.UniqueItem);
            if (data == null)
            {
                //Show default icon
                data = new ItemModel { Location = ItemLocationEnum.Unknown, ImageURI = ImageSource };

                //Turn off Clickable action
                ClickableButton = false;
            }

            //Hookup image button to show item pic
            var ItemButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ImageMediumStyle"],
                Source = data.ImageURI
            };

            if (ClickableButton)
            {
                //Add Event so user can click to see more about item
                ItemButton.Clicked += (sender, args) => ShowPopup(data);
            }

            //Add displayText
            var ItemLabel = new Label
            {
                Text = "Unique Item Drop",
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };

            //Put Image button and text in layout
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
        /// <returns>True if sucessful</returns>
        public bool ShowPopup(ItemModel data)
        {
            PopupLoadingView.IsVisible = true;
            PopupItemImage.Source = data.ImageURI;

            PopupItemName.Text = data.Name;
            PopupItemDescription.Text = data.Description;
            PopupItemLocation.Text = data.Location.ToMessage();
            //PopupItemAttribute.Text = data.Attribute.ToMessage();
            PopupItemValue.Text = " + " + data.Value.ToString();

            return true;
        }

        /// <summary>
        /// Sets visibility of popup to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClosePopup_Clicked(Object sender, EventArgs e)
        {
            PopupLoadingView.IsVisible = false;
        }

    }
}