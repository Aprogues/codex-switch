# Live recordings

Recorded on 2026-10-13 (Korea) from the maintainer's running Windows **Codex Switch 1.27** with four existing registered accounts and the original data directory. The native Codex desktop was not stopped and the active account was not switched.

| File | Logical UI size | Export pixels | Frames | Approximate duration |
| --- | --- | --- | --- | --- |
| compact.gif | 500 × 360 | 1000 × 720 | 90 | 9 seconds |
| standard.gif | 700 × 550 | 1400 × 1100 | 90 | 9 seconds |
| large.gif | 1000 × 700 | 2000 × 1400 | 90 | 9 seconds |

The running utility's actual WPF visual is rendered at 192 DPI directly into lossless PNG frames. The renderer does not include the OS pointer or external Codex cursor overlay. No JPEG stage or raster enlargement is used. UI sizes are set exactly for each recording and the previous window geometry is restored afterward. Measured elapsed frame intervals are retained at GIF timing precision. Animations contain real quota/resource changes and active-account water motion; no readings are injected.

Before export, every account-name/alias region is completely replaced with source-independent pixels and a generic blurred **Private account** placeholder. Original names are never blurred or retained. A shared GIF palette preserves the redacted covers across all 270 decoded frames. PNG posters use only sanitized frames. Raw images/timing files stay in ignored private local artifacts and are absent from Git and Release assets. GIF retains its 256-color format limit; posters are full-color PNG.

These recordings show dashboard layout and live quota observation. They are not an end-to-end account-switch or chat-resumption acceptance recording. Mac footage is not included. Start recording with `CodexSwitch.exe --record-dashboard <private-directory> --data-dir <same-directory-as-running-utility>`, then redact with `scripts/redact-promo.py` before sharing anything. Recording requires an existing running utility; it does not register accounts. Changing layout requires inspecting all identity rectangles.
