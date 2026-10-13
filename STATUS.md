# Delivery state

## 2026-10-14 clear session counter groups (1.27.6)

- Removed the Windows titlebar account/usage breadcrumb and its compact-window visibility branch.
- Replaced independently aligned labels/numbers with content-sized pairs: 6px inside each pair, 24px between pairs. Windows/Mac keep the complete row centered without changing its height or the card/resource layout.
- Windows publish and Mac compilation passed. Live Windows captures at 500x360, 700x550 and 1000x700 confirm the three distinct pairs, removed breadcrumb and all four card quotas. Captures remain ignored/private.
- Windows 1.27.6 and the existing desktop shortcut are applied; registrations/settings, authentication and existing Codex processes were preserved. Mac native execution, account actions, broad tests, commit/push and external publication were not performed.

## 2026-10-14 immediate resource tooltips (1.27.5)

- Added a complete Burn0 WPF tooltip surface and corresponding Mac tooltip theme: rounded elevation, subtle shadow, wrapped text and larger resource/value headings. Hardware and drive hovers have0ms configured delay and a120ms eased entrance when system motion is enabled; reduced-motion settings display immediately.
- Resource tooltip objects and their controls are reused during refresh. Windows drives and Mac hardware/volumes now update existing cells instead of clearing their hover targets on every sample. Resource descriptions use line breaks instead of middle-dot separators, and threshold/quantity strings are localized.
- Windows publish and Mac compilation passed. Four isolated KO/EN light/dark physical-hover cases confirmed screen fit, dismissal and stable instance/content update. The same surface's animation was separately exercised with motion enabled: opacity0 at start, intermediate opacity during the interval and1 at completion. Explicit drive updates preserve cell/tooltip references.
- Live installed CPU, VRAM and drive tooltips were captured. Hardware tooltip identity survives real2-second samples and CPU content changes in place. A longer drive observation had the pointer moved away by the user and is not proof of continuous hover across its15-second poll. This host has Windows client-area animations disabled; its live behavior is immediate appearance without motion. Captures/reports are ignored/private.
- Full Windows 1.27.5 package/shortcut applied; encrypted registrations/settings, authentication and existing Codex processes preserved. Mac native execution, account switching, broad test suite, commit/push and external publication were not performed.

## 2026-10-14 website account / multi-computer sync review

- Reviewed the current source and live official OpenAI documentation. AccountVault contains complete authentication caches as well as local settings/switch checkpoints. Windows DPAPI and the Mac local Keychain/AES-GCM format are local protection layers, not a portable cloud format. RefreshCoordinator/CredentialRevision serialize one utility instance, while native Codex renews credentials separately.
- Website login and registration/settings/snapshot sync are feasible. Full credential restoration requires a separate encrypted export/import layer and approved-device key provisioning; service login alone grants neither other OpenAI accounts nor the end-to-end vault key. Browser UI also needs an installed desktop agent for native account application.
- The main unresolved issue is concurrent token renewal across devices and the native desktop. Recommend separate per-device authorizations, treating shared-session import as a separately validated transfer feature. Current SIWC docs describe multiple registrations/hosts, with plan inference through Responses/app-server; that does not establish native desktop auth-cache or quota compatibility.
- Detailed proposed scope, security boundaries, source links and PoC gates are recorded in OPERATIONS.md. The installed 1.27.4 utility was not changed/restarted. No real credential access/upload, website/backend implementation, live account tests, commit/push, deployment or public release.

## 2026-10-14 centered sessions and resource footer (1.27.4)

- Removed the account-count/refresh-count text. Running, queue and goal counters are centered in one compact row above the account cards, with larger values and existing status tooltips.
- CPU, MEM, GPU and VRAM gauges/collection graphs form the first full-width footer row. Custom drive gauges and the existing footer controls form the second row. Warning colors, history and background collection are unchanged. Mac has the corresponding centered counters and resource footer.
- Reduced header/outer spacing to retain readable card quotas at 500x360. Actual live WPF captures at 500x360, 700x550 and 1000x700 confirm all four cards and complete quota numbers, with centered counters and two resource rows. The intermediate layout that clipped a quota at minimum size was replaced before completion. Captures remain ignored/private.
- Windows publish and Mac source compilation passed. The full Windows 1.27.4 package and desktop shortcut are applied, with registrations/settings/authentication and existing Codex processes preserved. Previous packages and encrypted backups remain. Native Mac execution, account actions, a broad test suite, commit/push and external publication were not performed.

## 2026-10-14 dropdown panels (1.27.2)

- Shared `DropdownTheme` now owns the complete WPF menu surface and rows: Burn0 elevation, 12px panel corners, subtle theme-dependent shadow, fixed check column, 32px minimum rows, wrapped labels, selected/hover/disabled states and themed separators. Language selection uses native checked state instead of space-padded text.
- Language, refresh-import, account and quota menus use the same owner-anchored placement with screen-edge fallback and close when their owner is unloaded. Menu styles live in each popup's resources so the detached visual remains consistent with its supplied theme. Mac account/quota/settings menus share corresponding explicit styling and checked quota state.
- Windows publish and Mac compilation passed. Four KO/EN light/dark isolated WPF captures were inspected, as was the live language popup: two visible/enabled 32px rows and its surface aligned to the button's right edge. Focus dismissal was confirmed. Captures are private ignored artifacts; Mac native execution/account actions and a broad test suite were not run.
- The full Windows 1.27.2 package is running from its new per-user version folder. Shortcut and white icon were updated; encrypted registrations/settings, authentication and native Codex processes were preserved. Previous packages/backups remain. No commit, push or external publication.

