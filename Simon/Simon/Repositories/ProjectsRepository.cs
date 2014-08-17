using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;
using Simon.Processes.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simon.Repositories
{
    /// <summary>
    /// Represents a projects repository.
    /// </summary>
    public sealed class ProjectsRepository
        : IAsyncPersistence<Project>
    {
        private readonly GlobalSettings globalSettings;
        private readonly IAsyncProcess<CreateNewProjectContext> createNewProject;
        private readonly IAsyncProcess<EmptyContext, GetAllProjectsResult> getAllProjects;

        /// <summary>
        /// Initializes an instance of <see cref="ProjectsRepository"/> class.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        /// <param name="createNewProject">The create new project process.</param>
        /// <param name="getAllProjects">The get all projects process.</param>
        public ProjectsRepository(
            GlobalSettings globalSettings,
            IAsyncProcess<CreateNewProjectContext> createNewProject,
            IAsyncProcess<EmptyContext, GetAllProjectsResult> getAllProjects)
        {
            Guard.NotNullArgument("globalSettings", globalSettings);
            Guard.NotNullArgument("createNewProject", createNewProject);
            Guard.NotNullArgument("getAllProjects", getAllProjects);

            this.globalSettings = globalSettings;
            this.createNewProject = createNewProject;
            this.getAllProjects = getAllProjects;
        }

        /// <summary>
        /// Reads all the persisted data.
        /// </summary>
        /// <returns>
        /// All the persisted data.
        /// </returns>
        public async Task<IEnumerable<Project>> ReadAll()
        {
            var result = await getAllProjects.ExecuteAsync(EmptyContext.Instance);
            return result.Projects;
        }

        /// <summary>
        /// Creates the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public async Task<Project> Create(Project data)
        {
            Guard.NotNullArgument("data", data);

            data.SetId(Guid.NewGuid());
            await createNewProject.ExecuteAsync(new CreateNewProjectContext { Project = data });

            return data;
        }

        /// <summary>
        /// Updates the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public Task Update(Project data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Deletes the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public Task Delete(Project data)
        {
            throw new System.NotImplementedException();
        }
    }
}