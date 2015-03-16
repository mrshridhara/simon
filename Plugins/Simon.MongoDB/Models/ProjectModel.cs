using System;
using System.Linq;

namespace Simon.Models
{
    internal class ProjectModel
    {
        public ProjectModel(Project project)
            : this()
        {
            this.Id = project.Id;
            this.Name = project.Name;
            this.Description = project.Description;
            this.Applications = new ApplicationModel[project.Applications.Count];
            for (int i = 0; i < this.Applications.Length; i++)
            {
                this.Applications[i] = new ApplicationModel(project.Applications[i]);
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
                this.Id,
                this.Name,
                this.Description,
                (this.Applications ?? new ApplicationModel[0]).Select(each => each.ToApplication()));
        }
    }
}