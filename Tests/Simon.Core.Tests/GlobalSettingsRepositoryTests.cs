using Moq;
using NUnit.Framework;
using Simon.Infrastructure;
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
            var globalSettingsDictionary = new Dictionary<string, string>
            {
                { "TestSetting", "some value" }
            };

            var expectedGlobalSettings = new Simon.Infrastructure.GlobalSettings(globalSettingsDictionary);

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
                                        GetGlobalSettingsResult>(It.IsAny<Simon.Infrastructure.GlobalSettings>()))
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
            Assert.AreEqual("some value", actualGlobalSettings["TestSetting"]);
        }

        [Test]
        public void Shrould_Update_Global_Settings()
        {
            // Arrange
            var globalSettingsDictionary = new Dictionary<string, string>
            {
                { "TestSetting", "some other value" }
            };

            var globalSettingsToBeUpdated = new Simon.Infrastructure.GlobalSettings(globalSettingsDictionary);

            var asyncProcessMock = new Mock<IAsyncProcess<UpdateGlobalSettingsContext>>();
            asyncProcessMock
                .Setup(mock => mock.ExecuteAsync(It.IsAny<UpdateGlobalSettingsContext>()))
                .Returns(Task.Run(() => { }))
                .Verifiable();

            var asyncProcessFactoryMock = new Mock<IAsyncProcessFactory>();
            asyncProcessFactoryMock
                .Setup(mock => mock.CreateAsyncProcess<
                                        UpdateGlobalSettingsContext>(It.IsAny<Simon.Infrastructure.GlobalSettings>()))
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