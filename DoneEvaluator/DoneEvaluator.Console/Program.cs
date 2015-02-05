
namespace DoneEvaluator.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            EvaluationService service = new EvaluationService();
            var filename = ParseArgs(args);
            if (string.IsNullOrEmpty(filename) == false)
            {
                service.Execute(new ManifestFileContextProvider(filename));
                System.Console.WriteLine("Please enter to close the application.");
                System.Console.ReadLine();
                return;
            }
            System.Console.WriteLine("No manifest file found");
        }

        private static string ParseArgs(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                var param = args[i].Split(':');
                if (param.Length >= 1)
                {
                    if (string.Compare(param[0], "-manifest", true) == 0)
                    {
                        return ExtractParameter(param);
                    }
                }
            }
            return null;
        }

        private static string ExtractParameter(string[] param)
        {
            string value = param[1];
            for (int i = 2; i < param.Length; i++)
            {
                value += ":" + param[i];
            }
            return value;
        }
    }
}
