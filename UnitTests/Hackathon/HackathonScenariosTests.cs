using NUnit.Framework;

using Game.Models;
using System.Threading.Tasks;
using Game.ViewModels;

namespace Scenario
{
    [TestFixture]
    public class HackathonScenarioTests
    {
        #region TestSetup
        readonly BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        [SetUp]
        public void Setup()
        {
            // Choose which engine to run
            EngineViewModel.SetBattleEngineToGame();

            // Put seed data into the system for all tests
            EngineViewModel.Engine.Round.ClearLists();

            //Start the Engine in AutoBattle Mode
            EngineViewModel.Engine.StartBattle(false);

            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Default;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum= HitStatusEnum.Default;

            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowCriticalHit = false;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowCriticalMiss = false;
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Scenario0
        [Test]
        public void HakathonScenario_Scenario_0_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      #
            *      
            * Description: 
            *      <Describe the scenario>
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      <List Files Changed>
            *      <List Classes Changed>
            *      <List Methods Changed>
            * 
            * Test Algrorithm:
            *      <Step by step how to validate this change>
            * 
            * Test Conditions:
            *      <List the different test conditions to make>
            * 
            * Validation:
            *      <List how to validate this change>
            *  
            */

            // Arrange

            // Act

            // Assert
           

            // Act
            var result = EngineViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Scenario0

        #region Scenario1
        [Test]
        public async Task HackathonScenario_Scenario_1_Valid_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      1
            *      
            * Description: 
            *      Make a Character called Mike, who dies in the first round
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      No Code changes requied 
            * 
            * Test Algrorithm:
            *      Create Character named Mike
            *      Set speed to -1 so he is really slow
            *      Set Max health to 1 so he is weak
            *      Set Current Health to 1 so he is weak
            *  
            *      Startup Battle
            *      Run Auto Battle
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify Mike is not in the Player List
            *      Verify Round Count is 1
            *  
            */

            //Arrange

            // Set Character Conditions

            EngineViewModel.Engine.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1, // Will go last...
                                Level = 1,
                                CurrentHealth = 1,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                            });

            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);

            // Set Monster Conditions

            // Auto Battle will add the monsters

            // Monsters always hit
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Hit;

            //Act
            var result = await EngineViewModel.AutoBattleEngine.RunAutoBattle();

            //Reset
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(null, EngineViewModel.Engine.EngineSettings.PlayerList.Find(m => m.Name.Equals("Mike")));
            Assert.AreEqual(1, EngineViewModel.Engine.EngineSettings.BattleScore.RoundCount);
        }
        #endregion Scenario1

        #region Scenario16

        [Test]
        public async Task HackathonScenario_Scenario_16_ToggleActive_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      16
            *      
            * Description: 
            *      Sets toggle for the characters to be ordered by speed starting with the slowest. 
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      Changes to the RoundEngineBase.cs - OrderPlayerListByTurnOrder()
            *      Changes to add toggle to the BattlePage.xaml and the corresponding function call
            *      in the code behind as well as the BattleSettingsModel.cs adding the TimeWarp variable
            * 
            * Test Algrorithm:
            *      Create Character named Mike
            *      Create Character named Doug
            *      Set speed to -1 so he is really slow
            *      Set Doug Speed to 10 so hes fast
            *    
            *      Mike should be first on the list at end of a round
            *  
            *      Startup Battle
            *      Run round
            *      
            *      Check lsit
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify Mike is first player in the list at the end of a round
            *  
            */

            //Arrange

            // Set Character Conditions

            EngineViewModel.EngineGame.EngineSettings.BattleSettingsModel.TimeWarp = true;
            

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1, // Will go first...
                                Level = 15,
                                CurrentHealth = 1,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                            });

            var CharacterPlayerDoug = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 10, // Will go last...
                                Level = 1,
                                CurrentHealth = 1,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Doug",
                            });

            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerMike);
            EngineViewModel.Engine.EngineSettings.CharacterList.Add(CharacterPlayerDoug);

            // Set Monster Conditions

            // Auto Battle will add the monsters

            // Monsters always mis so auto ends
            //EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Miss;

            //Act
            EngineViewModel.Engine.StartBattle(false);

            //Reset
            //EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            //Assert
            Assert.AreEqual(CharacterPlayerMike, EngineViewModel.Engine.EngineSettings.PlayerList[0]);
        }


        #endregion Scenario16

        #region Scenario 25
        [Test]
        public async Task HackathonScenario_Scenario_25_ToggleActive_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      25
            *      
            * Description: 
            *      Sets damage such that it can be reflected back towards a player
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      Changes to RoundEngineBase.cs - added ApplyReflectDamage method and changed TurnAsAttack()
            *      Changes to add toggle to the BattleSettingsPage.xaml and the corresponding function call
            *      Added fields in BattleSettingsModel for toggling reflect and the chance of reflecting
            * 
            * Test Algrorithm:
            *      Create Character named Mike with 1 health so that mike will die upon being damaged by anything
            *      Toggle Reflect damage on
            *      Set Reflect Chance to 100%
            *      Set Monsters to always miss
            *      Set Characters to always hit
            *      Set Ability Use to false
            *  
            *      Startup Battle
            *      Run Auto Battle
            *      
            *      Auto Battle should end with Mike Dying, since the monsters always miss and can't use abilities
            *      The only thing that could have damaged mike was himself!
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *  
            */

            //Arrange

            // Set Character Conditions

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Level = 1,
                                Name = "Mike",
                            });

            //add mike as the only character
            EngineViewModel.AutoBattleEngine.Battle.EngineSettings.CharacterList.Add(CharacterPlayerMike);

            // Auto Battle will add the monsters

            // Set Toggles
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.CharacterHitEnum = HitStatusEnum.Hit;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Miss;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.ForceAbilities = false;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.AllowAbilities = false;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.DamageReflect = true;
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.ReflectChance = 100;
            //set the party size to 1 so that only mike is fighting
            EngineViewModel.AutoBattleEngine.Battle.EngineSettings.MaxNumberPartyCharacters = 1;

            //Act
            var result = await EngineViewModel.AutoBattleEngine.RunAutoBattle();

            //Reset
            EngineViewModel.Engine.EngineSettings.BattleSettingsModel.MonsterHitEnum = HitStatusEnum.Default;

            //Assert
            //check that it succeeded
            Assert.AreEqual(true, result);
            //check that Mike died
            Assert.AreEqual(CharacterPlayerMike.CurrentHealth, 0);
        }
        #endregion
    }
}