## 2026-10-14 white icon and compact titlebar actions (1.27.1)

- Packaged Windows/Mac icons now draw the white cloud body beneath the accepted black outline and `>_<` face. Outside transparency and every native ICO size are retained; the original monochrome mark and theme-aware in-app/template glyphs are unchanged.
- Account addition and manual refresh are icon-only actions on the right of both titlebars, with localized tooltips and accessible names. Windows current-login import is available through the refresh button's context menu. The body toolbar now contains resource/session information; refresh remains asynchronous and does not disable other actions.
- Windows publish and Mac source compilation succeeded. The full Windows package is installed in `%LOCALAPPDATA%/Programs/CodexSwitch/1.27.1`, the desktop shortcut points to it and its white ICO, and the utility is responding. Native live WPF captures at 500x360, 700x550 and 1000x700 are retained in ignored artifacts; the minimum-size caption actions and all four cards fit.
- Encrypted registrations/settings, current authentication and native Codex processes were preserved during the utility-only restart. The earlier package and pre-update encrypted vault/shortcut backup remain available. No native Mac execution, account login/switch, test suite, commit/push or external publication was performed.

## 2026-10-14 Windows 1.27 personal application update

- Built the current private Windows source and installed the full self-contained 1.27.0 package in `%LOCALAPPDATA%/Programs/CodexSwitch/1.27.0` without overwriting the old 1.22 package.
- Gracefully replaced only the running utility and retained its actual `%LOCALAPPDATA%/CodexAccountDesk` vault and default Codex home. An encrypted pre-update vault backup is kept inside its private data directory.
- Added `Codex Switch.lnk` on the user's Desktop with the new executable/icon, installation working directory and explicit data/home arguments. The new process has the Codex Switch title, live window, expected version and responding state.
- Verified preserved registration count and language/theme settings, unchanged authentication and preserved native Codex processes. Test suites, account switching, commits/pushes and external publication were not part of this request. Private operation receipt stays in ignored artifacts.

## Current state: personal use, publication cancelled

- User requested repository removal and retention of icon changes in the personal repository. The crisp `>_<` geometry, Windows ICO and Mac icon/caption assets remain in this local source checkout, byte-identical to the accepted implementation. The running personal utility and account data are preserved.
- GitHubDELETE Gaebabi/codex-switch was rejected403 because the authenticated admin token lacks delete_repo scope. The repository was converted to private; anonymous repository and Release reads return404. It is not fully deleted. Original private Gaebabi/codex-account-desk remains private/preserved; its origin is unchanged.
- Signing/notarization work is cancelled. Its unfinished local files are retained without publishing or executing notarization. No new commit/push was made, and the former public checkout's origin link was removed to avoid continuing publication.

## 1.27 release downloads, crisp icons and lossless live media

- User authorized binary GitHub Releases and improvements to capture quality/centering/cursor and icon pixelation. Public source commit `8b6f120eca9077365c8fe181643337e26f0c2773` is pushed with a clean public working tree.
- Shared vector trace preserves the accepted `>_<` alpha silhouette within one source pixel; WPF/Avalonia titlebar/menu symbols render geometry. ICO has10independent16–256px renders; Mac PNG/ICNS use1024px vector render. Existing vault/Keychain/IPC identity and accounts are preserved.
- Live WPF capture uses192DPI PNG at exact500x360/700x550/1000x700 logical sizes, 90frames each, restoresgeometry and excludes externalcursor. New GIFs1000x720/1400x1100/2000x1400 eraseallaccount-namepixels;270decodedframeshaveconstantcovers. ActualGitHubDOM reports1000x720 compactimage displayed500x360 centeredwith0pxdifference. OldJPEG/cursorcaptureisreplaced.
- Windows and extracted ZIP checks pass93/93; SQLite/WAL23/23. Mac botharchitecturescompile/packagewithoutwarnings/errors, main/installerZIPmode0755. Packagesincludecomplete runtimes/notices, noauth/vault/privatecapture/log/debugsymbols. Public v1.27.0 Release contains SHA256SUMS and threeZIPs, withmatchingGitHubdigests and anonymousHTTP200/full-downloadSHA256matchesfor all4assets. main/tagbothpointto8b6f120; publicworkingtreeisclean. TheactualReleaseassetlinksarevisibleinthebrowserandcurrentdownloadviewwassavedoutsideGit.
- Source/history/media scanner has113trackedfiles/141reachableblobs and0sensitivefindings. OriginalnativeCodexprocesses andauthenticationhashareunchanged. macOS updatednativeicon/install, realswitch/resume andIntel-deviceexecutionremainunverified. NoRedditpostorautomaticupdater/CIreleaseisintroduced.

## 1.26 Codex Switch open-source publication (2026-10-13)

