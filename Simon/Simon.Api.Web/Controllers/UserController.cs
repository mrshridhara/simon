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
        public User Get()
        {
            return new User
            {
                Name = User.Identity.Name,
                DisplayName = User.Identity.Name,
                Role = ""
            };
        }
    }
}