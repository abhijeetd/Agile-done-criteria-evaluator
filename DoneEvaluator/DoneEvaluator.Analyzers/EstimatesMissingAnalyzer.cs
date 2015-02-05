using DoneEvaluator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoneEvaluator.Analyzers
{
    public class EstimatesMissingAnalyzer : TimeLogAnalyzer
    {
        public override void Analyze(EvaluationServiceContext context, TimeLog workitem)
        {
            if (workitem.Effort == 0)
            {
                //get first developer
                var assignedToDev = workitem.Tasks.Where(p => p.Owner == TaskOwnerType.Developer).FirstOrDefault();
                workitem.Observations.Add(new Observation
                {
                    Code = "Lifecycle checklist",
                    Title = "Estimates are missing.",
                    AssignedTo = assignedToDev != null ? assignedToDev.AssignedTo : string.Empty
                });
            }
        }
    }
}