- English startup/new-vault default; saved language choices remain authoritative. Windows/Mac display titles, tray/menu labels and packaging now use Codex Switch. Executable/app names are CodexSwitch.exe and Codex Switch.app/CodexSwitch, while vault/Keychain/bundle ID/IPC identities remain stable.
- The supplied terminal/cloud silhouette was edited with built-in ImageGen to a `>_<` face. PNG/ICO/ICNS and tinted titlebar/Mac template icons use the generated mark; asset attribution and prompt are documented without personal paths.
- Final Windows 1.26 isolated checks: 93/93; independent SQLite/WAL: 23/23. Both Mac architectures cross-publish without compiler warnings/errors, with executable/installer ZIP modes 0755. Real Mac renamed installation, icon/menu rendering and account login/switch/resume remain native acceptance items.
- The renamed Windows utility runs with its original data directory and four registrations. Live GIFs are 500x360, 699x543 and 1007x708, 36 frames each. All 108 decoded frames have constant source-independent account-identity covers; all-frame contact sheets and sanitized posters were inspected. Raw frames/private diagnostics remain ignored. Native Codex was not stopped or switched.
- New public checkout is `D:/Git/codex-switch`, a reviewed 107-file export with no old history. Private `Gaebabi/codex-account-desk` history and personal commit emails stay private. English/KO/JA/ZH-CN docs, MIT/third-party notices, SECURITY/CONTRIBUTING, publication/media scripts and a Reddit draft are included. Public export builds and passes 93/93 checks. Commit `4ae7e206d054f418ff95b00bfe3ebc898a31519a` is pushed to public `Gaebabi/codex-switch`/main with a noreply identity, matching remote SHA and clean working tree. The scanner finds zero sensitive matches across 107 tracked files/reachable blobs; anonymous README/GIF/LICENSE downloads match committed bytes. Private vulnerability reporting is enabled. No Reddit post or binary Release was made.

- Complete: Windows x64 self-contained WPF/tray application, managed browser-login registration, encrypted account vault, authoritative usage RPCs, 60-second refresh, aliases, remove, cancellation, queued desktop switching, refreshed-token persistence, same-account reauthentication, required workspace/method checks.
- Complete: published package self-tests 18/18, live current-account usage, original auth unchanged, original desktop still running, zero remaining runtime homes, visual WPF verification.
- Deliverables: outputs/CodexAccountDesk, application ZIP, source ZIP.
- Acceptance boundary: actual additional-account browser-login completion and real two-account desktop switching require the user's accounts. Local switch tests use a separate fake home; no current desktop was closed or switched.
- No Git commit, push, merge, or external deployment performed.

## 1.1 delivered

- Reset countdown updates independently of polling. Burn0's verified shared tokens and SVG nodes are embedded, with 40px custom caption and light/dark palettes.
- Account refreshes run independently (three concurrent readers), duplicate reads coalesce, and a fresh login supersedes the previous request immediately. Login and other controls remain independent.
- Credential revision checks discard old results after reauthentication or removal; scoped switch coordination protects the short authentication-file commit.
- 25 published-package checks pass, actual refresh keeps all relevant controls enabled, and both theme renders pass.
- The user's four registrations and aliases were preserved; all four have post-upgrade real usage timestamps. Only the utility was replaced; the Codex desktop remains running.
- Current package: outputs/CodexAccountDesk-v1.1. No actual desktop account switch was performed.

## 1.2 delivered

- Korean and English are available from the caption and tray language menus. Changing language immediately updates controls, dialogs, countdowns, status, and existing application errors.
- Language preferences are saved in the encrypted vault and restored by a separate subsequent process. Existing account identities, aliases, and server-returned data remain intact.
- Embedded catalogs use explicit resource names with WithCulture=false so the self-contained application loads them directly.
- 29 published-package checks pass. Real current-account usage succeeds in both languages; controls remain usable during refresh and language switching.
- English dark/light and Korean WPF renders were reviewed. The active 1.2 utility responds normally and preserves all four existing account registrations and aliases.
- Current package: outputs/CodexAccountDesk-v1.2. The Codex desktop remains running; no actual desktop account switch, Git commit, push, merge, or deployment was performed.

## 1.3 delivered

- Successful quota observations now persist per account/bucket/window in the DPAPI vault. History covers 30 days, at minute resolution for two days and quarter-hour resolution for older records. Older versions seed only their latest real snapshot.
- Forecasts use up to two recent hours in the latest continuous quota segment. At least five minutes and measurable growth are required. Reset changes, decreasing use, stale readings, and offline gaps do not reuse the old consumption rate.
- Korean/English outlooks show absolute depletion and reset times, time remaining, measured history with hover values, and a projected event timeline. An earlier reset is explicit; depletion after it is conditional on no reset.
- The history range (1h/24h/7d) persists across restarts. Countdown updates and language/theme changes retain asynchronous services and controls.
- 40 published-package checks pass. Twelve illustrative forecast renders cover both themes/languages and three states; real current-account renders and consecutive actual recorded observations pass separately.
- The running 1.3 utility responds and preserves all four existing registrations and aliases. The Codex desktop remains running; no actual desktop switch, Git commit, push, merge, or external deployment was performed.

## 1.4 delivered

- Main accounts now use responsive reservoir tiles, with fill height proportional to actual remaining quota and a 64px number in the center. Known zero is empty; missing data uses a dash without a fabricated percentage.
- The limiting quota is selected by default; alternate windows remain selectable. Depletion/reset are two compact rows, and switch/refresh controls remain directly available.
- Graphs, forecasting basis, credits, and reset credits are available in a modeless account detail window. Real UI button activation opens it while keeping the main window and refresh controls enabled.
- Removed the repeated page heading, always-visible range selector, and static footer. Four real accounts fit in a two-column 820x700 dashboard; 600px width uses one column without horizontal overflow.
- 41 package checks pass. Eight illustrative tank screens cover 0/9/52/100 percent, unavailable data, and multiple windows in both languages/themes. Real four-account dark/light/English/narrow renders and detail interaction pass separately.
- Current package: outputs/CodexAccountDesk-v1.4. Account registrations, usage history, settings, and asynchronous service ownership are preserved. No Git commit, push, merge, external deployment, or actual Codex desktop account switch was performed.

