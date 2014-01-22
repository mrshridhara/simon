using System;

namespace Simon.Domain
{
	public class Feature : IdNameAndDescription
	{
		public Feature(Guid id, string name, string description)
			: base(id, name, description)
		{
		}

		public FeatureState State { get; set; }

		public User CreatedBy { get; set; }

		public User SignedOffBy { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime ModifiedAt { get; set; }

		public SourceRepositoryBranch Branch { get; set; }
	}
}