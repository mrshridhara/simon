using System;
using System.Linq;

namespace Simon.Models
{
    internal class ProjectModel
    {
        public ProjectModel(Project project)
            : this()
        {
            Id = project.Id;
            Name = project.Name;
            Description = project.Description;
            Applications = new ApplicationModel[project.Applications.Count];
            for (int i = 0; i < Applications.Length; i++)
            {
                Applications[i] = new ApplicationModel(project.Applications[i]);
            }
        }

        public ProjectModel()
        {
        }

        public string Description { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public ApplicationModel[] Applications { get; set; }

        public Project ToProject()
        {
            return new Project(
                Id,
                Name,
                Description,
                (Applications ?? new ApplicationModel[0]).Select(each => each.ToApplication()));
        }
    }
}