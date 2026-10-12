# macOS 사용 안내

1.25는 기존 Windows WPF 실행 화면을 유지하고 별도의 Avalonia macOS 화면에서 같은 계정, 사용량, 추이 예측, 전환, 세션/큐 집계 코어를 사용합니다. Apple Silicon과 Intel용 앱 번들을 제공합니다. MacBook에서 네이티브 저장소·자원·합성 화면을 검증했으며 실제 로그인/전환/채팅 재개와 Intel 기기 수용은 별도입니다.

## 설치

macOS 12 이상과 설치된 Codex 데스크톱 앱이 필요합니다. Apple Silicon은 `osx-arm64`, Intel은 `osx-x64` ZIP을 사용하세요. 자체 포함 패키지이므로 앱 실행에 .NET SDK/런타임은 필요하지 않습니다.

1. ZIP 전체를 압축 해제합니다. 내부의 `Codex Switch.app` 파일 구조를 유지합니다.
2. 기존 Account Desk가 실행 중이면 메뉴의 종료 또는 Cmd+Q로 끝냅니다. 창 닫기는 메뉴 막대에 남는 동작입니다.
3. 같은 폴더의 `Install.command`를 실행합니다. 같은 설치 볼륨의 임시 폴더에 복사하고 plist·로컬 ad-hoc 서명·`--help` 기동을 확인한 뒤 `~/Applications`에 설치합니다. 기존 설치본은 날짜를 붙인 별도 앱으로 보존하며 교체가 실패하면 복원합니다. 계정 데이터는 이동/삭제하지 않습니다. 실행 중인 Account Desk가 있으면 설치를 진행하지 않습니다.
4. Finder에서 설치된 앱을 엽니다. Keychain 접근 요청이 나오면 이 앱의 저장소 키 접근을 허용합니다. Dock의 옵션에서 Dock에 유지를 선택할 수 있습니다.

Windows에서 만든 ZIP은 Developer ID 서명/공증이 없는 테스트 후보입니다. macOS가 확인을 요구하면 시스템의 앱 열기 절차를 따르세요. Gatekeeper를 끄거나 quarantine를 자동 삭제하는 코드는 포함하지 않습니다. 소스 빌드를 선호하면 아래 명령을 사용하세요.

## Mac에서 빌드

.NET 8 SDK 이상과 NuGet 연결이 필요합니다. 빌드 스크립트는 테스트나 앱 실행을 하지 않습니다.

```bash
bash scripts/build-macos.sh
# 또는
bash scripts/build-macos.sh osx-arm64
bash scripts/build-macos.sh osx-x64
```

출력은 `artifacts/macos/<rid>/<UTC timestamp>/` 아래의 앱 번들과 ZIP입니다. ZIP에는 `Install.command`도 들어갑니다. 기본 서명은 로컬 ad-hoc이며 `MAC_CODESIGN_IDENTITY`를 지정하면 빌드에 해당 identity를 사용할 수 있습니다. 공증과 외부 배포는 별도 작업입니다.

Windows에서 cross-publish하려면 다음 명령을 사용합니다. Python은 ZIP의 Unix 실행 권한을 기록하는 패키징 단계에만 필요합니다. 아이콘 PNG/ICNS는 저장소에 포함되어 있습니다.

```powershell
.\scripts\build-macos.ps1
```

## Mac에서 검증

```bash
bash scripts/verify-macos.sh
# 빌드한 자체 포함 앱을 검사할 경우
bash scripts/verify-macos.sh "/path/to/Codex Switch.app/Contents/MacOS/CodexSwitch"
# ZIP 서명 보존과 격리된 설치 교체/실패 검사
python3 scripts/verify-macos-install.py "/path/to/CodexSwitch-osx-arm64.zip"
```

.NET 빌드 검사에는 SDK, SQLite/WAL 검사에는 Python 3이 필요합니다. 보고서와 합성 PNG는 Git 제외 `artifacts/macos-verification/`에 저장합니다. 네이티브 검사는 계정이 없는 임시 저장소의 Keychain 암호화/재로드/변조 거절, 0700/0600 권한, 원자 교체·symlink 거절, 같은 UID 소켓과 실제 Mach/IOKit/루트 볼륨 조회를 확인합니다. 임시 Keychain 항목은 검사 후 삭제합니다. 합성 화면은 실제 Avalonia 네이티브 창에서 500×360/600×420/800×600, 두 언어·두 테마와 0/1/8개 계정 상태를 렌더합니다. 실제 계정과 Codex 채팅을 변경하지 않습니다.

