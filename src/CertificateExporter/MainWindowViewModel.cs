using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CertificateExporter;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _outputDir = "";

    [ObservableProperty]
    private string _inputRegex = "";

    private const string PfxPin = "1";

    public ObservableCollection<string> CommonRegexes { get; } =
    ["archive\\.cryptopro\\.ru-.*", "pki-cluster-core-.*"];

    [RelayCommand]
    public async Task Export()
    {
        if (string.IsNullOrWhiteSpace(OutputDir))
        {
            var d = ErrorDialog.Create("Output directory must be set.");
            await d.ShowDialog(App.MainWindow);
            return;
        }

        if (!Directory.Exists(OutputDir))
        {
            try
            {
                Directory.CreateDirectory(OutputDir);
            }
            catch (Exception e)
            {
                var d = ErrorDialog.Create($"Error during directory creation: {e.Message}.");
                await d.ShowDialog(App.MainWindow);
                return;
            }
        }

        using var store = new X509Store(
            StoreName.My,
            StoreLocation.CurrentUser,
            OpenFlags.ReadOnly
        );
        foreach (var certificate in store.Certificates)
        {
            var subjectCn = certificate.GetNameInfo(X509NameType.SimpleName, false);
            if (!Regex.IsMatch(subjectCn, InputRegex))
            {
                continue;
            }

            var cer = certificate.Export(X509ContentType.Cert);
            File.WriteAllBytes(Path.Combine(OutputDir, $"./{subjectCn}.cer"), cer);

            try
            {
                var pfx = certificate.Export(X509ContentType.Pfx, PfxPin);
                File.WriteAllBytes(Path.Combine(OutputDir, $"./{subjectCn}.pfx"), pfx);
            }
            catch (CryptographicException exception)
            {
                Console.Error.Write(
                    $"WARNING: Unable to export key for certificate {subjectCn} {certificate.Thumbprint}.\n"
                        + $"         Exception: {exception.Message}\n"
                );
            }
        }
    }

    [RelayCommand]
    public async Task Browse()
    {
        var storageProvider = App.MainWindow.StorageProvider;
        var dirPicker = await storageProvider.OpenFolderPickerAsync(
            new() { Title = "Choose Directory" }
        );

        OutputDir = dirPicker.SingleOrDefault()?.Path.AbsolutePath ?? OutputDir;
    }
}
