# Codex Switch on macOS

Requires macOS 12 or later and installed Codex desktop/CLI. Download the [Apple Silicon](https://github.com/Gaebabi/codex-switch/releases/download/v1.27.0/CodexSwitch-v1.27.0-osx-arm64.zip) or [Intel](https://github.com/Gaebabi/codex-switch/releases/download/v1.27.0/CodexSwitch-v1.27.0-osx-x64.zip) ZIP and follow the installation steps below. No source build, SDK or runtime is needed to use these self-contained packages.

To build from source instead, install .NET 8 SDK or later:

```bash
bash scripts/build-macos.sh osx-arm64 # Apple Silicon
bash scripts/build-macos.sh osx-x64   # Intel
```

Outputs are timestamped beneath `artifacts/macos/<rid>/`. Each ZIP contains `Codex Switch.app` and `Install.command`.

1. Extract the complete ZIP, preserving the app bundle structure.
2. Quit an existing Account Desk or Codex Switch through its menu or ⌘Q. Closing only hides the window.
3. Run `Install.command`. It stages and validates plist/signing and `--help`, then installs to `~/Applications`, retaining an existing app as a backup. A running utility prevents installation. Accounts are not moved or deleted.
4. Open from Finder. Keychain may request authorization when a locally signed app's code identity changes. Follow the normal macOS opening flow; do not disable Gatekeeper.

The published Mac ZIPs are cross-published unsigned packages; the included installer applies local ad-hoc signing. `MAC_CODESIGN_IDENTITY` selects an identity for a native source build. Developer ID notarization is not configured. Native Mac runtime acceptance is separate from package checks.

The rename preserves `~/Library/Application Support/CodexAccountDesk`, the Keychain service and bundle identifier. An older `Codex Account Desk.app` is not automatically removed. Use one edition at a time; quit the old utility before opening the renamed one.

Use ⌘R/F5 to refresh, ⌘W to hide and ⌘Q to quit. Drag the title/empty caption to move. Cards scroll when needed. The monochrome menu-bar icon shows the active account's reported remaining percentage, or **—** when unavailable.

```bash
bash scripts/verify-macos.sh
python3 scripts/verify-macos-install.py /path/to/CodexSwitch-osx-arm64.zip
```

Native checks use isolated Keychain/storage/socket fixtures, actual OS resources and synthetic account layouts. They do not sign into accounts or stop/switch Codex. Earlier Apple Silicon native checks passed; this rename is cross-compiled on Windows. Real login/switching/chat resumption, renamed installation on Mac, and Intel-device acceptance need native verification.
