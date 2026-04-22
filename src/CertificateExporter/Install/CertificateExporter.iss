#define RootDir "..\..\.."
#define MyAppName "Certificate Exporter"
#define MyExecutableName "CertificateExporter"
#define MyAppPublisher "Vladlen Afonin"
#define MyAppURL "https://github.com/VladlenAfonin/CertificateExporter"
#define MyBinPath RootDir + "\src\CertificateExporter\bin\Release\net10.0\win-x64\publish"
#define MyIconPath RootDir + "\src\CertificateExporter\Assets\certificate.ico"
#define MyAppVersion "0.1.0"

[Setup]
SetupIconFile={#MyIconPath}
AppId={{55C625B8-49DA-4277-894B-15C6E17543EB}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyExecutableName}
DefaultGroupName={#MyAppName}
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
OutputDir={#RootDir}/bin
OutputBaseFilename={#MyExecutableName}Setup-{#MyAppVersion}
Compression=lzma2
SolidCompression=yes
WizardStyle=modern

[Files]
Source: "{#MyBinPath}\{#MyExecutableName}.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#RootDir}\README.md"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#RootDir}\LICENSE"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyExecutableName}.exe"; WorkingDir: "{app}"
Name: "{group}\Uninstall {#MyAppName}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyExecutableName}.exe"; WorkingDir: "{app}"