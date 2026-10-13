# 운영 안내

## 유일한 정본 (2026-10-14)

사용자 요청으로 최신 1.27.6 코드, 아이콘, Windows/Mac UI, 개발 문서와 개인 검증 자료를 `D:/Git/codex-switch`에 통합했다. GitHub 정본은 `Gaebabi/codex-switch`, private, `main`이다. 이전 `D:/Git/codex-account-desk` 및 GitHub `Gaebabi/codex-account-desk`는 검증한 복구 자료를 남긴 뒤 삭제했고, 로컬 경로 부재/GitHub 삭제 성공 메시지와 인증 API404를 확인했다. 새 작업/빌드/배포는 codex-switch만 사용한다. 사용자가 통합 커밋/푸시를 명시 승인했으며 원격 main SHA 일치로 확인한다. 저장소 복구 자료와 정리 상태는 `REPOSITORY.md`가 소유한다. 과거 날짜의 로그에 있는 이전 경로는 당시 기록이며 현재 정본을 뜻하지 않는다. 계정 vault/home/호환 namespace와 설치된 앱 경로는 그대로 유지한다.

## 현재 공개 중단 상태 (2026-10-13)

사용자가 공개/Release/공증 작업을 취소하고 개인 사용으로 전환했다. `Gaebabi/codex-switch` 완전 삭제는 토큰의 delete_repo 권한 부족으로403거절되어 private으로 전환했고 비로그인 저장소/Release접근404를 확인했다. 실제삭제는아직안됐다. 기존 `Gaebabi/codex-account-desk` private과개인소스/계정/실행패키지는보존한다. 아이콘변경은현재checkout에유지하며만족확인/직접요청없이추가commit/push하지않는다. 이후공개/Release/공증은새사용자요청이있을때만재개한다.

2026-10-14 Windows 개인 설치는 `%LOCALAPPDATA%/Programs/CodexSwitch/1.27.6`의 전체 폴더 패키지를 사용한다. 바탕화면 `Codex Switch.lnk`는 이 버전의 `CodexSwitch.exe`와 같은 폴더의 흰색 채움 `app-icon.ico`를 가리키며 기존 `%LOCALAPPDATA%/CodexAccountDesk` 및 기본 Codex home을 명시 인자로 전달한다. 이전 버전 폴더와 outputs 패키지는 보존한다. 버전 디렉터리를 실행 중에 덮지 않고 호환 `--request-exit --data-dir <기존 경로>`로 유틸리티만 정상 종료한 뒤 교체한다. native Codex 종료나 계정 전환은 설치 단계에 포함하지 않는다. 바로가기의 icon 경로 변경 후 Shell 변경 알림으로 갱신하며 Explorer 종료나 전역 아이콘 캐시 삭제는 하지 않는다.

1.27.1은 계정 추가/사용량 새로고침을 타이틀바 우측의 아이콘 버튼으로 제공한다. Windows에서 현재 로그인 가져오기는 새로고침 우클릭 메뉴에 있으며 기존 비동기 갱신/로그인 게이트를 유지한다. 아이콘 생성은 `python scripts/vectorize-mark.py` → Windows build → `CodexSwitch.exe --export-icons <ignored directory>` → `python scripts/make-mac-icons.py <same directory>` → Windows rebuild 순서다. 기존 mark의 최외곽 contour를 `mark-body.path`로 저장해 흰 바탕을 먼저 그린다. 테마를 따르는 titlebar/template mark는 기존 geometry를 사용한다. 실제 실행 중인 대시보드 확인은 `--data-dir <동일 경로> --record-dashboard <private directory>`로 capture 후 창 크기/위치를 복원하며 개인 캡처는 Git에 넣지 않는다.

1.27.2 메뉴는 `DropdownTheme.Create(owner, theme)`로 생성하고 popup 자체 Resources에 완전한 ContextMenu/MenuItem/Separator 템플릿을 설치한다. 창 리소스나 기본 Windows 패널에 의존하지 않으며, 12px shadow 여백을 제외한 실제 패널 오른쪽 끝을 owner에 맞춘다. 아래/위 후보 위치는 WPF가 화면 가용 영역에 따라 선택한다. owner가 unload되면 열린 메뉴를 닫고 Closed에서 임시 이벤트 구독을 해제한다. 선택은 Header 공백 대신 IsChecked로 표시하고, WPF 메뉴의 separator 전용 resource key도 동일 테마를 사용한다. Mac `DeskTheme.Menu(owner)`는 해당 메뉴에 직접 스타일을 제공하며 창의 native menu bar는 AppKit 기본 동작을 유지한다.

1.27.4는 실행/큐/목표를 카드 위 중앙의 한 줄에 표시하고 계정 개수 문구를 제거한다. 하단은 CPU/MEM/GPU/VRAM 한 줄, 드라이브/기존 설정 한 줄이다. 수집/경고/추이 계산은 그대로 유지한다. 최소 창의 카드 잔량이 잘리지 않도록 counters 높이와 외부 여백을 함께 조정했다.

1.27.6은 타이틀바의 계정/사용량 문구와 이를 숨기던 크기별 분기를 제거한다. 실행/큐/목표는 각각 라벨과 숫자를 6px 간격으로 묶고 항목 사이에는 24px 간격을 둔다. Windows의 숫자 우측 정렬과 고정 64px 칸을 제거하고 내용 폭으로 중앙 정렬하며 Mac에도 같은 간격을 적용한다. 카운터 행 높이와 카드/자원 배치는 유지한다. 실제 500x360, 700x550, 1000x700 Windows 대시보드에서 세 묶음/중앙 배치/네 카드 잔량을 확인했다. Mac은 source compile 근거만 있다.

