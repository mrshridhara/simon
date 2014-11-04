using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simon.Processes.FileSystem;

namespace Simon.Core.Tests
{
    [TestClass]
    public class GetInstalledPluginsTests
    {
        [TestMethod]
        public void Should_Get_Installed_Plugins()
        {
            var target = new GetInstalledPlugins();
            var result = target.ExecuteAsync(EmptyContext.Instance).Result;
            Assert.IsNotNull(result);
        }
    }
}
