using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoneEvaluator
{
    [Serializable]
    public class TimeLogData
    {
        public EvaluationServiceContext ServiceContext { get; set; }
        public List<TimeLog> Workitems { get; set; }
        public TeamMemberProfile TeamMember { get; set; }
    }
}
