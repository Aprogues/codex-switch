# Account synchronization review

Review dated 2026-10-14. This is a proposal; no service or credential-sync feature is implemented.

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
