using System;

namespace Simon.Domain
{
    /// <summary>
    /// Represents a branch in a source control repository.
    /// </summary>
    public sealed class SourceRepositoryBranch : NamedEntityBase
    {
        /// <summary>
        /// Initializes an instance of <see cref="SourceRepositoryBranch"/> class.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        public SourceRepositoryBranch(Guid id, string name, string description)
            : base(id, name, description) { }

        /// <summary>
        /// Gets or sets the source control repository.
        /// </summary>
        public SourceRepository Repository { get; set; }

        /// <summary>
        /// Gets or sets the feature to which this branch belongs.
        /// </summary>
        public Feature Feature { get; set; }
    }
}