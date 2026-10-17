# Codex Switch 1.40.7: native Windows and Linux windows

Actual application windows from capture revision `a3f4d5f3a2e0c54378f5371682b1d928700c6c50`, source1.40.7/.NET10.0.13. [Windows verification](https://github.com/Gaebabi/codex-switch/actions/runs/39011565929) and [Linux native verification](https://github.com/Gaebabi/codex-switch/actions/runs/39011565994) passed all six protected checks before PR90 merged. [Original/presentation hashes and scope](gallery.json).

![Actual Windows application with the visible CPU download button](windows.png)

Windows uses the published WPF application with fictional accounts and sensor inputs. The download icon is a real button; driver/worker authorization remains explicit. This picture does not claim physical CPU availability. [Actual app before/after and sensor security evidence](../../evidence/cpu-setup/README.md).

![Actual installed Linux application with its original Xfce titlebar](linux.png)

Linux uses the ordinary per-user installed app with an empty account home and real Xfce/xfwm4 frame in isolated Debian13 userspace. [53-check session receipt](linux-session.json) covers lifecycle, original encrypted-key preservation, automatic initialization after unlock and offline managed-client integration. It is not a booted VM, full GNOME/KDE/Wayland/ARM64 desktop or authenticated active-chat continuation claim. Linux stays an unsigned integration preview.

The original titlebar/window pixels remain unchanged at1:1, centered on a solid1000×800 `#18202b` background. No personal desktop, cursor, account identity or authentication pixels are captured. Metadata is removed and final images visually inspected. Capture and final Release package revisions are deliberately distinct; the Release receipt binds final artifacts, reviewed source and merged tree.

**MacBook real-device screenshot remains reserved for the maintainer.** macOS downloads remain1.40.2. Do not relabel CI pictures as the owner's MacBook capture.
