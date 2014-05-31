using Simon.Domain.Process;
using Simon.Domain.Process.Contexts;
using Simon.Domain.Process.Results;
using System.Threading.Tasks;

namespace Simon.Processes.FileSystem.Json
{
    /// <summary>
    /// 
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
            throw new System.NotImplementedException();
        }
    }
}