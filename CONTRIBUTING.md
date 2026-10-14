# Development

Build from the repository root. [Installation](docs/INSTALL.md) / [Architecture](docs/ARCHITECTURE.md)

```powershell
.\scripts\build.ps1 -Verify
python scripts/verify-queues.py --executable artifacts/win-x64/CodexSwitch.exe
```

Mac native checks: `bash scripts/verify-macos.sh`. Use isolated accounts/storage/databases for tests. Do not stop the user's Codex or switch a real account to validate source changes.

## Editing

Use UTF-8 and focused patches. Fix underlying causes, preserve unavailable-versus-zero behavior and keep existing user settings.

UI translations use Korean keys in `Strings.en.json` and `Strings.ko.json`. Add both translations together; `node scripts/regenerate-ko.cjs` rebuilds the Korean catalog. Node is optional for normal builds.

## Documentation image

On Windows, run `python scripts/render-demo.py`. It requires the .NET 8 SDK and renders one fictional PNG using the current components. Python's standard library is sufficient. Inspect the image and update documentation when UI behavior changes.

## Before a commit

Check `git diff --check` and relevant links/builds. Never include authentication files, vaults, local databases, raw personal captures, private reports or build output. Respect explicit commit/push/publication scope in AGENTS.md.

MIT licensed. Preserve [asset notices](Burn0Assets.LICENSE.txt) and review [security](SECURITY.md).