현재 호스트에서 PowerShell/pwsh 시작이 출력 없이 지연될 때는 CMD에서 `dotnet publish CodexAccountDesk.csproj -c Release -r win-x64 --self-contained true --nologo -p:UseSharedCompilation=false -o artifacts/win-x64`를 직접 실행할 수 있다. 2026-10-14에는 동일 publish 및 Mac build가 정상 완료됐고, 개인 적용 helper는 Python의 DPAPI/프로세스 관측/IPC 종료와 cscript의 WMI 시작/shortcut COM을 사용했다. helper와 개인 receipt는 ignored artifacts에만 있다. 실제 Codex 프로세스 보존은 이전 유틸리티의 하위 프로세스를 제외한 PID/실행 경로를 비교하며 GUI 앱 폴더 이름으로 가정하지 않는다. 소스 수정은 계속 apply_patch를 사용한다.

## 자체 툴팁 (1.27.5)

Windows `ToolTipTheme`는 일반 tooltip의 전체 template을 Burn0 배경/폰트/라운드/그림자로 구성한다. 자원용 ResourceToolTip은 제목/현재값/줄바꿈 설명을 유지하는 재사용 control이다. CPU/MEM/GPU/VRAM 및 드라이브 owner의 InitialShowDelay/BetweenShowDelay는0이며 화면 가용 영역에 따라 위/아래로 배치한다. 현재값은 열린 tooltip 안에서 변경하고, DriveUsagePanel은 root 구성이 바뀔 때만 cell을 재생성한다. Mac도 명시적 tooltip theme과 자원 control을 사용하고 hardware/volume cell을 갱신마다 지우지 않는다.

입장은120ms ease-out opacity/작은 이동이며 첫 프레임의 base opacity를0으로 설정해 깜빡임을 막는다. Windows ClientAreaAnimation이 꺼져 있거나 Mac NSWorkspace의 reduce-motion이 켜져 있으면 움직임 없이 표시한다. 2026-10-14 이 Windows 호스트는 해당 animation 설정이 꺼져 있어 실제 hover는 즉시 표시다. motion-enabled 경로는 격리된 renderer에서 별도 확인했다. shadow/popup는 클릭을 가로채지 않고 native tooltip service가 이탈/owner unload 때 닫는다.

시각/호버 진단은 ignored artifacts의 별도 WPF probe이며 제품 source에는 포함하지 않는다. Windows project는 artifacts/**/*.cs를 Compile에서 제외한다. UIAutomation bounding rectangle은 실제 pixel 좌표이므로 probe는 PerMonitorV2 context에서 cursor/screenshot 좌표를 사용해야 한다. 초기 DPI-unaware 관측은 tooltip 실패 판정에 쓰지 않는다. 실제 계정/인증/native Codex를 변경하는 테스트는 수행하지 않는다.

## 웹 계정과 여러 컴퓨터 연동 기술 검토 (2026-10-14)

이 항목은 사용자가 요청한 기술 검토다. 구조와 검증 순서를 제안하며 구현/서비스 공개 승인이나 기존 공개 중단 상태 변경을 뜻하지 않는다. 동일 사용자가 소유한 계정을 자신의 승인된 컴퓨터들에 연동하는 범위를 전제로 한다.

### 가능 범위와 현재 소스

| 범위 | 판단 | 조건 |
| --- | --- | --- |
| Codex Switch 서비스 로그인, 계정 목록/별칭/설정 복원 | 구현 가능 | 서비스 사용자 인증, 계정 연결 확인, 기기 등록 및 sync API 필요 |
| 사용량/크레딧/리셋 스냅샷과 추이 표시 | 구현 가능 | 로컬 앱이 읽은 값에 account/window/device/관측 시각을 붙여 업로드, offline은 마지막 확인 시각 표시 |
| 추가 OpenAI 로그인 없이 인증까지 복원 | 조건부 가능 | 유효한 자격 증명, 복호화 키 전달, 저장 backend 호환 및 갱신 충돌 검증 필요 |
| 브라우저에서 native Codex 로그인 전환 | 설치 앱 연계 필요 | 브라우저가 직접 auth.json/Keychain을 수정하는 구조는 제공하지 않음 |
| 채팅/프로젝트/작업 상태를 다른 PC에서 이어가기 | 별도 기능 | 계정 연동만으로 local history, 프로젝트 파일, cwd와 작업 환경을 복원하지 못함 |

`Models.cs`의 AccountProfile은 AuthJson 전체와 사용량/이력을 담는다. AuthDocument는 native Codex의 id/access/refresh token 및 account_id가 있는 auth cache를 요구하고 account_id/subject로 로컬 key를 계산한다. `Storage.cs`는 이 데이터 전체를 단일 accounts.vault로 암호화한다. `VaultProtection.cs`의 Windows 경로는 DPAPI, Mac 경로는 directory별 Keychain 키와 AES-GCM이다. 그러므로 vault 파일만 cloud에 복사하는 방식은 범용 cross-device 복원 포맷이 아니다.

`AccountService.cs`는 임시 Codex home에 credentials를 전달해 account/read 및 account/rateLimits/read를 호출하고, 갱신된 auth.json을 로컬 revision과 비교해 저장한다. 현재 CredentialRevision은 JsonIgnore인 메모리 상태다. 계정 적용은 기존 desktop 종료/원본 인증 상태를 확인한 다음 auth.json을 원자적으로 교체하며, CheckCredentialBackend는 명시된 file 이외 backend를 거절한다. 웹 연동이 이 검증을 우회하거나 조직의 keyring 설정을 자동으로 바꾸면 안 된다.

### 공식 문서에서 확인한 사실과 지원 경계

