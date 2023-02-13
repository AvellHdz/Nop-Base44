using Nop.Services.Tasks;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Services
{
    /// <summary>
    /// Represents a schedule task to synchronize contacts
    /// </summary>
    public class SynchronizationTask : IScheduleTask
    {
        #region Fields

        private readonly SynchronizationManager _synchronizationManager;

        #endregion

        #region Ctor

        public SynchronizationTask(SynchronizationManager synchronizationManager)
        {
            _synchronizationManager = synchronizationManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Execute task
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async System.Threading.Tasks.Task ExecuteAsync()
        {
            await _synchronizationManager.SynchronizeAsync();
        }

        #endregion
    }
}
