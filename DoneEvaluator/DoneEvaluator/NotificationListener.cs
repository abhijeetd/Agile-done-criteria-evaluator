using PluggableService.Framework;
using System;

namespace DoneEvaluator
{
    public abstract class NotificationListener : Plugin
    {
        public abstract void Notify(NotificationContext context);

        public NotificationListener()
        {
            PluginType = typeof(NotificationListener).FullName;
        }
    }
}
