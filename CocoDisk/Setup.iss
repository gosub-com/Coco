[Setup]
AppName=CocoDisk
AppVersion=1.0.0
OutputDir=.
OutputBaseFilename=SetupCocoDisk
UsePreviousAppDir=false
UsePreviousGroup=false
DefaultDirName={pf64}\Gosub\CocoDisk
DefaultGroupName=CocoDisk
AppPublisher=Gosub Software
UninstallDisplayName=CocoDisk
UninstallDisplayIcon={app}\CocoDisk.exe
LicenseFile=License.txt

[Files]
Source: "CocoDisk.exe"; DestDir: "{app}"; flags:ignoreversion

[Icons]
Name: "{group}\CocoDisk"; Filename: "{app}\CocoDisk.exe"
Name: "{group}\Uninstall CocoDisk"; Filename: "{uninstallexe}"

[Run]
FileName: "{app}\CocoDisk.exe"; Flags: Postinstall

