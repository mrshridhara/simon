using System.IO;
using System.Threading.Tasks;
using Simon.Infrastructure;

namespace Simon.Processes.FileSystem
{
    /// <summary>
    /// Gets the global settings.
    /// </summary>
    public sealed class GetGlobalSettings
        : IAsyncProcess<EmptyContext, GetGlobalSettingsResult>
    {
        private readonly ISerializer serializer;

        /// <summary>
        /// Initializes an instance of <see cref="GetGlobalSettings"/> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        public GetGlobalSettings(ISerializer serializer)
        {
            this.serializer = serializer;
        }

        /// <summary>
        /// Executes the async process.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A task of type <see cref="Task&lt;GetGlobalSettingsResult&gt;"/></returns>
        public async Task<GetGlobalSettingsResult> ExecuteAsync(EmptyContext context)
        {
            CreateDirectoryIfRequired();

            string jsonFromFile;
            using (var fileStream
                = new FileStream(Constants.GlobalSettingsSavePath, FileMode.OpenOrCreate))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    jsonFromFile = streamReader.ReadToEnd();
                }
            }

            if (string.IsNullOrEmpty(jsonFromFile))
            {
                return GetDefaultResult();
            }

            var globalSettings
                = await serializer.DeserializeAsync<GlobalSettings>(jsonFromFile);

            if (globalSettings == null)
            {
                return GetDefaultResult();
            }

            return new GetGlobalSettingsResult
            {
                GlobalSettings = globalSettings
            };
        }

        private static void CreateDirectoryIfRequired()
        {
            var savePathDirectory = Path.GetDirectoryName(Constants.GlobalSettingsSavePath);
            if (Directory.Exists(savePathDirectory) == false)
            {
                Directory.CreateDirectory(savePathDirectory);
            }
        }

        private static GetGlobalSettingsResult GetDefaultResult()
        {
            return new GetGlobalSettingsResult
            {
                GlobalSettings = GlobalSettings.Empty
            };
        }
    }
}