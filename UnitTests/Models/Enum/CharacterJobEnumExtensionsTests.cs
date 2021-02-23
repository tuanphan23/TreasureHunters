using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class CharacterJobEnumExtensionsTests
    {
        [Test]
        public void CharacterJobEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Unknown.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Player", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Fighter_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Fighter.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Cleric_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Cleric.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Finder_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Finder.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Finder", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Adventurer_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Adventurer.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Adventurer", result);
        }


        [Test]
        public void CharacterJobEnumExtensionsTests_TreasureHunter_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.TreasureHunter.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Treasure Hunter", result);
        }

        [Test]
        public void CharacterJobEnumExtensionsTests_Seeker_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = CharacterJobEnum.Seeker.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Seeker", result);
        }

    }
}
