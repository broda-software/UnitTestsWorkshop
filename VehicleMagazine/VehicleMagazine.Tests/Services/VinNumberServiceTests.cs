using FluentAssertions;
using NUnit.Framework;
using VehicleMagazine.Services;
using VehicleMagazine.Services.Abstraction;

namespace VehicleMagazine.Tests.Services
{
    [TestFixture]
    class VinNumberServiceTests
    {
        public IVinNumberService sut;

        [SetUp]
        public void SetUp()
        {
            this.sut = new VinNumberService();
        }

        [TestCase("ABCDEFGHIJKLMNOPR")]
        [TestCase("01234567891234567")]
        [TestCase("A1B2C3D4E5F6G7H8I")]
        [TestCase("123456!@#$%^qweQW")]
        public void GivenVinNumber_WhenVinHasCorrectLength_ThenReturnTrue(string vinNumber)
        {   
            // Arrange
            // Act
            var result = this.sut.IsVinNumberLengthValid(vinNumber);

            // Assert
            result.Should().BeTrue();
        }

        [TestCase("A1B2C3D4E5F6G7H8")]
        [TestCase("123456!@#$%^qweQWQ")]
        [TestCase("")]
        [TestCase(null)]
        public void GivenVinNumber_WhenVinHasNotCorrectLength_ThenReturnFalse(string vinNumber)
        {
            // Arrange
            // Act
            var result = this.sut.IsVinNumberLengthValid(vinNumber);

            // Assert
            result.Should().BeFalse();
        }
    }
}
