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
    /// API to manipulate project data.
    /// </summary>
    public sealed class ProjectsController : ApiController
    {
        private readonly IAsyncPersistence<Project> projectPersistence;
        private readonly IMapper<ProjectModel, Project> projectModelToProjectMapper;
        private readonly IMapper<Project, ProjectModel> projectToProjectModelMapper;

        /// <summary>
        /// Initializes an instance of <see cref="ProjectsController"/>.
        /// </summary>
        /// <param name="projectPersistence">The project persistence.</param>
        /// <param name="projectModelToProjectMapper">The project model to project mapper.</param>
        /// <param name="projectToProjectModelMapper">The project to project model mapper.</param>
        public ProjectsController(
            IAsyncPersistence<Project> projectPersistence,
            IMapper<ProjectModel, Project> projectModelToProjectMapper,
            IMapper<Project, ProjectModel> projectToProjectModelMapper)
        {
            Guard.NotNullArgument("projectPersistence", projectPersistence);
            Guard.NotNullArgument("projectModelToProjectMapper", projectModelToProjectMapper);
            Guard.NotNullArgument("projectToProjectModelMapper", projectToProjectModelMapper);

            this.projectPersistence = projectPersistence;
            this.projectModelToProjectMapper = projectModelToProjectMapper;
            this.projectToProjectModelMapper = projectToProjectModelMapper;
        }

        /// <summary>
        /// Gets the sequence of projects.
        /// </summary>
        /// <returns>
        /// A sequence of projects.
        /// </returns>
        public async Task<IHttpActionResult> GetAsync()
        {
            var projects = await projectPersistence.ReadAll();

            var projectModels
                = projects.Select(
                    eachProject => projectToProjectModelMapper.Map(eachProject));

            return Ok(projectModels);
        }

        /// <summary>
        /// Gets the project with the sepecifed <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of a project.</param>
        /// <returns>
        /// Project with the sepecifed <paramref name="id"/>.
        /// </returns>
        public async Task<IHttpActionResult> GetAsync(string id)
        {
            Guid inputId;
            if (Guid.TryParse(id, out inputId) == false)
            {
                return BadRequest("id should be a valid GUID");
            }

            var projects = await projectPersistence.ReadAll();

            var availableProject
                    = projects.FirstOrDefault(
                        eachProject => eachProject.Id == inputId);

            if (availableProject != null)
            {
                var projectModel = projectToProjectModelMapper.Map(availableProject);
                return Ok(projectModel);
            }

            return NotFound();
        }

        /// <summary>
        /// Adds the specified <paramref name="projectModel"/> to the sequence of projects.
        /// </summary>
        /// <param name="projectModel">The project data taken from HTTP body.</param>
        /// <returns>
        /// Status of the addition.
        /// </returns>
        public async Task<IHttpActionResult> PostAsync([FromBody]ProjectModel projectModel)
        {
            var project = projectModelToProjectMapper.Map(projectModel);
            var updatedProject = await projectPersistence.Create(project);
            var updatedProjectModel = projectToProjectModelMapper.Map(updatedProject);

            return CreatedAtRoute(
                RouteConfig.DefaultRouteName,
                new { controller = "Projects", id = updatedProjectModel.Id },
                updatedProjectModel);
        }

        /// <summary>
        /// Updates the specified <paramref name="project"/> with the specified <paramref name="id"/> in the sequence of projects.
        /// </summary>
        /// <param name="id">The ID of the project.</param>
        /// <param name="project">The project data taken from HTTP body.</param>
        /// <returns>
        /// Status of the addition.
        /// </returns>
        public async Task<IHttpActionResult> PutAsync(string id, [FromBody]Project project)
        {
            return await Task.Run<IHttpActionResult>(() =>
            {
                return Ok();
            });
        }

        /// <summary>
        /// Deletes the project with the specified <paramref name="id"/> from the sequence of projects.
        /// </summary>
        /// <param name="id">The ID of a peoject.</param>
        public async Task<IHttpActionResult> DeleteAsync(string id)
        {
            return await Task.Run<IHttpActionResult>(() =>
            {
                return Ok();
            });
        }
    }
}