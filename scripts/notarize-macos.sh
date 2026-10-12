#!/bin/bash
set -euo pipefail

[[ "$(uname -s)" == "Darwin" ]] || { echo 'Apple signing and notarization must run on macOS.' >&2; exit 1; }
[[ $# -eq 1 ]] || { echo 'Usage: notarize-macos.sh <Developer-ID-signed .app>' >&2; exit 1; }
: "${MAC_NOTARY_PROFILE:?Set MAC_NOTARY_PROFILE to an existing notarytool Keychain profile.}"
task_app="$(cd "$1" && pwd -P)"
[[ "$task_app" == *.app && -f "$task_app/Contents/Info.plist" ]] || { echo 'Expected a complete app bundle.' >&2; exit 1; }
task_details="$(codesign -dv --verbose=4 "$task_app" 2>&1)"
[[ "$task_details" == *"Authority=Developer ID Application:"* ]] || { echo 'A Developer ID Application signature is required; ad-hoc signing is not accepted.' >&2; exit 1; }
[[ "$task_details" == *"Timestamp="* ]] || { echo 'A secure signature timestamp is required. Rebuild with MAC_CODESIGN_IDENTITY.' >&2; exit 1; }
codesign --verify --deep --strict "$task_app"

task_parent="$(dirname "$task_app")"
task_output="$(mktemp -d "$task_parent/notarization.XXXXXX")"
task_upload="$task_output/submission.zip"
task_report="$task_output/submission.json"
ditto -c -k --sequesterRsrc --keepParent "$task_app" "$task_upload"
xcrun notarytool submit "$task_upload" --keychain-profile "$MAC_NOTARY_PROFILE" --wait --output-format json > "$task_report"
task_status="$(plutil -extract status raw -o - "$task_report")"
[[ "$task_status" == "Accepted" ]] || { echo "Apple did not accept the submission. Private diagnostic report: $task_report" >&2; exit 1; }
xcrun stapler staple "$task_app"
xcrun stapler validate "$task_app"
codesign --verify --deep --strict "$task_app"
spctl --assess --type execute --verbose=2 "$task_app"

# A notarized release uses a standard drag-install DMG, with no custom installer
# executable that would need separate notarization or modify the app signature.
task_stage="$task_output/dmg-content"
mkdir "$task_stage"
ditto "$task_app" "$task_stage/$(basename "$task_app")"
ln -s /Applications "$task_stage/Applications"
task_dmg="$task_output/CodexSwitch-notarized.dmg"
hdiutil create -volname 'Codex Switch' -srcfolder "$task_stage" -ov -format UDZO "$task_dmg"
printf 'Notarized app: %s\nDistribution DMG: %s\n' "$task_app" "$task_dmg"
echo 'Publish the verified DMG with a checksum; keep submission reports and signing credentials private.'
