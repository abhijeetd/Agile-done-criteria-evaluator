using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoneEvaluator
{
    public class GlobalNotificationContext : NotificationContext
    {
        public List<TimeLog> Workitems { get; set; }
    }
}
