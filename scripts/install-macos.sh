#!/bin/bash
set -euo pipefail
task_script_dir="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd -P)"
task_source="${1:-$task_script_dir/Codex Switch.app}"
task_source="$(cd "$task_source" && pwd -P)"
[[ -f "$task_source/Contents/MacOS/CodexSwitch" && -f "$task_source/Contents/Info.plist" && -f "$task_source/Contents/Resources/entitlements.plist" ]] || { echo 'Not a complete Codex Switch bundle' >&2; exit 1; }
task_install_root="${2:-$HOME/Applications}"
mkdir -p "$task_install_root"
task_install_root="$(cd "$task_install_root" && pwd -P)"
task_destination="$task_install_root/Codex Switch.app"
if [[ "$task_source" == "$task_destination" ]]; then
  printf 'Already installed: %s\n' "$task_destination"
  exit 0
fi
if /usr/bin/pgrep -x CodexSwitch >/dev/null || /usr/bin/pgrep -x CodexAccountDesk >/dev/null; then
  echo 'Quit Codex Switch from its menu (or Cmd+Q), then run the installer again.' >&2
  exit 1
fi
task_lock="$task_install_root/.codex-account-desk-install.lock"
mkdir "$task_lock" 2>/dev/null || { echo 'Another installation is in progress.' >&2; exit 1; }
task_stage=""
task_backup=""
task_complete=false
task_cleanup() {
  if [[ "$task_complete" != true && -n "$task_backup" && -e "$task_backup" && ! -e "$task_destination" ]]; then
    mv "$task_backup" "$task_destination"
  fi
  if [[ -n "$task_stage" && -d "$task_stage" ]]; then rm -rf "$task_stage"; fi
  rmdir "$task_lock"
}
trap task_cleanup EXIT
task_stage="$(mktemp -d "$task_install_root/.account-desk-install.XXXXXX")"
task_candidate="$task_stage/Codex Switch.app"
ditto "$task_source" "$task_candidate"
chmod +x "$task_candidate/Contents/MacOS/CodexSwitch"
plutil -lint "$task_candidate/Contents/Info.plist"
while IFS= read -r -d '' task_binary; do
  codesign --force --sign - --timestamp=none --options runtime \
    --entitlements "$task_candidate/Contents/Resources/entitlements.plist" "$task_binary"
done < <(find "$task_candidate/Contents/MacOS" -type f ! -name CodexSwitch -print0)
codesign --force --sign - --timestamp=none --options runtime \
  --entitlements "$task_candidate/Contents/Resources/entitlements.plist" "$task_candidate"
codesign --verify --deep --strict "$task_candidate"
"$task_candidate/Contents/MacOS/CodexSwitch" --help >/dev/null
if [[ -e "$task_destination" ]]; then
  task_backup="$task_install_root/Codex Switch-$(date -u +%Y%m%dT%H%M%SZ)-$$.app"
  mv "$task_destination" "$task_backup"
fi
mv "$task_candidate" "$task_destination"
task_complete=true
if [[ -n "$task_backup" ]]; then printf 'Existing installation preserved at %s\n' "$task_backup"; fi
printf 'Installed: %s\n' "$task_destination"
echo 'Open it from Finder. To keep it in the Dock, choose Options > Keep in Dock.'
