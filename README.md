# SMS Web — School Management System (ASP.NET Core 8)

C++ CUI の学校管理システムを **ASP.NET Core 8 Razor Pages** + **Azure App Service** に移行するプロジェクト。

## プロジェクト構成

```
sms-web/
├── .github/
│   ├── agents/           # Custom Agent 定義
│   ├── skills/           # Custom Skill 定義（Copilot）
│   ├── workflows/        # GitHub Actions CI/CD
│   └── copilot-instructions.md
├── .vscode/
│   └── mcp.json          # MCP サーバー設定
├── docs/                 # 設計・分析ドキュメント
├── infra/                # Azure インフラ定義
├── src/
│   └── SmsWeb/           # ASP.NET Core 8 プロジェクト
└── README.md
```

## 技術スタック
| 項目 | 内容 |
|------|------|
| フレームワーク | ASP.NET Core 8 Razor Pages |
| ORM | Entity Framework Core 8 (Code First) |
| 認証 | ASP.NET Core Identity |
| DB | Azure SQL Database Serverless |
| ホスティング | Azure App Service B1 (Linux) |
| CI/CD | GitHub Actions |

## 移行 Phase

| Phase | 概要 | 状態 |
|-------|------|------|
| 0 | 環境セットアップ | ✅ 完了 |
| 1 | 現状分析 | ⬜ 未着手 |
| 2 | 要件定義 | ⬜ 未着手 |
| 3 | 設計 | ⬜ 未着手 |
| 4 | タスク分解 | ⬜ 未着手 |
| 5 | Azure 構築 / CI-CD | ⬜ 未着手 |
| 6 | 実装・デプロイ | ⬜ 未着手 |

## セットアップ手順

```bash
# 1. リポジトリをクローン
git clone https://github.com/<YOUR_USERNAME>/sms-web.git
cd sms-web

# 2. 環境変数を設定（.env は gitignore 済み）
cp .env.example .env
# .env を編集して GITHUB_PERSONAL_ACCESS_TOKEN / AZURE_SUBSCRIPTION_ID を設定

# 3. VS Code で開く
code .
```
