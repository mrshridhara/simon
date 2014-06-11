using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Simon.Processes.FileSystem.Json
{
    /// <summary>
    /// Gets the global settings.
    /// </summary>
    public sealed class GetGlobalSettings
        : IAsyncProcess<EmptyContext, GetGlobalSettingsResult>
    {
        /// <summary>
        /// Executes the async process.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A task of type <see cref="Task&lt;GetGlobalSettingsResult&gt;"/></returns>
        public async Task<GetGlobalSettingsResult> ExecuteAsync(EmptyContext context)
        {
            return await Task.Factory.StartNew(
                () => Execute(),
                TaskCreationOptions.LongRunning);
        }

        private static GetGlobalSettingsResult Execute()
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
                = JsonConvert.DeserializeObject<GlobalSettings>(jsonFromFile);

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