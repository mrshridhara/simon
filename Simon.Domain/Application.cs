using Simon.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simon.Domain
{
	/// <summary>
	/// Represents an application.
	/// </summary>
	public class Application : DomainBase
	{
		private readonly List<Feature> features;

		/// <summary>
		/// Initializes an instance of <see cref="Application"/> class.
		/// </summary>
		/// <param name="id">The ID.</param>
		/// <param name="name">The name.</param>
		/// <param name="description">The description.</param>
		/// <param name="features">The sequence of features.</param>
		public Application(Guid id, string name, string description, IEnumerable<Feature> features)
			: base(id, name, description)
		{
			this.features = new List<Feature>();

			if (features != null)
			{
				features.AsParallel().ForAll(AddFeature);
			}
		}

		/// <summary>
		/// Gets the sequence of features in the application.
		/// </summary>
		public IEnumerable<Feature> Features
		{
			get { return features.AsReadOnly(); }
		}

		/// <summary>
		/// Gets the project to which this application belongs.
		/// </summary>
		public Project Project { get; private set; }

		/// <summary>
		/// Adds the specified <paramref name="newFeature"/> to this application.
		/// </summary>
		/// <param name="newFeature">The feature to be added.</param>
		public void AddFeature(Feature newFeature)
		{
			Guard.NotNullArgument("newFeature", newFeature);

			newFeature.SetApplication(this);
			this.features.Add(newFeature);
		}

		/// <summary>
		/// Sets the specified <paramref name="newProject"/> as the project for this application.
		/// </summary>
		/// <param name="newProject">The project to be set.</param>
		public void SetProject(Project newProject)
		{
			Guard.NotNullArgument("newProject", newProject);

			if (this.Project != null)
			{
				throw new ApplicationException("Project can be set only once per instance.");
			}

			this.Project = newProject;
		}
	}
}