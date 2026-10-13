# Codex Switch repository

The only active source repository is `D:/Git/codex-switch`, branch `main`, with private GitHub origin `https://github.com/Gaebabi/codex-switch.git`. The October 14, 2026 consolidation includes all current 1.27.6 Windows/Mac code, icons, translations, layout/tooltips, working documents and private validation tools/captures.

The destination's Mac Developer ID timestamp support, installer handling for already signed bundles and notarization helper were retained. No notarization or external Release was run.

## Recovery material

Private recovery material lives under ignored `artifacts/repository-migration-20261014`. Verified Git bundles preserve both repositories' existing refs/history without merging the old private history into main. Source/working-state receipts, previous-target collision copies and GitHub repository/branch/tag/release/issue metadata are local only. Old diagnostic artifacts were copied with SHA-256 checks; normal bin/obj caches are regenerable.

Use `git bundle verify <bundle>` to check a bundle and `git clone <bundle> <separate recovery directory>` only if history recovery is needed. Routine development continues here. Never push the ignored recovery material, authentication files, account vaults or raw personal captures.

## Current execution and verification

- Windows source builds/publishes from this directory to `artifacts/win-x64`.
- Mac source compiles from `macos/CodexAccountDesk.Mac.csproj`; native Mac acceptance remains separate.
- Windows self-tests: 93 passed; isolated SQLite/WAL checks: 23 passed.
- Installed Windows 1.27.6 remains in the per-user Programs/CodexSwitch directory. Desktop shortcut and existing vault/home paths are independent of the retired source checkout.
- The old `D:/Git/codex-account-desk` and `Gaebabi/codex-account-desk` were removed at the user's request. The local directory is absent; GitHub displayed its deletion-success banner and an authenticated API read returns404. Final local/remote deletion receipts are recorded privately and summarized in STATUS.md.

The existing daily snapshot automation made local commit `d3844fc` during transfer. The user subsequently explicitly approved a scoped consolidation commit and push to private `codex-switch/main`. Push is verified by comparing local HEAD to the remote main reference; the resulting receipt is ignored/private. No public Release, CI deployment or Mac native/account test was performed. Historical dated entries retain their original paths and do not select a current work root.
