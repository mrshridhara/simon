using System.IO;
using System.Threading.Tasks;
using Simon.Infrastructure;

namespace Simon.Processes.FileSystem
{
    /// <summary>
    /// Updates the global settings.
    /// </summary>
    public sealed class UpdateGlobalSettings
        : IAsyncProcess<UpdateGlobalSettingsContext>
    {
        private readonly ISerializer serializer;

        /// <summary>
        /// Initializes an instance of <see cref="UpdateGlobalSettings"/> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        public UpdateGlobalSettings(ISerializer serializer)
        {
            this.serializer = serializer;
        }

        /// <summary>
        /// Executes the async process.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A task of type <see cref="Task&lt;EmptyResult&gt;"/></returns>
        public async Task ExecuteAsync(UpdateGlobalSettingsContext context)
        {
            CreateDirectoryIfRequired();

            var settingsAsJson = await serializer.SerializeAsync(context.GlobalSettings);

            using (var fileStream
                = new FileStream(Constants.GlobalSettingsSavePath, FileMode.Create))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(settingsAsJson);
                }
            }
        }

        private static void CreateDirectoryIfRequired()
        {
            var savePathDirectory = Path.GetDirectoryName(Constants.GlobalSettingsSavePath);
            if (Directory.Exists(savePathDirectory) == false)
            {
                Directory.CreateDirectory(savePathDirectory);
            }
        }
    }
}