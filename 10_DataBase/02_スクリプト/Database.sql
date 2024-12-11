-- =============================================
-- 依存関係を考慮したDROP文
-- =============================================
DROP TABLE IF EXISTS message;
DROP TABLE IF EXISTS channel;
DROP TABLE IF EXISTS user_profile;
DROP TABLE IF EXISTS user_status;
DROP TABLE IF EXISTS [user];
DROP TABLE IF EXISTS channel_icon_master;
DROP TABLE IF EXISTS user_icon;
DROP TABLE IF EXISTS status;
DROP TABLE IF EXISTS [group];
DROP TABLE IF EXISTS group_admin;

-- =============================================
-- status テーブル
-- =============================================
CREATE TABLE status (
    id INT IDENTITY(1,1) PRIMARY KEY, -- ステータスID
    name VARCHAR(30) NOT NULL          -- ステータス名
);

-- =============================================
-- user_icon テーブル
-- =============================================
CREATE TABLE user_icon (
    id INT IDENTITY(1,1) PRIMARY KEY,        -- アイコンID（自動インクリメント）
    icon_level INT NOT NULL UNIQUE,          -- ユーザーレベル（1, 2, 3...）
    batch_image_url VARCHAR(255) NOT NULL    -- バッチ画像URL
);

-- =============================================
-- channel_icon_master テーブル
-- =============================================
CREATE TABLE channel_icon_master (
    level INT PRIMARY KEY,            -- レベル
    image_url VARCHAR(255) NOT NULL   -- レベルに応じたアイコンのURL
);

-- =============================================
-- user テーブル
-- =============================================
CREATE TABLE [user] (
    id INT IDENTITY(1,1) PRIMARY KEY,                        -- ユーザID（自動インクリメント）
    login_id VARCHAR(20) NOT NULL,                           -- ログインID
    password VARCHAR(255) NOT NULL,                          -- パスワード
    is_active TINYINT NOT NULL DEFAULT 1,                    -- アクティブフラグ
    create_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP, -- 作成日時
    modified_day DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,-- 更新日時
    user_level INT,                                          -- ユーザレベル
    user_icon_id INT,                                        -- ユーザアイコンID
    is_deleted TINYINT DEFAULT 0,                           -- 論理削除フラグ
    FOREIGN KEY (user_icon_id) REFERENCES user_icon(id)      -- ユーザアイコンの外部キー
);

-- =============================================
-- user_status テーブル
-- =============================================
CREATE TABLE user_status (
    id INT IDENTITY(1,1) PRIMARY KEY,                        -- ユーザーステータスID
    user_id INT NOT NULL,                                    -- ユーザーID
    status_id INT NOT NULL,                                  -- 定型ステータスID
    custom_message VARCHAR(255),                             -- 任意のステータスメッセージ
    updated_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,  -- 更新日時
    FOREIGN KEY (user_id) REFERENCES [user](id),             -- ユーザーIDの外部キー
    FOREIGN KEY (status_id) REFERENCES status(id)            -- ステータスIDの外部キー
);

-- =============================================
-- user_profile テーブル
-- =============================================
CREATE TABLE user_profile (
    id INT IDENTITY(1,1) PRIMARY KEY,          -- プロフィールID
    user_id INT NOT NULL,                      -- ユーザーID
    profile_image_url VARCHAR(255),            -- プロフィール画像URL
    bio VARCHAR(255),                          -- 自己紹介文
    FOREIGN KEY (user_id) REFERENCES [user](id)-- ユーザーIDの外部キー
);

-- =============================================
-- group テーブル
-- =============================================
CREATE TABLE [group] (
    id INT IDENTITY(1,1) PRIMARY KEY,              -- グループID（自動インクリメント）
    name VARCHAR(50) NOT NULL,                     -- グループ名
    description VARCHAR(255),                      -- グループ説明
    created_user_id INT NOT NULL,                  -- 作成者ID
    created_day DATETIME DEFAULT CURRENT_TIMESTAMP,-- 作成日
    modified_day DATETIME DEFAULT CURRENT_TIMESTAMP,-- 更新日
    FOREIGN KEY (created_user_id) REFERENCES [user](id) -- 作成者IDの外部キー
);

-- =============================================
-- group_admin テーブル
-- =============================================
CREATE TABLE group_admin (
    id INT IDENTITY(1,1) PRIMARY KEY,              -- グループ管理者ID
    group_id INT NOT NULL,                         -- グループID
    user_id INT NOT NULL,                          -- 管理者ユーザーID
    assigned_day DATETIME DEFAULT CURRENT_TIMESTAMP,-- 任命日
    FOREIGN KEY (group_id) REFERENCES [group](id), -- グループIDの外部キー
    FOREIGN KEY (user_id) REFERENCES [user](id)    -- ユーザーIDの外部キー
);

-- =============================================
-- channel テーブル
-- =============================================
CREATE TABLE channel (
    id INT IDENTITY(1,1) PRIMARY KEY,                 -- チャンネルID（自動インクリメント）
    group_id INT NOT NULL,                            -- グループID
    title VARCHAR(30) NOT NULL,                       -- チャンネル名
    created_user_id INT NOT NULL,                     -- 作成者ID
    created_day DATETIME DEFAULT CURRENT_TIMESTAMP,   -- 作成日
    modified_day DATETIME DEFAULT CURRENT_TIMESTAMP,  -- 更新日
    level INT DEFAULT 1,                              -- チャンネルレベル（デフォルト1）
    description VARCHAR(80) NOT NULL,                 -- チャンネル説明
    FOREIGN KEY (group_id) REFERENCES [group](id),    -- グループIDの外部キー
    FOREIGN KEY (created_user_id) REFERENCES [user](id) -- 作成者IDの外部キー
);
-- =============================================
-- message テーブル
-- =============================================
CREATE TABLE message (
    id INT IDENTITY(1,1) PRIMARY KEY,                -- メッセージID（自動インクリメント）
    user_id INT NOT NULL,                            -- ユーザID
    handle_name VARCHAR(30),                         -- ハンドルネーム
    message_no INT IDENTITY(1,1),                    -- メッセージNo（自動インクリメント）
    text VARCHAR(255),                               -- メッセージテキスト
    media_url VARCHAR(255),                          -- メディアURL
    post_date DATETIME DEFAULT CURRENT_TIMESTAMP,    -- 投稿日時
    modified_day DATETIME DEFAULT CURRENT_TIMESTAMP, -- 更新日時
    FOREIGN KEY (user_id) REFERENCES [user](id)      -- ユーザIDの外部キー
);
