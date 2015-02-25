using PluggableService.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoneEvaluator
{
    public class EvaluationService : BaseService
    {
        private const int CapacityPerDay = 7;
        private const int TotalDaysInWeek = 7;
        private const int WorkingDaysPerWeek = 5;

        public EvaluationServiceContext Context { get; set; }

        protected override void Run(ServiceContext context)
        {
            Context = context as EvaluationServiceContext;
            if (Context == null)
            {
                throw new Exception("Configuration parameters not found");
            }

            var notificationListeners = PluginService.GetPlugins<NotificationListener>(typeof(NotificationListener).FullName);
            var dataProvider = PluginService.GetPlugin<TimeLogDataProvider>(typeof(TimeLogDataProvider).FullName);
            var analyzers = PluginService.GetPlugins<TimeLogAnalyzer>(typeof(TimeLogAnalyzer).FullName);

            if (analyzers != null && analyzers.Count > 0)
            {
                analyzers.Sort();
            }
            var workitems = dataProvider.LoadData(Context);

            AnalyzeWorkitems(Context, workitems, analyzers);

            RaiseGlobalNotifications(notificationListeners, workitems);

            RaiseTeamMemberNotifications(notificationListeners, workitems);
        }

        private void RaiseTeamMemberNotifications(List<NotificationListener> notificationListeners, List<TimeLog> workitems)
        {
            var teamMemberNotificationListeners = notificationListeners.Where(p => p.NotificationListenerType == NotificationListenerType.PerTeamMember).ToList();

            var developers = workitems.Select(p => p.AssignedTo).Distinct().ToList();

            foreach (var developer in developers)
            {
                TimeLogData data = new TimeLogData
                {
                    ServiceContext = Context,
                    TeamMember = Context.TeamProfiles.Where(p => p.Fullname == developer).SingleOrDefault(),
                    Workitems = workitems.Where(p => p.AssignedTo == developer).ToList()
                };
                string devEmail = Context.TeamProfiles.Where(p => p.Fullname == developer).Select(p => p.Email).SingleOrDefault();
                if (string.IsNullOrEmpty(devEmail) == false)
                {
                    teamMemberNotificationListeners.ForEach(p =>
                    {
                        try
                        {
                            p.Notify(new TeamMemberNotificationContext { Data = data });
                        }
                        catch (Exception ex)
                        {
                            //Log exception
                            Console.WriteLine("Error occured: {0}", ex.Message);
                        }
                    });
                }
            }
        }

        private void RaiseGlobalNotifications(List<NotificationListener> notificationListeners, List<TimeLog> workitems)
        {
            var globalNotificationListeners = notificationListeners.Where(p => p.NotificationListenerType == NotificationListenerType.Global).ToList();
            globalNotificationListeners.ForEach(p =>
            {
                try
                {
                    p.Notify(new GlobalNotificationContext { Workitems = workitems });
                }
                catch (Exception ex)
                {
                    //Log exception
                    Console.WriteLine("Error occured: {0}", ex.Message);
                }
            });
        }

        private void AnalyzeWorkitems(EvaluationServiceContext context, List<TimeLog> list, List<TimeLogAnalyzer> analyzers)
        {
            if (list != null && list.Count > 0 && analyzers != null && analyzers.Count > 0)
            {
                list.ForEach(workitem =>
                {
                    analyzers.ForEach(p => p.Analyze(context, workitem));
                    //attach workitem to each observation
                    workitem.Observations.ForEach(observation =>
                    {
                        observation.WorkitemId = workitem.WorkitemId;
                        observation.Type = ObservationType.Workitem;
                    });

                    //attach workitem to each tasklevel observation
                    workitem.Tasks
                        .ForEach(task => task.Observations
                            .ForEach(observation =>
                            {
                                observation.WorkitemId = workitem.WorkitemId;
                                observation.Type = ObservationType.Task;
                            })
                        );
                });
            }
        }
    }
}
