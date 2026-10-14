# Build and install

Use an existing complete package, or build from this repository. Codex desktop/CLI must already be installed. Only source builds require the .NET 8 SDK.

## Windows

Run these commands from the repository root:

```powershell
.\scripts\build.ps1 -Verify
.\artifacts\win-x64\CodexSwitch.exe
```

`artifacts/win-x64` is the complete self-contained package. Keep the entire folder; an EXE alone is insufficient. An existing installed copy can be opened using its Codex Switch shortcut.

## Mac

macOS 12 or later. Choose your processor:

```bash
bash scripts/build-macos.sh osx-arm64 # Apple Silicon
bash scripts/build-macos.sh osx-x64   # Intel
```

The output is beneath `artifacts/macos/<rid>/`.

1. Extract the complete ZIP.
2. Quit an existing Codex Switch with **⌘Q**.
3. Run `Install.command`, then open the installed **Codex Switch.app** from Finder.

The installer validates the new app and preserves the previous installation. Local builds use ad-hoc signing unless a Developer ID identity is configured. macOS may require its normal opening or Keychain authorization flow. [Mac details](MACOS.md)

## First use

Select **+**, complete browser sign-in, compare the cards and choose **Switch**. In Windows, right-click **↻** to import the current Codex login.

No automatic updater is configured. Public distribution is paused; old 1.27.0 Release links are not the current package.
