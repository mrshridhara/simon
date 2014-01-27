using Simon.Domain;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Simon.UI.Web.Areas.Api.Controllers
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
			projects = new List<Project>()
			{
				new Project(Guid.NewGuid(), "Project 1", "Project 1 description", null),
				new Project(Guid.NewGuid(), "Project 2", "Project 2 description", null),
				new Project(Guid.NewGuid(), "Project 3", "Project 3 description", null)
			};
		}

		/// <summary>
		/// Gets the sequence of projects.
		/// </summary>
		/// <returns>
		/// A sequence of projects.
		/// </returns>
		public IHttpActionResult Get()
		{
			return Ok(projects);
		}

		/// <summary>
		/// Gets the project with the sepecifed <paramref name="id"/>.
		/// </summary>
		/// <param name="id">The ID of a project.</param>
		/// <returns>
		/// Project with the sepecifed <paramref name="id"/>.
		/// </returns>
		public IHttpActionResult Get(string id)
		{
			return Ok();
		}

		/// <summary>
		/// Adds the specified <paramref name="project"/> to the sequence of projects.
		/// </summary>
		/// <param name="project">The project data taken from HTTP body.</param>
		/// <returns>
		/// Status of the addition.
		/// </returns>
		public IHttpActionResult Post([FromBody]Project project)
		{
			return Ok();
		}

		/// <summary>
		/// Updates the specified <paramref name="project"/> with the specified <paramref name="id"/> in the sequence of projects.
		/// </summary>
		/// <param name="id">The ID of the project.</param>
		/// <param name="project">The project data taken from HTTP body.</param>
		/// <returns>
		/// Status of the addition.
		/// </returns>
		public IHttpActionResult Put(string id, [FromBody]Project project)
		{
			return Ok();
		}

		/// <summary>
		/// Deletes the project with the specified <paramref name="id"/> from the sequence of projects.
		/// </summary>
		/// <param name="id">The ID of a peoject.</param>
		public IHttpActionResult Delete(string id)
		{
			return Ok();
		}
	}
}