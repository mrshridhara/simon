using Simon.Api.Web.Models;
using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Simon.Api.Web.Controllers
{
    /// <summary>
    /// API to manipulate SIMON version.
    /// </summary>
    public sealed class SimonVersionController : ApiController
    {
        private readonly IMapper<Version, SimonVersionModel> versionToSimonVersionModelMapper;

        /// <summary>
        /// Initializes an instance of <see cref="SimonVersionController"/> class.
        /// </summary>
        /// <param name="versionToSimonVersionModelMapper">The version to simon version model mapper.</param>
        public SimonVersionController(
            IMapper<Version, SimonVersionModel> versionToSimonVersionModelMapper)
        {
            Guard.NotNullArgument("versionToSimonVersionModelMapper", versionToSimonVersionModelMapper);

            this.versionToSimonVersionModelMapper = versionToSimonVersionModelMapper;
        }

        /// <summary>
        /// Gets the current version of SIMON.
        /// </summary>
        /// <returns>
        /// A sequence of projects.
        /// </returns>
        public async Task<IHttpActionResult> GetAsync()
        {
            return await Task.Run<IHttpActionResult>(() =>
            {
                var version = versionToSimonVersionModelMapper.Map(SimonAssembly.Version);
                return Ok(version);
            });
        }
    }
}