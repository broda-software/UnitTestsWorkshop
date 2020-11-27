using FluentAssertions;
using NUnit.Framework;
using VehicleMagazine.Models;
using VehicleMagazine.Validators;
using VehicleMagazine.Validators.Abstraction;

namespace VehicleMagazine.Tests.Validators
{
    [TestFixture]
    class VehicleValidatorTests
    {
        public IVehicleValidator sut;

        [SetUp]
        public void SetUp()
        {
            this.sut = new VehicleValidator();
        }

        [TestCase(1899)]
        [TestCase(2021)]
        public void GivenFirstRegYear_WhenYearIsNotValid_ThenReturnFalse(int firstRegYear)
        {
            // Arrange
            var vehicle = new Vehicle()
            {
                FirstRegYear = firstRegYear
            };

            // Act
            var result = this.sut.Validate(vehicle);

            // Assert
            result.Should().BeFalse();
        }

        [TestCase(1900)]
        [TestCase(1950)]
        [TestCase(2020)]
        public void GivenFirstRegYear_WhenYearIsValid_ThenReturnTrue(int firstRegYear)
        {
            // Arrange
            var vehicle = new Vehicle()
            {
                FirstRegYear = firstRegYear
            };

            // Act
            var result = this.sut.Validate(vehicle);

            // Assert
            result.Should().BeTrue();
        }
    }
}
