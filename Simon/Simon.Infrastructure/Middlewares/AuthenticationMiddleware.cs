using System.Threading.Tasks;
using Microsoft.Owin;

namespace Simon.Infrastructure.Middlewares
{
    /// <summary>
    /// Represents the authentication middle-ware for OWIN environment.
    /// </summary>
    public sealed class AuthenticationMiddleware : OwinMiddleware
    {
        private OwinMiddleware next;

        /// <summary>
        /// Initializes an instance of <see cref="AuthenticationMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middle-ware.</param>
        public AuthenticationMiddleware(OwinMiddleware next)
            : base(next)
        {
            this.next = next;
        }

        /// <summary>
        /// Process an individual request.
        /// </summary>
        /// <param name="context">The OWIN context.</param>
        /// <returns>A task to await.</returns>
        public override async Task Invoke(IOwinContext context)
        {
            // TODO: Check authentication here.

            if (next != null)
                await next.Invoke(context);
        }
    }
}