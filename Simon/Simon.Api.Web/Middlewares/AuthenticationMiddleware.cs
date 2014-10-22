using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Owin;
using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;

namespace Simon.Api.Web.Middlewares
{
    /// <summary>
    /// Represents the authentication middle-ware for OWIN environment.
    /// </summary>
    public sealed class AuthenticationMiddleware : OwinMiddleware
    {
        private const string AuthorizationHeader = "Authorization";
        private const string WwwAuthenticateHeader = "WWW-Authenticate";

        private readonly IAsyncAuthenticationProvider authenticationProvider;

        /// <summary>
        /// Initializes an instance of <see cref="AuthenticationMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middle-ware.</param>
        /// <param name="authenticationProvider">The authentication provider.</param>
        public AuthenticationMiddleware(OwinMiddleware next, IAsyncAuthenticationProvider authenticationProvider)
            : base(next)
        {
            Guard.NotNullArgument("authenticationProvider", authenticationProvider);

            this.authenticationProvider = authenticationProvider;
        }

        /// <summary>
        /// Process an individual request.
        /// </summary>
        /// <param name="context">The OWIN context.</param>
        /// <returns></returns>
        public override async Task Invoke(IOwinContext context)
        {
            Guard.NotNullArgument("context", context);

            context.Response.OnSendingHeaders(ValidateStatusCode, context.Response);

            AuthenticationHeaderValue authenticationHeader;
            if (TryGetAuthenticationHeader(context.Request, out authenticationHeader) == false)
            {
                await Next.Invoke(context);
                return;
            }

            IIdentity identity = await authenticationProvider.AuthenticateAsync(authenticationHeader.Parameter);
            if (identity != null)
            {
                context.Request.User = new ClaimsPrincipal(identity);
            }

            await Next.Invoke(context);
        }

        private void ValidateStatusCode(object state)
        {
            var response = (IOwinResponse)state;
            if (response.StatusCode == 401)
            {
                response.Headers[WwwAuthenticateHeader] = authenticationProvider.AuthenticationMode;
            }
        }

        private bool TryGetAuthenticationHeader(IOwinRequest request, out AuthenticationHeaderValue authenticationHeader)
        {
            var header = request.Headers[AuthorizationHeader];
            if (string.IsNullOrWhiteSpace(header))
            {
                authenticationHeader = null;
                return false;
            }

            authenticationHeader = AuthenticationHeaderValue.Parse(header);
            return string.Equals(authenticationProvider.AuthenticationMode, authenticationHeader.Scheme, StringComparison.OrdinalIgnoreCase);
        }
    }
}