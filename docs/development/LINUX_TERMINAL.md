# Linux terminal account switching and session resume

Implementation in progress for [issue97](https://github.com/Gaebabi/codex-switch/issues/97). Published1.40.7 does not contain these terminal commands. Do not confuse the existing GUI preview or fictional-card screenshots with terminal/account/continuation acceptance.

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

Source implementation, native command/PTY captures and authenticated account/continuation checks are pending. Existing Linux two-account desktop launch observations do not establish this CLI feature. Final commands, results, source/client versions, pictures and remaining limitations will be recorded here and in the PR.
