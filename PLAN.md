# Codex Switch

## 2026-10-14 single canonical repository

- [x] Compare both repositories, transfer all latest 1.27.6 source/assets/docs and retain the Mac signing/installer improvements unique to codex-switch.
- [x] Preserve old Git refs/history, working state, private captures/tools and remote repository metadata inside ignored recovery storage.
- [x] Build Windows/Mac and pass 93 Windows internal checks plus 23 isolated queue/WAL checks from codex-switch.
- [x] Retire the previous local/GitHub repository and verify that only codex-switch is an active repository.
- [x] Update canonical-path guidance and record deletion evidence; commit/push the reviewed consolidation under explicit user approval.

The old local checkout is absent. GitHub reports successful deletion of Gaebabi/codex-account-desk and an authenticated API read confirms 404; Gaebabi/codex-switch remains private and available. Windows/Mac builds and 93 internal plus 23 queue/WAL checks passed. Current source files, full old Git state and private evidence are preserved in ignored recovery storage. The user explicitly approved the final deletion and commit/push. Native Mac execution, real account switching and public Release were not performed.

## 2026-10-14 clear session counter groups

- [x] Remove the titlebar account/usage breadcrumb and its obsolete compact-window visibility logic.
- [x] Keep each session label beside its value with 6px spacing and separate groups by 24px on Windows and Mac.
- [x] Build Windows/Mac, inspect compact/large live layouts, apply the Windows package and preserve account/native Codex state.

Completed: 1.27.6 is installed and running with the desktop shortcut updated. Live 500x360, 700x550 and 1000x700 captures confirm each label/value pair, centered grouping, no titlebar breadcrumb and four complete quota cards. Registrations/settings, authentication and existing native Codex processes were preserved. Mac compilation passed; native Mac execution, account actions, broad tests, commit/push/publication were not performed.

## 2026-10-14 immediate themed resource tooltips

- [x] Provide a Burn0 tooltip surface with readable resource/value hierarchy, immediate hover and a short eased entrance; respect reduced motion.
- [x] Keep hardware/drive hover targets and tooltip instances stable across background samples, with live values and screen-edge placement.
- [x] Build Windows/Mac, inspect tooltip appearance/timing/update/dismissal, apply the Windows package and preserve account/native Codex state.

Completed: Windows 1.27.5 is installed and running. Four KO/EN light/dark physical-hover cases confirm 0ms configured delay, in-screen placement, update retention and dismissal; isolated motion validation confirms opacity starts at0, interpolates, then settles at1. Drive cell/tip identity remains stable during explicit reading updates. Live CPU/VRAM/drive hovers were captured and hardware tooltips retained their identity across real samples. The longer drive observation ended when the user moved the pointer away, so that observation is not reported as an uninterrupted polling check. This Windows host disables client-area animation and therefore uses immediate display. Mac compilation passed; native Mac execution/account actions/broad test suite/commit/push/publication were not performed.

## 2026-10-14 website account and multi-computer sync feasibility review

- [x] Inspect existing identity, vault encryption, refresh and desktop-application boundaries without reading or transferring real credentials.
- [x] Verify current official OpenAI identity login, plan-usage OAuth, protected-session transfer and token-renewal documentation.
- [x] Record a proposed architecture, product scope, acceptance gates and unresolved native-desktop compatibility in OPERATIONS.md.

Review complete: metadata/settings sync is feasible; portable encrypted credential restoration is a conditional feature requiring device-key recovery and real multi-device renewal validation. Independent per-device authorization is the default recommendation. SIWC plan tokens and Codex-managed auth caches are separate integrations. No website/backend/credential-sync implementation, login, account switch, deployment or publication was performed.

## 2026-10-14 centered sessions and two-row resource footer

- [x] Remove the account-count text and center running/queue/goal counters above the account cards.
- [x] Put CPU/MEM/GPU/VRAM in one full-width footer row, with drives and existing footer controls in the second row; preserve gauges, history, warnings and asynchronous collection.
- [x] Compile Windows/Mac, apply the Windows package/shortcut, inspect the minimum and larger dashboard sizes, and preserve accounts/settings/native Codex.

