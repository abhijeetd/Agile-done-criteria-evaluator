using PluggableService.Framework;

namespace DoneEvaluator
{
    public abstract class DataFormatter : Plugin
    {
        public DataFormatter()
        {
            PluginType = typeof(DataFormatter).FullName;
        }
    }
}
