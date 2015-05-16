using Simon.Infrastructure.Utilities;
using System;

namespace Simon
{
    /// <summary>
    /// Defines a base class for named domain entity.
    /// </summary>
    public abstract class NamedEntityBase
    {
        /// <summary>
        /// Initializes an instance of <see cref="NamedEntityBase"/> class.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        protected NamedEntityBase(Guid id, string name, string description)
        {
            Guard.NotNullOrEmptyStringArgument(nameof(name), name);
            Guard.NotNullOrEmptyStringArgument(nameof(description), description);

            Id = id;
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Gets the description for the instance.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the ID for the instance.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the name for the instance.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="newDescription"></param>
        public void SetDescription(string newDescription)
        {
            Guard.NotNullOrEmptyStringArgument(nameof(newDescription), newDescription);

            Description = newDescription;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="newId"></param>
        public void SetId(Guid newId)
        {
            Guard.NotDefaultValueArgument(nameof(newId), newId);

            if (Id != Guid.Empty)
            {
                throw new ApplicationException("ID can be set only once per instance.");
            }

            Id = newId;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="newName"></param>
        public void SetName(string newName)
        {
            Guard.NotNullOrEmptyStringArgument(nameof(newName), newName);

            Name = newName;
        }
    }
}