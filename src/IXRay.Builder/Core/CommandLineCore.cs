using System.Diagnostics;

namespace IXRay.Builder.Core 
{
    internal class CommandLineCore 
    {
        Process? CLProcess = null;
        ProcessStartInfo? ProcessStartInfo = null;

        public CommandLineCore(string Dir) 
        {
            ProcessStartInfo = new ProcessStartInfo("cmd.exe") 
            {
                RedirectStandardInput = true,
                WorkingDirectory = Dir,

                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false,

                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
        }

        public void Start(string Command)
        {
            if (ProcessStartInfo == null)
                return;

            ProcessStartInfo.Arguments = Command;

            CLProcess = Process.Start(ProcessStartInfo);
            if (CLProcess == null)
                return;

            CLProcess.OutputDataReceived += new DataReceivedEventHandler((sender, e) => 
            {
                if (!string.IsNullOrEmpty(e.Data)) 
                {
                    Print(e.Data);
                }
            });

            CLProcess.ErrorDataReceived += new DataReceivedEventHandler((sender, e) => 
            {
                // Prepend line numbers to each line of the output.
                if (!string.IsNullOrEmpty(e.Data)) 
                {
                    Print(e.Data);
                }
            });

            CLProcess.BeginOutputReadLine();
            CLProcess.BeginErrorReadLine();
        }

        void Print(string data) 
        {

        }
    }
}
