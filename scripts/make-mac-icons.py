"""Package the supplied Codex Switch mark into Windows and Mac icon sizes (Pillow)."""
from pathlib import Path
from PIL import Image

root = Path(__file__).resolve().parents[1]
image = Image.open(root / "Assets/mark.png").convert("RGBA")
if image.width != image.height or image.getextrema()[3][0] != 0:
    raise ValueError("Expected a square mark with genuine transparency")
image.resize((256, 256), Image.Resampling.LANCZOS).save(
    root / "Assets/app-icon.ico", format="ICO", sizes=[(16, 16), (24, 24), (32, 32), (48, 48), (64, 64), (128, 128), (256, 256)])
image.resize((1024, 1024), Image.Resampling.LANCZOS).save(root / "macos/Assets/app-icon.icns", format="ICNS")
image.resize((128, 128), Image.Resampling.LANCZOS).save(root / "macos/Assets/app-icon.png")
