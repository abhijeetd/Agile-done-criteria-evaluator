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
            var Context = context as GlobalNotificationContext;

            if (Context != null)
            {
                    System.Console.WriteLine("{0}: {1}", ToString(), ListenerType);
            }
        }
    }
}
