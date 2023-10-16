using System;

using Avalonia;
using Avalonia.ReactiveUI;

namespace IXRay.Builder;

internal class Program {
    /// <summary>
    /// Initialization code
    /// </summary>
    /// <param name="args"></param>
    [STAThread]
    public static void Main(string[] args) =>
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

    /// <summary>
    /// Avalonia configuration, also used by visual designer
    /// </summary>
    /// <returns></returns>
    public static AppBuilder BuildAvaloniaApp() =>
        AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();
}
