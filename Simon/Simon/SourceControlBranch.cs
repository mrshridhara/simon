using System;
using Simon.Repositories;

namespace Simon
{
    /// <summary>
    /// Represents a branch in a source control repository.
    /// </summary>
    public sealed class SourceControlBranch : NamedEntityBase
    {
        /// <summary>
        /// Initializes an instance of <see cref="SourceControlBranch"/> class.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        public SourceControlBranch(Guid id, string name, string description)
            : base(id, name, description)
        { }

        /// <summary>
        /// Gets or sets the tip commit SHA.
        /// </summary>
        public string TipCommitSha { get; set; }
    }
}