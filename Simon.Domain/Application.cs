using System;
using System.Collections.Generic;
using System.Linq;

namespace Simon.Domain
{
	public class Application : IdNameAndDescription
	{
		private readonly List<Feature> features;

		public Application(Guid id, string name, string description, IEnumerable<Feature> features)
			: base(id, name, description)
		{
			this.features = features.ToList();
		}

		public IEnumerable<Feature> Applications
		{
			get { return features.AsReadOnly(); }
		}

		public bool AddFeature(Feature newFeature)
		{
			throw new System.NotImplementedException();
		}
	}
}