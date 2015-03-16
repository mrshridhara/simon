using System;
using System.Linq;

namespace Simon.Models
{
    internal class ApplicationModel
    {
        public ApplicationModel(Application application)
            : this()
        {
            this.Id = application.Id;
            this.Name = application.Name;
            this.Description = application.Description;
            this.Features = new FeatureModel[application.Features.Count];
            for (int i = 0; i < this.Features.Length; i++)
            {
                this.Features[i] = new FeatureModel(application.Features[i]);
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
                this.Id,
                this.Name,
                this.Description,
                (this.Features ?? new FeatureModel[0]).Select(each => each.ToFeature()));
        }
    }
}