# Documentation screenshot

`demo.png` is the only documentation image: one 800×560 static PNG, rendered from the current Windows UI by `python scripts/render-demo.py`.

The visible **DEMO** label and reserved `example.invalid` addresses identify fictional everyday data.

- Four distinct balances: work 62%, backup 86%, personal 37%, research 14%.
- Ordinary activity: 5 running chats, 2 queued messages and 1 goal.
- Resources: CPU 26%, MEM 73%, GPU 42%, VRAM 58%. Each graph fluctuates independently within a small bounded range over two minutes.
- Status colors come from the existing controls: normal blue, low quota/memory caution yellow, low drive free space red.
- The transparent outer corners use the window's 8px radius and a thin 1px gray edge.

Forecasts are calculated by the actual usage predictor from synthetic history. No real accounts, authentication, live tasks or native Codex process are used. Resource values are simulated rather than produced by stressing the machine.

`demo.json` records the scene/source/date. The PNG has no private identities or image text/EXIF metadata. Re-render when the UI changes; this illustration is separate from account-switch, performance or Mac acceptance evidence.

Older GIFs, size variants and duplicate posters remain removed from the current tree.
