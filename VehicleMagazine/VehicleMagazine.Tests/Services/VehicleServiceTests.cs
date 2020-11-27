using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using VehicleMagazine.Models;
using VehicleMagazine.Repository.Abstraction;
using VehicleMagazine.Services;
using VehicleMagazine.Services.Abstraction;
using VehicleMagazine.Validators.Abstraction;

namespace VehicleMagazine.Tests.Services
{
    [TestFixture]
    class VehicleServiceTests
    {
        public Mock<IVehicleRepository> vehicleRepositoryMock;
        public Mock<IVehicleValidator> vehicleValidatorMock;

        public IVehicleService sut;

        [SetUp]
        public void SetUp()
        {
            this.vehicleRepositoryMock = new Mock<IVehicleRepository>();
            this.vehicleValidatorMock = new Mock<IVehicleValidator>();

            this.sut = new VehicleService(this.vehicleRepositoryMock.Object, this.vehicleValidatorMock.Object);
        }

        [Test]
        public void GivenVehicle_WhenVehicleIsNotValid_ThenThrowException()
        {
            // Arrange
            this.vehicleValidatorMock
                .Setup(s => s.Validate(It.IsAny<Vehicle>()))
                .Returns(false);

            // Act
            // Assert
            sut.Invoking(y => y.CreateVehicle(new Vehicle()))
            .Should().Throw<Exception>()
            .WithMessage("Vehicle data are not valid!");
        }

        [Test]
        public void GivenVehicle_WhenVehicleIsCreatedInDb_ThenVerify()
        {
            // Arrange
            var vehicle = new Vehicle()
            {
                FirstRegYear = 1990,
                Model = "Kia",
                VinNumber = "ABCDEFGHIJ1234567"
            };

            this.vehicleValidatorMock
                .Setup(s => s.Validate(It.IsAny<Vehicle>()))
                .Returns(true);
            this.vehicleRepositoryMock.Setup(s => s.Create(It.IsAny<Vehicle>()))
                .Returns(1);

            // Act
            this.sut.CreateVehicle(vehicle);

            // Assert
            this.vehicleValidatorMock.Verify(v => v.Validate(It.Is<Vehicle>(x => x.FirstRegYear == vehicle.FirstRegYear)), Times.Once);
            this.vehicleRepositoryMock.Verify(v => v.Create(It.Is<Vehicle>(x => x.FirstRegYear == vehicle.FirstRegYear)), Times.Once);
        }
    }
}