## 저장소와 Codex 연결

- 앱 데이터: `~/Library/Application Support/CodexSwitch/accounts.vault`
- 저장소: AES-256-GCM, 데이터 폴더별 키는 macOS Keychain의 `com.gaebabi.codex-account-desk.vault` 서비스에 보관합니다. 폴더 권한은 0700, 인증/저장 파일은 0600으로 만듭니다.
- Codex home: `CODEX_HOME` 또는 `~/.codex`
- Codex 연결: 선택한 home의 `ipc/ipc.sock`, 같은 UID의 Unix 소켓 peer만 허용합니다.
- 큐: 선택한 home의 JSON과 SQLite/WAL, macOS 시스템 `libsqlite3.dylib`를 읽기 전용으로 사용합니다.

Windows의 DPAPI 저장소는 Mac에서 복호화할 수 없습니다. Mac의 계정 추가에서 별도로 등록하세요. Keychain 키가 없거나 복호화가 실패하면 새 키/빈 저장소로 덮어쓰지 않습니다.

새 로컬 빌드로 ad-hoc 서명이 바뀌면 기존 키 접근 인증이 다시 표시될 수 있습니다. 이 경우 Mac의 Keychain 시스템 창에서 직접 인증해야 초기화가 이어집니다. 비밀번호를 앱이나 채팅에 입력하지 마세요. 키/저장소를 삭제해 인증 요청을 우회하지 않습니다.

계정 전환은 Codex의 **file 로그인 저장 방식**을 사용합니다. 앱 자체 저장소의 Keychain 암호화와 Codex의 로그인 저장 방식은 별개입니다. Codex 설정에 `cli_auth_credentials_store = "keyring"` 또는 `"auto"`가 지정되어 있으면 전환을 시작하기 전에 해당 설정을 file 방식으로 바꾸어야 합니다. 앱이 사용자 설정이나 기존 Keychain 로그인을 자동으로 덮어쓰지는 않습니다.

```toml
# ~/.codex/config.toml의 최상위 설정
cli_auth_credentials_store = "file"
```

실행 중인 `com.openai.codex` 번들을 우선 찾아 실제 executable을 읽고 `/Applications/Codex.app`, `~/Applications/Codex.app`을 탐색합니다. bundled CLI와 Homebrew/PATH의 CLI도 조회합니다. 필요한 경우 다음 환경변수와 명령행 옵션을 사용할 수 있습니다.

```bash
export CODEX_ACCOUNT_DESK_DESKTOP="/Applications/Codex.app"
export CODEX_ACCOUNT_DESK_CLI="/Applications/Codex.app/Contents/Resources/codex"
"$HOME/Applications/Codex Switch.app/Contents/MacOS/CodexSwitch" --codex-home "$HOME/.codex"
```

## 플랫폼 동작

계정별 비동기 조회, 로그인 직후 즉시 조회, 한국어/영어, 라이트/다크, 작은 창의 두 열 카드, 잔량 수치와 사용 중인 카드의 물결, History, 리셋/구독 D-day/초기화권/크레딧 표시를 연결했습니다. 주 채팅/큐/목표 수와 계정 조회의 갱신 주기는 독립적입니다. 전환은 이름 날짜 백업을 모두 확인한 뒤 NSRunningApplication의 정상 종료 요청으로 Codex를 닫고, 완전 종료 확인 후 로그인 파일을 적용합니다. 같은 번들과 같은 채팅 ID를 다시 열며 필요한 경우에만 기존 단일 Continue 흐름을 사용합니다. forceTerminate/killall이나 실제 채팅 파일 덮어쓰기를 사용하지 않습니다.

