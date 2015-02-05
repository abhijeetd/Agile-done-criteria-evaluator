using DoneEvaluator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoneEvaluator.Analyzers
{
    public class PBIHasUnassignedTasksAnalyzer: TimeLogAnalyzer
    {
        public override void Analyze(EvaluationServiceContext context, TimeLog workitem)
        {
            if (workitem.Tasks.Where(q => string.IsNullOrEmpty(q.AssignedTo) == true).Any())
            {
                workitem.Observations.Add(new Observation
                {
                    Code = "Mismatch",
                    Title = "There are one or more unassigned tasks created for this workitem.",
                    AssignedTo = workitem.AssignedTo   //TODO: Logic to identify assignedTo
                });
            }
        }
    }
}
