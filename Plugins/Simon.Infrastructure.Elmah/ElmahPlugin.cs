using Elmah;
using Autofac;
using Owin;
using Simon.Infrastructure.Utilities;

namespace Simon.Infrastructure.Elmah
{
    /// <summary>
    /// Represents the plug-in initializer.
    /// </summary>
    public sealed class ElmahPlugin : IPlugin
    {
        /// <summary>
        /// Initializes the plug-in and updates the specified <paramref name="globalSettings"/>
        /// if required.
        /// </summary>
        /// <param name="appBuilder">The app builder.</param>
        /// <param name="container">The IOC container.</param>
        /// <param name="globalSettings">The global settings.</param>
        /// <returns>
        /// The updated instance of <see cref="GlobalSettings"/> class.
        /// </returns>
        public GlobalSettings Init(IAppBuilder appBuilder, IContainer container, GlobalSettings globalSettings)
        {
            Guard.NotNullArgument("appBuilder", appBuilder);
            Guard.NotNullArgument("container", container);
            Guard.NotNullArgument("globalSettings", globalSettings);

            ////if (globalSettings[Constants.ElmahDashboardPathKey] == null)
            ////{
            ////    var settingItem
            ////        = new GlobalSettingsItem("ELMAH Dashboard", "/elmah", true);

            ////    globalSettings.Add(Constants.ElmahDashboardPathKey, settingItem);
            ////}

            return globalSettings;
        }
    }
}