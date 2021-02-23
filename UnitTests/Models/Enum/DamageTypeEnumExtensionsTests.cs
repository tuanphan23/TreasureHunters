using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class DamageTypeEnumExtensionsTests
    {
        [Test]
        public void DamageTypeEnumExtensionsTests_None_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DamageTypeEnum.None.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("None", result);
        }

        [Test]
        public void DamageTypeEnumExtensionsTests_Fire_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DamageTypeEnum.Fire.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Fire", result);
        }

        [Test]
        public void DamageTypeEnumExtensionsTests_Electric_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DamageTypeEnum.Electric.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Electric", result);
        }

        [Test]
        public void DamageTypeEnumExtensionsTests_Poison_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DamageTypeEnum.Poison.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Poison", result);
        }

        [Test]
        public void DamageTypeEnumExtensionsTests_Healing_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DamageTypeEnum.Heal.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("Healing", result);
        }

    }
}
