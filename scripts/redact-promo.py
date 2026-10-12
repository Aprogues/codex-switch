"""Redact live dashboard recordings before GIF export. Requires Pillow.

Every frame's identity rectangles are replaced with source-independent pixels.
Only a generic placeholder is blurred; original identity pixels are never blurred.
Private input paths are not included in public receipts or GIF metadata.
"""
import argparse
import hashlib
import json
from pathlib import Path
from PIL import Image, ImageDraw, ImageFilter

parser = argparse.ArgumentParser()
parser.add_argument("input", type=Path)
parser.add_argument("output", type=Path)
parser.add_argument("--rects", required=True, help="JSON list of [left,top,right,bottom] rectangles covering ALL names and aliases")
args = parser.parse_args()
rects = json.loads(args.rects)
paths = sorted(args.input.glob("*.png")) or sorted(args.input.glob("*.jpg"))
times = json.loads((args.input / "timing.json").read_text())
if not paths or len(paths) != len(times) or len(rects) != 4:
    raise ValueError("Expected a four-account recording and one timestamp per frame")
frames = []
size = Image.open(paths[0]).size
for path in paths:
    frame = Image.open(path).convert("RGB")
    if frame.size != size:
        raise ValueError("Window resized during recording; reject this capture")
    for index, rect in enumerate(rects):
        left, top, right, bottom = rect
        if not (0 <= left < right <= size[0] and 0 <= top < bottom <= size[1]):
            raise ValueError("Identity rectangle outside frame")
        replacement = Image.new("RGB", (right-left, bottom-top), "#e0e4e9")
        draw = ImageDraw.Draw(replacement)
        draw.text((5, 3), "Private account " + str(index+1), fill="#52606e")
        replacement = replacement.filter(ImageFilter.GaussianBlur(4))
        frame.paste(replacement, (left, top))
        if frame.crop(rect).tobytes() != replacement.tobytes():
            raise ValueError("Identity pixels were not completely overwritten")
    frames.append(frame)
durations = [max(20, round((b-a)/10)*10) for a,b in zip(times, times[1:])]
durations.append(durations[-1] if durations else 250)
args.output.parent.mkdir(parents=True, exist_ok=True)
palette = frames[0].quantize(colors=256, dither=Image.Dither.NONE)
indexed = [frame.quantize(palette=palette, dither=Image.Dither.NONE) for frame in frames]
indexed[0].save(args.output, save_all=True, append_images=indexed[1:], duration=durations,
               loop=0, optimize=False, disposal=2)
with Image.open(args.output) as gif:
    count = gif.n_frames
    if gif.size != size or count < 2 or "comment" in gif.info or "exif" in gif.info:
        raise ValueError("Invalid animation or unexpected metadata")
    for i in range(count):
        gif.seek(i)
        decoded = gif.convert("RGB")
        for rect in rects:
            if decoded.crop(rect).getbbox() is None:
                raise ValueError("Unexpected empty identity cover")
frames[0].save(args.output.with_suffix(".png"))
print(json.dumps({"file":args.output.name, "width":size[0], "height":size[1], "frames":count,
                  "durationMs":sum(durations), "sha256":hashlib.sha256(args.output.read_bytes()).hexdigest(),
                  "identityRectangles":rects, "identityPolicy":"source pixels replaced before generic placeholder blur",
                  "source":"live Windows Codex Switch 1.27 lossless WPF visual; no account switch performed"}))
