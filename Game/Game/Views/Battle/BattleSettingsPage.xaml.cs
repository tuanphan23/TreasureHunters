using Game.Helpers;
using Game.Models;
using Game.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//TODO: remove crit settings (no crits)
//TODO: remove miss settings (no missing)
//TODO: new settings in constructor

namespace Game.Views
{
    /// <summary>
    /// The Main Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BattleSettingsPage : ContentPage
    {
        // Empty Constructor for UTs
       // public BattleSettingsPage(bool UnitTest) { }

        public int ReflectChance = 30;

        /// <summary>
        /// Constructor
        /// </summary>
        public BattleSettingsPage()
        {
            InitializeComponent();

            ReflectChance = 0;

            BindingContext = this;

            #region BattleMode
            // Load the values for the Diffculty into the Picker
            foreach (var item in BattleModeEnumHelper.GetListMessageAll)
            {
                BattleModePicker.Items.Add(item);
            }

            // Set Values to current State
            BattleModePicker.SelectedItem = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum.ToMessage();
            BattleModePicker.SelectedIndex = BattleModePicker.Items.IndexOf(BattleModePicker.SelectedItem.ToString());
            #endregion BattleMode

            #region HitPickers
            // Load the values for the Diffculty into the Picker
            foreach (var item in HitStatusEnumHelper.GetListAll)
            {
                MonsterHitPicker.Items.Add(item);
                CharacterHitPicker.Items.Add(item);
            }

            // Set Values to current State
            MonsterHitPicker.SelectedItem = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum.ToString();
            MonsterHitPicker.SelectedIndex = MonsterHitPicker.Items.IndexOf(MonsterHitPicker.SelectedItem.ToString());

            CharacterHitPicker.SelectedItem = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum.ToString();
            CharacterHitPicker.SelectedIndex = CharacterHitPicker.Items.IndexOf(CharacterHitPicker.SelectedItem.ToString());
            #endregion HitPickers

            #region PlayerToggles
            ImmunePlayersSwitch.IsToggled = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.ImmunePlayers;
            #endregion

            #region MonsterToggles
            AllowMonsterItemsSwitch.IsToggled = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.AllowMonsterItems;
            ImmuneMonstersSwitch.IsToggled = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.ImmuneMonsters;
            #endregion

            #region Abilities
            AllowAbilitiesSwitch.IsToggled = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.AllowAbilities;
            ForceAbilitiesSwitch.IsToggled = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.ForceAbilities;
            #endregion

            #region Hackathon
            ReflectDamageSwitch.IsToggled = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.DamageReflect;
            #endregion
        }

        /// <summary>
        /// Set the Character Hit Enum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void BattleModePicker_Changed(object sender, EventArgs args)
        {
            // Check for null, SelectedItem is not set when the control is created
            if (BattleModePicker.SelectedItem == null)
            {
                return;
            }

            // Change the Difficulty
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.BattleModeEnum = BattleModeEnumHelper.ConvertMessageStringToEnum(BattleModePicker.SelectedItem.ToString());
        }

        /// <summary>
        /// Set the Monster Hit Enum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void MonsterHitPicker_Changed(object sender, EventArgs args)
        {
            // Check for null, SelectedItem is not set when the control is created
            if (MonsterHitPicker.SelectedItem == null)
            {
                return;
            }

            // Change the Difficulty
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnumHelper.ConvertStringToEnum(MonsterHitPicker.SelectedItem.ToString());
        }

        /// <summary>
        /// Set the Character Hit Enum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void CharacterHitPicker_Changed(object sender, EventArgs args)
        {
            // Check for null, SelectedItem is not set when the control is created
            if (CharacterHitPicker.SelectedItem == null)
            {
                return;
            }

            // Change the Difficulty
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnumHelper.ConvertStringToEnum(CharacterHitPicker.SelectedItem.ToString());
        }

        /// <summary>
        /// Close The Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void CloseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Toggle ImmunePlayers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ImmunePlayers_Toggled(object sender, EventArgs e)
        {
            // Flip the settings
            if (ImmunePlayersSwitch.IsToggled == true)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.ImmunePlayers = true;
                return;
            }

            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.ImmunePlayers = false;
        }

        /// <summary>
        /// Toggle ImmuneMonsters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ImmuneMonsters_Toggled(object sender, EventArgs e)
        {
            // Flip the settings
            if (ImmuneMonstersSwitch.IsToggled == true)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.ImmuneMonsters = true;
                return;
            }

            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.ImmuneMonsters = false;
        }

        /// <summary>
        /// Toggle AllowAbilities
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AllowAbilities_Toggled(object sender, EventArgs e)
        {
            // Flip the settings
            if (AllowAbilitiesSwitch.IsToggled == true)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.AllowAbilities = true;
                return;
            }

            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.AllowAbilities = false;
        }

        /// <summary>
        /// Toggle ForceAbilities
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ForceAbilities_Toggled(object sender, EventArgs e)
        {
            // Flip the settings
            if (ForceAbilitiesSwitch.IsToggled == true)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.ForceAbilities = true;
                return;
            }
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.ForceAbilities = false;
        }

        /// <summary>
        /// Toggle Monster Items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AllowMonsterItems_Toggled(object sender, EventArgs e)
        {
            // Flip the settings
            if (AllowMonsterItemsSwitch.IsToggled == true)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.AllowMonsterItems = true;
                return;
            }

            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.AllowMonsterItems = false;
        }

        /// <summary>
        /// Toggle reflection of damage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ReflectDamage_Toggled(object sender, EventArgs e)
        {
            // Flip the settings
            if (ReflectDamageSwitch.IsToggled == true)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.DamageReflect = true;
                return;
            }

            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.DamageReflect = false;
        }

        public void TimeWarp_Toggled(object sender, EventArgs e)
        {
            // Flip the settings
            if (TimeWarpSwitch.IsToggled == true)
            {
                BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.TimeWarp = true;
                return;
            }

            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleSettingsModel.TimeWarp = false;
        }

        /// <summary>
        /// sets the chance of reflection to the stepper value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ReflectChance_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            ChanceText.Text = ReflectChance + "%";
        }
    }
}