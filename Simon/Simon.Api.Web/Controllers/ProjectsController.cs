using Simon.Api.Web.Models;
using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Simon.Api.Web.Controllers
{
    /// <summary>
    /// API to manipulate project data.
    /// </summary>
    public class ProjectsController : ApiController
    {
        private static readonly ICollection<ProjectModel> projects = new List<ProjectModel>()
        {
            new ProjectModel {
                Id = new Guid("1f65c0b6-5743-4981-b405-048101d262aa"),
                Name = "Project 1",
                Description = "Project 1 description",
                Applications = new List<ApplicationModel> {
                    new ApplicationModel {
                        Id = new Guid("1f65c0b6-5743-4981-b405-048101d368aa"),
                        Name = "Application 1",
                        Description = "Application 1 description"
                    }
                }
            },
            new ProjectModel {
                Id = new Guid("1f65c0b6-5743-4981-b405-048101d262bb"),
                Name = "Project 2",
                Description = "Project 2 description"
            },
            new ProjectModel {
                Id = new Guid("1f65c0b6-5743-4981-b405-048101d262cc"),
                Name = "Project 3",
                Description = "Project 3 description"
            },
            new ProjectModel {
                Id = new Guid("1f65c0b6-5743-4981-b405-048101d262dd"),
                Name = "Project 4",
                Description = "Project 4 description"
            }
        };

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
            return await Task.Run<IHttpActionResult>(() =>
            {
                // TODO: Get data from repository.
                return Ok(projects);
            });
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
            return await Task.Run<IHttpActionResult>(() =>
            {
                // TODO: Get data from repository.
                var availableProject
                    = projects.FirstOrDefault(project => project.Id == new Guid(id));

                if (availableProject != null)
                {
                    return Ok(availableProject);
                }

                return NotFound();
            });
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
            return await Task.Run<IHttpActionResult>(() =>
            {
                projectModel.Id = Guid.NewGuid();
                projects.Add(projectModel);

                // TODO: Store data to repository.
                //var project = projectModelToProjectMapper.Map(projectModel);
                //projectPersistence.Create(project);

                return CreatedAtRoute(
                    RouteConfig.DefaultRouteName,
                    new { controller = "Projects", id = projectModel.Id },
                    projectModel);
            });
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