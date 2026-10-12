# Binary releases

Official project downloads are GitHub Release ZIPs under this repository. They are self-contained; end users do not build source or install .NET. This is an independent community project, not an OpenAI release.

## v1.27.0

- `CodexSwitch-v1.27.0-win-x64.zip`: complete Windows x64 folder with WPF/.NET runtime, `CodexSwitch.exe` and license notices.
- `CodexSwitch-v1.27.0-osx-arm64.zip`: Apple Silicon `.app`, runtime and `Install.command`.
- `CodexSwitch-v1.27.0-osx-x64.zip`: Intel `.app`, runtime and `Install.command`.
- `SHA256SUMS.txt`: SHA-256 hashes for all three ZIPs.

Packages have no credentials, vaults, recordings, private diagnostics or debug symbols. Mac ZIP executable and installer modes are 0755. Windows packages are unsigned; Mac ZIPs are cross-published unsigned packages with a local ad-hoc signing installer. Native Mac rendering/installation/account-switch acceptance and Intel-device execution are separate from cross-build/package inspection.

## Maintainer procedure

1. Set the same version in both projects and the Mac plist. Build Windows with `scripts/build.ps1 -Verify`, and Mac with `scripts/build-macos.ps1` or a native `scripts/build-macos.sh` build.
2. Package the entire Windows publish folder, not an EXE alone. Preserve Mac ZIP Unix executable modes and the complete `.app` structure. Include MIT and icon/theme notices.
3. Run the extracted Windows ZIP's isolated checks. Inspect archive member paths and private-data exclusions, Mac app-host architecture/execute bits, and checksums. Never package a data directory or raw recording.
4. Commit the corresponding source/docs/media, run `scripts/audit-public.py`, and push. Tag that exact source commit.
5. Create a draft GitHub Release, upload the three ZIPs and checksum file, check their sizes/digests, then publish. Verify anonymous download headers/digests and README links.

Publication is manual. No automatic deployment, update service or CI-triggered release is configured.
