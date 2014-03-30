using System.Web.Mvc;

namespace Simon.UI.Web.Controllers
{
    /// <summary>
    /// Represents the controller for /Home
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// GET /Home/Index or /Home or /
        /// </summary>
        /// <returns>
        /// View for the index page.
        /// </returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}