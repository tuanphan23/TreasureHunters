using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;
using Game.ViewModels;
using Game.Engine.EngineGame;
using Game.Engine.EngineModels;

namespace UnitTests.Engine.EngineGame
{
    [TestFixture]
    public class TurnEngineGameTests
    {
        #region TestSetup
        BattleEngine Engine;

        [SetUp]
        public void Setup()
        {
            Engine = new BattleEngine();
            Engine.Round = new RoundEngine();
            Engine.Round.Turn = new TurnEngine();
            //Engine.StartBattle(true);   // Start engine in auto battle mode
        }

        [TearDown]
        public void TearDown()
        {
        }
        #endregion TestSetup

        #region Constructor
        [Test]
        public void TurnEngine_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = Engine;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
        #endregion Constructor

        #region Attack
        [Test]
        public void TurnEngine_Attack_Valid_Empty_Monster_List_Should_Fail()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel(new CharacterModel());

            // Act
            var result = Engine.Round.Turn.Attack(PlayerInfo);

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void TurnEngine_Attack_InValid_Empty_Character_List_Should_Fail()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel(new MonsterModel());

            // Cause an error by making the list empty
            Engine.EngineSettings.CharacterList.Clear();
            Engine.EngineSettings.CurrentDefender = null;
            Engine.EngineSettings.CurrentAttacker = null;

            Engine.StartBattle(true);   // Clear the Engine

            // Act
            var result = Engine.Round.Turn.Attack(PlayerInfo);

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void TurnEngine_Attack_Valid_Correct_List_Should_Pass()
        {
            // Arrange
            var PlayerInfo = new PlayerInfoModel();
            Engine.EngineSettings.MonsterList.Add(new PlayerInfoModel(new MonsterModel()));

            // Act
            var result = Engine.Round.Turn.Attack(PlayerInfo);

            // Reset
            Engine.StartBattle(false);   // Clear the Engine

            // Assert
            Assert.AreEqual(true, result);
        }
        #endregion Attack
    }
}