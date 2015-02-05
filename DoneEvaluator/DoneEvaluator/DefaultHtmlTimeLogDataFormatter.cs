using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoneEvaluator
{
    public class DefaultHtmlTimeLogDataFormatter : TimeLogDataFormatter
    {
        public string TransformXslFile { get; set; }

        public override string FormatTitle(TimeLogData data)
        {
            return string.Format("TimeMachine: {0} - {1}", data.TeamMember.Fullname, data.ServiceContext.IterationPath);
        }

        public override string FormatData(TimeLogData data)
        {
            var xml = data.Serialize<TimeLogData>();
            return xml.Transform(TransformXslFile);
        }
    }
}
