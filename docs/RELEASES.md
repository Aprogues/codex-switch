# Package delivery

The current repository is private. Public Release publication is paused; source version **1.27.6** is newer than the archived 1.27.0 packages. There is no automatic deployment or updater.

For local delivery:

1. Build from the current source. [Build instructions](INSTALL.md)
2. Copy the entire Windows publish folder, or the complete Mac app/installer ZIP.
3. Include MIT and asset notices. Exclude credentials, vaults, diagnostics and personal captures.
4. Verify extracted files, checksums and Mac executable modes. Native Mac acceptance is separate from cross-compilation.

A new Release, tag, public push or notarization requires a new explicit request. `scripts/notarize-macos.sh` is available for an appropriately signed native Mac app; its presence is not proof of notarization.

The sole documentation image is `docs/media/demo.png`. Do not package documentation-rendering fixtures or recovery archives.
