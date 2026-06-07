---
name: generate-github-actions
description: >
  ASP.NET Core 8 アプリを Azure App Service (Linux) にデプロイする
  GitHub Actions ワークフロー YAML を生成するスキル。
  Phase 5 の Azure/CI-CD セットアップフェーズで使用する。
---

# generate-github-actions スキル

## 目的
以下を含む `deploy.yml` を生成する。
1. `dotnet restore` → `dotnet build` → `dotnet test` → `dotnet publish`
2. Azure Web Apps Deploy アクション (`azure/webapps-deploy@v3`)
3. EF Core マイグレーション自動実行（`dotnet-ef database update`）

## 入力
- Azure App Service 名（例: `sms-app-prod`）
- アプリケーションプロジェクトのパス（例: `src/SmsWeb/SmsWeb.csproj`）

## 出力先
- `.github/workflows/deploy.yml`

## 規約
- トリガー: `push` to `main` ブランチのみ
- GitHub Secrets から接続文字列・認証情報を参照する  
  （ハードコードは絶対禁止）
  - `AZURE_WEBAPP_PUBLISH_PROFILE` — Azure 発行プロファイル
  - `AZURE_SQL_CONNECTION_STRING` — DB 接続文字列
- `actions/setup-dotnet@v4` で .NET 8.x を指定する
- ビルドキャッシュ (`actions/cache@v4`) を使用してビルド時間を短縮する
