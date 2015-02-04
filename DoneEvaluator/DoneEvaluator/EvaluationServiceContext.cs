using PluggableService.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoneEvaluator
{    
    [Serializable]
    public class EvaluationServiceContext : ServiceContext
    {
        public List<TeamMemberProfile> TeamProfiles { get; set; }

        public Organization Organization { get; set; }
        public Project Project { get; set; }
        
        public string IterationPath { get; set; }

        public List<Milestone> Milestones { get; set; }

        public DateTime? GetMilestone(string milestoneTitle)
        {
            if (Milestones == null)
            {
                return null;
            }
            return Milestones.Where(p => string.Compare(p.Title, milestoneTitle, true) == 0).Select(p => p.CompletionDate).SingleOrDefault();
        }
    }
}
