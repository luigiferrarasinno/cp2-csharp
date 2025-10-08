-- ===================================
-- INSERIR DADOS DE EXEMPLO - CORRIGIDO
-- ===================================

-- Inserir clientes de exemplo (SEM hífen no CEP)
INSERT INTO RM98047_97648_CLIENTE (NOME, CPF, EMAIL, TELEFONE, ENDERECO, CIDADE, ESTADO, CEP) VALUES
('João Silva', '123.456.789-00', 'joao.silva@email.com', '(11) 99999-1234', 'Rua das Flores, 123', 'São Paulo', 'SP', '01234567');

INSERT INTO RM98047_97648_CLIENTE (NOME, CPF, EMAIL, TELEFONE, ENDERECO, CIDADE, ESTADO, CEP) VALUES
('Maria Santos', '987.654.321-00', 'maria.santos@email.com', '(11) 88888-5678', 'Av. Paulista, 456', 'São Paulo', 'SP', '01310100');

INSERT INTO RM98047_97648_CLIENTE (NOME, CPF, EMAIL, TELEFONE, ENDERECO, CIDADE, ESTADO, CEP) VALUES
('Pedro Oliveira', '456.789.123-00', 'pedro.oliveira@email.com', '(21) 77777-9012', 'Rua Copacabana, 789', 'Rio de Janeiro', 'RJ', '22070011');

INSERT INTO RM98047_97648_CLIENTE (NOME, CPF, EMAIL, TELEFONE, ENDERECO, CIDADE, ESTADO, CEP) VALUES
('Ana Costa', '321.654.987-00', 'ana.costa@email.com', '(11) 96666-5555', 'Rua Augusta, 1500', 'São Paulo', 'SP', '01304001');

INSERT INTO RM98047_97648_CLIENTE (NOME, CPF, EMAIL, TELEFONE, ENDERECO, CIDADE, ESTADO, CEP) VALUES
('Carlos Mendes', '789.123.456-00', 'carlos.mendes@email.com', '(21) 95555-4444', 'Av. Atlântica, 200', 'Rio de Janeiro', 'RJ', '22021001');

INSERT INTO RM98047_97648_CLIENTE (NOME, CPF, EMAIL, TELEFONE, ENDERECO, CIDADE, ESTADO, CEP) VALUES
('Fernanda Lima', '654.321.789-00', 'fernanda.lima@email.com', '(11) 94444-3333', 'Rua Oscar Freire, 800', 'São Paulo', 'SP', '01426001');

INSERT INTO RM98047_97648_CLIENTE (NOME, CPF, EMAIL, TELEFONE, ENDERECO, CIDADE, ESTADO, CEP) VALUES
('Ricardo Souza', '147.258.369-00', 'ricardo.souza@email.com', '(47) 93333-2222', 'Rua XV de Novembro, 300', 'Blumenau', 'SC', '89010000');

INSERT INTO RM98047_97648_CLIENTE (NOME, CPF, EMAIL, TELEFONE, ENDERECO, CIDADE, ESTADO, CEP) VALUES
('Juliana Martins', '258.369.147-00', 'juliana.martins@email.com', '(51) 92222-1111', 'Av. Borges de Medeiros, 500', 'Porto Alegre', 'RS', '90020021');

INSERT INTO RM98047_97648_CLIENTE (NOME, CPF, EMAIL, TELEFONE, ENDERECO, CIDADE, ESTADO, CEP) VALUES
('Roberto Alves', '369.147.258-00', 'roberto.alves@email.com', '(85) 91111-0000', 'Rua do Comércio, 150', 'Fortaleza', 'CE', '60025100');

INSERT INTO RM98047_97648_CLIENTE (NOME, CPF, EMAIL, TELEFONE, ENDERECO, CIDADE, ESTADO, CEP) VALUES
('Patricia Rocha', '159.753.486-00', 'patricia.rocha@email.com', '(61) 90000-9999', 'SQN 205 Bloco A', 'Brasília', 'DF', '70843010');

-- Commit das transações
COMMIT;

-- Verificar se foram inseridos
SELECT COUNT(*) AS TOTAL_CLIENTES FROM RM98047_97648_CLIENTE;
SELECT * FROM RM98047_97648_CLIENTE ORDER BY ID;
