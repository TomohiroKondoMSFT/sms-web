# Phase 2 — 要件定義

> 生成日: 2026-06-07  
> 参照: `docs/phase1-assessment.md`

---

## 1. プロジェクトスコープ

### 対象範囲（IN）
- 認証・認可（ログイン / ログアウト / ロール制御）
- 管理者による生徒・教師の登録・編集・削除・閲覧
- 教師による生徒の登録・出席管理・成績入力
- 生徒による自己情報閲覧・成績確認・出席確認・試験スケジュール確認・お知らせ閲覧
- Faculty（学科）・Class（クラス）のマスタ管理

### 対象外（OUT）
| 項目 | 理由 |
|------|------|
| 経理（Accountancy） | 元ソースがスタブのみで要件不明 |
| プッシュ通知 | 元ソースがスタブのみ。将来拡張として保留 |
| Windows コンソール UI | Web アプリに移行するため不要 |

---

## 2. ユーザーロール定義

| ロール | 説明 | 対応する元クラス |
|--------|------|----------------|
| **Admin** | 全データの管理・ユーザー登録が可能な管理者 | `Admin` クラス |
| **Teacher** | 担当クラスの生徒管理・成績・出席を管理する教師 | `Teacher` クラス |
| **Student** | 自分の情報・成績・出席を閲覧できる生徒 | `Student` クラス |

---

## 3. 機能要件

### Epic 1: 認証・認可

| 要件ID | 要件名 | ロール | 優先度 | 元機能 |
|--------|--------|--------|--------|--------|
| REQ-001 | ユーザーログイン | 全員 | 🔴 Must | F-001 |
| REQ-002 | ユーザーログアウト | 全員 | 🔴 Must | F-003（未実装→新規） |
| REQ-003 | ログイン失敗ロックアウト（5回） | 全員 | 🔴 Must | F-002（Identity で代替） |
| REQ-004 | ロールベースアクセス制御 | 全員 | 🔴 Must | 新規 |
| REQ-005 | パスワード変更 | 全員 | 🟡 Should | 新規 |

### Epic 2: 管理者機能

| 要件ID | 要件名 | ロール | 優先度 | 元機能 |
|--------|--------|--------|--------|--------|
| REQ-010 | 教師アカウント登録 | Admin | 🔴 Must | F-010 |
| REQ-011 | 生徒アカウント登録 | Admin | 🔴 Must | F-010 |
| REQ-012 | ユーザー情報編集 | Admin | 🔴 Must | F-011 |
| REQ-013 | ユーザー削除 | Admin | 🔴 Must | F-012（スタブ→新規） |
| REQ-014 | ユーザー一覧・詳細閲覧 | Admin | 🔴 Must | F-013（スタブ→新規） |
| REQ-015 | Faculty マスタ管理（CRUD） | Admin | 🟡 Should | 新規 |
| REQ-016 | Class マスタ管理（CRUD） | Admin | 🟡 Should | 新規 |

### Epic 3: 教師機能

| 要件ID | 要件名 | ロール | 優先度 | 元機能 |
|--------|--------|--------|--------|--------|
| REQ-020 | 担当クラスの生徒登録 | Teacher | 🔴 Must | F-020 |
| REQ-021 | 生徒情報編集 | Teacher | 🔴 Must | F-021（スタブ→新規） |
| REQ-022 | 生徒削除 | Teacher | 🟡 Should | F-022（スタブ→新規） |
| REQ-023 | 生徒一覧・詳細閲覧 | Teacher | 🔴 Must | F-023（スタブ→新規） |
| REQ-024 | 出席入力（日別） | Teacher | 🔴 Must | F-024（スタブ→新規） |
| REQ-025 | 成績入力（科目別） | Teacher | 🔴 Must | F-025（スタブ→新規） |

### Epic 4: 生徒機能

| 要件ID | 要件名 | ロール | 優先度 | 元機能 |
|--------|--------|--------|--------|--------|
| REQ-030 | 自己情報閲覧 | Student | 🔴 Must | F-031（スタブ→新規） |
| REQ-031 | 自己情報更新 | Student | 🟡 Should | F-030（スタブ→新規） |
| REQ-032 | 成績確認 | Student | 🔴 Must | F-033（スタブ→新規） |
| REQ-033 | 出席確認 | Student | 🔴 Must | F-034（スタブ→新規） |
| REQ-034 | 試験スケジュール閲覧 | Student | 🟡 Should | F-035（スタブ→新規） |
| REQ-035 | お知らせ閲覧 | Student | 🟡 Should | F-036（スタブ→新規） |

---

## 4. 非機能要件

| 要件ID | カテゴリ | 要件 |
|--------|----------|------|
| NFR-001 | セキュリティ | パスワードは ASP.NET Core Identity の PBKDF2 でハッシュ化して保存する |
| NFR-002 | セキュリティ | SQL はすべて EF Core パラメータバインドを使用し、文字列連結を禁止する |
| NFR-003 | セキュリティ | DB 接続文字列はコードに含めず、Azure App Service 環境変数から取得する |
| NFR-004 | セキュリティ | HTTPS のみ許可。HTTP → HTTPS リダイレクトを強制する |
| NFR-005 | セキュリティ | CSRF トークンをすべてのフォームに付与する（Razor Pages デフォルト） |
| NFR-006 | 可用性 | Azure App Service B1 の SLA 99.95% を目標とする |
| NFR-007 | パフォーマンス | ページロード 3 秒以内（一覧ページ、件数 500 件以下） |
| NFR-008 | 保守性 | EF Core Code First Migration でスキーマ変更を管理する |
| NFR-009 | 保守性 | GitHub Actions による自動ビルド・テスト・デプロイを実現する |
| NFR-010 | ユーザビリティ | Bootstrap 5 を使用し、PC / タブレットでの閲覧に対応する |

