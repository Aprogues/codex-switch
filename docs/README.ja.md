# Codex Switch

**Codex アカウントを切り替える。次に使うアカウントの残り利用枠もひと目で確認。**

[English](../README.md) · [한국어](README.ko.md) · **日本語** · [简体中文](README.zh-CN.md)

Windows / macOS 向けのローカルデスクトップツールです。実行ファイルとアプリ名は引き続き **Codex Switch** です。OpenAI の公式製品ではありません。

![実際のコンパクト画面。アカウント名は元の画素を消去して匿名化](media/compact.gif)

- ブラウザログインで複数のアカウントを登録し、現在のログインを取り込み、**Switch** で切り替えます。
- 切り替え時はローカルの実行中ルートチャット名を日付付きで保存し、Codex を通常終了して新しいアカウントで再起動。同じチャット ID を開き、必要な待機中の続きに一度だけ **Continue** を送ります。
- アカウントごとの実測残量、リセット時間、プラン、クレジット、条件付きの消費予測を表示します。
- ローカルの実行・キュー・目標数、CPU / メモリ / GPU / VRAM の推移、ディスク空き容量を確認できます。
- サイズに応じたカード配置、ライト / ダーク、Windows トレイ、Mac メニューバーを備えています。

新規インストールの既定言語は英語です。アプリ UI は英語と韓国語に対応し、日本語はドキュメント翻訳です。既存の言語設定は保持されます。

GIF は日常使用中の Windows v1.26 を録画したものです。利用量は合成していません。名前の元画素を消去した後に汎用のぼかしを重ねています。実際の切り替え・チャット再開は録画していません。[標準サイズ](media/standard.gif) · [大きいサイズ](media/large.gif)

## ビルドと使用

.NET 8 SDK 以降と Codex アプリ / CLI が必要です。

```powershell
git clone https://github.com/Gaebabi/codex-switch.git
cd codex-switch
.\scripts\build.ps1 -Verify
.\artifacts\win-x64\CodexSwitch.exe
```

Windows では `artifacts/win-x64` フォルダー全体を配布してください。

```bash
bash scripts/build-macos.sh osx-arm64
bash scripts/build-macos.sh osx-x64
```

[Mac の手順](MACOS.md)を参照してください。実アカウントの Mac ログイン・切り替え・チャット再開、Intel 実機の受け入れ検証は別途必要です。GitHub Release と自動更新はまだありません。

アカウント切り替えは Codex を再起動し、同じ認証ファイルを使う CLI / IDE にも影響します。[切り替え動作](SWITCHING.md)と[セキュリティ](../SECURITY.md)を確認してください。認証・vault・個人ログを公開しないでください。[貢献](../CONTRIBUTING.md) · [MIT](../LICENSE)
