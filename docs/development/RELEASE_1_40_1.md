# Release1.40.1 checkpoint

The owner explicitly authorizes publishing current Windows/Mac packages and Linux preview packages to GitHub Release, refreshing README download links and adding actual Windows/Linux app-window images on a plain background. Keep the previous releases available. This authorizes release publication; it does not complete pending real two-account Linux handoff or broaden desktop acceptance.

1. Build complete Windows x64 and macOS15 arm64/x64 packages on native CI workers from the same reviewed source. Preserve existing Windows/Mac native tests and actual app-window captures. Verify native ad-hoc Mac signatures, ZIP extraction and staged install/update/preservation. No Developer ID/notarization claim.
2. Run existing native Linux x64/ARM64 provider/client/package gates and ordinary x64 Xfce session. Publish the complete `.deb`, `.rpm` and `.tar.gz` assets with explicit preview names and `supportedAccountHandoff: false`. Keep #5/#6/#7/#76 open for their remaining real-account/full-desktop criteria.
3. Capture only the actual application/its native WM frame, keeping title/controls intact. Place the unaltered window pixels on a solid presentation background; identify synthetic profiles and exact OS/source/runtime. Never include a personal desktop, cursor, login, private identity or raw diagnostics. Do not infer account switching from a screenshot.
4. Verify exact-source CI artifacts and SHA256, inspect exported images, and attach evidence to an issue/PR. Commit/push checkpoints, record author self-review and merge the exact verified tree.
5. Create a draft Release against the merged tree/tag, upload only verified packages, SHA256SUMS and sanitized verification receipts, then verify GitHub digests before publishing. Update all README language download links and current installation/release guides. Source/package differences in provenance must be limited to documented release/evidence files, never application/build inputs.

CI remains read-only with no release/account/signing secrets; the authorized owner publishes manually through a local authenticated GitHub request. Linux is an integration preview and the Mac bundles are ad-hoc signed; both limitations must be visible beside the downloads.

## Reproducible native package inputs

The official Linux `latest` download advanced to26.1013.31256 during release verification. CI now downloads approved26.1007.71326 from the vendor's versioned Debian pool. Both complete downloads match the existing reviewed x64/ARM64 SHA256 values exactly; installed-version, executable, ASAR and CLI trust checks remain unchanged. Newer client versions require their own compatibility review and are not silently accepted by this preview.

The Mac bundle's `Contents/MacOS` directory contains managed runtime assemblies as well as Mach-O libraries. Apple's bundle signing requires sealing these nested code objects too; signing only Mach-O files fails on an unsigned managed DLL. Packaging follows the existing native build/installer signing order for every published file, then the outer bundle, and requires strict verification before and after ZIP extraction. No signature verification is bypassed.

## Reviewed candidate checkpoint

Application/build codea70ec5f passes all four [Verify jobs](https://github.com/Gaebabi/codex-switch/actions/runs/38917767076) and both actual-architecture [Linux native jobs](https://github.com/Gaebabi/codex-switch/actions/runs/38917767141). Windows94 existing/ownership and12 native recovery checks, seven native installation checks on each Mac architecture, and ordinary x64 Xfce46 checks pass. All source-bound candidate packages and native image artifacts are downloaded with GitHub digest verification before staging.

The [current gallery](../media/release-1.40.1/README.md) uses actual Windows and ordinary installed Linux windows. Original pixels/titlebars are preserved without scaling, metadata is removed and PNGs are visually inspected. The owner will provide the MacBook real-device screenshot; its slot remains pending and the documentation commit explicitly records this requirement. Native Mac CI verification does not substitute for that image.

Issue80's Windows startup recovery and atomic ownership-record writing are included. The local94/12 checks and actual owner-app recovery are distinct from synthetic fixtures or authenticated Linux handoff. The latter remains separately pending; two owner-logged-in Linux accounts passed11 authenticated read-only checks only. Publication remains a Windows/Mac release plus explicitly experimental Linux assets.