## 1.5 delivered

- Replaced width-only wrapping and fixed card heights with a viewport-bound UniformGrid. Four accounts remain in 2x2 cells at 600x400 and 500x360 without scrolling.
- Compact cards move action buttons below the large percentage. Typography uses the available metric height; names, remaining values, forecast/reset rows, and actions fit at the minimum supported size.
- Smaller toolbar controls use meaningful icons/tooltips; the title-bar breadcrumb collapses and status text stays on one line. Bigger windows restore the larger card presentation.
- Alternate quota selection remains available by clicking the number; full graphs/credits remain modeless. Credential, history, forecasting, and async refresh ownership are unchanged.
- 41 published-package checks pass. Actual four-account renders and geometric bounds confirm every card, number, and action fits at 500x360, 600x400, and 820x700. Korean/English and light/dark small screens were reviewed.
- Current package: outputs/CodexAccountDesk-v1.5. The updated utility was reopened. No Git commit, push, merge, external deployment, or actual Codex desktop account switch was performed.

## 1.6 delivered

- Removed refresh buttons from the toolbar, every account card, and the detail window. Automatic polling, immediate reads after login, F5, and tray refresh remain available.
- Card summaries use aligned short labels and bold 12px values, e.g. depletion 21h 38m and reset 6d 21h. Calendar timestamps and forecast basis are preserved in tooltips/detail.
- Shortened missing/stale/collecting states and used the main foreground for readable values over the water fill. Both languages have the duration resources embedded.
- 41 published-package checks pass. Real visual-tree inspection finds zero dashboard refresh buttons; four cards/numbers/actions fit at 500x360, 600x400, and 820x700. Korean/English small screens were reviewed.
- Current package: outputs/CodexAccountDesk-v1.6. The utility was reopened with the existing vault. No Git commit, push, merge, external deployment, or actual desktop account switch was performed.

## 1.7 delivered

- Removed the bright waterline stroke. Actual remaining fill and its wave shape remain without an outline.
- The modeless trend window now emphasizes remaining percentage (52px), depletion duration, and reset duration (28px), followed by one compact measured chart.
- One selected quota is displayed at a time; alternate windows remain available through a selector. Credits, reset credits, and last-check time are collapsed under More info. Exact dates and forecast assumptions remain in tooltips.
- Removed repeated quota percentage text, forecast paragraphs, graph legends, and the secondary future-event timeline from this view. No refresh buttons were added.
- 41 checks pass, actual main/detail rendering and three dashboard sizes pass, and illustrative forecast states were rendered in both themes/languages. The utility was reopened with existing registrations/history/settings.
- Current package: outputs/CodexAccountDesk-v1.7. No Git commit, push, merge, external deployment, or actual Codex desktop account switch was performed.

## 1.8 delivered

- Introduced a shared rounded frame for the dashboard, trend window, confirmation dialogs, and name editor. Windows 11 uses the native DWM rounded-corner preference and suppresses the frame outline.
- Fixed the underlying frame configuration: zero glass caused WindowChrome to create a region, which prevents DWM rounding. A 1px glass frame leaves native composition in control without adding content padding or disabling resize behavior.
- Main/detail HWND inspection confirms corner preference 2, no custom region, and no per-pixel transparency. A screen capture of the running main window verifies the composed corners, separately from WPF bitmap previews.
- Windows controls maximized/snapped corner geometry. Earlier Windows use WindowChrome's 8px radius; this fallback was not exercised on the current Windows 11 host.
- Build succeeds with zero warnings/errors. Existing 41 checks pass. Four live queries succeed; main/detail interaction, no-refresh-button state, and all-card/number/action bounds at 500x360, 600x400, and 820x700 pass.
- Reopened outputs/CodexAccountDesk-v1.8. Four account identities/aliases, history, Korean language, and light theme remain intact. Native Codex and its authentication file remain intact.
- No Git commit, push, merge, external deployment, or actual Codex desktop account switch was performed.

## 1.8.1 delivered

- Reproduced the exact SetterBaseCollection exception by selecting another language through the real language menu. The stack identifies SetResources called from the menu's language-change handler.
- The menu item style was inserted into live resources before its template setter was added. Existing menu items can immediately consume and seal the replacement style. All styles are now fully constructed before resource publication.
- Added a report-mode interaction regression that opens the actual language menu, selects both languages, and toggles the title-bar theme button over three cycles (12 changes). Failure details belong to the diagnostic report; normal UI code does not absorb or bypass style errors.
- The fixed package passes all 12 changes and the existing 41 checks. Four live queries succeed; compact layouts at 500x360, 600x400, and 820x700 and native main/detail rounding remain valid.
- Reopened outputs/CodexAccountDesk-v1.8.1 and inspected its composed screen: all four account cards display normally. Registrations, history tracks, language, and theme match the encrypted backup; native Codex remains running and authentication is unchanged in the read-only probe.
- No Git commit, push, merge, external deployment, or actual Codex desktop account switch was performed.

## 1.9 delivered