CPU는 Mach 전체 CPU tick의 차이로 계산합니다. MEM은 전체 물리 메모리에서 free/inactive 페이지를 제외한 사용 비율로, macOS 활동 모니터의 메모리 압력 지표와는 정의가 다릅니다. GPU는 IOKit 드라이버의 `Device Utilization %`/`GPU Activity(%)`를 사용합니다. 전용 VRAM 용량과 전역 사용량을 모두 제공하는 장치만 VRAM 비율을 계산합니다. Apple Silicon의 통합 메모리를 전용 VRAM으로 표시하거나 이 앱 프로세스의 Metal 할당을 PC 전체 값으로 쓰지 않습니다. 미지원 지표는 `—`와 tooltip으로 구분합니다. 최근 2분 그래프와 70/85% 경고 기준을 유지합니다.

드라이브는 기본 `/` 볼륨이며 설정에서 로컬 mounted volume, 표시 이름, 순서를 선택할 수 있습니다. 경로의 대소문자를 보존하고 네트워크 볼륨은 제외합니다. 좁은 창에서 표시 가능한 볼륨만 나열하며 전체 선택의 실제 잔량은 tooltip에서 확인합니다. 메뉴 막대와 Dock에서 앱을 다시 열 수 있습니다.

⌘R/F5 또는 상단 ↻로 갱신하고 초기화 실패도 다시 시도합니다. ⌘N은 계정 추가, ⌘O는 창 열기, ⌘W는 창 숨기기, ⌘Q는 종료입니다. 계정이 많으면 두 열 카드의 최소 높이를 유지하며 스크롤합니다. 계정 메뉴에는 해당 계정만 즉시 갱신하는 항목이 있습니다. 이름/볼륨 대화상자는 Enter로 저장하고 Escape로 취소합니다. History의 한도/기간 버튼은 작은 창에서도 줄바꿈합니다.

창은 상단의 `Codex Switch` 제목 또는 그 옆 빈 공간을 잡아 이동합니다. 언어/테마/설정 버튼과 macOS 창 제어 버튼은 드래그를 시작하지 않습니다. 버튼 글자는 가로·세로 중앙에 맞추고 메뉴/갱신/위아래 이동 아이콘은 같은 크기의 벡터로 표시합니다.

상단 메뉴 막대에는 단색 계정 심볼과 현재 계정의 잔여 %가 표시됩니다. 기본값은 가장 적게 남은 한도이며, 현재 계정 카드에서 다른 한도를 선택하면 메뉴 막대도 같은 값을 표시합니다. 조회된 값이 없거나 현재 계정이 없으면 `—`입니다. 심볼은 macOS template 이미지로 주변 메뉴와 같은 흰색/검은색 전경에 맞춰지고, %는 네이티브 텍스트라 긴 숫자도 잘리지 않습니다. 클릭하면 열기·계정 추가·새로 고침·취소·종료를 사용할 수 있으며 창을 닫거나 ⌘W로 숨겨도 유지됩니다. 앱을 종료하면 메뉴 막대 항목도 사라집니다.

## 사용자 확인 항목

- Apple Silicon/Intel에서 설치, 첫 실행, Keychain 허용, 종료/재실행, Dock/메뉴 막대 재열기
- 계정 추가, 각 계정의 실제 사용량/플랜/구독/리셋/크레딧과 비동기 버튼 동작
- 테스트용 진행 채팅의 날짜 백업, 정상 종료, 실제 계정 전환, 같은 ID 재개와 Continue 중복 방지
- 큐 추가/취소/소진의 개수 변화, 주 채팅/하위 채팅/Goal 수, 연결 종료 후 복구
- 최소 500x360, 두 언어/두 테마의 카드, 숫자/버튼/팝업/History/물결
- 실제 장치의 CPU/MEM/GPU/VRAM 제공 여부와 볼륨 잔량/설정 저장

참고: [Avalonia macOS 번들](https://docs.avaloniaui.net/docs/deployment/macos), [Apple Keychain](https://developer.apple.com/documentation/security/adding-a-password-to-the-keychain), [Apple Mach 메모리 ABI](https://github.com/apple-oss-distributions/xnu/blob/main/osfmk/mach/vm_statistics.h). 설치 앱에서 확인한 내부 IPC version 11과 SQLite 스키마는 외부 확장 계약이 아니며 다른 Codex 버전의 실제 호환은 사용자 테스트에 포함합니다.
