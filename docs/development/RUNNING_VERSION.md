# Running Windows version

Issue [105](https://github.com/Gaebabi/codex-switch/issues/105) adds a small muted version beside **Codex Switch** in the Windows titlebar. It reads `typeof(MainWindow).Assembly.GetName().Version` from the running application assembly, with three version components. It never reads the on-disk replacement, a network release or account data. App identity, window title, IPC names and storage remain unchanged.

Closing the window to the tray does not terminate its process. Newly installed files take effect after **Exit** from the tray and a normal launch. The caption identifies the process currently in use; it is not an updater or a latest-version claim.

The existing native `--verify-ui` host checks the loaded version, visible caption bounds and separation from titlebar actions in English/Korean, dark/light and 500x360/800x560. It captures only its own app windows with four fictional accounts on a disposable hosted Windows runner. `scripts/verify-ui-evidence.py` requires and exports all eight caption checks. Do not run the visible capture on the owner's desktop.

## Evidence

The [existing v1.41.1 Windows screen](../media/release-1.41.1/windows.png) is the real app baseline without a version label. Native post-implementation pictures and exact-source receipts are pending. This work does not publish a new binary Release, replace an installation or restart the owner's app/Codex.
