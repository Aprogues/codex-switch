# Usage history design evidence

The approved design improves the shared Avalonia history window used by macOS and the Linux source preview. Windows WPF has a separate history view.

## Actual application baseline

| Dark baseline | Light baseline |
| --- | --- |
| ![Actual English Mac history baseline, fictional usage](before/en-dark-history-native.png) | ![Actual English Mac history baseline, fictional usage](before/en-light-history-native.png) |

Source `ec26e9fa9ee008b880ec8717a1e5b04f23781fe5`, app 1.37.0, native macOS ARM64. The history window and chart sources are unchanged in an external source archive; capture-only host instrumentation supplies a fictional Demo account and the same synthetic usage pattern in both themes. Increasing measured usage is drawn downward, chart axes are absent, and the selected range is indistinguishable from other buttons. [Baseline image hashes and capture scope](before/evidence.json).

Implementation and actual after confirmation are pending. The approved external design prototype is not production acceptance. All published screenshots and captions for this change use English.

Only app-owned NSWindows are captured. Images contain fictional input from inception and have no ancillary PNG metadata. No personal desktop, credential, home path, account switching or chat resumption is involved. Public downloads remain 1.27.6.
