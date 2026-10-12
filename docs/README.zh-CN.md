# Codex Switch

**轻松切换 Codex 账号，先看清下一个账号的剩余额度。**

[English](../README.md) · [한국어](README.ko.md) · [日本語](README.ja.md) · **简体中文**

适用于 Windows 和 macOS 的本地桌面工具。可执行文件和应用包仍使用 **Codex Switch** 名称。本项目不是 OpenAI 官方产品。

![日常使用中的紧凑界面；账号名称已永久遮盖](media/compact.gif)

- 通过浏览器登录添加多个账号，导入当前 Codex 登录，点击 **Switch** 切换。
- 切换时先为本地正在运行的主聊天名称保存日期后缀，正常退出 Codex 后应用选定账号并重新启动，打开相同聊天 ID，仅向需要继续的空闲聊天发送一次 **Continue**。
- 显示各账号的真实剩余额度、重置时间、套餐、积分和有条件的耗尽预测。
- 观察本地运行 / 队列 / 目标数量、CPU / 内存 / GPU / VRAM 趋势及磁盘剩余空间。
- 支持自适应卡片布局、浅色 / 深色主题、Windows 托盘和 Mac 菜单栏。

新安装默认使用英语。应用界面支持英语和韩语；中文仅为说明文档翻译。现有语言偏好会保留。

GIF 来自日常使用中的 Windows v1.26，使用量不是模拟数据。账号名称区域先覆盖原始像素，再添加通用模糊占位内容，不保留原始名称。GIF 展示额度和布局，没有录制实际账号切换或聊天恢复。[标准窗口](media/standard.gif) · [大窗口](media/large.gif)

## 构建与使用

需要 .NET 8 SDK 或更高版本，以及已安装的 Codex 应用 / CLI。

```powershell
git clone https://github.com/Gaebabi/codex-switch.git
cd codex-switch
.\scripts\build.ps1 -Verify
.\artifacts\win-x64\CodexSwitch.exe
```

Windows 请保留整个 `artifacts/win-x64` 文件夹，不要只复制 EXE。

```bash
bash scripts/build-macos.sh osx-arm64
bash scripts/build-macos.sh osx-x64
```

详见 [Mac 指南](MACOS.md)。Mac 真实登录 / 切换 / 聊天恢复和 Intel 实机验证仍是单独验收项。暂不提供 GitHub Release 或自动更新。

切换会正常退出并重启 Codex，也可能影响使用同一认证文件的 CLI / IDE。使用前请阅读[切换说明](SWITCHING.md)和[安全说明](../SECURITY.md)。不要上传认证文件、账号 vault 或私人日志。[贡献指南](../CONTRIBUTING.md) · [MIT 许可](../LICENSE)
