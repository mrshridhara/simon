using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simon.Domain.Process.Results
{
    /// <summary>
    /// Represents the result of getting global settings.
    /// </summary>
    public sealed class GetGlobalSettingsResult
    {
        /// <summary>
        /// Gets or sets global settings.
        /// </summary>
        public GlobalSettings GlobalSettings { get; set; }
    }
}