# Operations

## Current state

- Canonical source: `D:/Git/codex-switch`, private `Gaebabi/codex-switch/main`.
- Source/app version: **1.27.6**. Public distribution, automatic updates and CI release publication are paused.
- Previous codex-account-desk local/GitHub repositories were removed. Recovery material is described in [REPOSITORY.md](REPOSITORY.md).
- Last product verification: Windows internal checks 93/93, disposable SQLite/WAL 23/23, Windows publish and Mac compilation. Native Mac/account acceptance remains in [BACKLOG.md](BACKLOG.md).
- Documentation uses one fictional static demo, not live account or switching evidence. [Recipe](docs/media/README.md)

## Build and verify

[Installation](docs/INSTALL.md) covers normal builds and execution.

```powershell
.\scripts\build.ps1 -Verify
python scripts/verify-queues.py --executable artifacts/win-x64/CodexSwitch.exe
```

When this Windows host's PowerShell startup stalls, use CMD directly:

```text
dotnet publish CodexAccountDesk.csproj -c Release -r win-x64 --self-contained true --nologo -p:UseSharedCompilation=false -o artifacts/win-x64
dotnet build macos/CodexAccountDesk.Mac.csproj -c Release --nologo -p:UseSharedCompilation=false
```

Mac native checks, packaging/signing and device limitations: [Mac development](macos/README.md). Cross-compilation is separate from native acceptance.

## Installed Windows copy

The current per-user installation is `%LOCALAPPDATA%/Programs/CodexSwitch/1.27.6`. The desktop shortcut points there and passes the existing data directory and Codex home.

Keep the complete package. For an update, stage a new version folder, use `--request-exit --data-dir <existing-directory>` to stop only the utility, then start the new copy with the same data/home arguments. Do not overwrite a running folder or terminate native Codex for installation verification.

## Data and privacy

Windows data remains in `%LOCALAPPDATA%/CodexAccountDesk`. Mac data remains in `~/Library/Application Support/CodexAccountDesk`. Default Codex home is `CODEX_HOME` or `~/.codex`. Preserve the existing encryption keys, vault paths, bundle ID and IPC identity.

Authentication, vaults, raw captures, diagnostic reports, packages and recovery archives stay ignored. Live recordings are unredacted. The demo renderer uses temporary fictional data without starting Codex.

## Development routes

[Architecture](docs/ARCHITECTURE.md) / [Switching](docs/SWITCHING.md) / [Forecast](docs/FORECAST.md) / [Account-sync proposal](docs/ACCOUNT_SYNC_REVIEW.md) / [Package delivery](docs/RELEASES.md)

Manual commits/pushes follow the user's explicit scope; automatic snapshots are local backups. A push is not a Release or deployment. Older implementation/validation history remains in Git rather than the getting-started documents.
