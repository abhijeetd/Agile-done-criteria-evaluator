using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoneEvaluator
{
    public abstract class TimeLogDataFormatter : DataFormatter
    {
        public abstract string FormatTitle(TimeLogData data);
        public abstract string FormatData(TimeLogData data);

        public TimeLogDataFormatter()
        {
            PluginType = typeof(TimeLogDataFormatter).FullName;
        }
    }
}
