using System;

namespace Simon.Models
{
    internal class FeatureModel
    {
        public FeatureModel(Feature feature)
            : this()
        {
            Id = feature.Id;
            Name = feature.Name;
            Description = feature.Description;
            FeatureState = feature.State;
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
                Id,
                Name,
                Description,
                FeatureState);
        }
    }
}