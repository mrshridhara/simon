using System;

namespace Simon.Models
{
    internal class FeatureModel
    {
        public FeatureModel(Feature feature)
            : this()
        {
            this.Id = feature.Id;
            this.Name = feature.Name;
            this.Description = feature.Description;
            this.FeatureState = feature.State;
        }

        public FeatureModel()
        {
        }

        public string Description { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public FeatureState FeatureState { get; set; }

        public Feature ToFeature()
        {
            return new Feature(
                this.Id,
                this.Name,
                this.Description,
                this.FeatureState);
        }
    }
}