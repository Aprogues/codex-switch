# How account switching works

1. Register an account with browser sign-in, or import the current Codex login using the account icon next to **Add account**.
2. Compare each account's reported remaining quota, reset deadline and plan. The active account is labeled **In use**.
3. Select **Switch** on another account. The utility first saves the active local root-chat names with a `[yyMMdd]` suffix based on the Korean calendar, replacing an earlier suffix.
4. After verifying the saved names, it requests a normal shutdown of the installed Codex desktop. A failed shutdown stops the account change. If Codex refuses the normal request, exit Codex through its own menu and retry.
5. Once all desktop processes have exited, it backs up the previous login, atomically applies the selected account and reopens Codex.
6. It reopens the same chat IDs with their existing folders, models and permissions. Already running or finished work is left alone; eligible idle continuations receive one **Continue**. Unclear send outcomes are not automatically repeated.

Progress is checkpointed in the encrypted vault. A pending handoff can be continued from the selected account's **Resume chats** action. Cancellation is available from the account menu and tray. No new chat is created to stand in for an existing chat.

This affects the shared Codex login: separate CLI/IDE tools using that same home can see the new account. Local desktop activity counts are machine-wide, not attributed to individual accounts. Remote/cloud work and separate CLI turns are outside those counts.

Local tests check encryption, identity isolation and the switching state machine. Public GIFs show the live account dashboard, refresh and responsive layout; they do not demonstrate a real account switch or prove successful chat resumption. A real end-to-end switch needs the user's accounts and intentionally restarts Codex.
