﻿using Simon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Simon.Api.Web.Areas.Api.Controllers
{
    /// <summary>
    /// API to manipulate project data.
    /// </summary>
    public class ProjectsController : ApiController
    {
        private IEnumerable<Project> projects;

        /// <summary>
        /// Initializes an instance of <see cref="ProjectsController"/>.
        /// </summary>
        public ProjectsController()
        {
            // TODO: Get data from repository.
            projects = new List<Project>()
			{
				new Project(new Guid("1f65c0b6-5743-4981-b405-048101d262ba"), "Project 1", "Project 1 description", null),
				new Project(new Guid("1f65c0b6-5743-4981-b405-048101d262bb"), "Project 2", "Project 2 description", null),
				new Project(new Guid("1f65c0b6-5743-4981-b405-048101d262bc"), "Project 3", "Project 3 description", null)
			};
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
                var availableProject = projects.FirstOrDefault(project => project.Id == new Guid(id));

                if (availableProject != null)
                {
                    return Ok(availableProject);
                }

                return NotFound();
            });
        }

        /// <summary>
        /// Adds the specified <paramref name="project"/> to the sequence of projects.
        /// </summary>
        /// <param name="project">The project data taken from HTTP body.</param>
        /// <returns>
        /// Status of the addition.
        /// </returns>
        public async Task<IHttpActionResult> PostAsync([FromBody]Project project)
        {
            return await Task.Run<IHttpActionResult>(() =>
            {
                return Ok();
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