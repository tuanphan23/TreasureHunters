using System.Threading.Tasks;
using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;
using Game.ViewModels;
using Game.Engine.EngineKoenig;

namespace UnitTests.Engine.EngineKoenig
{
    [TestFixture]
    public class AutoBattleEngineKoenigTests
    {
        #region TestSetup
        public AutoBattleEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new AutoBattleEngine();

            Engine.Battle.EngineSettings.CharacterList.Clear();
            Engine.Battle.EngineSettings.MonsterList.Clear();
            Engine.Battle.EngineSettings.CurrentDefender = null;
            Engine.Battle.EngineSettings.CurrentAttacker = null;

            Engine.Battle.StartBattle(true);   // Clear the Engine
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Constructor
        [Test]
        public void AutoBattleEngine_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void AutoBattleEngine_Constructor_Valid_Battle_Round_Turn_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;
            result.Battle = new BattleEngine();
            result.Battle.Round = new RoundEngine();
            result.Battle.Round.Turn = new TurnEngine();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        #endregion Constructor

        #region RunAutoBattle
        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Valid_Default_Should_Pass()
        {
            //Arrange

            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(3);

            var data = new CharacterModel { Level = 1, MaxHealth = 10 };

            Engine.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            Engine.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            Engine.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            Engine.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            Engine.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
            Engine.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));

            //Act
            var result = await Engine.RunAutoBattle();

