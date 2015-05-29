using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Owin;

[assembly: AssemblyTitle("Simon.UI.Web")]
[assembly: AssemblyDescription("")]
[assembly: Guid("562699ca-3161-44a0-9329-ffd618b1755a")]

[assembly: OwinStartup(typeof(Simon.Api.Web.Startup))]