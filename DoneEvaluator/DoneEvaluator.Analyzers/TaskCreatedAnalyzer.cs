using DoneEvaluator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoneEvaluator.Analyzers
{
    public class TaskCreatedAnalyzer : TimeLogAnalyzer
    {
        public override void Analyze(EvaluationServiceContext context, TimeLog workitem)
        {
            if (workitem.Tasks == null || workitem.Tasks.Count == 0)
            {
                workitem.Observations.Add(new Observation
                {
                    Code = "Lifecycle checklist",
                    Title = "Tasks not created under this PBI",
                    AssignedTo = workitem.AssignedTo
                });
            }
        }
    }
}
