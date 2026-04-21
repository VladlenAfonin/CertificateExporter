using System.Threading.Tasks;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CertificateExporter;

public partial class ErrorDialogViewModel : ObservableObject
{
    private readonly Window _window;

    [ObservableProperty]
    private string _message;

    public ErrorDialogViewModel(Window window, string message)
    {
        _window = window;
        _message = message;
    }

    [RelayCommand]
    public async Task Close()
    {
        _window.Close();
    }
}
