using PluggableService.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoneEvaluator
{
    public abstract class TimeLogAnalyzer : Plugin, IComparable<TimeLogAnalyzer>
    {
        public int Sequence { get; set; }
        public abstract void Analyze(EvaluationServiceContext context, TimeLog workitem);

        public TimeLogAnalyzer()
        {
            Sequence = 1000;
            PluginType = typeof(TimeLogAnalyzer).FullName;
        }

        public int CompareTo(TimeLogAnalyzer other)
        {
            if (other == null) return 1;

            return this.Sequence.CompareTo(other.Sequence);
        }
    }
}
