using Microsoft.Owin;
using Simon.Infrastructure;
using Simon.Infrastructure.Utilities;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Simon.Api.Web.Middlewares
{
    /// <summary>
    /// Represents the authentication middle-ware for OWIN environment.
    /// </summary>
    public sealed class AuthenticationMiddleware : OwinMiddleware
    {
        private const string AuthorizationHeader = "Authorization";
        private const string CookieHeader = "Cookie";
        private const string CookieKey = "Token";
        private const string SetCookieHeader = "Set-Cookie";
        private const string WwwAuthenticateHeader = "WWW-Authenticate";

        private readonly IAuthenticationProvider authenticationProvider;

        /// <summary>
        /// Initializes an instance of <see cref="AuthenticationMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next middle-ware.</param>
        /// <param name="authenticationProvider">The authentication provider.</param>
        public AuthenticationMiddleware(OwinMiddleware next, IAuthenticationProvider authenticationProvider)
            : base(next)
        {
            Guard.NotNullArgument(nameof(authenticationProvider), authenticationProvider);

            this.authenticationProvider = authenticationProvider;
        }

        /// <summary>
        /// Process an individual request.
        /// </summary>
        /// <param name="context">The OWIN context.</param>
        /// <returns></returns>
        public override async Task Invoke(IOwinContext context)
        {
            Guard.NotNullArgument(nameof(context), context);

            context.Response.OnSendingHeaders(ValidateStatusCode, context);

            AuthenticationHeaderValue authenticationHeader;
            if (TryGetAuthenticationHeader(context.Request, out authenticationHeader) == false)
            {
                await Next.Invoke(context);
                return;
            }

            var identity = await authenticationProvider.AuthenticateAsync(authenticationHeader.Parameter);
            if (identity != null)
            {
                context.Request.User = new ClaimsPrincipal(identity);
            }

            await Next.Invoke(context);
        }

        private bool TryGetAuthenticationHeader(IOwinRequest request, out AuthenticationHeaderValue authenticationHeader)
        {
            var cookieValue = request.Cookies[CookieKey];

            var header
                = string.IsNullOrWhiteSpace(cookieValue)
                    ? request.Headers[AuthorizationHeader]
                    : cookieValue.ToDecodedBase64String();

            if (string.IsNullOrWhiteSpace(header))
            {
                authenticationHeader = null;
                return false;
            }

            authenticationHeader = AuthenticationHeaderValue.Parse(header);
            return string.Equals(authenticationProvider.AuthenticationMode, authenticationHeader.Scheme, StringComparison.OrdinalIgnoreCase);
        }

        private void ValidateStatusCode(object state)
        {
            var context = (IOwinContext)state;
            AuthenticationHeaderValue authenticationHeader;
            if (context.Response.StatusCode == 401)
            {
                context.Response.Headers[WwwAuthenticateHeader] = authenticationProvider.AuthenticationMode;
            }
            else if (context.Response.StatusCode == 200
                && TryGetAuthenticationHeader(context.Request, out authenticationHeader)
                && context.Request.Cookies[CookieKey] == null)
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true
                };

                var cookieValue = authenticationHeader.ToString().ToEncodedBase64String();
                context.Response.Cookies.Append(CookieKey, cookieValue, cookieOptions);
            }
        }
    }
}