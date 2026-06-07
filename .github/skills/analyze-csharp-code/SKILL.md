---
name: analyze-csharp-code
description: >
  C++ または C# のソースコードとSQLスキーマを解析し、
  移行アセスメントドキュメント (Markdown) を生成するスキル。
  Phase 1 の現状分析フェーズで使用する。
---

# analyze-csharp-code スキル

## 目的
既存の C++/C# ソースコードと SQL DDL を入力として受け取り、以下を出力する。

1. **機能一覧** — 現行システムが持つ全機能をテーブル形式で列挙
2. **データモデル** — テーブル定義・カラム型・リレーションを図解
3. **移行リスク** — 移植困難な箇所（Windows API 依存、平文パスワード等）を列挙
4. **推奨アーキテクチャ** — Azure クラウドネイティブ構成の提案

## 入力
- `C:\GHCP_Work\0607_CtoAz_01\01_Analayze_Original Sorce\sms2\SMS\SMS.cpp` — C++ メインソース
- `C:\GHCP_Work\0607_CtoAz_01\01_Analayze_Original Sorce\sms2\SQL Query\sms_create.sql` — DB スキーマ

## 出力
- `docs/phase1-assessment.md`

## 実行手順
1. `SMS.cpp` を全文読み込み、関数・クラス・メニュー構造を把握する
2. `sms_create.sql` を読み込み、テーブル定義・カラム制約・リレーションを把握する
3. 機能一覧、データモデル、移行リスク、推奨アーキテクチャの順に Markdown を生成する
4. `docs/phase1-assessment.md` として保存する
