using System.Web.Http;

namespace Simon.Api.Web
{
    /// <summary>
    /// 
    /// </summary>
    public static class FilterConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new AuthorizeAttribute());
        }
    }
}