            //Reset
            DiceHelper.DisableForcedRolls();
            CharacterIndexViewModel.Instance.ForceDataRefresh();

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Valid_Monsters_1_Should_Pass()
        {
            //Arrange

            // Need to set the Monster count to 1, so the battle goes to Next Round Faster
            Engine.Battle.EngineSettings.MaxNumberPartyMonsters = 1;
            Engine.Battle.EngineSettings.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1,
                                Level = 10,
                                CurrentHealth = 11,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            });

            Engine.Battle.EngineSettings.CharacterList.Add(CharacterPlayerMike);

            //Act
            var result = await Engine.RunAutoBattle();

            //Reset
            CharacterIndexViewModel.Instance.ForceDataRefresh();

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public async Task AutoBattleEngine_RunAutoBattle_Valid_Monster_1_Should_ReturnNewRound()
        {
            //Arrange

            // Need to set the Monster count to 1, so the battle goes to Next Round Faster
            Engine.Battle.EngineSettings.MaxNumberPartyMonsters = 1;
            Engine.Battle.EngineSettings.MaxNumberPartyCharacters = 2;

            // Make a Strong Character with lots of health,  set level to 1 so the monsters are low level
            Engine.Battle.EngineSettings.CharacterList.Add(new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 100,
                                Level = 1,
                                CurrentHealth = 110,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                                ListOrder = 1,
                            }));

            //Act
            var result = await Engine.RunAutoBattle();

            //Reset
            CharacterIndexViewModel.Instance.ForceDataRefresh();

            //Assert
            Assert.AreEqual(true, result);
        }
        #endregion RunAutoBattle

        #region CreateCharacterParty
        [Test]
        public async Task AutoBattleEngine_CreateCharacterParty_Valid_Characters_Should_Assign_6()
        {
            //Arrange
            Engine.Battle.EngineSettings.MaxNumberPartyCharacters = 6;

            CharacterIndexViewModel.Instance.Dataset.Clear();

            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "1" });
            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "2" });
            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "3" });
            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "4" });
            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "5" });
            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "6" });
            await CharacterIndexViewModel.Instance.CreateAsync(new CharacterModel { Name = "7" });

            //Act
            var result = Engine.CreateCharacterParty();
            var count = Engine.Battle.EngineSettings.CharacterList.Count();
            var name = Engine.Battle.EngineSettings.CharacterList.ElementAt(5).Name;

            //Reset
            CharacterIndexViewModel.Instance.ForceDataRefresh();

            //Assert
            Assert.AreEqual(6, count);
            Assert.AreEqual("6", name);
        }

        [Test]
        public void AutoBattleEngine_CreateCharacterParty_Valid_Characters_CharacterIndex_None_Should_Create_6()
        {
            //Arrange
            Engine.Battle.EngineSettings.MaxNumberPartyCharacters = 6;

            CharacterIndexViewModel.Instance.Dataset.Clear();

            //Act
            var result = Engine.CreateCharacterParty();
            var count = Engine.Battle.EngineSettings.CharacterList.Count();

            //Reset
            CharacterIndexViewModel.Instance.ForceDataRefresh();

            //Assert
            Assert.AreEqual(6, count);
        }
        #endregion CreateCharacterParty   

        #region DetectInfinateLoop

        [Test]
        public void AutoBattleEngine_DetectInfinateLoop_InValid_RoundCount_Higher_MaxRound_Should_Return_True()
        {
            //Arrange
            var oldTurnCount = Engine.Battle.EngineSettings.BattleScore.TurnCount;
            var oldTurnMax = Engine.Battle.EngineSettings.MaxTurnCount;
            var oldRoundCount = Engine.Battle.EngineSettings.BattleScore.RoundCount;
            var oldRoundMax = Engine.Battle.EngineSettings.MaxRoundCount;

            Engine.Battle.EngineSettings.BattleScore.RoundCount = 10;
            Engine.Battle.EngineSettings.MaxRoundCount = 1;
            Engine.Battle.EngineSettings.BattleScore.TurnCount = 1;
            Engine.Battle.EngineSettings.MaxTurnCount = 10;

            //Act
            var result = Engine.DetectInfinateLoop();

            //Reset
            Engine.Battle.EngineSettings.BattleScore.TurnCount = oldTurnCount;
            Engine.Battle.EngineSettings.MaxTurnCount = oldTurnMax;
            Engine.Battle.EngineSettings.BattleScore.RoundCount = oldRoundCount;
            Engine.Battle.EngineSettings.MaxRoundCount = oldRoundMax;

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void AutoBattleEngine_DetectInfinateLoop_InValid_TurnCount_Higher_MaxTurn_Should_Return_True()
        {
            //Arrange
            var oldTurnCount = Engine.Battle.EngineSettings.BattleScore.TurnCount;
            var oldTurnMax = Engine.Battle.EngineSettings.MaxTurnCount;
            var oldRoundCount = Engine.Battle.EngineSettings.BattleScore.RoundCount;
            var oldRoundMax = Engine.Battle.EngineSettings.MaxRoundCount;

            Engine.Battle.EngineSettings.BattleScore.RoundCount = 1;
            Engine.Battle.EngineSettings.MaxRoundCount = 10;
            Engine.Battle.EngineSettings.BattleScore.TurnCount = 10;
            Engine.Battle.EngineSettings.MaxTurnCount = 1;

            //Act
            var result = Engine.DetectInfinateLoop();

            //Reset
            Engine.Battle.EngineSettings.BattleScore.TurnCount = oldTurnCount;
            Engine.Battle.EngineSettings.MaxTurnCount = oldTurnMax;
            Engine.Battle.EngineSettings.BattleScore.RoundCount = oldRoundCount;
            Engine.Battle.EngineSettings.MaxRoundCount = oldRoundMax;

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void AutoBattleEngine_DetectInfinateLoop_Valid_TurnCount__RoundCount_Lower_Max_Should_Return_false()
        {
            //Arrange
            var oldTurnCount = Engine.Battle.EngineSettings.BattleScore.TurnCount;
            var oldTurnMax = Engine.Battle.EngineSettings.MaxTurnCount;
            var oldRoundCount = Engine.Battle.EngineSettings.BattleScore.RoundCount;
            var oldRoundMax = Engine.Battle.EngineSettings.MaxRoundCount;

            Engine.Battle.EngineSettings.BattleScore.RoundCount = 1;
            Engine.Battle.EngineSettings.MaxRoundCount = 10;

            Engine.Battle.EngineSettings.BattleScore.TurnCount = 1;
            Engine.Battle.EngineSettings.MaxTurnCount = 10;

            //Act
            var result = Engine.DetectInfinateLoop();

            //Reset
            Engine.Battle.EngineSettings.BattleScore.TurnCount = oldTurnCount;
            Engine.Battle.EngineSettings.MaxTurnCount = oldTurnMax;
            Engine.Battle.EngineSettings.BattleScore.RoundCount = oldRoundCount;
            Engine.Battle.EngineSettings.MaxRoundCount = oldRoundMax;

            //Assert
            Assert.AreEqual(false, result);
        }
        #endregion DetectInfinateLoop
    }
}
