using PluggableService.Framework;
using System.Collections.Generic;

namespace DoneEvaluator
{
    public abstract class TimeLogDataProvider : Plugin
    {
        public abstract List<TimeLog> LoadData(EvaluationServiceContext context);

        public TimeLogDataProvider()
        {
            PluginType = typeof(TimeLogDataProvider).FullName;
        }
    }
}
