using System;
using System.Diagnostics;

namespace IXRay.Builder.Servies;

public class ProcessService {
    private static string ExecuteCommand(string command, string arguments) {
        try {
            var process = new Process();
            process.StartInfo.FileName = command;
            process.StartInfo.Arguments = arguments;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.Start();

            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            if (process.ExitCode == 0) {
                return output;
            }
        } catch (Exception ex) {
            throw new Exception(ex.Message);
        }
        return string.Empty;
    }

    public static string GetGitVersion() {
        var output = ExecuteCommand("git", "--version");
        return output.Split(' ')[2].Trim();
    }

    public static string GetCMakeVersion() {
        var output = ExecuteCommand("cmake", "--version");
        return output.Split(' ')[2].Split('\n')[0];
    }

    public static string GetVisualStudioVersion() {
        var output = ExecuteCommand(Environment.GetEnvironmentVariable("ProgramFiles(x86)") + @"\Microsoft Visual Studio\Installer\vswhere", "-latest -property catalog_productDisplayVersion");
        return output.Trim();
    }
}
