namespace IXRay.Builder.Core 
{
	internal class CMakeCore 
	{
        public enum Configuration 
		{
            Win32,
            x64,
            Linux,
            MacOS
		}

        public struct Options
        {
            public bool Multiplayer;
            public bool EngineUtils;
            public bool AdressSanitaizer;
            public bool UnityBuild;
        }

        CommandLineCore CLI;
        Configuration BuildCfg = Configuration.Win32;

        public CMakeCore(Configuration configuration) 
        {
            CLI = new CommandLineCore("");
            BuildCfg = configuration;
        }

        public void Start(Options options) 
        {
            string CommandLine = $"cmake -B build -A={BuildCfg.ToString()} ";

            if (options.Multiplayer) 
            {
                CommandLine += "-DIXRAY_MP=ON ";
            }
            
            if (options.EngineUtils) 
            {
                CommandLine += "-DIXRAY_UTILS=ON ";
            }
            
            if (options.AdressSanitaizer) 
            {
                CommandLine += "-DIXRAY_ASAN=ON ";
            }
            
            if (options.UnityBuild) 
            {
                CommandLine += "-DIXRAY_UNITYBUILD=ON ";
            }

            CLI.Start(CommandLine);
        }

        public void OpenSolution()
        {
            // TODO
        }
    }
}
