using System.Linq;

namespace DoneEvaluator.Analyzers
{
    public class TaskOwnerAnalyzer : TimeLogAnalyzer
    {
        public override void Analyze(EvaluationServiceContext context, TimeLog workitem)
        {
            ValidateByrole(context, workitem, TaskOwnerType.Architect, "Architect code review");
            ValidateByrole(context, workitem, TaskOwnerType.Peer, "Peer code review");
            ValidateByrole(context, workitem, TaskOwnerType.Developer, "Development");
            ValidateByrole(context, workitem, TaskOwnerType.Tester, "Testing");
            ValidateByrole(context, workitem, TaskOwnerType.Team, "Generic");
        }

        private void ValidateByrole(EvaluationServiceContext context, TimeLog workitem, TaskOwnerType taskowner, string taskTypes)
        {
            var teamMembers = context.TeamProfiles.Where(p => string.Compare(p.Role, taskowner.ToString(), true) == 0).Select(p=> p.Fullname.ToLower()).ToList();
            workitem.Tasks.Where(p => p.Owner == taskowner).ToList().ForEach(p =>
            {
                if (teamMembers.Where(q => teamMembers.Contains(q.ToLower()) == false).Any())
                {
                    workitem.Observations.Add(new Observation
                    {
                         Code = "Lifecycle checklist",
                         Title = string.Format("One or more {0} tasks are not assigned to respective {1}s", taskTypes, taskowner),
                         AssignedTo = workitem.AssignedTo
                    });
                }
            });
        }
    }
}
