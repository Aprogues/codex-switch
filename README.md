# Codex Switch

Switch Codex accounts and see what is left before you choose the next one. **Windows and macOS / 1.27.6**

[English](README.md) / [한국어](docs/README.ko.md) / [日本語](docs/README.ja.md) / [简体中文](docs/README.zh-CN.md)

![Fictional everyday demo: varied balances, stable resources and status colors](docs/media/demo.png)

*Fictional everyday data: different account balances, gentle resource fluctuations and normal/caution states. Rendered with the current Windows UI and rounded window frame.*

## Get started

1. Use a complete Windows or Mac package. Windows: run `CodexSwitch.exe`. Mac: run `Install.command`, then open **Codex Switch.app**. [Build and install](docs/INSTALL.md)
2. Select **+** in the title bar to add accounts. On Windows, right-click **↻** to import the current Codex login.
3. Compare the cards and select **Switch**. Reads refresh every 60 seconds; **↻** or **F5** refreshes immediately.

Keep the full package together. Packaged apps need no .NET installation; building source requires the .NET 8 SDK and installed Codex desktop/CLI.

## What you can see

- Remaining quota, reset countdown, plan, subscription end date, reset credits and credit balance.
- Recent usage and a depletion estimate based on usage history. Open **History** from an account's **...** menu.
- Local running/queued/goal counts, resource trends and configurable drive free space. Hover a gauge for details.

The title bar has language and light/dark settings. The UI supports English and Korean; Japanese and Chinese are documentation translations.

**Switching restarts Codex** and reopens the same local chats. It can also affect CLI/IDE clients sharing the login. [Switching details](docs/SWITCHING.md)

## More

[Mac setup](docs/MACOS.md) / [Forecast](docs/FORECAST.md) / [Security](SECURITY.md) / [Development](CONTRIBUTING.md)

The repository is private and public distribution is paused. This is independent software, not an official OpenAI product. Credentials stay in a local encrypted vault. [MIT](LICENSE) / [Asset notices](Burn0Assets.LICENSE.txt)