- Every dashboard card displays its plan name and reset-credit count in the right side of the existing two summary rows. Compact mode keeps both visible, without consuming percentage height or another row.
- Names such as Pro and Pro Lite are readable; duplicate plan metadata was removed from the wide header. Reset credits use the account's actual AvailableResets value; zero is explicit and missing data displays a dash.
- Added concise Korean/English labels and tooltips. Existing account refresh events update both values as each query finishes, including immediately after login.
- All 41 existing checks pass, and the actual language-menu/theme controls complete 12 changes. Four live accounts return Pro/Pro Lite and 1/2/0/0 reset credits; rendered labels match those counts.
- All cards, numbers, actions, plan labels, and reset-credit labels fit at 500x360, 600x400, and 820x700. Both languages and themes, plus synthetic positive/zero/unknown cases, were rendered and reviewed.
- Reopened outputs/CodexAccountDesk-v1.9 and inspected the real composed screen. Four registrations, history tracks, language, and theme match the encrypted backup. Native Codex/authentication remains intact.
- No Git commit, push, merge, external deployment, or actual Codex desktop account switch was performed.

## 1.11 delivered

- Added subscription period end and source-check time from the account's ID-token subscription claims. Existing registrations hydrate these fields from their encrypted sign-in data; refreshed sign-in data updates or clears them. JWT expiration is never used as a subscription or payment date.
- Displays the end date and D-day countdown in the lower left of every card, with full year/KST time and source-check time in the tooltip/detail. The countdown uses Korean calendar days and updates through the existing clock. Same-day dates show Today; elapsed dates show D+; missing information stays unavailable.
- Moved switch/more controls to the upper right at every card size. History remains at the lower right. Reused the vacated footer space and balanced compact padding/control height to keep the percentage area.
- All 44 checks pass, including subscription claim/reload/update behavior and Korean-midnight countdown transitions. Actual four-account labels match their stored subscription periods and D-17/D-26/D-6/D-5 on the test date.
- All account cards, numbers, controls, plan/reset-credit/date/countdown labels fit at 500x360, 600x400, and 820x700 in Korean and English. All switch/more groups are geometrically in the header. Twelve appearance changes and both-theme/missing-data renders pass.
- Reopened outputs/CodexAccountDesk-v1.11 and inspected its composed screen. Four registrations, history tracks, language, and theme match the encrypted backup; native Codex and authentication remain intact.
- Dates represent the subscription period provided in sign-in data. A separate scheduled billing date is not supplied or inferred. Version 1.10 was an intermediate date-only build; final packaging includes the additional countdown and button-position requests in 1.11.
- No Git commit, push, merge, external deployment, or actual Codex desktop account switch was performed.

## 1.12 delivered

- Learns consumption from complete 10-minute increase blocks in the current consumption segment and last 24 hours. Initial median and bounded EWMA (alpha 0.1591, innovation capped at half the previous rate) limit a single block's rate change to about 7.96%. Zero-growth pauses do not dilute the learned rate; sustained changes adapt.
- Forecast duration equals actual remaining quota divided by learned rate, conditional on continuous use from now. Idle clock time does not reduce measured quota or turn a historical projected deadline into measured exhaustion. Learned models are cached per screen snapshot.
- Real data exposed five false segments caused only by ±1-second changes in reported reset time. Segments now use observed consumption decreases or passage of an earlier reset deadline. Existing segment metadata is reconstructed from observations while preserving quota values.
- Current-account partial water levels animate with a small mean-preserving wave; inactive surfaces are horizontal. Rendering is limited to 20fps and detaches on unload, hidden, or minimized windows. Empty/full levels retain exact quota fill.
- Fifty-one checks pass: pauses/switch gaps, incomplete bursts, single outliers, sustained changes, rounded reporting, polling cadence, reset corrections/legacy repair, numeric date bounds, and wave geometry. Actual WPF rendering records active frames and zero inactive frames, plus stop/restore lifecycle.
- Four live queries succeed with original authentication and native Codex preserved. Six Korean/English layouts fit at 500x360, 600x400, and 820x700; 12 appearance changes and rendered trend/tank examples pass. The real account forecast is available after repairing the false segmentation.
- Package: outputs/CodexAccountDesk-v1.12, including the formula document. Reopened with the existing registrations/history/settings. No Git commit, push, merge, external deployment, or actual native Codex account switch was performed.

## Git repository setup (2026-10-12)

- Copied the v1.12.0 source to D:/Git/codex-account-desk and initialized main. Original source, delivered packages, and user account data remain preserved.
- Added repository guidance, reproducible Windows publishing and verification scripts, and exclusions for generated files, credentials, account vaults, and private diagnostics.
- The relocated self-contained Windows build passes all 51 internal checks. The new repository grants its current owner inheritable FullControl so the existing private-directory ACL setup can execute correctly.
- The user explicitly requested an initial commit, push, and private GitHub publication. Remote completion is verified separately from application account-switch behavior.

## 1.13 live desktop session count

- Added a background observer of the existing desktop's local IPC state. Root chats with active runtime status appear as Running; approval/user-input waits appear separately. Child and side conversations are excluded. Counts update independently of account queries and their refresh interval.
- Missing connection, incomplete discovery, unsupported status/schema, and revision gaps display an unavailable count rather than zero. The observer retains only status/owner/revision/child metadata and reconnects after owner loss; it does not start, stop, resume, or own a chat turn.
- All 58 internal checks pass. A standalone 18-second read-only observation found 11 root chats and 6 running, matching the desktop's actual thread listing. Waiting cases are covered by local state replay, not an injected live approval request.
- Four real account queries succeed with native authentication unchanged and Codex still running. All cards and actual Running 6 / 실행 6 labels fit 500x360, 600x400, and 820x700 in both languages. Twelve actual language/theme control changes pass. The minimum-size English and Korean renders were inspected.
- Counts cover the selected local Codex home's desktop chats. They have no account attribution and do not claim remote/cloud/standalone CLI coverage. Internal IPC stream version 11 is verified on Codex 26.1007.2314; incompatible changes are shown explicitly as unavailable.
- This work changes local source and creates a Windows v1.13 candidate. No additional Git commit/push or external release/deployment is included.

