using NUnit.Framework;
using Simon.UI.Web.Tests.Steps;

namespace Simon.UI.Web.Tests.Features
{
	[TestFixture]
	public class CreateNewProjectFeature : FeatureBase<CreateNewProjectSteps>
	{
		[Test]
		public void ShouldBeAbleToCreateNewProject()
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