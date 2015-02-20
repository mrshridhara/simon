using Simon.Api.Web.Models;
using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Simon.Api.Web.Controllers
{
    /// <summary>
    /// API to manipulate application data.
    /// </summary>
    public sealed class ApplicationsController : ApiController
    {
        private readonly IMapper<ApplicationModel, Application> applicationModelToApplicationMapper;
        private readonly IMapper<Application, ApplicationModel> applicationToApplicationModelMapper;
        private readonly IPersistence<Project> projectPersistence;

        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationsController"/> class.
        /// </summary>
        /// <param name="projectPersistence">The project persistence.</param>
        /// <param name="applicationModelToApplicationMapper">The application model to application mapper.</param>
        /// <param name="applicationToApplicationModelMapper">The application to application model mapper.</param>
        public ApplicationsController(
            IPersistence<Project> projectPersistence,
            IMapper<ApplicationModel, Application> applicationModelToApplicationMapper,
            IMapper<Application, ApplicationModel> applicationToApplicationModelMapper)
        {
            Guard.NotNullArgument("projectPersistence", projectPersistence);
            Guard.NotNullArgument("applicationModelToApplicationMapper", applicationModelToApplicationMapper);
            Guard.NotNullArgument("applicationToApplicationModelMapper", applicationToApplicationModelMapper);

            this.projectPersistence = projectPersistence;
            this.applicationModelToApplicationMapper = applicationModelToApplicationMapper;
            this.applicationToApplicationModelMapper = applicationToApplicationModelMapper;
        }

        /// <summary>
        /// Gets the application with the specified <paramref name="applicationId"/>
        /// belonging to the project with the specified <paramref name="projectId"/>.
        /// </summary>
        /// <param name="projectId">The ID of a project.</param>
        /// <param name="applicationId">The ID of a application.</param>
        /// <returns>
        /// Application with the specified <paramref name="applicationId"/>.
        /// </returns>
        public async Task<IHttpActionResult> GetAsync(string projectId, string applicationId)
        {
            Guid inputProjectId;
            if (Guid.TryParse(projectId, out inputProjectId) == false)
            {
                return BadRequest("Project ID should be a valid GUID.");
            }

            Guid inputApplicationId;
            if (Guid.TryParse(applicationId, out inputApplicationId) == false)
            {
                return BadRequest("Application ID should be a valid GUID.");
            }

            var projects = await projectPersistence.ReadAll();

            var selectedProject
                = projects.FirstOrDefault(eachProject => eachProject.Id == inputProjectId);

            if (selectedProject == null)
            {
                return NotFound();
            }

            var selectedApplication
                = selectedProject
                    .Applications
                    .FirstOrDefault(
                        eachApplication => eachApplication.Id == inputApplicationId);

            if (selectedApplication == null)
            {
                return NotFound();
            }

            var applicationModel = applicationToApplicationModelMapper.Map(selectedApplication);
            return Ok(applicationModel);
        }

        /// <summary>
        /// Adds the specified <paramref name="applicationModel"/> to the sequence of applications.
        /// </summary>
        /// <param name="applicationModel">The application data taken from HTTP body.</param>
        /// <returns>
        /// Status of the addition.
        /// </returns>
        public async Task<IHttpActionResult> PostAsync([FromBody]ApplicationModel applicationModel)
        {
            var projects = await projectPersistence.ReadAll();

            var selectedProject
                = projects.FirstOrDefault(eachProject => eachProject.Id == applicationModel.ProjectId);

            if (selectedProject == null)
            {
                return BadRequest("Project ID is not valid.");
            }

            var application = applicationModelToApplicationMapper.Map(applicationModel);

            if (application.Id == Guid.Empty)
            {
                selectedProject.AddApplication(application);
            }
            else
            {
                selectedProject.ReplaceApplication(application);
            }

            await projectPersistence.Update(selectedProject);

            return Ok();
        }
    }
}