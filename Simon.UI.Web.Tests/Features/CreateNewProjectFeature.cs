using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simon.UI.Web.Tests.Steps;

namespace Simon.UI.Web.Tests.Features
{
	[TestClass]
	public class CreateNewProjectFeature : FeatureBase<CreateNewProjectSteps>
	{
		[TestMethod]
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