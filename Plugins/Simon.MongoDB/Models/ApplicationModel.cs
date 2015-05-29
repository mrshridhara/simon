using System;
using System.Linq;

namespace Simon.Models
{
    internal class ApplicationModel
    {
        public ApplicationModel(Application application)
            : this()
        {
            Id = application.Id;
            Name = application.Name;
            Description = application.Description;
            Features = new FeatureModel[application.Features.Count];
            for (int i = 0; i < Features.Length; i++)
            {
                Features[i] = new FeatureModel(application.Features[i]);
            }
        }

        public ApplicationModel()
        {
        }

        public string Description { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public FeatureModel[] Features { get; set; }

        public Application ToApplication()
        {
            return new Application(
                Id,
                Name,
                Description,
                (Features ?? new FeatureModel[0]).Select(each => each.ToFeature()));
        }
    }
}