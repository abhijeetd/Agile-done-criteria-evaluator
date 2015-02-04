using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoneEvaluator.Console
{
    public class ConsoleNotificationListener : NotificationListener
    {
        public override void Notify(NotificationContext context)
        {
            var Context = context as TimeLogNotificationContext;

            if (Context != null)
            {
                var formatter = Context.DataFormatter as TimeLogDataFormatter;

                if (formatter != null)
                {
                    System.Console.WriteLine(formatter.FormatData(Context.Data));
                }
            }
        }
    }
}
