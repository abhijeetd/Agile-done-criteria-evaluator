using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoneEvaluator.Console
{
    public class SampleTimeLogDataProvider : TimeLogDataProvider
    {
        public override List<TimeLog> LoadData(EvaluationServiceContext context)
        {
            var organization = new Organization { Id = 1, Title = "Organization 1" };
            var project = new Project { Id = 1, Title = "Project 1", Organization = organization };

            var tasks = new List<TimeLog>();
            tasks.Add(new TimeLog
            {
                Title = "Task title 1"
            });
            
            var workitems = new List<TimeLog>();
            workitems.Add(new TimeLog
            {
                Id = 1,
                Title = "product backlog item #1",
                Activity = "Development",
                Effort = 10,
                IsTaskMarkedAsDone = true,
                Owner = TaskOwnerType.Developer,
                AssignedTo = "Abhijeet Dhamankar",
                IterationPath = "Release 1",
                Project = project,
                State = "New",
                TrackingDate = DateTime.Now,
                Type = "Coding",
                Tasks = tasks
            });
            return workitems;
        }
    }
}
