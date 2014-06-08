using Moq;
using NUnit.Framework;
using Simon.Processes;
using Simon.Processes.FileSystem;
using Simon.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simon.Core.Tests
{
    [TestFixture]
    public class GlobalSettingsRepositoryTests
    {
        [Test]
        public void Shrould_Get_Global_Settings()
        {
            // Arrange
            var globalSettingsDictionary = new Dictionary<string, dynamic>
            {
                { "TestSetting", true }
            };

            var expectedGlobalSettings = new GlobalSettings(globalSettingsDictionary);

            var asyncProcessMock = new Mock<IAsyncProcess<EmptyContext, GetGlobalSettingsResult>>();
            asyncProcessMock
                .Setup(mock => mock.ExecuteAsync(It.IsAny<EmptyContext>()))
                .Returns(Task.Factory.StartNew(() =>
                    new GetGlobalSettingsResult { GlobalSettings = expectedGlobalSettings }))
                .Verifiable();

            var asyncProcessFactoryMock = new Mock<IAsyncProcessFactory>();
            asyncProcessFactoryMock
                .Setup(mock => mock.CreateAsyncProcess<
                                        EmptyContext,
                                        GetGlobalSettingsResult>(It.IsAny<GlobalSettings>()))
                .Returns(asyncProcessMock.Object)
                .Verifiable();

            var target = new GlobalSettingsRepository(asyncProcessFactoryMock.Object);

            // Act
            var results = target.ReadAll().Result;

            // Assert
            asyncProcessFactoryMock.VerifyAll();
            asyncProcessMock.VerifyAll();

            Assert.IsNotNull(results);

            var actualGlobalSettings = results.FirstOrDefault();
            Assert.IsNotNull(actualGlobalSettings);
            Assert.IsTrue(actualGlobalSettings["TestSetting"]);
        }

        [Test]
        public void Shrould_Update_Global_Settings()
        {
            // Arrange
            var globalSettingsDictionary = new Dictionary<string, dynamic>
            {
                { "TestSetting", true }
            };

            var globalSettingsToBeUpdated = new GlobalSettings(globalSettingsDictionary);

            var asyncProcessMock = new Mock<IAsyncProcess<UpdateGlobalSettingsContext>>();
            asyncProcessMock
                .Setup(mock => mock.ExecuteAsync(It.IsAny<UpdateGlobalSettingsContext>()))
                .Returns(Task.Run(() => { }))
                .Verifiable();

            var asyncProcessFactoryMock = new Mock<IAsyncProcessFactory>();
            asyncProcessFactoryMock
                .Setup(mock => mock.CreateAsyncProcess<
                                        UpdateGlobalSettingsContext>(It.IsAny<GlobalSettings>()))
                .Returns(asyncProcessMock.Object)
                .Verifiable();

            var target = new GlobalSettingsRepository(asyncProcessFactoryMock.Object);

            // Act
            target.Update(globalSettingsToBeUpdated).Wait();

            // Assert
            asyncProcessFactoryMock.VerifyAll();
            asyncProcessMock.VerifyAll();
        }
    }
}