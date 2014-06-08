using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
namespace Simon.Processes.FileSystem.Json
{
    /// <summary>
    /// Updates the global settings.
    /// </summary>
    public sealed class UpdateGlobalSettings
        : IAsyncProcess<UpdateGlobalSettingsContext>
    {
        /// <summary>
        /// Executes the async process.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A task of type <see cref="Task&lt;EmptyResult&gt;"/></returns>
        public async Task ExecuteAsync(UpdateGlobalSettingsContext context)
        {
            await Task.Factory.StartNew(
                () => Execute(context),
                TaskCreationOptions.LongRunning);
        }

        private static void Execute(UpdateGlobalSettingsContext context)
        {
            var settingsAsJson = JsonConvert.SerializeObject(context.GlobalSettings);

            using (var fileStream
                = new FileStream(Constants.GlobalSettingsSavePath, FileMode.Create))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(settingsAsJson);
                }
            }
        }
    }
}