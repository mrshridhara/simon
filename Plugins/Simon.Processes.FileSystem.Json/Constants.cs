using System;
using System.IO;

namespace Simon.Processes.FileSystem.Json
{
    /// <summary>
    /// Represents the constants.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The save path for global settings json file.
        /// </summary>
        public static readonly string GlobalSettingsSavePath
            = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\GlobalSettings.json");
    }
}