using System.Security.Principal;
using System.Threading.Tasks;
using Simon.Infrastructure.Utilities;

namespace Simon.Infrastructure.Windows
{
    /// <summary>
    /// Represents the windows authentication provider.
    /// </summary>
    public class WindowsAuthenticationProvider : IAsyncAuthenticationProvider
    {
        /// <summary>
        /// Gets the authentication mode.
        /// </summary>
        public string AuthenticationMode
        {
            get { return "NTLM"; }
        }

        /// <summary>
        /// Authenticates the current logged in user.
        /// </summary>
        /// <param name="authenticationToken">The authentication token.</param>
        /// <returns>The identity instance.</returns>
        public Task<IIdentity> AuthenticateAsync(string authenticationToken)
        {
            Guard.NotNullOrEmptyStringArgument("authenticationToken", authenticationToken);

            return Task.Run(() => WindowsIdentity.GetCurrent() as IIdentity);
        }
    }
}