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

            var globalSettingsDictionary
                = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonFromFile);

            if (globalSettingsDictionary == null)
            {
                return GetDefaultResult();
            }

            return new GetGlobalSettingsResult
            {
                GlobalSettings = new GlobalSettings(globalSettingsDictionary)
            };
        }

        private static GetGlobalSettingsResult GetDefaultResult()
        {
            return new GetGlobalSettingsResult
            {
                GlobalSettings = new GlobalSettings(new Dictionary<string, dynamic>())
            };
        }
    }
}