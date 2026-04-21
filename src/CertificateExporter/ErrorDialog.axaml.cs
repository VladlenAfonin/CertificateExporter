using Avalonia.Controls;

namespace CertificateExporter;

public partial class ErrorDialog : Window
{
    public ErrorDialog()
    {
        InitializeComponent();
    }

    public static ErrorDialog Create(string message)
    {
        var dialog = new ErrorDialog();
        var vm = new ErrorDialogViewModel(dialog, message);
        dialog.DataContext = vm;

        return dialog;
    }
}