## 1.14 system resource monitoring

- Added CPU/MEM/GPU/VRAM percentages to a two-by-two block within the existing toolbar height. Sampling runs every two seconds on its own background task; UI updates values and colors without rebuilding account cards or blocking account actions.
- Uses one persistent Windows PDH query and physical-memory API. GPU aggregates processes on each hardware engine and selects the busiest engine. Adapter-wide dedicated usage is matched by LUID to 64-bit DXGI capacity; highest per-adapter VRAM pressure is shown with device/byte tooltips. Missing data is distinct from zero.
- Burn0 warning/danger colors activate at 80/95 percent and clear below 75/90. Six new aggregation/large-capacity/unknown/hysteresis cases bring internal checks to 64, all passing.
- Actual native sampling reports all four metrics and a dedicated GPU capacity above 4 GiB without truncation. Independent OS CIM exposes the same physical RAM capacity and adapter-wide dedicated usage. An isolated 18-second observer run averages 3.21ms per warm sample, about 0.16% total CPU, and 53.1MiB working set; these numbers describe this run rather than a future performance guarantee.
- Actual CPU warning color is observed during ordinary existing work. Four account queries, unchanged native authentication, all four cards and all resource labels at 500x360/600x400/820x700 in both languages, and 12 actual appearance controls pass. Both-theme normal/warning/critical/unavailable/idle component renders were inspected; synthetic red examples are distinguished from live load evidence.
- Windows v1.14 is folder-packaged locally. Existing source changes from v1.13 remain preserved. No additional commit/push or external release/deployment is included.

## 1.15 resource gauges and earlier warnings

- Each CPU/MEM/GPU/VRAM cell now has a horizontal background fill proportional to observed usage. Reuses Burn0 accent/warning/danger colors without border strokes or additional render timers, preserving the original toolbar size.
- Warning and critical entry move from 80/95 to 70/85 percent. Release remains five points lower (below 65/80); shared constants also populate both-language tooltips. Unavailable has no fill, zero is empty, and 100 fills the full cell.
- All 64 checks pass, including the updated policy boundaries and release transitions. Actual fill proportions and label fit are verified in Korean/English at 500x360, 600x400, and 820x700 with all four account cards visible. Twelve language/theme inputs pass; four real account queries succeed and native authentication/Codex remain unchanged.
- Both-theme 70/85 warning examples and unknown/empty/full gauges were rendered and inspected as synthetic cases; the actual compact Korean screen was separately inspected. Package is Windows v1.15. No additional Git commit/push or external release/deployment is included.

## 1.16 collected resource trends

- Resource cell backgrounds now show thin history lines and translucent area fills, following the supplied small rising-graph reference. Existing positions, dimensions, labels, numbers, Burn0 themes, and 70/85 warnings remain unchanged.
- The background collector retains at most two minutes/61 real observations in memory. Duplicate snapshots and UI/theme updates do not append points. Invalid measurements stay missing, gaps over six seconds break the graph, and clock rollback starts a fresh timeline. Fixed 0–100 vertical scaling avoids exaggerating small changes; startup shows only genuinely collected points.
- All 67 checks pass, including retention, snapshot immutability, missing/gap segmentation, and clock rollback. Actual observation history drives all four plots. Four live account queries, unchanged native authentication, native Codex still running, six size/language layouts with fitting plots/numbers and all cards, and 12 appearance inputs pass.
- Light/dark reference-like rising, warning, unknown, idle, and full examples were separately rendered as synthetic cases. The actual 500x360 Korean screen was also inspected. Windows v1.16 is packaged locally; no additional Git commit/push or external release/deployment is included.

## 1.17 configurable drive capacity

- Added C:/D: remaining GiB and free-space fills within the existing footer. Local fixed/removable volumes refresh asynchronously every 15 seconds; settings trigger immediate resampling. Missing/unreadable drives show unavailable rather than zero.
- The themed settings dialog selects drives, custom names, and order. Configuration is encrypted with existing settings and survives reload, including disabling all drives. Default C:/D: fills older vaults that lack the property.
- All 68 checks pass. Actual C/D readings are consistent with Windows logical-disk capacity observations. The actual settings window and 500x360 Korean screen were inspected; six size/language layouts preserve drives, hardware history plots, and all four cards. Twelve appearance controls pass, authentication is unchanged, and native Codex stays running.
- Version 1.17 includes the collected resource graphs from 1.16. No additional Git commit/push or external release/deployment is included.

## 1.18 account menu, alignment, and credits

- History moves to the first entry of each upper-right account menu. Its former lower-right position now displays reported credits. No detached or hidden History button drives the product interaction; the readonly UI probe opens the actual menu and its item.
- Credits use the selected quota bucket, distinguishing finite, zero, unlimited, and missing values. Large balances are compact with full original values in tooltips; no currency or missing balance is inferred.
- Reduced the extra leading action gap, aligned footer summary baselines, kept depletion/reset at minimum card height, and reclaimed History control height for the remaining-percentage area. Subscription/date/plan/reset-credit placement stays consistent across cards.
- All 69 checks pass. Live balances are displayed, including zero; actual menu-to-detail interaction and 12 appearance inputs pass. Six size/language layouts fit numbers, metadata, credits, and all four cards; actual 500x360 and illustrative credit cases were inspected. Authentication and native Codex remain unchanged.
- Local Windows v1.18 packaging includes the existing hardware graphs/drive configuration. No additional Git commit/push or external release/deployment is included.

