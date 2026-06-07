---
name: generate-efcore-entities
description: >
  SQLスキーマ定義または phase1-assessment.md のデータモデル記述を入力として、
  EF Core 8 Code First の DbContext・エンティティクラスを生成するスキル。
  Phase 3 の設計フェーズおよび Phase 6 の実装フェーズで使用する。
---

# generate-efcore-entities スキル

## 目的
- SQL DDL から C# エンティティクラス（POCO）を生成する
- `ApplicationDbContext` クラスに `DbSet<T>` を追加する
- EF Core のデータアノテーション（`[Required]`, `[MaxLength]` 等）を付与する
- リレーションは Fluent API で `OnModelCreating` に記述する

## 出力先
- `src/SmsWeb/Models/` — エンティティクラス
- `src/SmsWeb/Data/ApplicationDbContext.cs` — DbContext

## 規約
- テーブル名はパスカルケースに変換（例: `student_table` → `Student`）
- カラム名はパスカルケースに変換（例: `FULL_NAME` → `FullName`）
- `ID` カラムは `int Id` にマッピングし、`[Key]` 属性を付与する
- `NOT NULL` カラムは `[Required]` を付与する
- `varchar(N)` は `[MaxLength(N)]` で制約する
- `decimal` 型には `[Column(TypeName = "decimal(18,2)")]` を付与する
