"""Inspect the public Git tree and reachable history without printing sensitive matches.

This is a targeted publication check, not a guarantee that every possible secret
format can be recognized. Run before the first push and on later contributions.
"""
import json
import re
import subprocess
from pathlib import Path
from PIL import Image

root = Path(__file__).resolve().parents[1]
def git(*args):
    return subprocess.check_output(["git", "-C", str(root), *args])

patterns = {
    "private-key": rb"-----BEGIN (?:RSA |EC |OPENSSH )?PRIVATE KEY-----",
    "github-token": rb"\b(?:gh[pousr]_[A-Za-z0-9]{30,}|github_pat_[A-Za-z0-9_]{30,})\b",
    "openai-key": rb"\bsk-(?:proj-|svcacct-)?[A-Za-z0-9_-]{30,}\b",
    "aws-key": rb"\b(?:AKIA|ASIA)[A-Z0-9]{16}\b",
    "slack-token": rb"\bxox[baprs]-[A-Za-z0-9-]{20,}\b",
    "personal-checkout": rb"(?i)(?:D:[\\/]Git[\\/]|[\\/]Users[\\/](?:CNI|cni)[\\/])",
}
email = re.compile(rb"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}")
findings = []
def inspect(label, data):
    for kind, pattern in patterns.items():
        if re.search(pattern, data): findings.append({"path":label,"kind":kind})
    for address in email.findall(data):
        domain = address.split(b"@")[1].lower()
        if domain.endswith((b".test", b".invalid", b".example")) or domain in (b"example.com", b"example.org", b"example.net", b"users.noreply.github.com"):
            continue
        findings.append({"path":label,"kind":"non-example-email"})

paths = [p.decode("utf-8") for p in git("ls-files", "-z").split(b"\0") if p]
for name in paths:
    path = root / name
    if path.name in ("auth.json","accounts.vault","accounts.json","owner.json") or path.suffix.lower() in (".vault",".pfx",".p12",".key",".pem",".sqlite",".db") or path.name.startswith(".env"):
        findings.append({"path":name,"kind":"private-data-file"})
    if any(part in ("bin","obj","artifacts","runtime","outputs","work") for part in path.relative_to(root).parts):
        findings.append({"path":name,"kind":"generated-or-private-directory"})
    if path.suffix.lower() in (".cs",".json",".csproj",".md",".txt",".py",".ps1",".sh",".css",".plist",".manifest"):
        inspect(name, path.read_bytes())
    if path.suffix.lower() in (".gif", ".png"):
        with Image.open(path) as media:
            if any(key in media.info for key in ("comment","exif","XML:com.adobe.xmp","Description","Software")):
                findings.append({"path":name,"kind":"unreviewed-image-metadata"})

objects = git("rev-list", "--objects", "--all").decode("utf-8").splitlines()
blob_count = 0
for entry in objects:
    oid, _, name = entry.partition(" ")
    if git("cat-file", "-t", oid).strip() != b"blob": continue
    data = git("cat-file", "blob", oid)
    blob_count += 1
    if b"\0" not in data[:4096]: inspect("history:" + name, data)
inspect("commit-identities", git("log", "--all", "--format=%an <%ae> %cn <%ce>"))
print(json.dumps({"trackedFiles":len(paths),"reachableBlobs":blob_count,"findings":findings,
                  "scope":"tracked source/text/media metadata, reachable text history, commit emails, common token formats and private file paths"}, indent=2))
raise SystemExit(1 if findings else 0)
