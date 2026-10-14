# Current status

Updated 2026-10-14. Source/app version **1.27.6**.

## Current release refresh

- The owner resumed public distribution and requested commit/push plus latest binary Release. Download instructions now target 1.27.6 for Windows x64/Mac arm64/x64, with no source build/.NET installation required.
- Main READMEs now explicitly cover pre-switch chat/login backup, same chat ID/folder/model/permission restoration, one automatic Continue to eligible idle continuations, already-running/completed exclusion and encrypted pending-handoff recovery. These descriptions were checked against AccountSwitchCoordinator and DesktopSwitchBackend; no new switching behavior was introduced.
- Fresh Windows build and extracted package pass 93 internal checks; independent SQLite/WAL checks pass23. Both Mac cross-publishes succeed; archive CPU architecture, version1.27.6, complete runtime and0755 app/installer modes match. All packages exclude auth/vault/private logs/captures and carry checksums/licenses.
- Mac native acceptance/notarization remains separate. The current documentation image remains a labeled fictional demo, not live switch/resumption evidence. Signing credentials, private diagnostics and binary output are ignored.

## Ready

- One canonical public repository: codex-switch; public visibility verified through GitHub API on 2026-10-14 after the owner's resumed distribution. Previous local/GitHub codex-account-desk repositories are removed; verified recovery archives remain ignored.
- Asynchronous accounts/usage, compact water cards, reset/subscription/credit values, centered activity counters, resource/drive graphs and themed menus/tooltips.
- Windows package and shortcut retain the existing account data/home.
- Last product validation: Windows 93/93 internal checks, SQLite/WAL 23/23 isolated checks, Windows publish and Mac source compilation. The consolidation commit 31c1c6d was pushed and local/remote main matched.

## Documentation cleanup

- All four READMEs share a centered 88px app icon and centered Codex Switch title, reusing macos/Assets/app-icon.png without generating another asset.
- Four-language quick-start pages now share one static, labeled fictional demo; installation and developer details have separate focused pages.
- The current demo shows everyday fictional usage: four different balances (62%, 86%, 37%, 14%), 5 running / 2 queued / 1 goal, and independently fluctuating resources (26%, 73%, 42%, 58%). The window's 8px rounded corners and thin gray edge are included in the PNG.
- Existing blue/yellow/red states distinguish normal usage, low quota/memory caution and low drive free space. Forecasts use the actual predictor with synthetic history. The illustration is separate from live workload/account-switch evidence.
- Replaced 18,183,140 bytes of GIF/poster media with one 73,560-byte PNG. Removed 1,516 obsolete local media/capture files totaling 212,937,189 bytes; recovery archives/receipts and one current live reference remain.
- Verified 22 Markdown documents and 78 local links, one 800×560 static PNG with only sRGB/gamma/DPI metadata, fictional identities and no live account/task inputs. Private verification/cleanup receipts stay ignored.
- No product behavior or real account/native Codex state is changed by this documentation work.

## Still separate

Native Mac login/switch/chat-resumption/Intel acceptance and credit-only forecasting remain in [BACKLOG.md](BACKLOG.md). Cloud sync is a proposal. The owner authorized the current Release refresh; Apple notarization remains unverified.
