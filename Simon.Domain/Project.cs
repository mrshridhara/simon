using System;
using System.Collections.Generic;
using System.Linq;

namespace Simon.Domain
{
	public class Project : IdNameAndDescription
	{
		private readonly List<Application> applications;

		public Project(Guid id, string name, string description, IEnumerable<Application> applications)
			: base(id, name, description)
		{
			this.applications = applications != null ? applications.ToList() : new List<Application>();
		}

		public IEnumerable<Application> Applications
		{
			get { return applications.AsReadOnly(); }
		}

		public bool AddApplication(Application newApplication)
		{
			throw new System.NotImplementedException();
		}
	}
}