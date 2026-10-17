"""Capture real app/demo cards inside original Xfwm4 frames on an owned disposable X11 display."""
import argparse
import hashlib
import json
import os
from pathlib import Path
import re
import subprocess
import sys
import tempfile
import time
from PIL import Image

parser=argparse.ArgumentParser(description=__doc__)
parser.add_argument('--app',type=Path,required=True)
parser.add_argument('--output',type=Path,required=True)
parser.add_argument('--revision',required=True)
parser.add_argument('--inside',action='store_true')
args=parser.parse_args()
if sys.platform!='linux' or os.environ.get('CODEX_SWITCH_DISPOSABLE_RUNNER')!='true' or not re.fullmatch('[0-9a-f]{40}',args.revision):
    raise SystemExit('Only the declared disposable native Linux runner and exact source are allowed')
app=args.app.resolve(strict=True);output=args.output.resolve()
if not args.inside:
    if output.exists() or not output.is_relative_to(Path('artifacts').resolve()):raise SystemExit('Use a fresh owned artifact folder')
    environment=dict(os.environ)
    with tempfile.TemporaryDirectory(prefix='codex-framed-ui-') as temporary:
        for name in ['home','config','cache','data','runtime']:(Path(temporary)/name).mkdir(mode=0o700)
        environment.update(HOME=str(Path(temporary)/'home'),XDG_CONFIG_HOME=str(Path(temporary)/'config'),XDG_CACHE_HOME=str(Path(temporary)/'cache'),XDG_DATA_HOME=str(Path(temporary)/'data'),XDG_RUNTIME_DIR=str(Path(temporary)/'runtime'),CODEX_SWITCH_CAPTURE_WM_FRAMES='1')
        subprocess.run(['dbus-run-session','--','xvfb-run','-a','-s','-screen 0 1600x1000x24 -nolisten tcp',sys.executable,str(Path(__file__).resolve()),'--app',str(app),'--output',str(output),'--revision',args.revision,'--inside'],env=environment,check=True,timeout=180)
    raise SystemExit(0)
output.mkdir(parents=True);raw=output.parent/(output.name+'-raw')
if raw.exists():raise SystemExit('Raw capture directory must be fresh')
with (output.parent/(output.name+'-private.log')).open('wb') as log:
    manager=subprocess.Popen(['xfwm4','--compositor=off'],stdout=log,stderr=log)
    try:
        deadline=time.monotonic()+15
        while True:
            if manager.poll() is not None:raise RuntimeError('Original Xfwm4 process exited')
            probe=subprocess.run(['xprop','-root','_NET_SUPPORTING_WM_CHECK'],capture_output=True,text=True,timeout=5)
            if re.search(r'window id # 0x[0-9a-f]+',probe.stdout):break
            if time.monotonic()>=deadline:raise RuntimeError('Owned window manager did not become ready')
            time.sleep(.1)
        subprocess.run([str(app),'--verify-ui',str(raw)],stdout=log,stderr=log,check=True,timeout=120)
    finally:
        if manager.poll() is None:manager.terminate()
        manager.wait(timeout=10)
render=json.loads((raw/'render-report.json').read_text());report=json.loads((raw/'wm-report.json').read_text())
if render['failures'] or len(render['checks'])!=12 or report['failures'] or len(report['frames'])!=12:
    raise RuntimeError('Complete native app/card/frame verification is required')
images=[]
for frame in report['frames']:
    if frame['WindowManager']!='Xfwm4' or not all(frame[k] for k in ['OriginalAppPidVerified','DirectParentFrameVerified','DesktopRootExcluded']) or frame['DemoAccounts']!=4:
        raise RuntimeError('Original app PID, direct native frame and four demo cards must be verified')
    name=frame['File']
    if not re.fullmatch(r'(en|ko)-(dark|light)-(500x360|600x420|800x600)-native-wm\.png',name):raise RuntimeError('Unexpected frame filename')
    with Image.open(raw/name) as image:
        image.load();width,height=map(int,re.search(r'(\d+)x(\d+)',name).groups())
        if not (width<image.width<width+100 and height<image.height<height+100):raise RuntimeError('Original native OS frame is missing or unrelated')
        clean=Image.new('RGB',image.size);clean.paste(image.convert('RGB'));clean.save(output/name)
    with Image.open(output/name) as checked:
        if checked.info:raise RuntimeError('Image metadata must be absent')
    images.append(dict(frame,file=name,sha256=hashlib.sha256((output/name).read_bytes()).hexdigest(),width=clean.width,height=clean.height))
value={'schema':1,'revision':args.revision,'os':'Linux','architecture':render['architecture'],'appVersion':render['version'],'runtime':render['runtime'],
       'windowManager':'Xfwm4','nativeWindowCapture':True,'renderChecks':12,'images':images,
       'scope':'Actual published app on an owned native X11 display with four fictional cards and original direct-parent Xfce titlebar. No titlebar composition, owner data, real login or authenticated handoff/full-desktop claim.'}
(output/'evidence.json').write_text(json.dumps(value,indent=2)+'\n',encoding='utf-8')
print(json.dumps({'nativeFramedImages':12,'appAndOsFrameTogether':True,'fictionalCards':4,'noOwnerData':True}))
