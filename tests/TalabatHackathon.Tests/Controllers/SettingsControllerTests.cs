using System;
using FluentAssertions;
using NSubstitute;
using TalabatHackathon.API.Controllers;
using Xunit;

namespace TalabatHackathon.API.Controllers
{
    public class SettingsControllerTests
    {
        public SettingsControllerTests() { }

        private SettingsController CreateSettingsController()
        {
            return new SettingsController();
        }

        [Fact]
        public void GetSettings_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var settingsController = this.CreateSettingsController();

            // Act
            var result = settingsController.GetSettings();

            // Assert
            result.Should().NotBeNull();
        }
    }
}
