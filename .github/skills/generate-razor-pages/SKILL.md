---
name: generate-razor-pages
description: >
  エンティティクラスと要件定義を入力として、
  ASP.NET Core 8 Razor Pages の PageModel (.cshtml.cs) と
  ビューテンプレート (.cshtml) を生成するスキル。
  Phase 6 の実装フェーズで使用する。
---

# generate-razor-pages スキル

## 目的
CRUD 操作（一覧・詳細・作成・編集・削除）の Razor Pages セットを生成する。

## 入力
- 対象エンティティクラス（例: `Student`, `Teacher`, `Subject`）
- ロール制御要件（誰がアクセス可能か）

## 出力先
- `src/SmsWeb/Pages/{Entity}/` — 各ページ (.cshtml + .cshtml.cs)

## 生成ページ
| ページ名 | ファイル名 | 説明 |
|---------|-----------|------|
| Index | Index.cshtml | 一覧表示 |
| Details | Details.cshtml | 詳細表示 |
| Create | Create.cshtml | 新規作成フォーム |
| Edit | Edit.cshtml | 編集フォーム |
| Delete | Delete.cshtml | 削除確認 |

## 規約
- PageModel は `[Authorize(Roles = "...")]` で認可制御する
- フォームバインドには `[BindProperty]` を使用する
- サービス層 (`IStudentService` 等) を DI で注入し、PageModel にビジネスロジックを書かない
- バリデーションは DataAnnotations + `ModelState.IsValid` で行う
- Bootstrap 5 クラスを使用してレイアウトを整える