Completed: Windows 1.27.4 is running from its versioned installation folder with the desktop shortcut updated. The counters use a compact single line centered above the cards; footer readings occupy two rows. Actual WPF captures at 500x360, 700x550 and 1000x700 confirm four visible cards, complete remaining-quota numbers and the resource layout. Registration/settings/authentication and existing Codex processes were preserved. Windows publish and Mac compilation pass; native Mac execution/account actions/test suites/commit/push/publication were not performed.

## 2026-10-14 dropdown panel consistency

- [x] Use a complete Burn0 popup surface, consistent row spacing, native checked/disabled states and separators for language, account, quota and refresh menus.
- [x] Anchor menus to their controls, reserve the same check column for every row, wrap long labels and close menus when their owner is removed. Preserve the framework's menu navigation and dismissal.
- [x] Compile both platforms, inspect Windows popup renders in both themes/languages, apply the complete Windows package and retain accounts/settings/native Codex.

Completed: Windows 1.27.2 is installed and responding. Four isolated native WPF popup renders cover KO/EN and light/dark, including selection, separator and disabled rows. The live language popup has two visible 32px rows and its surface right edge matches the button; focus dismissal was confirmed. Mac compilation passed, with native Mac execution and account actions untested. No commit/push/publication.

## 2026-10-14 white icon and compact titlebar actions

- [x] Fill the packaged cloud icon white behind its existing black outline and face, retaining transparency outside the silhouette and independent renders for every Windows/Mac size.
- [x] Move account addition and manual refresh into compact, accessible icon buttons on the right of both titlebars. Preserve async refresh and secondary current-login import.
- [x] Build and apply the Windows package and desktop shortcut using the existing data/home paths. Inspect the native icon and smallest supported layout; keep native Codex and account identity intact.

Completed: Windows 1.27.1 is installed and running. The white body/black face and a live 500x360 dashboard with both titlebar actions and four visible cards were inspected. Windows publish and Mac source compilation succeeded. Native Mac execution and account login/switch testing were not performed; no commit/push or external publication.

## 2026-10-14 Windows personal installation update

- Publish the current Windows self-contained source without running the test suite, preserve the old package, and copy the full new package to a versioned per-user installation directory.
- Gracefully stop only the running utility through its compatible IPC, preserve its actual data/home paths, back up the encrypted vault, and start the new utility independently of the build shell.
- Add the Codex Switch desktop shortcut with explicit data/home arguments, working directory and the embedded application icon.

Completed: Windows 1.27.0 from source 89682f2 is running from the per-user Programs/CodexSwitch/1.27.0 folder. Shortcut target/arguments/icon and real window/title/liveness were confirmed. Four registrations and the existing light/English preferences remain intact; authentication and native Codex processes are unchanged. No account switching, test suite, commit/push or external publication was performed.

## 2026-10-13 publication cancelled, personal use retained

- User cancelled open-source/public Release and signing/notarization work. Keep the accepted crisp `>_<` icon and local personal application/source/accounts.
- The GitHub delete request for `Gaebabi/codex-switch` returned403: the current token has repository admin but no delete_repo scope. Changed the repository to private and verified anonymous repository/ReleaseHTTP404 instead. Full deletion still needs the owner's GitHub session or explicitly authorized deletion credentials.
- Existing private `Gaebabi/codex-account-desk` and its remote are preserved. Local personal source has all icon geometry/ICO/Mac assets. Removed the former public checkout's origin link; no filesystem/history/account deletion and no additional backup commit or private push was performed.

## 2026-10-13 release downloads and capture/icon quality

- [x] Preserve the accepted cloud `>_<` silhouette in a shared vector path, render titlebar/menu glyphs as geometry and package ten native ICO sizes plus 1024px Mac artwork.
- [x] Record actual WPF visuals at 2x lossless PNG with no external cursor; verify 270 redacted GIF frames. GitHub's rendered compact GIF is 1000x720, displayed500x360, with zero horizontal center difference.
- [x] Build/verify complete Windows/Mac arm64/x64 packages, 93 Windows and23 SQLite checks, ZIP private-file/0755/runtime checks, uploaded digests; public v1.27.0 and all4anonymous downloads haveHTTP200/exactSHA256matches.
- [x] Source/history scan:113 tracked files/141 reachable blobs, zero sensitive findings. Original native Codex processes and authentication hash preserved. Native Mac and real account-switch acceptance remain separate.

## 2026-10-13 open-source publication: Codex Switch 1.26

