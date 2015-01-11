using System.Web.Http;

namespace Simon.Api.Web
{
    /// <summary>
    /// Represents the configuration for global HTTP action filers.
    /// </summary>
    public static class FilterConfig
    {
        /// <summary>
        /// Registers the global HTTP filters to the specified <paramref name="config"/>.
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new AuthorizeAttribute());
        }
    }
}