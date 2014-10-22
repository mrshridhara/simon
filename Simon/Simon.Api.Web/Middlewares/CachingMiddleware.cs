using System.Threading.Tasks;
using Microsoft.Owin;

namespace Simon.Api.Web.Middlewares
{
    /// <summary>
    /// Represents the caching middle-ware for OWIN environment.
    /// </summary>
    public sealed class CachingMiddleware : OwinMiddleware
    {
        /// <summary>
        /// Initializes an instance of <see cref="CachingMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middle-ware.</param>
        public CachingMiddleware(OwinMiddleware next)
            : base(next)
        {
        }

        /// <summary>
        /// Process an individual request.
        /// </summary>
        /// <param name="context">The OWIN context.</param>
        /// <returns>A task to await.</returns>
        public override async Task Invoke(IOwinContext context)
        {
            context.Response.OnSendingHeaders(response =>
            {
                // TODO: Set headers.
            }, context.Response);

            await Next.Invoke(context);
        }
    }
}