- [x] Keep the private repository/history; publish a separately initialized `Gaebabi/codex-switch` after source/media inspection, with a public noreply commit identity.
- [x] English default for new/missing-language settings; preserve stored preferences. Rename display titles, executable/app bundle and packaging references while preserving vault/Keychain/IPC identity.
- [x] English-first README plus KO/JA/ZH-CN explanations, MIT/license attribution, contribution/security/switching/Mac/Reddit documentation.
- [x] Generate the supplied silhouette with a `>_<` face and apply to Windows/Mac app identity.
- [x] Record the user's actual live utility at three native sizes, erase all name/alias pixels before generic blur, inspect all 108 sanitized GIF frames and commit no raw captures.
- [x] Verify Windows 93 isolated checks, SQLite/WAL 23 checks and both Mac cross-publishes; distinguish actual Windows footage from account-switch and native Mac acceptance.
- [x] Export only the reviewed 107 source/docs/assets into clean public Git history; source/history/media scan finds no sensitive matches. Public commit 4ae7e206d054f418ff95b00bfe3ebc898a31519a is pushed, remote SHA/visibility and anonymous README/GIF bytes match. Reddit text is prepared without posting it.

1. Verify the installed Codex protocol and read current usage without changing its login. Done.
2. Build a Windows tray application: account import, browser sign-in, real usage, manual and timed refresh.
3. Store account credentials with Windows DPAPI and use isolated Codex homes for inactive accounts.
4. Queue account switching until every desktop process exits; save the previous login, atomically install the selected login, and reopen the installed desktop app.
5. Verify account isolation, encryption, missing-data handling, cancellation, concurrent-login protection, live read-only usage, and the rendered window. Publish a complete Windows package.

The running desktop app is not stopped by development or validation. A real second-account sign-in and desktop transition require the user's accounts and remain distinct from local switch tests.

## 1.1 follow-up

1. Reuse Burn0's current design-system tokens and title-bar geometry, including light/dark palettes and native resize/drag controls.
2. Display time to reset as days, hours, and minutes; update the display locally without waiting for the usage polling interval.
3. Replace the global UI/network lock with per-account refresh coordination, independent browser login, and short credential-write transactions. Keep other controls usable.
4. Refresh the newly registered account immediately, superseding any query using its previous login. Reject stale results after reauthentication or removal.
5. Verify countdown boundaries, concurrent refreshes, single-flight deduplication, supersession, independent login controls, fresh-login immediate scheduling, actual usage, and the rendered title bar. Publish and reopen the updated utility while preserving registered accounts.

## 1.2 localization

- Add embedded Korean/English catalogs and a persistent language choice accessible from the caption and tray.
- Apply changes immediately to controls, menus, countdowns, dialogs, and existing error messages while keeping account names and API data intact.
- Verify catalog completeness, formatting, preference persistence, live language switching, and English/Korean renders before publishing and reopening the utility.

Completion evidence: all three localization items are complete; 29 checks pass, a separate process restores English without a language override, and the reopened utility preserves the user's four accounts.

## 1.3 usage history and forecast

1. Persist actual per-account, per-bucket, per-window observations in the encrypted vault. Retain 30 days with bounded time resolution; seed only the last known real observation from older versions.
2. Derive a forecast from the latest continuous quota cycle, using at most two hours of recent observations. Require five minutes of observations and a measurable increase; stop estimating when data is stale, reset, or reduced.
3. Add localized history ranges, a measured-use graph with hover values, prominent depletion/reset times, and an event timeline showing which happens first. Preserve Burn0 themes and asynchronous controls.
4. Verify retention, identity isolation, resets, zero-growth, stale data, forecasting arithmetic, both-language/theme renders, and actual usage recording. Publish/reopen 1.3 while preserving the user's accounts.

Acceptance: projected values are labeled as estimates conditional on continued recent usage. Missing history is shown as collecting; historic use is never reconstructed or invented.

Completion evidence: all four items are complete. Forty checks pass; twelve illustrative forecast screens plus actual account screens were rendered. Consecutive real observations persist, and the reopened utility preserves the user's four accounts.

## 1.4 compact tank dashboard

