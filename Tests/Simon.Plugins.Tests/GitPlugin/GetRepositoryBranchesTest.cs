using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simon.Infrastructure;
using Simon.Processes.SourceControl.Git;

namespace Simon.Plugins.Tests.GitPlugin
{
    [TestClass]
    public class GetRepositoryBranchesTest
    {
        [TestMethod]
        [Ignore]
        public void Should_Get_Available_Branches()
        {
            // Arrange.
            var globalSettings = new GlobalSettings(new Dictionary<string, GlobalSettingsItem>
            {
                {
                    Constants.GitRepoPathKey,
                    new GlobalSettingsItem(string.Empty, @"C:\Users\mrshr_000\Projects\Simon\.git", false)
                }
            });
            var target = new GetRepositoryBranches(globalSettings);

            // Act.
            var result = target.ExecuteAsync(EmptyContext.Instance).Result;

            // Assert.
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Branches);
            foreach (var eachBranch in result.Branches)
            {
                Assert.IsNotNull(eachBranch.TipCommitSha);
            }
        }
    }
}