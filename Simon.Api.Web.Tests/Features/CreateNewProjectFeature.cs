using NUnit.Framework;
using Simon.Api.Web.Tests.Steps;

namespace Simon.Api.Web.Tests.Features
{
    [TestFixture]
    public class CreateNewProjectFeature : FeatureBase<CreateNewProjectSteps>
    {
        [Test(Description = "Scenario: Create new project")]
        [Ignore("Incomplete feature.")]
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