- Replace the tall quota/graph stacks with responsive account tiles. The complete tile is a reservoir: its fill height equals the remaining quota, with a large percentage in the middle.
- Show the limiting quota by default and expose other quota windows as selectable values. Keep account switch/refresh actions visible; compress depletion and reset into two readable rows.
- Open measured graphs, forecasting basis, credits, and reset credits in a modeless detail window. It updates from the same service and does not block other account controls.
- Remove the repeated page heading, always-visible history toolbar, and persistent static footer. Reuse Burn0 tokens/titlebar, preserve history, settings, and asynchronous behavior.
- Verify empty/full/low/unavailable levels, both languages/themes, a four-account dashboard, a narrow layout, real usage, and detail-window behavior. Publish/reopen 1.4 without modifying the Codex desktop login.

Completion evidence: all five items are complete. Forty-one checks pass; eight illustrative tank renders plus real four-account/narrow/detail screens were reviewed. Actual detail-button activation leaves the main window and refresh controls enabled. The updated utility was reopened with the existing vault.

## 1.5 fit all accounts in small windows

- Replace width-only wrapping and fixed tile heights with a bounded grid that allocates both viewport dimensions. Four accounts keep a 2x2 arrangement at 600x400 and 500x360.
- Reflow small cards: preserve names and large percentages, move actions to the bottom, size typography from available space, and retain detail access.
- Reduce compact toolbar/footer overhead without disabling asynchronous actions. Preserve water levels, credentials, history, language/theme, and forecast services.
- Validate actual four-account bounds and action visibility at small, minimum, and large window sizes in both languages/themes, then publish/reopen 1.5.

Completion evidence: all four items are complete. Forty-one checks pass. Real four-account captures prove 2x2 layout with all cards/numbers/actions inside the viewport at 500x360, 600x400, and 820x700; the updated utility was reopened at 600x400.

## 1.6 short copy and no refresh buttons

- Remove manual refresh buttons from the dashboard, cards, and detail window; retain automatic refresh, login-triggered reads, F5, and the tray command.
- Replace repeated calendar/date/countdown sentences with aligned short labels and bold remaining durations. Keep exact timestamps and forecast basis in tooltips/detail.
- Verify both languages/themes and minimum-size four-account bounds, then publish/reopen 1.6 with existing accounts/history/settings.

Completion evidence: all three items are complete. Forty-one checks pass; real small-window renders and geometric bounds pass, and the visual tree contains zero refresh buttons. The updated utility was reopened.

## 1.7 clean gauge and focused trend view

- Remove the gauge's bright waterline stroke; keep the actual remaining fill.
- Focus the trend view on three large values: remaining percent, estimated depletion duration, and reset duration. Use one selected quota and one measured chart; move incidental metadata into a collapsed section.
- Keep exact dates, forecasting assumptions, all quota windows, range controls, and asynchronous updates accessible. Verify live main/detail renders and small dashboards, then publish/reopen 1.7.

Completion evidence: all three items are complete. Forty-one checks pass; actual main/detail screens and small-dashboard bounds pass, twelve illustrative forecast states were rendered, and the updated utility was reopened.

## 1.8 rounded window corners

- Apply one shared frame policy to the dashboard, trend window, confirmation dialogs, and name editor. On Windows 11, remove the custom-region cause and enable native DWM rounding without a painted border; earlier Windows use WindowChrome rounding.
- Keep native resize/caption behavior and let Windows handle maximized/snapped window geometry.
- Publish the Windows package, inspect real HWND rounding attributes and region state, check the existing compact layouts, and reopen with saved accounts/history/settings.

Completion evidence: all three items are complete. Native main/detail rounding attributes and absence of custom regions are verified; the running main window's composed screenshot was inspected. Build and 41 checks pass, compact layouts pass, and 1.8 was reopened with the four saved registrations and settings.

## 1.8.1 style sealing error

- Reproduce the reported SetterBaseCollection exception through language menu selection and theme controls.
- Finish styles before placing them in live resources. Preserve the rounded frame and compact UI.
- Check repeated appearance changes, menu styles, compact layout, and existing account/history/settings preservation, then package/reopen the fixed utility.

Completion evidence: the old build reproduces the exact error through the language menu. Completing styles before resource publication fixes it; all 12 appearance changes and 41 existing checks pass. Compact bounds and rounding pass. The fixed utility was reopened and its screen/registrations/history/settings were verified.

## 1.9 visible plan and reset credits

