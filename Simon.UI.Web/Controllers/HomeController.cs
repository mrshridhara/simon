using System.Threading.Tasks;
using System.Web.Mvc;

namespace Simon.UI.Web.Controllers
{
    /// <summary>
    /// Represents the controller for /Home
    /// </summary>
    public class HomeController : AsyncController
    {
        /// <summary>
        /// GET /Home/Index or /Home or /
        /// </summary>
        /// <returns>
        /// View for the index page.
        /// </returns>
        public async Task<ActionResult> IndexAsync()
        {
            return await Task.Run<ActionResult>(() =>
            {
                return View();
            });
        }
    }
}