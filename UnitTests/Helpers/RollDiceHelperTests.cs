﻿using NUnit.Framework;

using Game.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    public class RollDiceHelperTests
    {
        [Test]
        public void RollDiceHelper_RollDice_Valid_1Time_6sided_Should_Between_1_and_6()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(1, 6);

            // Reset

            // Assert
            Assert.IsTrue(result<7);
            Assert.IsTrue(result > 0);
        }

        [Test]
        public void RollDiceHelper_RollDice_Valid_1Time_6sided_Should_Not_Less_1_and_Greater_6()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(1, 6);

            // Reset

            // Assert
            Assert.IsFalse(result > 6);
            Assert.IsFalse(result < 1);
        }

        [Test]
        public void RollDiceHelper_RollDice_Valid_1Time_6sided_Forced_6_Should_Pass()
        {
            // Arrange
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(6);

            // Act
            var result = DiceHelper.RollDice(1, 6);

            // Reset
            DiceHelper.DisableForcedRolls();

            // Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void RollDiceHelper_RollDice_InValid_NegTime_6sided_Should_Fail()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(-1, 6);

            // Reset

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void RollDiceHelper_RollDice_InValid_1Time_0sided_Should_Fail()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(1, 0);

            // Reset

            // Assert
            Assert.AreEqual(0,result);
        }

        [Test]
        public void RollDiceHelper_RollDice_InValid_1Time_Negsided_Should_Fail()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(1, -1);

            // Reset

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void RollDiceHelper_RollDice_InValid_Neg1Time_6sided_Forced1_Should_Fail()
        {
            //Arrange
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(1);

            //Act
            var result = DiceHelper.RollDice(-1, 6);

            //Reset
            DiceHelper.DisableForcedRolls();

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void RollDiceHelper_RollDice_Valid_1Time_Neg1Sided_Forced1_Should_Pass()
        {
            //Arrange
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(1);

            //Act
            var result = DiceHelper.RollDice(1, -1);

            //Reset
            DiceHelper.DisableForcedRolls();

            //Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void RollDiceHelper_RollDice_InValid_1Time_6Sided_ForcedNeg1_Should_Fail()
        {
            //Arrange
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(-1);

            //Act
            var result = DiceHelper.RollDice(-1, 6);

            //Reset
            DiceHelper.DisableForcedRolls();

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void RollDiceHelper_SetForcedRollValue_Valid_Forced6_Should_Pass()
        {
            //Arrange

            //Act
            var result = DiceHelper.SetForcedRollValue(6);

            //Reset

            //Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void RollDiceHelper_SetForcedRollValue_InValid_ForcedNeg1_Should_Fail()
        {
            //Arrange

            //Act
            var result = DiceHelper.SetForcedRollValue(-1);

            //Reset

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void RollDIceHelper_EnableForcedRolls_Valid_Should_Pass()
        {
            //Arrange

            //Act
            var result = DiceHelper.EnableForcedRolls();

            //Reset
            DiceHelper.DisableForcedRolls();

            //Assert
            Assert.AreEqual(true, result);
        }

        [Test]
        public void RollDiceHelper_DisableForcedRolls_Valid_Should_Pass()
        {
            //Arrange
            DiceHelper.EnableForcedRolls();

            //Act
            var result = DiceHelper.DisableForcedRolls();

            //Reset

            //Assert
            Assert.AreEqual(false, result);
        }
    }
}