- Keep plan names and each account's reset-credit count visible on every dashboard card, including the minimum supported window. Distinguish zero credits from unavailable data.
- Reuse the existing two summary rows so remaining percentages and controls keep their space. Translate concise labels in both languages.
- Verify live/synthetic zero, positive, and unknown counts, compact geometry, appearance switches, then package/reopen while preserving the saved accounts/history/settings.

Completion evidence: all three items are complete. Live labels match Pro/Pro Lite and 1/2/0/0 reset credits; metadata and other card content fit at every supported test size. Eight illustrative renders, 41 existing checks, and 12 appearance changes pass. Version 1.9 was reopened and registrations/history/settings were preserved.

## 1.10 subscription period end date

- Derive the subscription period end and source-check time from the account's ID-token subscription claims, including older saved accounts and refreshed sign-in data. Do not substitute JWT expiration or assume an actual scheduled payment date.
- Show the period end next to the plan, with the full year/KST time and source in tooltips/detail. Preserve compact card height and distinguish missing dates.
- Verify claim parsing/reload/update behavior, live date labels, minimum-size bounds, languages/themes, and saved account state; package/reopen the updated utility.

Date parsing, saved-account hydration, and all four live dates pass (43 checks). Final packaging incorporates the subsequent countdown and button-position requests in version 1.11.

## 1.11 countdown and card actions

- Show the subscription end date and D-day count together, updating by the Korean calendar day. Use Today for the end day, D+ for elapsed dates, and no invented count for missing information.
- Keep switch/more actions in the card's upper right at every size. Use the vacated lower-left area for the date and countdown; keep history at the lower right.
- Verify top-action geometry, all small-card information and controls, calendar-boundary behavior, appearance switches, then package/reopen with saved state.

Completion evidence: all items, including the subscription-date work above, are complete in 1.11. Forty-four checks and 12 appearance changes pass. Real four-account labels/countdowns and upper-right actions fit all three sizes in both languages. The composed running screen and preserved registrations/history/settings were verified.

## 1.12 stable trend prediction and active water motion

- Replace the wall-time endpoint slope with fully observed 10-minute growth blocks within the current reset segment and last 24 hours. Learn a bounded, smoothed rate; zero-growth pauses do not reduce it. Forecast conditional continuous-use time from measured remaining quota.
- Cache the learned model per rendered snapshot. Validate paused/switched intervals, outliers, persistent rate changes, gaps, resets, and incomplete/quantized observations with replay tests.
- Animate only the account marked In use, gently, without a waterline stroke. Keep other surfaces horizontal and detach render callbacks on unload/hide/minimize.
- Verify real motion and static cards, both-language compact layouts, preserved state, then package/reopen with a documented formula.

Completion evidence: all four items are complete. Fixed a live-data root cause where ±1-second reset-deadline corrections created false segments. Fifty-one checks pass; actual current-account frames advance while inactive cards have zero frames, and hide/minimize/restore behavior passes. Six compact-layout cases and appearance changes pass. Version 1.12 was reopened with saved state and the formula is included in the package.

## 1.13 live desktop session count

- Observe the running desktop's local IPC state without starting, interrupting, or owning a turn. Discover local thread IDs and subscribe as an observer; retain only status, parent, revision, and owner metadata.
- Count root chats with active runtime status, separating approval/user-input waits. Display a concise Korean/English total above the cards, independent of usage-refresh timing and button availability.
- Distinguish connection failure or incomplete observations from a verified zero. Reconnect and rediscover after desktop/owner changes; invalidate patch gaps and unsupported protocol versions.
- Validate status reduction, duplicate snapshots, child exclusion, waits, missing snapshots, revision gaps, disconnects, and real read-only desktop counts. Build and deliver the full Windows folder; preserve native Codex and account state.

Completion evidence: 58 checks pass. The actual observer and desktop listing both show 6 running among 11 root chats. Actual labels and all four cards fit the six size/language combinations; 12 appearance changes pass. Native authentication and desktop execution remain intact. Account attribution and remote/cloud/standalone CLI counts are outside the available observation scope.

## 1.14 system resource monitoring

