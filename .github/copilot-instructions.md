# SMS Migration Project — Copilot Custom Instructions

## プロジェクト概要
C++ CUI School Management System を ASP.NET Core 8 Razor Pages + Azure App Service に移行するデモプロジェクト。

## 技術スタック（ターゲット）
- **フレームワーク**: ASP.NET Core 8 Razor Pages
- **ORM**: Entity Framework Core 8 (Code First)
- **データベース**: Azure SQL Database Serverless
- **認証**: ASP.NET Core Identity (3ロール: Admin / Teacher / Student)
- **ホスティング**: Azure App Service B1 (Linux)
- **CI/CD**: GitHub Actions

## コーディング規約
- 言語: C#、ファイル名はパスカルケース
- Nullable reference types を有効化 (`<Nullable>enable</Nullable>`)
- async/await を徹底する（同期 I/O 禁止）
- Entity Framework Core は DbContext を DI で注入する
- Razor Pages の PageModel クラスに直接ビジネスロジックを書かない（サービス層に委譲）
- 変数名・メソッド名はキャメルケース / パスカルケース（C# 標準）
- ログ出力には ILogger<T> を使用し、Console.WriteLine は禁止

## ファイル出力ルール
- 生成ファイルはすべて `src/SmsWeb/` 以下に配置する
- ドキュメントは `docs/` に Markdown で出力する
- インフラ構成メモは `infra/` に出力する

## 禁止事項
- パスワードを平文でコードに埋め込まない
- SQL を文字列結合で生成しない（EF Core のパラメータバインドを使う）
- `Console.WriteLine` や `System.Console` の使用禁止（Webアプリのため）

## Phase別ルール（各Phaseで追記）
<!-- Phase 1以降の追加ルールをここに追記する -->
