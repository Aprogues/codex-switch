# Security and privacy

This application handles local Codex credentials. Treat the account vault, raw captures and diagnostics as private data even when encrypted.

## Storage and account switching

- Windows protects the vault using DPAPI for the current Windows user.
- macOS protects the vault with AES-GCM and a Keychain-held key, plus private POSIX file permissions.
- Inactive-account usage reads use isolated local Codex homes. The application talks directly to Codex tooling; it has no project-operated account server or analytics endpoint.
- An account switch changes the shared Codex authentication file and can affect CLI/IDE clients using the same Codex home. It requests a normal desktop exit before applying the selected login. It does not force-kill the desktop.
- Local chat handoff can rename active root chats with a date suffix and send one `Continue` to eligible idle chats. Review [switch behavior](docs/SWITCHING.md) before using it.

Encryption at rest does not protect against malicious software running as you or someone with access to your unlocked desktop. Do not upload a vault to an issue, chat or external service.

## Reporting a vulnerability

Use this repository's GitHub **Report a vulnerability** option when available. Do not open a public issue containing a credential, account name, private chat or exploit exposing another user's data. If private reporting is unavailable, open a minimal issue requesting a private contact without including sensitive material.

## Public media

The public GIFs are recordings of the maintainer's live Windows utility, with account identity regions overwritten before a generic blurred placeholder is added. GIF frames contain no original account-name pixels in those regions, raw frame files, hidden text or account metadata. The raw recordings remain outside the public Git tree and Release packages. Blur alone is not adequate redaction.

`--record-dashboard` writes unredacted PNGs from the running app into the private directory you specify, at the current-user-only IPC boundary. These files are private even though the capture excludes external cursors. Run the redaction/export tool and inspect every frame before publishing. Never record directly into a tracked docs/assets directory.
