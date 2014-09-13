using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Simon.Infrastructure;
using Simon.Processes.FileSystem;
using Simon.Repositories;

namespace Simon.Core.Tests
{
    [TestClass]
    public class GlobalSettingsRepositoryTests
    {
        [TestMethod]
        public void Shrould_Get_Global_Settings()
        {
            // Arrange
            var globalSettingsDictionary = new Dictionary<string, GlobalSettingsItem>
            {
                { "TestSetting", new GlobalSettingsItem("some name", "some value") }
            };

            var expectedGlobalSettings = new GlobalSettings(globalSettingsDictionary);

            var getGlobalSettingsMock = new Mock<IAsyncProcess<EmptyContext, GetGlobalSettingsResult>>();
            getGlobalSettingsMock
                .Setup(mock => mock.ExecuteAsync(It.IsAny<EmptyContext>()))
                .Returns(Task.Factory.StartNew(() =>
                    new GetGlobalSettingsResult { GlobalSettings = expectedGlobalSettings }))
                .Verifiable();

            var updateGlobalSettingsMock = new Mock<IAsyncProcess<UpdateGlobalSettingsContext>>();
            updateGlobalSettingsMock
                .Setup(mock => mock.ExecuteAsync(It.IsAny<UpdateGlobalSettingsContext>()))
                .Throws<InvalidOperationException>();

            var target
                = new GlobalSettingsRepository(
                        getGlobalSettingsMock.Object,
                        updateGlobalSettingsMock.Object);

            // Act
            var results = target.ReadAll().Result;

            // Assert
            getGlobalSettingsMock.VerifyAll();
            results.Should().NotBeNull();

            var actualGlobalSettings = results.FirstOrDefault();
            actualGlobalSettings.Should().NotBeNull();
            actualGlobalSettings.Should().BeEquivalentTo(expectedGlobalSettings);
        }

        [TestMethod]
        public void Shrould_Update_Global_Settings()
        {
            // Arrange
            var globalSettingsDictionary = new Dictionary<string, GlobalSettingsItem>
            {
                { "TestSetting", new GlobalSettingsItem("some other name", "some other value") }
            };

            var globalSettingsToBeUpdated = new GlobalSettings(globalSettingsDictionary);

            var getGlobalSettingsMock = new Mock<IAsyncProcess<EmptyContext, GetGlobalSettingsResult>>();
            getGlobalSettingsMock
                .Setup(mock => mock.ExecuteAsync(It.IsAny<EmptyContext>()))
                .Throws<InvalidOperationException>();

            var updateGlobalSettingsMock = new Mock<IAsyncProcess<UpdateGlobalSettingsContext>>();
            updateGlobalSettingsMock
                .Setup(mock => mock.ExecuteAsync(It.IsAny<UpdateGlobalSettingsContext>()))
                .Returns(Task.Run(() => { }))
                .Verifiable();

            var target
                = new GlobalSettingsRepository(
                        getGlobalSettingsMock.Object,
                        updateGlobalSettingsMock.Object);

            // Act
            target.Update(globalSettingsToBeUpdated).Wait();

            // Assert
            updateGlobalSettingsMock.VerifyAll();
        }
    }
}