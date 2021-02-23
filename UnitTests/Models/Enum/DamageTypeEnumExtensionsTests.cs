using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class DamageTypeEnumExtensionsTests
    {
        [Test]
        public void DamageTypeEnumExtensionsTests_Unknown_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = DamageTypeEnum.None.ToMessage();

            // Reset

            // Assert
            Assert.AreEqual("None", result);
        }

    }
}
