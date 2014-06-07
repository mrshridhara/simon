using System.Diagnostics;

namespace Simon.Presentation.Tests.Steps
{
    public class CreateNewProjectSteps
    {
        public void SimonNewProjectPageIsOpen()
        {
            Debug.WriteLine("new project page is open in simon app");
            throw new System.NotImplementedException();
        }

        public void NewProjectTextBoxAndButtonAreVisible()
        {
            Debug.WriteLine("new project text box and button are visible");
            throw new System.NotImplementedException();
        }

        public void IEnterTheProjectNameAs(string projectName)
        {
            Debug.WriteLine("I enter the project name as \"{0}\"", new object[] { projectName });
            throw new System.NotImplementedException();
        }

        public void ClickOnButtonWithName(string buttonText)
        {
            Debug.WriteLine("click on button with name \"{0}\"", new object[] { buttonText });
            throw new System.NotImplementedException();
        }

        public void ANewProjectShouldGetCreatedWithNameAs(string projectName)
        {
            Debug.WriteLine("a new project should get created with name as \"{0}\"", new object[] { projectName });
            throw new System.NotImplementedException();
        }

        public void SimonShouldNavigateToTheNewlyCreatedProjectPage()
        {
            Debug.WriteLine("simon should navigate to the newly created project page");
            throw new System.NotImplementedException();
        }
    }
}