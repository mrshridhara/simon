namespace Simon.Api.Web.Models
{
    /// <summary>
    /// Represents the version of SIMON.
    /// </summary>
    public sealed class SimonVersionModel
    {
        /// <summary>
        /// Gets or sets the build number.
        /// </summary>
        public int Build { get; set; }

        /// <summary>
        /// Gets or sets the display text.
        /// </summary>
        public string DisplayText { get; set; }

        /// <summary>
        /// Gets or sets the major version.
        /// </summary>
        public int Major { get; set; }

        /// <summary>
        /// Gets or sets the minor version.
        /// </summary>
        public int Minor { get; set; }
    }
}