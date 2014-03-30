using Simon.Utilities;
using System;

namespace Simon.Domain
{
    /// <summary>
    /// Defines a base class for domain.
    /// </summary>
    public abstract class DomainBase
    {
        /// <summary>
        /// Initializes an instance of <see cref="DomainBase"/> class.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        protected DomainBase(Guid id, string name, string description)
        {
            Guard.NotNullOrEmptyStringArgument("name", name);
            Guard.NotNullOrEmptyStringArgument("description", description);

            this.Id = id;
            this.Name = name;
            this.Description = description;
        }

        /// <summary>
        /// Gets the ID for the instance.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the name for the instance.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description for the instance.
        /// </summary>
        public string Description { get; private set; }

        public void SetName(string newName)
        {
            Guard.NotNullOrEmptyStringArgument("newName", newName);

            this.Name = newName;
        }

        public void SetDescription(string newDescription)
        {
            Guard.NotNullOrEmptyStringArgument("newDescription", newDescription);

            this.Description = newDescription;
        }

        public void SetId(Guid newId)
        {
            Guard.NotDefaultValueArgument("newId", newId);

            if (this.Id != Guid.Empty)
            {
                throw new ApplicationException("ID can be set only once per instance.");
            }

            this.Id = newId;
        }
    }
}
