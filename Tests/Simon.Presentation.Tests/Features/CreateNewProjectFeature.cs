using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simon.Presentation.Tests.Steps;

namespace Simon.Presentation.Tests.Features
{
    [TestClass]
    public class CreateNewProjectFeature : FeatureBase<CreateNewProjectSteps>
    {
        [TestMethod]
        [Ignore]
        public void CreateNewProject()
        {
            Given.SimonNewProjectPageIsOpen();
            And.NewProjectTextBoxAndButtonAreVisible();

            When.IEnterTheProjectNameAs("NewProject_1");
            And.ClickOnButtonWithName("Create New Project");

            Then.ANewProjectShouldGetCreatedWithNameAs("NewProject_1");
            And.SimonShouldNavigateToTheNewlyCreatedProjectPage();
        }
    }
}