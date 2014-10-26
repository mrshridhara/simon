using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace Simon.Api.Web.Controllers
{
    /// <summary>
    ///
    /// </summary>
    public sealed class UserController : ApiController
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> GetAsync()
        {
            return await Task.Run(() =>
            {
                var claimsPrincipal = User as ClaimsPrincipal;

                if (claimsPrincipal != null)
                {
                    var user = new User
                    {
                        Name = User.Identity.Name,
                        DisplayName = User.Identity.Name,
                        Role = ""
                    };

                    return Ok(user) as IHttpActionResult;
                }

                return Unauthorized() as IHttpActionResult;
            });
        }
    }
}