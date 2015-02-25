using PluggableService.Framework;
using System;

namespace DoneEvaluator
{
    public enum NotificationListenerType
    {
        Global,
        PerTeamMember
    }

    public abstract class NotificationListener : Plugin
    {
        public abstract void Notify(NotificationContext context);
 
        public NotificationListenerType ListenerType { get; set; }

        public NotificationListener()
        {
            PluginType = typeof(NotificationListener).FullName;
        }
    }
}
