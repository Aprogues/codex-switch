# Live recordings

Recorded on 2026-10-13 (Korea) from the maintainer's running Windows **Codex Switch 1.26** with four existing registered accounts. The utility was renamed/restarted using its original data directory. The native Codex desktop was not stopped and the active account was not switched.

| File | Native pixels | Frames | Approximate duration |
| --- | --- | --- | --- |
| compact.gif | 500 × 360 | 36 | 10 seconds |
| standard.gif | 699 × 543 | 36 | 10 seconds |
| large.gif | 1007 × 708 | 36 | 10 seconds |

Frames were sampled from the actual target window with Windows Graphics Capture through Computer Use. Measured elapsed frame intervals are retained at GIF timing precision. Animations contain real quota/resource changes and active-account water motion; neither user actions nor usage readings are injected.

Before export, every account-name/alias region is completely replaced with pixels generated independently of the source. A generic **Private account** placeholder is then blurred. This removes original name pixels rather than relying on reversible blur. Each frame is checked before encoding; the resulting GIF is decoded and visually inspected. PNG posters use only sanitized frames. Raw images/timing files stay in ignored local artifacts and are absent from the public Git tree.

These recordings show dashboard layout and live quota observation. They are not an end-to-end account-switch or chat-resumption acceptance recording. Mac footage is not included. Capture/export instructions are in `scripts/redact-promo.py`; changing layout requires inspecting and updating all identity rectangles.
