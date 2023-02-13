using System.Linq;
using FluentMigrator;
using Nop.Core.Domain.Tasks;
using Nop.Data;
using Nop.Data.Migrations;

namespace Nop.Plugin.Misc.SyncCatalog.Data.Migrations
{
    [NopMigration("2023/01/24 11:00:00:2551888", "SyncCatalog.AddNewTaskMigration.Data base schema", UpdateMigrationType.Data)]
    public class SyncMigration : Migration
    {
        private readonly INopDataProvider _dataProvider;

        public SyncMigration(INopDataProvider dataProvider)
        {
            _dataProvider = dataProvider;

        }
        public override void Down()
        {

        }

        public override void Up()
        {
            var task = _dataProvider.GetTable<ScheduleTask>()
                .FirstOrDefault(l => l.Name == LiteralSync.SynchronizationTaskName);

            if (task is null)
            {
                _dataProvider.InsertEntity(new ScheduleTask()
                {
                    Enabled = true,
                    Seconds = LiteralSync.DefaultSynchronizationPeriod * 60 * 60,
                    Name = LiteralSync.SynchronizationTaskName,
                    Type = LiteralSync.SynchronizationTask,
                });
            }
        }
    }
}
