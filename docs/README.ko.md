# Codex Switch

**Codex 계정 전환을 빠르고 편하게. 전환할 계정의 남은 사용량도 한눈에.**

[English](../README.md) · **한국어** · [日本語](README.ja.md) · [简体中文](README.zh-CN.md)

Windows와 macOS용 로컬 데스크톱 유틸리티입니다. 프로그램·타이틀바·실행 패키지 이름은 **Codex Switch**입니다. OpenAI의 공식 제품은 아닙니다.

<p align="center"><img src="media/compact.gif" width="500" alt="실사용 대시보드 — 계정 이름 영구 가림, 커서 제외" /></p>

- **계정 전환:** 계정별 브라우저 로그인, 현재 로그인 가져오기, 기존 인증 백업 후 선택한 계정 적용.
- **채팅 이어가기:** 진행 중인 로컬 주 채팅 이름을 날짜와 함께 저장하고 Codex를 정상 종료·재실행한 뒤 같은 채팅 ID를 다시 엽니다. 필요한 idle 채팅에만 Continue를 한 번 보냅니다.
- **선택을 돕는 사용량:** 계정별 실제 잔량, 리셋 시간, 요금제, 크레딧과 조건부 소진 예측.
- **작업 현황:** 로컬 실행/큐/목표 개수, CPU·메모리·GPU·VRAM 추이와 드라이브 잔량.
- **작은 창에서도 사용:** 크기별 카드 배치, 라이트/다크, 영어/한국어 UI, 트레이와 Mac 메뉴 막대.

새 설치는 영어가 기본입니다. 상단의 **English**에서 한국어로 즉시 변경할 수 있으며 기존 언어 설정은 보존됩니다. 일본어와 중국어는 문서 번역이며 앱 UI는 영어·한국어를 지원합니다.

실제 사용 중인 Windows v1.27 화면을 2배 해상도의 무손실 PNG로 기록하고 GIF로 변환했습니다. 외부 마우스/Codex 커서는 포함하지 않았습니다. 사용량은 합성하지 않았고 계정 이름은 원문 픽셀을 제거한 뒤 일반 대체 문구만 블러 처리했습니다. GIF는 실제 전환·채팅 재개의 성공 증거는 아닙니다.

<details><summary>일반 창</summary>

<p align="center"><img src="media/standard.gif" width="700" alt="일반 크기의 선명한 실사용 화면" /></p>

</details>
<details><summary>큰 창</summary>

<p align="center"><img src="media/large.gif" width="850" alt="큰 크기의 선명한 실사용 화면" /></p>

</details>

## 다운로드와 실행

[Windows x64](https://github.com/Gaebabi/codex-switch/releases/download/v1.27.0/CodexSwitch-v1.27.0-win-x64.zip) · [Mac Apple Silicon](https://github.com/Gaebabi/codex-switch/releases/download/v1.27.0/CodexSwitch-v1.27.0-osx-arm64.zip) · [Mac Intel](https://github.com/Gaebabi/codex-switch/releases/download/v1.27.0/CodexSwitch-v1.27.0-osx-x64.zip)

소스 빌드나 .NET 설치 없이 사용합니다. Windows는 ZIP 전체를 풀고 `CodexSwitch.exe`를 실행하세요. Mac은 전체를 풀고 `Install.command`로 설치한 뒤 `Codex Switch.app`을 엽니다. 패키지는 서명되지 않았으며 Mac 설치 시 로컬 ad-hoc 서명을 적용합니다. [릴리즈 안내와 체크섬](https://github.com/Gaebabi/codex-switch/releases/tag/v1.27.0)

## 소스에서 빌드

.NET 8 SDK 이상과 설치된 Codex 앱/CLI가 필요합니다.

```powershell
git clone https://github.com/Gaebabi/codex-switch.git
cd codex-switch
.\scripts\build.ps1 -Verify
.\artifacts\win-x64\CodexSwitch.exe
```

Windows 실행 패키지는 **artifacts/win-x64 폴더 전체**입니다. EXE만 복사하지 마세요.

```bash
bash scripts/build-macos.sh osx-arm64 # Apple Silicon
bash scripts/build-macos.sh osx-x64   # Intel
```

Mac 설치·서명·검증 경계는 [Mac 안내](MACOS.md)를 확인하세요. Mac 실제 로그인/전환/채팅 재개와 Intel 기기 검증은 별도 수용 항목입니다. 자동 업데이트는 아직 제공하지 않습니다.

## 사용과 개인정보

**Add account** 또는 옆의 계정 아이콘으로 등록한 뒤 전환할 카드의 **Switch**를 선택하세요. 계정 전환은 실제 Codex를 정상 종료·재실행하고 같은 인증 파일을 쓰는 CLI/IDE에도 영향을 줄 수 있습니다. [전환 동작](SWITCHING.md)을 먼저 확인하세요.

Windows는 DPAPI, Mac은 Keychain 키와 AES-GCM으로 로컬 vault를 보호합니다. 인증·vault·개인 로그를 공개 이슈에 첨부하지 마세요. [보안 안내](../SECURITY.md) · [기여 안내](../CONTRIBUTING.md) · [MIT 라이선스](../LICENSE)
