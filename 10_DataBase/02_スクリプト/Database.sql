-- =============================================
-- �ˑ��֌W���l������DROP��
-- =============================================
DROP TABLE IF EXISTS messages;
DROP TABLE IF EXISTS group_admins;
DROP TABLE IF EXISTS channels;
DROP TABLE IF EXISTS user_profiles;
DROP TABLE IF EXISTS user_icons;
DROP TABLE IF EXISTS user_statuses;
DROP TABLE IF EXISTS refresh_tokens;
DROP TABLE IF EXISTS channel_icon_masters;
DROP TABLE IF EXISTS statuses;
DROP TABLE IF EXISTS users;
DROP TABLE IF EXISTS groups;

-- =============================================
-- statuses �e�[�u��
-- =============================================
CREATE TABLE statuses (
    id INT IDENTITY(1,1) PRIMARY KEY, -- �X�e�[�^�XID
    name VARCHAR(30) NOT NULL         -- �X�e�[�^�X��
);

-- =============================================
-- user_icons �e�[�u��
-- =============================================
CREATE TABLE user_icons (
    id INT IDENTITY(1,1) PRIMARY KEY,           -- �A�C�R��ID�i�����C���N�������g�j
    icon_level INT NOT NULL UNIQUE,            -- ���[�U�[���x���i1, 2, 3...�j
    batch_image_url VARCHAR(255) NOT NULL    -- �o�b�`�摜URL
);

-- =============================================
-- channel_icon_masters �e�[�u��
-- =============================================
CREATE TABLE channel_icon_masters (
    level INT PRIMARY KEY,            -- ���x��
    image_url VARCHAR(255) NOT NULL -- ���x���ɉ������A�C�R����URL
);

-- =============================================
-- users �e�[�u��
-- =============================================
CREATE TABLE users (
    id INT IDENTITY(1,1) PRIMARY KEY,                     -- ���[�UID�i�����C���N�������g�j
    login_id VARCHAR(20) NOT NULL,                         -- ���O�C��ID
    password VARCHAR(255) NOT NULL,                         -- �p�X���[�h
    is_active TINYINT NOT NULL DEFAULT 1,                 -- �A�N�e�B�u�t���O
    create_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP, -- �쐬����
    modified_day DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,-- �X�V����
    user_level INT,                                         -- ���[�U���x��
    user_icon_id INT,                                       -- ���[�U�A�C�R��ID
    is_deleted TINYINT DEFAULT 0,                         -- �_���폜�t���O
    FOREIGN KEY (user_icon_id) REFERENCES user_icons(id)      -- ���[�U�A�C�R���̊O���L�[
);

-- =============================================
-- user_statuses �e�[�u��
-- =============================================
CREATE TABLE user_statuses (
    id INT IDENTITY(1,1) PRIMARY KEY,                     -- ���[�U�[�X�e�[�^�XID
    user_id INT NOT NULL,                                   -- ���[�U�[ID
    status_id INT NOT NULL,                                 -- ��^�X�e�[�^�XID
    custom_message VARCHAR(255),                            -- �C�ӂ̃X�e�[�^�X���b�Z�[�W
    updated_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP, -- �X�V����
    FOREIGN KEY (user_id) REFERENCES users(id),             -- ���[�U�[ID�̊O���L�[
    FOREIGN KEY (status_id) REFERENCES statuses(id)         -- �X�e�[�^�XID�̊O���L�[
);

-- =============================================
-- user_profiles �e�[�u��
-- =============================================
CREATE TABLE user_profiles (
    id INT IDENTITY(1,1) PRIMARY KEY, -- �v���t�B�[��ID
    user_id INT NOT NULL,             -- ���[�U�[ID
    profile_image_url VARCHAR(255),    -- �v���t�B�[���摜URL
    bio VARCHAR(255),                -- ���ȏЉ
    FOREIGN KEY (user_id) REFERENCES users(id)-- ���[�U�[ID�̊O���L�[
);

-- =============================================
-- refresh_tokens �e�[�u��
-- =============================================
CREATE TABLE refresh_tokens (
    id INT IDENTITY(1,1) PRIMARY KEY,  -- ���t���b�V���g�[�N��ID
    user_id INT NOT NULL,              -- ���[�U�[ID
    token VARCHAR(255) NOT NULL,     -- ���t���b�V���g�[�N��
    expiry_date DATETIME NOT NULL,   -- �L������
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP, -- �쐬����
    FOREIGN KEY (user_id) REFERENCES users(id)      -- ���[�U�[ID�̊O���L�[
);

-- =============================================
-- groups �e�[�u��
-- =============================================
CREATE TABLE groups (
    id INT IDENTITY(1,1) PRIMARY KEY,                     -- �O���[�vID�i�����C���N�������g�j
    name VARCHAR(50) NOT NULL,                           -- �O���[�v��
    description VARCHAR(255),                            -- �O���[�v����
    created_user_id INT NOT NULL,                         -- �쐬��ID
    created_day DATETIME DEFAULT CURRENT_TIMESTAMP,-- �쐬��
    modified_day DATETIME DEFAULT CURRENT_TIMESTAMP,-- �X�V��
    FOREIGN KEY (created_user_id) REFERENCES users(id) -- �쐬��ID�̊O���L�[
);

-- =============================================
-- group_admins �e�[�u��
-- =============================================
CREATE TABLE group_admins (
    id INT IDENTITY(1,1) PRIMARY KEY,                     -- �O���[�v�Ǘ���ID
    group_id INT NOT NULL,                                -- �O���[�vID
    user_id INT NOT NULL,                                 -- �Ǘ��҃��[�U�[ID
    assigned_day DATETIME DEFAULT CURRENT_TIMESTAMP,-- �C����
    FOREIGN KEY (group_id) REFERENCES groups(id),       -- �O���[�vID�̊O���L�[
    FOREIGN KEY (user_id) REFERENCES users(id)         -- ���[�U�[ID�̊O���L�[
);

-- =============================================
-- channels �e�[�u��
-- =============================================
CREATE TABLE channels (
    id INT IDENTITY(1,1) PRIMARY KEY,                     -- �`�����l��ID�i�����C���N�������g�j
    group_id INT NOT NULL,                                -- �O���[�vID
    title VARCHAR(30) NOT NULL,                          -- �`�����l����
    created_user_id INT NOT NULL,                         -- �쐬��ID
    created_day DATETIME DEFAULT CURRENT_TIMESTAMP, -- �쐬��
    modified_day DATETIME DEFAULT CURRENT_TIMESTAMP, -- �X�V��
    level INT DEFAULT 1,                                 -- �`�����l�����x���i�f�t�H���g1�j
    description VARCHAR(80) NOT NULL,                     -- �`�����l������
    FOREIGN KEY (group_id) REFERENCES groups(id),       -- �O���[�vID�̊O���L�[
    FOREIGN KEY (created_user_id) REFERENCES users(id) -- �쐬��ID�̊O���L�[
);
-- =============================================
-- messages �e�[�u��
-- =============================================
CREATE TABLE messages (
    id INT IDENTITY(1,1) PRIMARY KEY,                     -- ���b�Z�[�WID�i�����C���N�������g�j
    user_id INT NOT NULL,                                   -- ���[�UID
    handle_name VARCHAR(30),                               -- �n���h���l�[��
    message_no INT,
    text VARCHAR(255),                                   -- ���b�Z�[�W�e�L�X�g
    media_url VARCHAR(255),                               -- ���f�B�AURL
    post_date DATETIME DEFAULT CURRENT_TIMESTAMP,    -- ���e����
    modified_day DATETIME DEFAULT CURRENT_TIMESTAMP, -- �X�V����
    FOREIGN KEY (user_id) REFERENCES users(id)             -- ���[�UID�̊O���L�[
);
