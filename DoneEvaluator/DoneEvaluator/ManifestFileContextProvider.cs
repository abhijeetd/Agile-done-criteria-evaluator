using PluggableService.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoneEvaluator
{
    public class ManifestFileContextProvider : IContextProvider
    {
        private string _manifestFilename;
        public ManifestFileContextProvider(string manifestFilename)
        {
            _manifestFilename = manifestFilename;
        }
        public ServiceContext GetServiceContext()
        {
            return _manifestFilename.DeserializeFile<EvaluationServiceContext>();
        }
    }
}