---

## 5. ユーザーストーリー

### Epic 1: 認証・認可

```
US-001: ユーザーとして、メールアドレスとパスワードでログインできる。
        → ログイン成功後はロールに応じたダッシュボードに遷移する。
        → 失敗5回でアカウントをロックし、管理者のみ解除できる。

US-002: ユーザーとして、ログアウトボタンを押してセッションを終了できる。

US-003: Admin として、他ユーザーのロックを解除できる。
```

### Epic 2: 管理者機能

```
US-010: Admin として、フォームから教師情報（名前・年齢・住所・電話番号・クラス・給与・教師種別）を
        入力して教師アカウントを登録できる。

US-011: Admin として、フォームから生徒情報（名前・年齢・性別・住所・電話番号・クラス・学籍番号・学科）を
        入力して生徒アカウントを登録できる。

US-012: Admin として、登録済みのユーザーを一覧で確認し、情報を編集・削除できる。

US-013: Admin として、Faculty と Class のマスタデータを管理できる。
```

### Epic 3: 教師機能

```
US-020: Teacher として、担当クラスの生徒を一覧で確認できる。

US-021: Teacher として、日付を選択して生徒ごとの出席状況（出席/欠席/遅刻）を入力できる。

US-022: Teacher として、科目ごとに生徒の成績（点数）を入力・更新できる。

US-023: Teacher として、生徒の基本情報を編集できる。
```

### Epic 4: 生徒機能

```
US-030: Student として、ログイン後に自分のプロフィール情報を確認できる。

US-031: Student として、自分の科目別成績を一覧で確認できる。

US-032: Student として、自分の月別出席率を確認できる。

US-033: Student として、試験スケジュール（科目・日時・会場）を確認できる。

US-034: Student として、学校からのお知らせ一覧を確認できる。
```

---

## 6. 画面一覧

| 画面ID | 画面名 | ロール | URL パス |
|--------|--------|--------|---------|
| SCR-001 | ログイン | 全員 | `/Account/Login` |
| SCR-002 | ダッシュボード（Admin） | Admin | `/Admin/Dashboard` |
| SCR-003 | ダッシュボード（Teacher） | Teacher | `/Teacher/Dashboard` |
| SCR-004 | ダッシュボード（Student） | Student | `/Student/Dashboard` |
| SCR-010 | 教師一覧 | Admin | `/Admin/Teachers` |
| SCR-011 | 教師詳細・編集 | Admin | `/Admin/Teachers/{id}` |
| SCR-012 | 教師登録 | Admin | `/Admin/Teachers/Create` |
| SCR-013 | 生徒一覧 | Admin, Teacher | `/Admin/Students` |
| SCR-014 | 生徒詳細・編集 | Admin, Teacher | `/Admin/Students/{id}` |
| SCR-015 | 生徒登録 | Admin, Teacher | `/Admin/Students/Create` |
| SCR-016 | Faculty 管理 | Admin | `/Admin/Faculties` |
| SCR-017 | Class 管理 | Admin | `/Admin/Classes` |
| SCR-020 | 出席入力 | Teacher | `/Teacher/Attendance` |
| SCR-021 | 成績入力 | Teacher | `/Teacher/Grades` |
| SCR-030 | 生徒プロフィール | Student | `/Student/Profile` |
| SCR-031 | 成績確認 | Student | `/Student/Grades` |
| SCR-032 | 出席確認 | Student | `/Student/Attendance` |
| SCR-033 | 試験スケジュール | Student | `/Student/ExamSchedule` |
| SCR-034 | お知らせ | Student | `/Student/Notices` |

---

## 7. 制約・前提条件

| 項目 | 内容 |
|------|------|
| 開発言語 | C# 12 / ASP.NET Core 8 |
| フレームワーク | Razor Pages（MVC は使わない） |
| 認証基盤 | ASP.NET Core Identity（既存の `credentials_login` テーブルは廃止） |
| DB 管理 | EF Core 8 Code First Migration（元の DDL は参照のみ） |
| ホスティング | Azure App Service B1 Linux |
| CI/CD | GitHub Actions（`main` ブランチへの push で自動デプロイ） |

---

## 8. 次のアクション（Phase 3 への引き渡し）

- [ ] 本ドキュメントのすべての REQ を Phase 3 の設計に反映する
- [ ] エンティティ設計: `Student`, `Teacher`, `Faculty`, `Class`, `TeacherType`, `Attendance`, `Grade`, `ExamSchedule`, `Notice` を設計する
- [ ] Identity の `ApplicationUser` に `StudentId` / `TeacherId` の外部キーを追加する設計を確定する
- [ ] ロールベースルーティングの設計を確定する（`/Admin/`, `/Teacher/`, `/Student/` プレフィックス）
