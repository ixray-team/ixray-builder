using IXRay.Builder.Servies;

using ReactiveUI;

namespace IXRay.Builder.ViewModels;

public class MainViewModel : ReactiveObject {
    private string? _gitVersion;

    public string? GitVersion {
        get => _gitVersion;
        set => this.RaiseAndSetIfChanged(ref _gitVersion, value);
    }

    private string? _cmakeVersion;

    public string? CMakeVersion {
        get => _cmakeVersion;
        set => this.RaiseAndSetIfChanged(ref _cmakeVersion, value);
    }

    private string? _visualStudioVersion;

    public string? VisualStudioVersion {
        get => _visualStudioVersion;
        set => this.RaiseAndSetIfChanged(ref _visualStudioVersion, value);
    }

    public MainViewModel() {
        GitVersion = ProcessService.GetGitVersion();
        CMakeVersion = ProcessService.GetCMakeVersion();
        VisualStudioVersion = ProcessService.GetVisualStudioVersion();
    }
}
