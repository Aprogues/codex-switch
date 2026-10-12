# Reddit sharing draft

## Title

I built Codex Switch: an open-source account switcher for Codex on Windows and macOS

## Post

I use multiple Codex accounts and wanted a small desktop utility that lets me choose the next account without manually juggling login files. I built **Codex Switch** and have been using it in my daily workflow.

Account switching is the main feature. It backs up the current login, saves active local root-chat names with a date suffix, requests a normal Codex shutdown, applies the selected account and reopens the same chats. Eligible idle continuations get one Continue; already running or finished work is left alone.

To help choose an account, it shows reported remaining quota, reset times, plan/credits and measured history. The water cards fit into a compact window, with light/dark themes and local activity/resource indicators.

- Windows and macOS source, MIT license.
- English default, English/Korean UI; docs in English, Korean, Japanese and Chinese.
- Credentials in a local encrypted vault: DPAPI on Windows, Keychain-backed AES-GCM on Mac.
- No project-operated account server or analytics endpoint.

**Source:** https://github.com/Gaebabi/codex-switch

**Live GIFs:** [compact](https://github.com/Gaebabi/codex-switch/blob/main/docs/media/compact.gif), [standard](https://github.com/Gaebabi/codex-switch/blob/main/docs/media/standard.gif), [large](https://github.com/Gaebabi/codex-switch/blob/main/docs/media/large.gif).

The GIFs show my actual Windows dashboard with names permanently redacted, recorded from lossless 2× app renders without a cursor overlay. They show usage/layout, not a staged switching success. Switching really restarts Codex and can affect CLI/IDE tools sharing its login. Download complete [Windows, Apple Silicon and Intel packages](https://github.com/Gaebabi/codex-switch/releases/tag/v1.27.0) without building source or installing .NET. Packages are unsigned; real Mac account switching/chat resumption and Intel-device acceptance still need native testing.

Independent community software, not an official OpenAI product. Feedback on the switching flow and native Mac testing would be useful.

## Attachments

Use only `docs/media/compact.gif`, `standard.gif` or `large.gif`. Never attach raw recordings, vaults or private diagnostics. If a community requires video, use a sanitized export instead of the original recording.

This draft has not been posted. Check the target community's current rules before submitting.
