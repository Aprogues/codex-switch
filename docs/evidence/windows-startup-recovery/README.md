# Windows initialization recovery

Release issue78: an initial client/login failure leaves `_ready` false. The former Windows manual refresh, tray refresh and timer all require `_ready`, so none can retry after Codex becomes available. Account actions correctly remain unavailable, but refresh must be able to retry initialization.

## Actual baseline

![Actual Windows WPF window after initial client-path failure; refresh remains disabled](before.png)

The actual1.40.1 WPF window uses an owned absent client path and empty disposable storage. No real account, login, client process or personal desktop is involved. The native own-HWND screenshot retains the real titlebar. The regression invokes the production initializer, actual refresh button and DispatcherTimer; it does not set `_ready` or replace service results. The baseline fails at “refresh remains reachable after initialization failure”. Post-fix manual/timer confirmation is pending.

Run on Windows with the normal CLI prerequisite available:

```text
dotnet run --project tests/windows-startup/CodexSwitch.WindowsStartup.Tests.csproj -c Release -p:UseSharedCompilation=false -- artifacts/startup-recovery/new-run
```

The later-available placeholder is discovered but never executed. Empty account storage avoids authentication/RPC/network. This proves UI initialization recovery only, not real account/client handoff. [Sanitized baseline source/image receipt](baseline.json).
