# Linux terminal account switching and session resume

Source1.41.0 implements the terminal commands in [issue97](https://github.com/Gaebabi/codex-switch/issues/97). Published1.40.7 does not contain them: [build current source](../INSTALL.md#linux-preview) until a separate binary release includes them. Do not confuse GUI preview or fictional-card screenshots with authenticated continuation acceptance.

## Commands

The complete Linux app also handles `cli` commands before GUI initialization. DISPLAY/Wayland is not needed. Use an existing unlocked configured GNOME Keyring/KWallet Secret Service and the same Codex home/data directory as the GUI. No new credentials, vault or provider are silently substituted.

Select an official native Linux executable, not the npm JavaScript launcher. Version0.162.1 and the separately approved packaged0.162.0-alpha.17.2 are currently verified; other versions fail the protocol check. Supply its exact SHA256 and native path together, or use the approved installed desktop package's CLI. Verify where your executable came from before trusting its checksum. The wrapper never searches PATH for an arbitrary program. Examples use shell variables for an explicitly chosen native executable and expected digest:

```sh
# Set these to the actual trusted native executable and its reviewed SHA256.
native=/absolute/path/to/native/codex
expected=REPLACE_WITH_EXPECTED_SHA256
cs() { /absolute/path/to/CodexSwitch cli "$@" --codex-cli "$native" --codex-cli-sha256 "$expected"; }

# Sign in using the official Codex CLI, then save each login under a unique name.
cs import --name personal
cs list
cs sessions

# Quit clients using the shared login normally first. Switching always needs this command.
cs switch personal
cs switch personal --resume 00000000-0000-4000-8000-000000000001
# Add --continue to submit one explicit follow-up after restoring the chosen session.
cs switch personal --resume 00000000-0000-4000-8000-000000000001 --continue
# SSH/batch without a terminal: noninteractive continuation is explicitly selected.
cs resume 00000000-0000-4000-8000-000000000001 --exec --continue
```

The UUID above is an example: replace it with a real saved CLI/exec session from `cs sessions`. The wrapper rejects a nonexistent session or a desktop/app-server metadata-only thread before applying an account. `sessions` returns at most100 CLI/exec records and a `nextCursor`; use `cs sessions --cursor '<nextCursor>'` for the next page. It does not infer tasks from a desktop screenshot. Commands accept `--codex-home`, `--data-dir` and `--client-context` for an explicitly selected existing environment. `list` uses stable account IDs/aliases and omits emails/tokens; duplicate aliases require the full ID.

`--resume` restores the original exact session in its recorded directory. Interactive mode inherits the real terminal and uses official `codex resume --no-daemon`; it does not reuse a background server holding an earlier login. `--exec --continue` delegates to official `codex exec resume --json`, exposing upstream progress events on stdout and wrapper status on stderr. The wrapper sets no sandbox/approval/model/provider override. Original transcript/settings restoration remains the official CLI's responsibility and existing project/managed credential policy must permit the selected account. No automatic rotation, inferred last-session selection, forced client shutdown or automatic repeat after an uncertain send.

Close existing CLI/IDE/desktop clients before switching the shared login. If a normal Codex shared daemon remains after clients exit, stop it explicitly with the official `codex app-server daemon stop` before using the wrapper; it never kills or adopts an external process. Do not stop a daemon that still owns work. Wrapper-launched interactive resumes use their own foreground lifetime. A pending desktop recovery must be completed first. A failed model turn is returned as a failure; a completed account application is not reported as a completed task.

References: [official interactive/noninteractive resume](https://developers.openai.com/codex/cli/reference), [upstream CLI features](https://developers.openai.com/codex/cli/features).

## Delivery checkpoints

1. Define the headless command and safety contract in an issue-linked branch. Preserve the existing encrypted vault, native key provider, public data identities and published packages.
2. Add `CodexSwitch cli list/import/switch/sessions/resume` before GUI initialization. Explicit native executable/SHA selection and fresh file/workspace policy are mandatory. Reuse existing account application and previous-login backup.
3. Bind resume to an exact persisted session UUID and saved working directory. Launch the verified official native `codex resume` with inherited terminal descriptors and no shell, permission override or invented session. `--continue` is an explicit optional follow-up, never an automatic quota/account rotation.
4. Verify normal-user native x64/ARM64 account/data/policy/process conflict contracts and actual PTY/UI resumption. Keep offline lifecycle evidence separate from real account identity/inference/continuation. Capture only an owned terminal with fictional identifiers; strip metadata and bind source/hash.
5. Update all README languages and the support matrix with the actual completed scope. Require all six exact-head protected checks, recorded author review, expected-head merge and public-main verification. Existing desktop/full-environment acceptance issues retain their own criteria.

## Safety contract

- No desktop, DISPLAY, browser or GUI is needed for the terminal command surface. An available unlocked configured Secret Service/keyring is still required for the existing encrypted vault; SSH does not provide one automatically. No plaintext or implicit new key fallback.
- Import saves a login established by the official CLI into the existing vault. It never accepts tokens on the command line. Accounts use explicit stable IDs or unique aliases, never an account index that can silently select a different login.
- Quit existing Codex CLI/IDE/desktop clients normally before switching the shared login. Never adopt or kill another terminal's process. Commands serialize with the existing GUI and other terminal commands; conflicting clients prevent mutation.
- Resume uses an exact local saved session UUID, validates its recorded project policy for the target account, and starts in that saved directory. It does not edit session logs/configuration or downgrade model/sandbox/approval policy. The official CLI owns transcript/settings restoration.
- No automatic retry of a submitted follow-up. A failed launch after a completed account application must report that boundary clearly; a new manual resume is explicit user action.
- Existing pending desktop recovery is not overwritten by terminal commands. No new binary Release is part of this issue.

## Verification status

Native input-descriptor inspection belongs to `src/platforms/client/LinuxTerminal`; the application command orchestrator retains its existing no-native-import boundary. All six local composition checks pass after correcting this ownership. Real-account verification also checks model compatibility: a saved model unsupported by the target account is an upstream turn failure, never a reason to change the saved model or claim successful continuation. A fresh dedicated test may explicitly select a model offered to both accounts before creating its session; the wrapper still supplies no model override.

The implementation builds without errors/warnings. The current local normal-user network-disabled container passes15 headless-command/storage/native-client contracts plus real native exec/resume lifecycle verification. Ordinary CLI input creates a saved exec session; normal SIGINT interrupts it, the production account command applies the other fictional account, and official exec resume emits the same session ID and persists exactly one Continue before another normal interrupt. No successful model response is faked or claimed. Checkpoint58c7150 separately passes14 earlier contracts and actual terminal capture on native x64/ARM64. [Inspected actual terminal confirmations and per-architecture receipts](../evidence/linux-terminal/README.md). Final exact-head native results, six protected checks and real authenticated continuation remain pending in PR98. Existing desktop login observations do not establish this new CLI feature.