OpenAI의 [인증 문서](https://learn.chatgpt.com/docs/auth#fallback-authenticate-locally-and-copy-your-auth-cache)는 trusted headless 장치로 local auth cache를 복사하는 예를 제공한다. 이는 자격 증명의 기술적 이전 가능성을 뒷받침하며, 무제한 multi-device session 복제나 제3자 hosted token 보관 전체가 보증된다는 의미는 아니다.

[웹 Sign in with ChatGPT](https://developers.openai.com/siwc/website)는 표준 identity 로그인과 우리 서비스 세션 생성을 설명한다. 이 로그인은 다른 저장 계정의 Codex 권한을 자동으로 부여하지 않는다. 현재 웹용 상용 연동은 선택된 파트너의 제한된 trial로 안내돼 있으므로 서비스 회원 로그인은 일반 OIDC/이메일 등의 독립 인증으로 설계할 수 있다.

[SIWC plan OAuth 개요](https://developers.openai.com/siwc/token-sharing-open-source)는 동일 user/workspace의 여러 host를 지원한다. [등록/로그인](https://developers.openai.com/siwc/token-sharing-open-source/sign-in)은 loopback callback, PKCE/state/nonce 및 발급 client_id와 검증된 identity별 credentials를 분리한다. [app-server 통합](https://developers.openai.com/siwc/token-sharing-open-source/codex-app-server)은 해당 토큰으로 Responses API를 이용하는 구성이다. 이 토큰을 현재 native AuthJson 형식에 넣으면 desktop 전환/기존 quota RPC가 그대로 된다는 근거는 없으므로 두 credential type을 분리해야 한다. 문서는 open-source/local hosting을 대상으로 하며 paid/remote-hosted plan 사용은 별도 문의 대상으로 안내한다. 단순 metadata/암호문 sync의 적용 범위를 그 제한과 동일하게 단정하지 않는다.

[계정/세션 문서](https://developers.openai.com/siwc/token-sharing-open-source/profiles-and-sessions)는 같은 session의 회전 토큰 갱신을 직렬화하도록 요구한다. [self-hosted VM 이전](https://developers.openai.com/siwc/token-sharing-open-source/self-hosted-vms)은 기존 세션을 이전하고 이후 VM이 refresh를 소유하게 한다. 이 flow의 transferred session에서는 host별 plan usage attribution/revocation이 아직 제공되지 않는다. 서버가 ciphertext만 보관하는 E2EE vault와 새 기기 승인 절차는 이 문서가 완성해 주는 기능이 아니라 우리가 설계/검증할 부분이다.

### 제안 구조

서비스 계정은 `ServiceUser`, 승인된 컴퓨터는 `Device`, 연동 계정은 `AccountRegistration`으로 분리한다. 서비스 DB에는 사용자/기기 권한, opaque record ID, 동기화 version과 암호문을 보관한다. 토큰 원문과 vault 복호화 키를 서버에 두지 않는 구조를 우선 검토한다. tenant별 권한 검사와 record의 사용자/account/schema/version 결합은 각 API 요청 및 AEAD 검증에서 유지해야 한다.

기존 PC에서 로컬 vault를 읽어 명시적으로 선택한 계정 record만 portable AEAD 포맷으로 암호화한다. 새 PC는 서비스 로그인 후 기존 기기의 승인 또는 사용자 recovery key로 vault key를 받고, 가져온 record를 검증한 뒤 자기 DPAPI/Keychain 보호로 재저장한다. 각 device private key는 해당 기기에 남긴다. 서비스 로그인 토큰이나 이메일을 복호화 키로 사용하지 않는다. 로그인만으로 서버가 key를 복원해 주는 구현은 server custody가 되며 E2EE라고 표시할 수 없다. 비밀번호 재설정만으로 잃어버린 E2EE key가 복구되는 것도 아니다.

기기 등록은 public-key challenge/서명으로 확인하고, 보이는 device ID나 SIWC host ID 자체를 인증 증거로 사용하지 않는다. native app으로 서비스 로그인 결과를 넘길 때는 일회용 code와 PKCE를 사용하고 URL에 credentials를 넣지 않는다. OAuth 등록 identity는 서명/issuer/audience/expiry/nonce를 검증하며 이메일 일치만으로 계정을 합치지 않는다.

Shared 데이터 후보는 계정 별칭, 선호 설정, 계정별 이력/스냅샷과 명시 선택한 credentials다. CurrentKey/IsCurrent/RequiresApply, PreviousDesktopAuthJson, PendingSwitch, native 채팅 ID/IPC, 설치 경로/Codex home, 드라이브 경로/CPU 등 telemetry는 기기별이다. PC A의 선택 계정이 PC B의 native 로그인 변경/종료를 유발하지 않게 한다. 기기 telemetry를 웹에서 보고 싶다면 별도 동의와 device/last-seen 표시를 둔다.

Sync worker는 기존 로그인/계정 전환/사용량 갱신과 분리해 비동기로 돌리고, network 장애에서도 로컬 앱을 사용할 수 있게 한다. 저장된 account record version과 tombstone으로 offline 삭제/복구 충돌을 처리하며, auth token 묶음은 generation 단위로 원자적으로 교체한다. Usage history는 account/quota/reset window 및 event ID/관측 시각으로 중복을 구분한다. 이전 기기의 오래된 전체 vault를 최신본 위에 last-write-wins로 덮지 않는다.

### 가장 큰 기술 제약: native Codex의 갱신 소유권

같은 refresh token을 여러 PC로 복사한 뒤 각 PC가 갱신하면 충돌할 수 있다. cloud lease/CAS는 우리 앱끼리만 지키는 것으로 충분하지 않다. native Codex와 CLI도 독립적으로 token을 자동 갱신하므로 Switch의 잠금이나 CredentialRevision만으로 그 전체를 직렬화하지 못한다.

기본안은 계정 목록을 즉시 내려받되 각 기기에 별도 OAuth 인증 세션을 마련하고 기기 간 session tokens를 서로 덮지 않는 방식이다. 필요한 재인증은 공식 browser flow로 진행한다. 유효 auth cache 복원은 opt-in 백업/이전 기능 후보로 두고 동시 사용/정상 refresh/실패 복구를 통과해야 활성화한다. 우리 앱이 모든 token 사용을 직접 소유하는 별도 app-server client라면 외부 credential lifecycle을 통제할 여지가 있지만, 이것을 현재 native Codex desktop과 같은 제품 기능으로 간주하지 않는다.

서비스의 기기 연동 해제는 sync 접근과 vault-key 전달을 중단한다. 이미 복사한 credentials/키를 offline 장치에서 원격 삭제하거나 OpenAI 접근까지 확실히 차단하지는 못한다. OpenAI 세션 회수는 provider에서 별도로 확인해야 하며 공유 세션을 회수하면 다른 기기도 영향을 받을 수 있다. 문서가 지원하지 않는 host별 provider 회수를 약속하지 않는다.

### 구현 전 확인할 PoC와 출시 단계 제안

1. 별도 검증 계정/임시 home의 Windows 두 대와 Mac에서 계정/워크스페이스 identity, valid auth 이전, file/keyring backend, 기존 native 계정 보존을 확인한다.
2. 동일 session 동시 refresh, native와 Switch의 동시 갱신, stale/offline 기기의 복귀, revoked/expired auth, refresh 후 저장 직전 crash를 검증한다. 재사용 허용 구간이나 만료 기간을 native Codex 계약으로 추정하지 않는다.
3. 승인되지 않은 기기, 서비스 계정만 탈취된 경우, 다른 tenant record 접근, rollback/삭제 복원, key 분실/recovery, 서비스 해제와 provider 회수 차이를 검증한다.
4. SIWC token으로 기존 native desktop/account/rateLimits와 동등 기능이 되는지는 별도 interoperability PoC로 확인한다. 관측되지 않은 지원을 제품 문구로 확정하지 않는다.

1차 기능은 서비스 로그인/계정 목록/설정/사용량 최근값 sync와 새 기기 승인이다. 2차는 기기별 인증과 만료 계정만 재로그인하는 흐름이다. 완전한 무인 credentials 복원은 앞선 갱신/보안/지원 범위 검증을 통과한 뒤 별도 선택 기능으로 판단한다. 검토 과정에서 실제 credentials 조회/업로드, 계정 로그인/전환, 실행 앱 재시작, 서버 구현/배포/공개를 하지 않았다.

## 저장소와 실행 경로

- 소스: Windows `D:/Git/codex-switch` 및 Mac의 같은 `codex-switch` 저장소 checkout
- GitHub: `Gaebabi/codex-switch`, private, 기준 브랜치 `main`; 추가 공개/Release는 별도 요청이 필요하다.
- 이전 Git 이력은 ignored `artifacts/repository-migration-20261014`의 검증한 bundle로 보존하며 현재 브랜치에 병합하지 않는다.
- 기술: .NET 8 WPF/WinForms 트레이, 자체 포함 Windows x64, 별도 앱 NuGet 의존성 없음
- macOS: 별도 `macos/CodexAccountDesk.Mac.csproj`, .NET 8/Avalonia 11.3.22, osx-arm64/osx-x64, 기존 코어 소스 링크 공유
- 빌드 출력: `artifacts/win-x64`, Git 제외
- 계정 저장소: 현재 Windows 사용자 전용 `%LOCALAPPDATA%\CodexAccountDesk`, Git 제외
- 1.26 프로그램/타이틀바/트레이 이름은 Codex Switch, Windows 실행 파일은 `CodexSwitch.exe`, Mac 앱은 `Codex Switch.app`/`CodexSwitch`다. 기존 vault 경로·DPAPI/Keychain·bundle ID·IPC namespace는 호환성을 위해 유지한다. 현재 실행 중인 유틸리티가 `--data-dir`를 사용하면 종료/재실행도 같은 경로를 지정한다.
- 공개 export는 내부 작업 문서(AGENTS/PLAN/STATUS/OPERATIONS/BACKLOG/개발안내)와 artifacts/bin/obj/runtime을 제외한다. 공개 README·docs·SECURITY/CONTRIBUTING이 사용자 안내를 소유한다. 원본 프레임/개인 캡처는 ignored artifacts에만 있고, 검수한 docs/media GIF만 예외적으로 공개한다.
- 이전 Documents/Codex 작업 폴더와 전달 패키지는 보존합니다. 이 저장소에서는 소스만 관리합니다.

## 빌드와 검증

### Codex Switch 1.27 공개 실행 패키지

- 공개 정본 `D:/Git/codex-switch`, GitHub `Gaebabi/codex-switch`의 `v1.27.0` Release에 self-contained Windows x64와 Mac arm64/x64 ZIP, SHA256SUMS.txt를 게시한다. .NET/source build 없이 다운로드해 실행하며 각 플랫폼의 전체 폴더/번들을 유지한다.
- Windows는 `scripts/build.ps1 -Verify`, Mac은 `scripts/build-macos.ps1` 또는 native `build-macos.sh`로 만든다. 실행 중인 publish 폴더를 덮지 않고 별도 release-build 출력에 최종 Windows 빌드를 만든다. Mac cross-build는 unsigned이며 Install.command가 로컬 ad-hoc 서명을 적용한다. Developer ID 공증/자동 업데이트/자동 CI 게시 없음.
- 1.27 브랜드는 수용한 PNG 알파 실루엣의 공유 mark.path/mark.svg를 WPF/Avalonia에서 벡터로 그린다. `--export-icons` → make-mac-icons.py로 Windows 16–256px10크기와 Mac1024px source를 만든다. source PNG를 작은 비트맵으로 확대하지 않는다.
- `CodexSwitch.exe --record-dashboard <private-directory> --data-dir <동일 실행 저장소>`는 현재 실행 중인 유틸리티의 실제 WPF 화면을 세 크기/192DPI PNG90장씩 저장하고 창 geometry를 복원한다. 실제 사용량을 바꾸지 않으며 외부 OS/Codex cursor는 렌더 대상 밖이다. 원본은 민감하므로 ignored/private artifacts에만 저장하고 `scripts/redact-promo.py`로 원문 이름 픽셀 제거 후 공개한다.
- 공개 GIF는 logical500x360/700x550/1000x700, raster1000x720/1400x1100/2000x1400,270프레임이다. Windows ZIP 재실행93검사/SQLite23검사와 Mac compile/package/0755검사를 구분하며 실제 Mac 새아이콘/설치/전환·Intel실행 수용은 별도다.

1.23 이식은 당시 요청에 따라 컴파일/패키징만 수행했습니다. 1.24 MacBook 폴리싱 요청은 Mac의 격리된 내부 검사·합성 네이티브 렌더·실제 OS 자원 조회를 포함하며 `bash scripts/verify-macos.sh [실행파일]`로 재현합니다. 실제 계정 로그인/전환/채팅 재개와 Intel 기기 수용은 별도입니다. 검증을 위해 실행 중인 native Codex를 변경/종료하지 않습니다.

Mac 빌드/설치/권한/내부 IPC와 SQLite 버전/드라이버 제한은 [macos/README.md](./macos/README.md)를 먼저 봅니다. `bash scripts/build-macos.sh [osx-arm64|osx-x64]`는 native 번들/로컬 서명/ZIP만 만들며 실행/검사를 시작하지 않습니다. Windows의 `scripts/build-macos.ps1`는 cross-publish와 Unix mode가 기록된 unsigned ZIP을 만듭니다. Install.command는 사용자 Applications에 복사하고 기존 설치본을 보존하며 ad-hoc 서명합니다. Developer ID 공증/Release 업로드/자동 CI는 추가하지 않았습니다.

1.24 설치는 같은 대상 볼륨에 임시 앱을 복사하고 plist·서명·`--help` 기동을 확인한 뒤 기존 앱을 백업하고 교체합니다. 실행 중인 Account Desk가 있으면 종료를 요청하는 안내만 표시합니다. 설치 검사는 `bash scripts/install-macos.sh <앱 번들> <격리된 설치 디렉터리>`로 가능하며 실제 저장소나 Codex 앱을 건드리지 않습니다. 검사 보고서·합성 PNG·앱/ZIP은 `artifacts/`에만 보관합니다.

`python3 scripts/verify-macos-install.py <Apple Silicon ZIP>`은 격리된 디렉터리에서 ZIP 서명 보존·첫 설치·실패 보존·정리·백업·실행 중 교체 거절을 7개 검사로 확인합니다. 실제 설치 폴더나 계정은 변경하지 않습니다. ad-hoc 빌드의 코드 identity가 바뀌면 기존 Keychain 키 접근에 사용자 인증이 필요할 수 있으며 저장소/키를 재생성해서 우회하지 않습니다. macOS 네이티브 메뉴는 최초 한 번만 export하고 이후 문구·활성 상태만 갱신합니다.

`CodexAccountDesk --probe-window <report>`는 실제 계정/Keychain/Codex home을 읽지 않는 합성 네이티브 창을 유지하고 실제 PositionChanged 좌표만 보고합니다. 제목과 상단 빈 영역은 native BeginMoveDrag에 연결하고 traffic lights·언어/테마/설정 버튼은 이동 영역에서 제외합니다. 드래그 검사는 빌드/이미지 렌더와 구분하며 검사 창만 Cmd+Q로 종료합니다.

macOS 공통 버튼 스타일은 HorizontalContentAlignment/VerticalContentAlignment를 Center로 지정합니다. 아이콘은 14px 벡터로 표시하며 font baseline에 의존하지 않습니다. 합성 네이티브 렌더 검사는 모든 표시 버튼의 실제 내용 중심과 버튼 중심 차이를 1px 이내로 확인합니다.

2026-10-12 자원 정리로 과거 macOS 출력과 bin/obj를 삭제했으며, 최신 arm64/x64 패키지와 설치된 앱·계정 저장소는 유지합니다. 이후 사용자의 상단 표시 요청에 따라 1.25 설치본을 갱신·재실행합니다. 삭제한 생성물은 위 빌드 명령으로 재생성합니다. 정리 범위와 실제 공간 측정, 브랜치 복구 정보는 `~/Desktop/mac-cleanup-2026-10-12`의 JSON/번들에 보관하고 커밋하지 않습니다.

1.25 메뉴 막대는 공개 AppKit의 variable-length NSStatusItem과 stable NSMenu를 사용합니다. Retina template 심볼은 시스템 전경색을 따르고, 네이티브 텍스트는 현재 계정의 선택된 한도 잔여 %입니다. UI 서비스 갱신·한도 선택·언어 변경 때 같은 항목을 갱신하고 미측정은 `—`로 유지합니다. 창 숨김과 앱 종료를 구분하며 종료 시 status item과 callback target을 해제합니다. 네이티브 렌더 검사에는 template/표시/항목 유지와 0%·100%·미측정·비현재 계정만 있는 상태가 포함됩니다. `--probe-window`는 메뉴 title/geometry도 기록하며 AppKit 첫 layout 이후 값으로 확인합니다.

공통 Storage는 Windows DPAPI 형식을 유지하고 Mac만 Keychain 키 + AES-GCM을 사용합니다. POSIX private folder/file mode와 원자적 rename을 적용합니다. MacDesktop은 실제 NSRunningApplication bundle/executable과 같은 UID 소켓 peer를 확인하고 정상 terminate 요청/완전 종료 확인을 사용합니다. 네이티브 프로세스 강제 종료나 계정 변경을 검증 목적으로 사용하지 않습니다. 공유 ReadOnlySqlite는 OS별 native library를 선택하며 Unix 세션은 현재 Codex home의 `ipc/ipc.sock`을 사용합니다.

```powershell
.\scripts\build.ps1 -Verify
```

검사 결과는 Git 제외 `artifacts/self-tests.json`에 저장됩니다. 현재 내부 검사는 92개이며, 암호화/파싱/격리된 인증 전환/예측 재생/수면 기하/실행·큐·목표 집계/하드웨어 집계·경고·추이 이력/드라이브 설정 저장/크레딧 표시를 검사합니다. 실제 로그인, 실제 Codex 전환과 실행 중 화면 수용은 별도입니다.

계정/검사 디렉터리는 현재 사용자만 접근하는 ACL로 보강하면서 소유자도 지정합니다. 새 저장소의 현재 사용자 소유 루트에는 하위 디렉터리에 상속되는 FullControl이 필요합니다. D:\Git 기본 Modify 상속만 있으면 검사 디렉터리를 만들 수 있어도 소유자/ACL 지정에서 접근이 거절될 수 있습니다. 2026-10-12 초기 세팅에서 이 새 저장소 루트에만 소유자 FullControl을 설정했으며 D:\Git 전역 권한은 변경하지 않았습니다.

실제 사용량 조회를 점검할 경우 계정 저장소를 별도의 암호화 검증 디렉터리에 복사하고 `--data-dir <directory> --verify-readonly <report> --preview <png>`를 사용합니다. 개인 계정 진단과 캡처는 Git에 넣지 않습니다. `--preview-tanks`와 `--preview-trends`는 합성 상태를 렌더링하며 실제 계정 상태를 수정하지 않습니다.

## 채팅 실행 상태

### 날짜 백업과 전환 재개

사용자가 전환 버튼 또는 `--switch-account <email>`으로 직접 요청하면 AccountSwitchCoordinator가 active root ID를 고정하고 한국 시간 `[yyMMdd]`를 추가/갱신합니다. DesktopSwitchBackend는 기존 home/provider의 metadata app-server에서 `thread/name/set` 후 `thread/read`로 저장된 이름을 확인합니다. metadata 프로세스는 종료 요청 전에 닫습니다. 새 thread를 만들거나 기록 파일을 직접 덮어쓰지 않습니다.

DesktopShutdown은 exact desktop executable의 기본 PID와 시작 시각만 Windows Restart Manager에 등록하고 RmShutdown(flags=0)을 요청합니다. renderer/child PID를 별도 등록하거나 force shutdown/Process.Kill을 사용하지 않습니다. 정상 종료 실패는 계정 적용을 막습니다. AccountService는 완전 종료와 원본 계정/인증 파일 일치를 다시 확인하고 원자적으로 적용합니다. 별도 CLI/IDE와 다른 프로그램은 종료하지 않습니다.

계정을 적용한 뒤 desktop과 `codex://threads/<id>`를 열고 새 owner/resumed 상태를 확인합니다. active/완료/새 턴은 그대로 두고 idle continuation에만 version 2 `thread-follower-start-turn`으로 Continue를 보냅니다. clientUserMessageId를 암호화 checkpoint에 먼저 저장하고 inheritThreadSettings=true를 사용합니다. 불명확한 전송은 자동 반복하지 않으며 기존 승인/권한 판단과 Goal 예산을 재설정하지 않습니다.

PendingSwitch는 DPAPI vault의 이름/ID/제출 nonce/단계/부분 결과로 복구하며 완료하면 비웁니다. 같은 private data directory의 `last-switch.json`에는 이름/인증이 없는 단계/개수/대상 key 요약만 기록합니다. 취소는 메뉴/트레이에 있어 최소 창의 footer 높이를 늘리지 않습니다.

`--verify-switch-protocol <report>`는 별도의 local-only provider/home에서 추론 없이 두 app-server 간 loaded name 저장과 재개 ID/name/cwd를 확인합니다. `--verify-sessions`의 ownerRpcVerified는 실제 owner의 읽기 전용 model-settings IPC만 검사합니다. 이 IPC result는 method wrapper가 이미 제거되어 있으므로 추가로 풀지 않습니다. KO/EN busy UI probe는 합성 상태이며 실제 전환을 누르지 않습니다. 실제 종료/전환/Continue 실행은 검증과 구분한 사용자의 직접 요청에 따릅니다.

`DesktopSessionMonitor`는 실행 중인 데스크톱의 `codex-ipc` Windows named pipe에 observer로 연결합니다. 선택된 Codex home의 `thread-writer-locks`에서 후보 ID를 발견한 뒤 `thread-owner-discovery`로 실제 데스크톱 owner를 확인하고 상태 스트림만 구독합니다. 새 조회 app-server의 메모리 상태나 로그 수정 시각으로 실행 수를 추정하지 않습니다. 현재 내부 stream protocol version 11을 설치된 Codex 26.1007.2314에서 검증했습니다. 공식 외부 확장 계약이 아니므로 형식이 바뀌면 수치를 숨기고 tooltip에 상태 형식 변경을 표시합니다.

상태 snapshot/patch에서 owner, revision, runtime status, 대기 flag, 하위 채팅 여부와 Goal status를 유지합니다. 전환의 동일 채팅 재개 판단에는 제목/resume 상태/최근 턴과 메시지 ID도 메모리에서 사용하며 전환 중 필요한 메타데이터만 암호화 checkpoint에 보관합니다. Goal은 active만 상단에 집계하고 paused/blocked/budgetLimited/usageLimited는 tooltip의 멈춘 목표에 따로 집계합니다. complete/null은 active 목표가 아니며 제공되지 않거나 알 수 없는 상태는 목표 수를 unknown으로 둡니다. 목표와 실행 수는 독립적인 집계입니다. 채팅 본문/목표 원문을 보관하거나 진단 보고서에 제목/원문을 기록하지 않습니다. 본문 patch는 revision만 진행하며 누락된 revision/지원하지 않는 상태 patch는 새 snapshot을 요청합니다. 동일하거나 이전 revision의 재전송은 무시합니다. owner 연결 종료 시 집계를 무효화하고 다시 연결합니다. 스캔은 2초, 연결 재시도는 3초이며 상태 메시지는 비동기로 즉시 반영됩니다. 계정 인증과 사용량 갱신 쿨타임에 의존하지 않습니다. 계정 귀속·원격/클라우드/별도 CLI 작업 수는 제공하지 않습니다.

큐는 같은 Codex home의 `.codex-global-state.json`에서 `queued-follow-ups`와 `queue_1.sqlite`의 `queued_items`를 함께 읽습니다. Windows 기본 `winsqlite3.dll`의 SQLITE_OPEN_READONLY 연결로 커밋된 WAL까지 읽으며 immutable 복사본이나 새 조회 app-server를 사용하지 않습니다. SELECT는 ID/thread ID/UserInput.client_id와 형식만 반환합니다. 본문/첨부를 C#이나 보고서로 가져오지 않습니다. SQLite 연결은 250ms busy timeout을 사용하며 쓰기 쿼리도 거절합니다. DB 본체나 WAL에 쓰거나 checkpoint/repair하지 않습니다. 근거: https://www.sqlite.org/c3ref/open.html , https://www.sqlite.org/wal.html .

서버 큐는 `state_5.sqlite` 메타데이터의 originator=Codex Desktop, source=vscode, agent_path=null인 thread로 제한하며 관측된 하위 채팅도 제외합니다. 기존 JSON 큐는 명시된 비로컬 submission host/execution host를 제외합니다. 불러오지 않은 데스크톱 주 채팅 큐도 포함합니다. 서버 submission ID/client ID와 저장 메시지 ID를 thread별로 비교해 두 저장소에 걸친 중복만 제거합니다. 서버의 서로 다른 submission은 같은 client ID라도 각각 한 개이며 서로 다른 thread의 ID를 합치지 않습니다. JSON pausedReason과 관측된 interrupted thread의 서버 큐는 보류 수에 집계합니다. 불러오지 않은 서버 큐의 보류 상태는 추정하지 않습니다.

owner가 보내는 version 2 `thread-queued-followups-changed`는 즉시 반영하고 ID/client ID/보류 여부만 유지합니다. 파일 조회 시작 sequence 뒤 도착한 broadcast를 이전 조회로 지우지 않습니다. 이후 저장 파일이 동일 상태로 따라오면 override를 해제하며 owner 변경/연결 종료 시 비웁니다. FileSystemWatcher는 JSON과 queue DB/WAL/journal 변경으로 background loop를 깨우고 SHM 잠금 파일은 제외합니다. 누락된 알림은 기존 최대 2초 조회가 보완합니다. 어느 저장소든 접근/형식/스키마 오류가 있으면 큐만 unknown이고 실행/목표 수는 유지합니다. queue DB가 없는 구버전 home은 서버 큐가 비어 있는 것으로 읽지만 새로운 queue 버전 파일은 unknown입니다. 현재 내부 저장 스키마는 설치 Codex 26.1007.2314에 근거하며 원격/클라우드/CLI 큐는 집계하지 않습니다.

`artifacts/win-x64/CodexAccountDesk.exe --verify-queues <report>`는 계정/채팅 접근 없이 두 큐 저장소의 saved/server/합산 수와 조회 비용만 기록합니다. `python scripts/verify-queues.py`는 별도 임시 home에서 Python SQLite writer를 열어 23개 검사로 WAL-only 커밋, 미커밋 제외, 추가/삭제/zero, client ID 중복, child/CLI 제외, 형식 오류와 DB/WAL byte 보존을 확인합니다. 실제 Codex 큐를 만들거나 삭제/실행하지 않으며 source home이나 인증에 접근하지 않습니다. 일반 실행/빌드에는 Python이 필요하지 않습니다.

`SessionUsagePanel`은 기존 상단에서 세 열의 10px 라벨/17px 숫자를 표시합니다. 최소 창에서는 계정 수/갱신 안내를 tooltip에 두어 toolbar 34px 높이를 유지합니다. header에 구분점을 사용하지 않습니다. read-only layout probe는 실제 수치와 별도로 unknown/zero/99 합성 상태의 geometry를 검사한 뒤 실제 표시로 복원합니다. Codex에 큐/목표를 주입하는 검사는 없습니다.

실제 상태 관측만 검증하려면 `artifacts/win-x64/CodexAccountDesk.exe --verify-sessions artifacts/sessions-live.json`을 실행합니다. 18초간 일반 observer의 실제 상태 수만 보고하며 계정 vault를 열거나 작업을 시작/중단/재개하지 않습니다. 결과는 Git 제외입니다. 상태 정의의 공식 근거: https://learn.chatgpt.com/docs/app-server 의 runtime status와 thread/status/changed.

## 하드웨어 사용률

`HardwareResourceMonitor`는 2초 간격의 단일 background task에서 `HardwareSampler`를 호출합니다. Windows PDH query를 재사용하고 `PdhAddEnglishCounterW`로 표시 언어와 무관한 CPU/GPU counter를 추가합니다. CPU는 `Processor Information(_Total)/% Processor Time`, RAM은 `GlobalMemoryStatusEx`의 물리 메모리입니다. rate counter는 두 번째 관측부터 표시합니다. UI dispatcher에서는 값/색상만 바꾸며 카드나 계정 조회를 재생성하지 않습니다. PowerShell/WMI/nvidia-smi 프로세스를 주기적으로 실행하지 않습니다.

GPU Engine의 같은 LUID/physical node/engine에 속한 프로세스 사용률을 합산하고 엔진별 최댓값을 사용합니다. 전용 메모리는 GPU Adapter Memory의 Dedicated Usage를 DXGI AdapterDesc1의 64-bit DedicatedVideoMemory와 LUID로 결합합니다. GPU Process Memory의 공유 할당을 중복 합산하거나 이 프로세스만의 QueryVideoMemoryInfo를 PC 전체 사용량으로 표시하지 않습니다. 다중 GPU에서는 GPU/VRAM 각각의 최고 사용률과 해당 장치를 tooltip에 명시합니다. DXGI capacity는 60초마다 갱신하며 카운터/용량이 없는 항목은 unavailable입니다.

경고 단계는 70% warning/85% critical, 해제는 65%/80% 미만입니다. HardwareMath의 shared constants를 알고리즘과 두 언어의 tooltip에서 함께 사용합니다. 이전 경고를 유지해 경계에서 색상이 반복 변경되는 것을 방지하며 값이 unavailable이면 경고도 unknown으로 바꿉니다. Burn0의 기존 warning/danger 색상을 두 테마에서 사용합니다. `HardwareHistory`는 같은 background sampler에서 실제 관측 시각의 2분/최대61개 기록만 유지합니다. UI/theme 갱신은 이력을 추가하지 않습니다. 중복 시각을 제외하고 시계 역행 시 새 timeline을 시작하며, 기록은 파일에 저장하지 않습니다.

`ResourceTrendSurface`는 기존 toolbar 174x34의 각 셀에 얇은 추이선과 옅은 영역 채움을 그립니다. 세로는 0–100% 고정, 가로는 실제 모인 구간(최대2분)이며 단일 샘플은 점으로 표시합니다. 미측정/6초 초과 공백을 연결하거나 관측되지 않은 이전 값을 채우지 않습니다. 현재 값이 unknown이면 숫자는 dash, 남은 실제 과거 그래프는 muted 색상입니다. 위치/숫자/반경/색상 토큰과 outer border 없음은 유지하며 새 timer를 추가하지 않습니다. `artifacts/win-x64/CodexAccountDesk.exe --verify-resources artifacts/resources-live.json`은 18초간 실제 OS 관측·이력과 모니터 프로세스의 CPU/메모리·샘플 시간을 기록합니다. 계정 접근이나 인위적인 부하 생성은 없습니다. `--preview-resources artifacts/resource-colors`는 상승/경고/미측정/0%/100% 추이의 합성 렌더이며 실제 높은 부하를 증명하지 않습니다.

정의/네이티브 API 근거: https://devblogs.microsoft.com/directx/gpus-in-the-task-manager/ , https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetformattedcounterarrayw , https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-globalmemorystatusex . 실제 수치·부하는 ignored 진단 보고서와 별도로 확인합니다.

## 게시와 승인

Windows 11의 창 외곽선은 shared WindowFrame에서 DWM BORDER_COLOR로 지정합니다. 기존 COLOR_NONE의 테두리 억제를 제거하고 light active/inactive는 #B5B8BE/#C4C7CB, dark는 #60656C/#484C53를 사용합니다. source initialization·activation·theme 변경 때 갱신하며 기본 native 얇은 폭/DPI·라운드·shadow·resize를 유지합니다. main/detail/settings/confirmation 창은 같은 helper를 사용합니다. 카드와 내부 컨트롤에는 border를 추가하지 않습니다. WPF RenderTargetBitmap은 non-client frame을 포함하지 않습니다. BORDER_COLOR는 setter-only이므로 GetWindowAttribute(34)는 E_INVALIDARG를 반환합니다. 진단은 성공한 setter의 applied color와 실제 getter가 지원하는 visible thickness/corner/region을 별도로 기록합니다. 기준: https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/ne-dwmapi-dwmwindowattribute .

계정 History는 우측 상단 account menu의 첫 MenuItem으로 엽니다. readonly UI probe도 실제 more button과 menu item을 통해 detail을 열어 메뉴 이동을 확인합니다. AccountTankCard 하단 오른쪽에는 현재 quota bucket의 CreditBalance/UnlimitedCredits를 표시하며 없으면 codex/첫 bucket을 조회합니다. zero/missing/unlimited를 구분하고 큰 수는 K 표기, raw balance는 tooltip으로 유지합니다. 소진/리셋은 최소 카드에서도 남기고 기존 History footer control의 공간을 회수해 잔량 숫자의 높이를 확보합니다.

드라이브 표시 설정은 VaultData.Drives에 저장합니다. 기본 C:/D:, 임의 로컬 fixed/removable 드라이브 선택·표시 이름·순서를 지원하고 빈 선택도 보존합니다. DriveMonitor는 15초마다 background task에서 DriveInfo.AvailableFreeSpace/TotalSize를 읽으며 설정 변경 시 semaphore로 즉시 재조회합니다. 미연결/접근 거절은 unavailable로 표시하고 network 볼륨은 제외합니다. DriveUsagePanel의 채움은 남은 비율이며 30% 이하 황색/15% 이하 적색입니다. 기존 footer 안에 배치하므로 dashboard 행을 추가하지 않습니다. 실제 설정 창 렌더·기본 C/D OS 용량은 별도 readonly UI probe로 확인합니다.

사용자의 2026-10-12 직접 요청으로 로컬 Git 초기화, 소스 커밋, private GitHub 생성과 initial `main` push를 승인받았습니다. 원격 privacy와 commit 일치는 push 후 확인합니다.

GitHub Actions나 자동 배포는 없습니다. 이후 push, 태그/Release 업로드, public 전환, 운영 배포는 추가 명시 요청이 필요합니다. 인증은 기존 Git Credential Manager를 사용하며 토큰을 파일이나 URL에 저장하지 않습니다.
