"""Package a cross-published .app preserving executable mode bits on Windows."""
from pathlib import Path
import stat
import sys
import zipfile

bundle, output = [Path(p).resolve() for p in sys.argv[1:]]
if not bundle.is_dir() or bundle.suffix != ".app":
    raise ValueError("Expected an application bundle")
with zipfile.ZipFile(output, "x", compression=zipfile.ZIP_DEFLATED, compresslevel=6) as archive:
    for path in sorted(bundle.rglob("*")):
        if path.is_symlink():
            raise ValueError("Unexpected symlink in Windows cross-published bundle")
        if not path.is_file():
            continue
        name = path.relative_to(bundle.parent).as_posix()
        executable = path.name == "CodexSwitch" or path.suffix == ".dylib" or path.name == "createdump"
        entry = zipfile.ZipInfo(name)
        entry.create_system = 3
        entry.external_attr = (stat.S_IFREG | (0o755 if executable else 0o644)) << 16
        entry.compress_type = zipfile.ZIP_DEFLATED
        archive.writestr(entry, path.read_bytes())
    installer = bundle.parent / "Install.command"
    if installer.is_file():
        entry = zipfile.ZipInfo("Install.command")
        entry.create_system = 3
        entry.external_attr = (stat.S_IFREG | 0o755) << 16
        entry.compress_type = zipfile.ZIP_DEFLATED
        archive.writestr(entry, installer.read_text(encoding="utf-8").encode("utf-8"))
print(output)
