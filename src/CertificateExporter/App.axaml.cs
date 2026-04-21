using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace CertificateExporter;

public partial class App : Application
{
    public static MainWindow MainWindow { get; set; } = null!;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow() { DataContext = new MainWindowViewModel() };
            MainWindow = (MainWindow)desktop.MainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