- Add compact CPU/MEM/GPU/VRAM percentages within the existing toolbar height; preserve four-card visibility at 500x360 and both languages/themes.
- Sample Windows native CPU/GPU counters and physical RAM every two seconds in one background task. Use DXGI adapter capacities and adapter-wide dedicated-memory counters; avoid external processes, per-process VRAM summation, and engine averaging.
- Show the busiest GPU engine and highest dedicated-memory pressure across adapters, with device/byte details in tooltips. Unknown/unsupported data remains unavailable rather than zero.
- Use Burn0 warning/danger colors at 80/95 percent, with five-point release hysteresis. Verify aggregation, capacity matching, warning transitions, actual hardware readings, sampling overhead, and compact rendered controls before folder packaging.

Completion evidence: 64 checks pass. Actual CPU/RAM/GPU/dedicated VRAM values and DXGI capacity matching are confirmed; OS CIM reads independently expose the same memory capacity and adapter-wide allocation source. The isolated observer averages 3.21ms per warm sample and 0.16% system CPU in an 18-second run. Actual amber warning, six size/language layouts with no toolbar overlap and all four cards, 12 appearance changes, and both-theme synthetic critical/unknown/zero renders pass. Account authentication and native Codex remain unchanged.

## 1.15 resource gauges and earlier warnings

- Fill each resource cell horizontally in proportion to measured usage, behind the label and number. Use flat, borderless Burn0 blue/amber/red surfaces within the existing toolbar geometry. Unknown has no fill; zero is empty and 100 is full.
- Move warning/critical entry to 70/85 percent, retaining five-point release hysteresis (below 65/80). Use shared constants in the status algorithm and both-language tooltips.
- Verify threshold transitions, actual gauge widths and all four cards in the six size/language layouts, 12 appearance changes, both-theme warning/unknown/zero/full renders, then folder-package and reopen the updated utility.

Completion evidence: 64 checks pass with the earlier thresholds. Actual usage drives all four fill widths; the six size/language layouts retain all four cards and fitting resource labels, and 12 appearance changes pass. Light/dark 70/85 boundary, unavailable, empty, and full examples were rendered and inspected separately from actual readings. Authentication and native Codex remain intact.

## 1.16 collected resource trends

- Replace each instantaneous background gauge with a thin line and translucent area representing actual recent samples. Preserve the current cell dimensions, labels/numbers, Burn0 colors, 70/85 warnings, and toolbar/card layout.
- Retain at most two minutes/61 observations in the existing background collector. UI/theme refreshes do not create observations. Keep fixed 0–100 vertical scaling, show a single initial point, break missing/long-gap intervals, and reset the timeline on clock rollback.
- Validate retention/deduplication/gaps/rollback, actual multi-sample graphs and compact label bounds, both-theme reference-like rise/unknown/idle/full examples, then package and reopen the utility.

Completion evidence: 67 checks pass. Actual collected history drives all four graphs, and the six size/language layouts preserve labels and all account cards. Twelve appearance changes pass without adding observations. Both-theme synthetic rising/unknown/idle/full examples and the actual minimum-size Korean screen were inspected. Native authentication and Codex execution remain intact.

## 1.17 configurable drive capacity

- Add C:/D: remaining GiB and free-space fill in the existing footer without adding a dashboard row. Query local fixed/removable volumes asynchronously every 15 seconds; missing volumes remain unavailable.
- Provide a themed drive-settings dialog with visibility selection, custom labels, and ordering. Persist selections in the existing encrypted vault, retain defaults for old vaults, and immediately resample after changes.
- Verify encrypted settings reload/disabled selections, real drive readings, minimum-size layouts, settings-dialog rendering, and preserve the hardware history implementation from 1.16 before packaging/reopening.

Completion evidence: 68 checks pass. Native C/D free-space readings agree with independent Windows logical-disk readings at their observation times. The settings dialog and actual 500x360 Korean layout were inspected; all six size/language layouts retain drives, resource plots, and four account cards, and 12 appearance changes pass. Encrypted custom label/order and empty-selection reload are verified. Native authentication and Codex remain preserved.

## 1.18 account menu, alignment, and credits

- Move History into the existing upper-right account menu and verify the actual menu-to-detail interaction. Use the vacated lower-right space for the selected quota bucket's reported credit balance.
- Preserve zero/unlimited/missing states and exact balance tooltips; compact large values without inventing currency. Align top actions and footer baselines and keep depletion/reset labels at minimum card size.
- Validate credit formatting, menu access, actual values, all six size/language layouts, both-theme synthetic credit cases, and appearance switching before packaging/reopening.