## 1.19 thin native window edge

- Replaced DWM COLOR_NONE border suppression with a subtle gray outer edge. Light/dark active/inactive colors update through the shared frame helper on initialization, activation, and theme changes. Inner cards and controls remain unchanged.
- Native frame validation reports 1px visible border width at the tested DPI, rounded-corner preference 2, no custom region, and the existing glass frame. Successful setter state confirms light/dark colors on main/detail windows. BORDER_COLOR cannot be read with DwmGetWindowAttribute; the initial diagnostic getter was corrected rather than bypassing its error.
- All 69 checks, 12 actual appearance inputs, and six compact size/language layouts pass. Authentication and native Codex remain preserved. Windows v1.19 is packaged locally; no additional Git commit/push or external release/deployment is included.

## 1.20 running, queued, and goal totals

- The existing session area now has three compact columns: running root chats, saved local queued messages, and active goals. Labels sit above larger numbers without middle-dot separators. Compact windows put account/refresh counts in the tooltip and keep the toolbar height.
- The observer retains goal status from snapshots/patches, including pause/limit/complete/clear transitions. Runtime and goal totals overlap independently; unsupported or missing goal state remains unknown.
- The desktop's saved local follow-up queue is read asynchronously every two seconds, with owner queue broadcasts applied immediately. Message IDs are deduplicated; explicit remote hosts and observed child queues are excluded. Paused saved messages stay in the total and are identified in the tooltip. Queue-file failures leave valid runtime counts visible and show only the queue as unknown.
- All 76 checks pass. Live observation confirms the saved paused queue and independent runtime/goal values. Six size/language layouts fit all four cards, hardware plots, and unknown/zero/99 header scenarios; 12 appearance actions pass. Source authentication is unchanged, encrypted account registrations are preserved, and native Codex remains running. Positive goal and queue transitions are replay evidence, not injected live Codex work.
- Windows v1.20 is packaged locally. No additional Git commit/push or external release/deployment is included.

## 1.21 date backup and automatic chat resume

- User-triggered switching stamps/updates [yyMMdd] in running root-chat names, confirms every saved name before graceful Windows shutdown, applies credentials only after exit and source checks, then reopens the same chats. Buttons show Backup/Switching/Resuming while other controls stay usable.
- The encrypted pending plan preserves names, IDs, submission identities, phases, and partial progress. Already running/completed work is skipped; idle continuations receive one Continue with inherited thread settings. Ambiguous delivery is retained for inspection and never automatically repeated. Resume retry is available on the selected account.
- All 87 tests pass, including failure/cancellation/recovery/order and continuation guards. Isolated native loaded-name/reopen protocol passes with no inference. Actual read-only desktop owner settings RPC passes; six compact busy layouts, six normal layouts, and 12 appearance changes pass. Validation preserves authentication and live Codex work. Actual switching requested separately by the user is tracked in the private operation receipt.
- No additional Git commit/push or external deployment is included.

## 1.22 server queue counting and live update ordering

- Fixed omitted app-server queues: read committed queue_1.sqlite identities with Windows SQLite in read-only mode, including WAL. Thread metadata filters out standalone CLI and child queues. Combine server and saved queues per thread, deduplicating submission/client message identities across sources.
- Fixed two-second polling reverting owner broadcasts: retain identity-only overrides until storage catches up; a poll already in flight cannot acknowledge a later broadcast. Empty removal updates, ownership changes, and disconnects clear the appropriate state. Queue-file notifications wake the background observer; a two-second rescan remains, with SHM lock changes excluded.
- All 92 internal checks and 23 independent disposable SQLite/WAL checks pass. WAL-only additions/deletions, uncommitted invisibility, source deduplication, child/CLI exclusion, unsupported/missing/corrupt metadata, and original DB/WAL byte preservation are verified. Positive transitions use isolated fixtures, without creating or changing real Codex tasks.
- Actual read-only desktop observation has valid runtime/queue/goal counts with no queue errors; independent storage counts agree. Native owner settings RPC passes, authentication is unchanged and the native Codex processes remain alive. Existing compact UI is unchanged.
- Delivered the complete v1.22 Windows folder/ZIP and source ZIP. Gracefully replaced only the v1.21 utility with v1.22 using its existing data directory; the new process has a live window and responds. Native Codex processes and authentication remain unchanged. Source commit/push is covered by the user's earlier explicit request; no GitHub Release or external deployment is part of this fix.

## 1.23 macOS implementation, user-owned runtime validation

- Added a dedicated Avalonia .NET 8 macOS project sharing the original account/RPC/history/predictor/switch/session/queue implementation. The Windows WPF project excludes the Mac UI and retains its existing platform behavior.
- Added Keychain-backed authenticated vault encryption, POSIX private mode/atomic writes, .app/plist/CLI discovery, exact-bundle native quit/relaunch, same-UID Unix socket transport, system SQLite and case-preserving volume preferences. No forceQuit or fabricated activity/usage data is used.
- Ported Burn0 token colors, compact water cards with current-account motion, independent async account actions, KO/EN settings, History, date/reset/plan/reset-credit/credit fields, session totals, collected hardware charts and mounted-volume settings/order. Missing driver metrics remain unknown; unified memory is not labeled as dedicated VRAM.
- Added Apple Silicon/Intel bundle scripts, executable-mode ZIP packaging, PNG/ICNS/vector icon, local install/sign helper and Mac setup/acceptance documentation. Tests, actual app launches, login/switch/session/hardware probes were deliberately not run at the user's request. Compile/publish evidence and package receipts are separate from Mac runtime acceptance; BACKLOG records user-owned gates.

