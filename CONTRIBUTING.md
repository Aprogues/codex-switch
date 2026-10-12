# Contributing to Codex Switch

Build from source using the commands in [README](README.md). Keep changes focused and describe the behavior they fix. Use UTF-8 and preserve existing language choices.

- Windows: `./scripts/build.ps1 -Verify` runs local internal checks.
- Queue/WAL checks: `python scripts/verify-queues.py --executable artifacts/win-x64/CodexSwitch.exe` uses disposable databases.
- macOS: `bash scripts/verify-macos.sh` on a Mac; cross-compilation does not prove native behavior.

Never include `auth.json`, account vaults, tokens, private logs, personal captures, build output or local Codex databases in a pull request. Use synthetic accounts for tests. Do not stop a contributor's running Codex or switch their real account as a test.

UI translations live in `Strings.en.json` and `Strings.ko.json`. The current catalog uses Korean source strings as stable keys. Add both translations together; `node scripts/regenerate-ko.cjs` regenerates the Korean key catalog. Node is optional for normal builds.

The application uses Codex app-server and local desktop protocols. Keep unavailable data distinct from zero, preserve read-only observation, and document protocol compatibility limitations. Tests of isolated switching are separate from real account handoff acceptance.

Code contributions use the [MIT license](LICENSE); third-party notices remain in [Burn0Assets.LICENSE.txt](Burn0Assets.LICENSE.txt).