Completion evidence: 69 checks pass. The actual more-menu History item opens the detail window, and real reported credits appear in all four cards, including zero balances. All six size/language layouts fit metadata/credits/numbers and retain all four cards; 12 appearance inputs pass. The actual 500x360 screen and synthetic finite/zero/unlimited/large credit cases were inspected. Native authentication and Codex remain preserved.

## 1.19 thin native window edge

- Replace the suppressed DWM outer border with a subtle gray native edge. Preserve native rounded corners, shadow, resize behavior, and inner layouts.
- Update edge colors for light/dark theme and active/inactive state on main/detail/settings/dialog windows through the shared frame helper.
- Verify the actual native border color/thickness and corner attributes in both themes and after appearance changes, then package and reopen the utility.

Completion evidence: 69 checks and 12 appearance actions pass. Native getters report a 1px visible edge, rounded-corner preference 2, and no custom region on main/detail windows; successful setter state records light/dark edge colors. Corrected the diagnostic's unsupported BORDER_COLOR getter at its root. Six compact layouts, authentication, and native Codex remain preserved.

## 1.20 running, queued, and goal totals

- Extend the observer with active goal status and the desktop's persisted local follow-up queue. Count pending messages independently from approval/input waits; expose paused queue/goal states in tooltips.
- Show three compact values in the existing session area, using spacing with no middle-dot separators. Preserve all four cards and hardware plots at minimum size in both languages.
- Verify snapshots/patches, goal transitions, queue removal/deduplication/host filtering, unavailable versus zero, actual read-only observations, and compact rendering before packaging/reopening. Never start or alter a Codex task for verification.

Completion evidence: all 76 checks pass. Live observation reports independent running, saved queue, and goal totals; the saved paused queue matches its source. Six size/language layouts fit the three-column header, all four cards, and hardware plots. Unknown/zero/99 illustrative geometry and 12 appearance actions pass. Native authentication remains unchanged and Codex stays running. Queue/goal transitions are covered by local replay tests; no real task was created or altered for validation.

## 1.21 date backup and resume during account switching

- On a user-triggered switch, capture the local running root chats, stamp/update their leading [yyMMdd] name, and show Backup while every name is confirmed saved. Keep the same thread IDs and persist the transition in the encrypted vault.
- After backup, request graceful desktop shutdown, apply the selected credentials only after complete exit, reopen the desktop, and reopen the captured chats with their existing settings.
- Observe each reopened chat: leave already active or completed work alone, and send one Continue only when continuation is needed. Persist submission progress, distinguish unconfirmed delivery, and never repeat an ambiguous send automatically.
- Keep unrelated controls asynchronous, retain partial progress on failure/restart, and provide retry/resume access. Verify date-prefix cases, ordered transitions, cancellation/failures/recovery, native protocol shapes in an isolated disposable home, and the busy-button compact renders. Do not terminate, rename, switch, or resume real Codex chats for validation.

Implementation evidence: 87 checks pass. Isolated two-process loaded-thread name persistence and reopen identity/name/cwd pass without inference. The installed desktop's read-only owner RPC verifies the wire response shape. Six normal layouts, six minimum-size KO/EN busy layouts, and 12 appearance actions pass with other controls enabled. Native authentication and running work remain untouched by validation. The user's separate direct account-switch request is an operational action, recorded privately through last-switch.json, not a validation fixture.

## 1.22 complete local queue counts

- Read committed server queue rows from queue_1.sqlite through Windows SQLite in read-only mode, including WAL updates. Restrict server rows to local desktop root chats using state_5.sqlite metadata; never read message content or start a second app-server.
- Merge saved and server queue identities per thread, deduplicating server submission IDs and client message IDs across the two sources. Keep owner broadcasts until the saved file catches up, including empty removal broadcasts and polls already in flight.
- Wake the background observer on queue file changes while retaining a two-second rescan. Preserve unknown/error states, disconnect reset, child exclusion, and the existing compact UI.
- Verify merge/removal/race regressions, independent SQLite WAL fixtures, actual read-only counts, build the complete Windows folder and replace only the running utility. Preserve native Codex work and authentication.