## 1.24 MacBook polish and native verification

- Added readable minimum card heights and scrolling for additional accounts, refresh/retry with Cmd+R/F5, native Cmd+N/O/W menus, per-account refresh, visible stale/error status, compact volume tooltips and keyboard-friendly dialogs. History selectors wrap in small windows.
- Fixed an actual macOS startup crash: replacing an exported TrayIcon.NativeMenu raises `The menu being updated does not match`. Keep the native menu tree and items for the application lifetime, updating only headers and enabled states. The native render matrix now exercises repeated language/menu updates as well as cards.
- Fixed incomplete bundle signing: dylib-only signing leaves .NET DLLs unsigned. Sign all internal files before the primary executable/app bundle, then require plist validation, correct executable architecture and `codesign --verify --deep --strict`. ZIP extraction retains the signatures.
- Installation stages a complete candidate on the target volume and verifies signing/CLI boot before moving the previous app to a recoverable backup. Failed candidates leave the installed app intact; concurrent/running-app replacement is refused.
- Apple Silicon macOS 26.6: 11 native/catalog/storage/socket/resource/volume checks, 23 independent SQLite/WAL checks, 15 synthetic native layout/scroll checks and 7 ZIP/installation checks pass. Windows cross-target build has zero warnings/errors; both Mac architectures publish and pass signature/architecture checks. Intel execution, real login/switch/chat resumption remain separate acceptance items.
- Installed the corrected Apple Silicon app at `~/Applications/Codex Account Desk.app`. Its native window runs; the existing local vault key requires the user's Keychain authorization after the ad-hoc code identity changed. Account data and native Codex are preserved. Private crash samples/reports, PNGs and all build artifacts stay outside Git.

## macOS drag and button alignment follow-up

- Fixed missing custom title bar movement by connecting the caption/empty area to native BeginMoveDrag. Traffic lights and language/theme/settings controls stay outside that region.
- Fixed shared button content defaults: explicitly center text/icons horizontally and vertically. More, refresh and volume reorder buttons use consistent 14px vector icons instead of font glyph baselines, with localized accessibility labels. The same button style applies to account actions, History and dialogs.
- Native account-free interaction observes actual position (564,365) → (876,219), seven PositionChanged events, and working language/theme clicks without window movement. Fifteen render/scroll cases pass with per-button text/icon centering assertions. Catalog keys match, and both Mac bundles pass publish/plist/architecture/strict-signature checks.
- Before replacement, the existing installed app showed the real account, resources and session/queue totals; Keychain initialization had completed. Only Account Desk is gracefully replaced, preserving the vault and the running native Codex. Probe coordinates and captures remain Git-excluded.

## 2026-10-12 Mac resource cleanup

- Audited eight local repositories. Completed MTD work was fast-forwarded to master; Backrooms moved to main. Two completed worktrees, five missing worktree registrations and seven local branches were removed after ancestry/recovery checks.
- The user selected a history-only merge for the historical daily-offers branch with ten conflicts. MTD master `cc8223b2` retains the exact pre-merge source tree (`b375fb32`), reaches the original `7f0086df` commit and has a verified incremental recovery bundle.
- Removed rebuildable caches, stale app/IPA/ZIP exports and 66,823 raw diagnostic images while retaining dirty source, Git/source backups, credentials, current/preceding IPA exports, latest Mac packages and symbol archives. Cleanup increased available space from about 32GiB to at least 85GiB; actual volume measurements are in the private ledger.
- Per the user's selection, stopped Simulator/MTD simulation, Roblox and Account Desk. The completed computer-use helper also stopped. Active Codex, browser and automatic release/feedback services remain running. The installed Account Desk app and its vault are retained.
- Existing dirty status in the diagnostic MTD copy and ReLayer was preserved. The MTD merge's 42 targeted checks passed; generated caches will be rebuilt when those projects next build. Detailed manifests are outside Git at `~/Desktop/mac-cleanup-2026-10-12`.

## 2026-10-12 — 1.25 menu bar and maintenance records

- Added a macOS variable-width native status item with an 18pt Retina template account symbol and native monospaced percentage. It uses the current account card's selected quota and updates on observed usage, selection and language changes. Missing/current-account-unavailable is `—`; actual 0%/100% values are preserved.
- Stable native menu actions provide open/add/refresh/cancel/quit. Native resources and rooted Objective-C callbacks are released at shutdown; closing the window keeps the menu available.
- Nineteen native render/scroll/menu cases pass, including repeated KO/EN/light/dark layout changes and zero/full/unavailable/inactive-only percentages. Both Mac architectures publish with plist/architecture/strict-signature checks. Intel runtime acceptance remains separate.
- Installed 1.25.0 in the user's Applications folder and preserved the previous app. After the user completed the renewed Keychain prompt, the existing real account and current 73% weekly remainder, resources and session totals loaded successfully. Validation did not terminate or switch Codex. Windows cross-target compilation also passes with zero warnings/errors.
- Recorded and pushed cleanup in MTD, ReLayer, BackroomsBagSurvivor, Burn0, CursorShot and gaebabi-tools. The shared context merge preserves current remote documentation and excludes the user's existing uncommitted paragraphs/PDF. The temporary integration checkout was removed. Account Desk source and records are included in this task's requested main push.
