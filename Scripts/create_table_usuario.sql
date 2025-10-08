-- Script SQL para Tabela de Usuários
-- Prefixo: RM98047_97648

-- ===================================
-- CRIAÇÃO DA TABELA DE USUÁRIOS
-- ===================================

-- Dropar a tabela se ela existir (opcional)
-- DROP TABLE RM98047_97648_USUARIO CASCADE CONSTRAINTS;

-- Criar tabela de usuários
CREATE TABLE RM98047_97648_USUARIO (
    ID NUMBER(10) NOT NULL,
    NOME VARCHAR2(100) NOT NULL,
    EMAIL VARCHAR2(100) NOT NULL,
    SENHA VARCHAR2(255) NOT NULL,
    TIPO VARCHAR2(20) DEFAULT 'Usuario' NOT NULL,
    ATIVO NUMBER(1) DEFAULT 1 NOT NULL,
    DATA_CADASTRO DATE DEFAULT SYSDATE NOT NULL,
    ULTIMO_ACESSO DATE,
    CONSTRAINT PK_RM98047_97648_USUARIO PRIMARY KEY (ID),
    CONSTRAINT UK_RM98047_97648_USUARIO_EMAIL UNIQUE (EMAIL),
    CONSTRAINT CK_RM98047_97648_USUARIO_ATIVO CHECK (ATIVO IN (0, 1)),
    CONSTRAINT CK_RM98047_97648_USUARIO_TIPO CHECK (TIPO IN ('Admin', 'Usuario', 'Gestor'))
);

-- Criar sequência para ID do usuário
CREATE SEQUENCE SEQ_RM98047_97648_USUARIO
    START WITH 1
    INCREMENT BY 1
    NOCACHE
    NOCYCLE;

-- Criar trigger para auto increment do ID
CREATE OR REPLACE TRIGGER TRG_RM98047_97648_USUARIO_ID
    BEFORE INSERT ON RM98047_97648_USUARIO
    FOR EACH ROW
BEGIN
    IF :NEW.ID IS NULL THEN
        :NEW.ID := SEQ_RM98047_97648_USUARIO.NEXTVAL;
    END IF;
END;
/

-- ===================================
-- INSERIR USUÁRIOS DE EXEMPLO
-- ===================================

-- Usuário Admin padrão (senha: admin123)
INSERT INTO RM98047_97648_USUARIO (NOME, EMAIL, SENHA, TIPO) VALUES
('Administrador', 'admin@sistema.com', 'admin123', 'Admin');

-- Usuário comum (senha: user123)
INSERT INTO RM98047_97648_USUARIO (NOME, EMAIL, SENHA, TIPO) VALUES
('João Silva', 'joao@email.com', 'user123', 'Usuario');

-- Gestor (senha: gestor123)
INSERT INTO RM98047_97648_USUARIO (NOME, EMAIL, SENHA, TIPO) VALUES
('Maria Santos', 'maria@email.com', 'gestor123', 'Gestor');

-- Mais usuários de exemplo
INSERT INTO RM98047_97648_USUARIO (NOME, EMAIL, SENHA, TIPO) VALUES
('Pedro Oliveira', 'pedro@email.com', 'pedro123', 'Usuario');

INSERT INTO RM98047_97648_USUARIO (NOME, EMAIL, SENHA, TIPO) VALUES
('Ana Costa', 'ana@email.com', 'ana123', 'Gestor');

-- Commit
COMMIT;

-- ===================================
-- CONSULTAS ÚTEIS
-- ===================================

-- Ver todos os usuários
SELECT * FROM RM98047_97648_USUARIO ORDER BY ID;

-- Ver apenas usuários ativos
SELECT * FROM RM98047_97648_USUARIO WHERE ATIVO = 1 ORDER BY ID;

-- Contar usuários por tipo
SELECT TIPO, COUNT(*) AS TOTAL 
FROM RM98047_97648_USUARIO 
GROUP BY TIPO 
ORDER BY TIPO;

-- Atualizar último acesso (exemplo)
-- UPDATE RM98047_97648_USUARIO SET ULTIMO_ACESSO = SYSDATE WHERE ID = 1;

-- ===================================
-- SCRIPTS DE LIMPEZA (OPCIONAL)
-- ===================================

-- Limpar dados
-- DELETE FROM RM98047_97648_USUARIO;
-- COMMIT;

-- Dropar tabela
-- DROP TABLE RM98047_97648_USUARIO CASCADE CONSTRAINTS;
-- DROP SEQUENCE SEQ_RM98047_97648_USUARIO;