Validation evidence: 92 internal checks and 23 independent SQLite/WAL checks pass. Actual observer and storage counts agree, native owner settings RPC passes, source authentication and native Codex processes are preserved. Positive queue changes are isolated fixture evidence. Delivery and utility replacement are recorded in STATUS.

## 1.23 macOS support

- Preserve the Windows WPF project and share account/RPC/history/prediction/switch/session/queue logic with a dedicated Avalonia macOS project.
- Port storage to owner-only POSIX files and Keychain-backed AES-GCM; discover native .app/CLI paths, use Unix IPC, system SQLite, graceful native quit and exact-bundle relaunch.
- Provide the Burn0 compact water cards, asynchronous account operations, Korean/English preferences, history, session totals, system resource trends and configurable mounted-volume capacity on macOS.
- Package Apple Silicon and Intel .app bundles with local build/install instructions. Compile only; do not run tests, logins, switching, app launches or hardware/session probes. Runtime testing is delegated to the user by explicit request.
- Record unsupported driver metrics as unknown, document platform requirements and acceptance items, then commit and push the requested source changes.

## 1.24 MacBook polish and native validation

- Follow the new request to polish, validate, commit and push from `/Users/cni/Desktop/Git/codex-account-desk`. The earlier compile-only restriction describes the 1.23 task.
- Preserve readable card sizes with scrolling for additional accounts, add Cmd+R/F5 refresh and Cmd+W hide, native menus and initialization retry, and show stale/error status without changing observed usage.
- Stage and verify installation before replacing the existing app; keep a recoverable backup and refuse replacement while Account Desk is running.
- Validate disposable Keychain/POSIX/socket fixtures, native resources and mounted volumes, independent SQLite/WAL checks and synthetic native KO/EN/light/dark renders. Do not close/switch the real Codex desktop or modify its chats for validation.
- Build both macOS architectures, document the tested boundaries and deliver the MacBook installation, then commit and push only source/documentation changes.

Completion evidence: 11 native checks, 23 SQLite/WAL checks, 15 native render/scroll cases and 7 ZIP/install checks pass. Both Mac bundles pass strict signature/architecture checks, and Windows cross-target compilation has zero warnings/errors. The actual startup menu crash and incomplete nested signing were fixed at their cause. The corrected app is installed; the user's existing Keychain authorization and real account/Intel acceptance remain distinct from disposable tests.

## macOS title bar drag follow-up

- Connect the custom caption and empty title bar area to native BeginMoveDrag on left pointer press; keep native traffic lights and caption buttons outside the drag region.
- Build and verify actual pointer dragging and button clicks in an account-free native window, record observed PositionChanged coordinates, update the installed app and commit/push within the existing authorization.
- Apply centered horizontal/vertical content alignment to the shared button style. Replace font-based more/refresh/reorder glyphs with uniformly sized vector icons and localized accessibility labels.

Validation: actual native window position changed from (564,365) to (876,219), while language/theme button clicks preserved the initial position. All 15 KO/EN/light/dark/size/account-count render cases pass, including geometric centering of every visible button's text/icon in the layout matrix. Both Mac architectures publish with strict signature validation.

## Mac disk and process cleanup

- Survey all local Git repositories and preserve dirty source, credentials and deployed/current packages while consolidating completed work into main/master.
- Remove completed worktrees, merged local branches, prunable registrations, rebuildable compiler caches, stale build ZIP/IPA exports and raw diagnostic capture intermediates.
- Close the user-selected Simulator, Roblox and Account Desk plus the completed capture helper; keep the active Codex/browser and configured release services.
- Verify actual free disk space, source status, branch ancestry and stopped processes. Save the detailed cleanup ledger outside repositories at `~/Desktop/mac-cleanup-2026-10-12`.

## 1.25 macOS menu bar and maintenance publication

- Add a monochrome template account symbol and native percentage text to a variable-width macOS menu bar item. Follow the current account card's selected quota, preserve missing/zero/full values, and keep open/refresh/quit actions available when the window is hidden.
- Verify native template/title/action persistence through view and language rebuilds, then install and reopen the Apple Silicon app without modifying Codex or the account vault.
- Commit and push the user's requested merges and cleanup records to seven distinct remotes. Preserve the independent MTD diagnostic changes, ReLayer's two source modifications and unrelated shared-context/PDF changes. Integrate current remote history before publication and remove the temporary integration checkout afterward.
