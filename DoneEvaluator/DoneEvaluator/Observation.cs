using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoneEvaluator
{
    public enum ObservationType
    {
        Workitem,
        Task,
        Generic
    }

    public class Observation
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Project Project { get; set; }
        public string Code { get; set; }
        public int Points { get; set; }
        public DateTime Timestamp { get; set; }

        public int WorkitemId { get; set; }

        public ObservationType Type { get; set; }
        public string AssignedTo { get; set; }

        public Observation()
        {
            Timestamp = DateTime.Now.Date;
            Type = ObservationType.Workitem;
        }
    }
}
