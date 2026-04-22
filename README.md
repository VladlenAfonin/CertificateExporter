# Certificate Exporter

## Create Installer

Install Inno Setup: <https://jrsoftware.org/>.

1. Build the app:

    ```PowerShell
    dotnet publish
    ```

2. Create installer:

    ```PowesShell
    iscc ".\src\CertificateExporter\Install\CertificateExporter.iss"
    ```

## Credits

- Certificate diploma Icon by Aleksandr Reva on <https://icon-icons.com/authors/258-aleksandr-reva>. File <a href="/src/CertificateExporter/Assets/certificate.ico">/src/CertificateExporter/Assets/certificate.ico</a>.
- Close remove delete warning Icon by Papirus Development Team on <https://icon-icons.com/authors/550-papirus-development-team>. File <a href="/src/CertificateExporter/Assets/error.ico">/src/CertificateExporter/Assets/error.ico</a>.
- Apply accept ok done Icon by Papirus Development Team on <https://icon-icons.com/authors/550-papirus-development-team>. File <a href="/src/CertificateExporter/Assets/success.ico">/src/CertificateExporter/Assets/success.ico</a>.