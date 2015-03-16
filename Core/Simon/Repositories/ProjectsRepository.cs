using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;
using Simon.Processes.Database;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simon.Repositories
{
    /// <summary>
    /// Represents a projects repository.
    /// </summary>
    public sealed class ProjectsRepository
        : IPersistence<Project>
    {
        private readonly IProcess<EmptyContext, GetAllProjectsResult> getAllProjects;
        private readonly GlobalSettings globalSettings;
        private readonly IProcess<SaveProjectContext> saveProject;

        /// <summary>
        /// Initializes an instance of <see cref="ProjectsRepository"/> class.
        /// </summary>
        /// <param name="globalSettings">The global settings.</param>
        /// <param name="saveProject">The save project process.</param>
        /// <param name="getAllProjects">The get all projects process.</param>
        public ProjectsRepository(
            GlobalSettings globalSettings,
            IProcess<SaveProjectContext> saveProject,
            IProcess<EmptyContext, GetAllProjectsResult> getAllProjects)
        {
            Guard.NotNullArgument("globalSettings", globalSettings);
            Guard.NotNullArgument("createNewProject", saveProject);
            Guard.NotNullArgument("getAllProjects", getAllProjects);

            this.globalSettings = globalSettings;
            this.saveProject = saveProject;
            this.getAllProjects = getAllProjects;
        }

        /// <summary>
        /// Creates the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public async Task<Project> CreateAsync(Project data)
        {
            Guard.NotNullArgument("data", data);

            data.SetId(Guid.NewGuid());
            await saveProject.ExecuteAsync(new SaveProjectContext { Project = data });

            return data;
        }

        /// <summary>
        /// Deletes the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public Task DeleteAsync(Project data)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Reads all the persisted data if the filter is null,
        /// otherwise; reads filtered data.
        /// </summary>
        /// <returns>
        /// The persisted data if the filter is null,
        /// otherwise; reads filtered data.
        /// </returns>
        public async Task<IQueryable<Project>> ReadAsync(Expression<Func<Project, bool>> filter = null)
        {
            var result = await getAllProjects.ExecuteAsync(EmptyContext.Instance);

            if (filter == null)
                return result.Projects;

            return result.Projects.Where(filter);
        }

        /// <summary>
        /// Updates the data in persistence.
        /// </summary>
        /// <param name="data">The data.</param>
        public async Task UpdateAsync(Project data)
        {
            Guard.NotNullArgument("data", data);

            await saveProject.ExecuteAsync(new SaveProjectContext { Project = data });
        }
    }
}