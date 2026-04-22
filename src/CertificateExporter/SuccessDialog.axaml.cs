using Avalonia.Controls;

namespace CertificateExporter;

public partial class SuccessDialog : Window
{
    public SuccessDialog()
    {
        InitializeComponent();
    }

    public static SuccessDialog Create(string message)
    {
        var dialog = new SuccessDialog();
        var vm = new SuccessDialogViewModel(dialog, message);
        dialog.DataContext = vm;

        return dialog;
    }
}
