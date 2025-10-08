-- ===================================
-- INSERIR PRODUTOS DE EXEMPLO
-- ===================================

-- Inserir produtos de exemplo
INSERT INTO RM98047_97648_PRODUTO (NOME, DESCRICAO, PRECO, QUANTIDADE, CATEGORIA, CODIGO) VALUES
('Smartphone Samsung Galaxy', 'Smartphone com 128GB de armazenamento', 899.99, 50, 'Eletrônicos', 'SMART001');

INSERT INTO RM98047_97648_PRODUTO (NOME, DESCRICAO, PRECO, QUANTIDADE, CATEGORIA, CODIGO) VALUES
('Notebook Dell Inspiron', 'Notebook Intel Core i5, 8GB RAM, 256GB SSD', 2499.90, 25, 'Eletrônicos', 'NOTE001');

INSERT INTO RM98047_97648_PRODUTO (NOME, DESCRICAO, PRECO, QUANTIDADE, CATEGORIA, CODIGO) VALUES
('Camiseta Polo', 'Camiseta polo masculina 100% algodão', 79.90, 100, 'Roupas', 'POLO001');

INSERT INTO RM98047_97648_PRODUTO (NOME, DESCRICAO, PRECO, QUANTIDADE, CATEGORIA, CODIGO) VALUES
('Mesa de Jantar', 'Mesa de jantar para 6 pessoas em madeira maciça', 1299.00, 10, 'Casa', 'MESA001');

INSERT INTO RM98047_97648_PRODUTO (NOME, DESCRICAO, PRECO, QUANTIDADE, CATEGORIA, CODIGO) VALUES
('Mouse Gamer Logitech', 'Mouse gamer com iluminação RGB e 7 botões', 149.90, 75, 'Eletrônicos', 'MOUSE001');

INSERT INTO RM98047_97648_PRODUTO (NOME, DESCRICAO, PRECO, QUANTIDADE, CATEGORIA, CODIGO) VALUES
('Teclado Mecânico', 'Teclado mecânico gamer com switches blue', 299.00, 40, 'Eletrônicos', 'TECL001');

INSERT INTO RM98047_97648_PRODUTO (NOME, DESCRICAO, PRECO, QUANTIDADE, CATEGORIA, CODIGO) VALUES
('Tênis Esportivo Nike', 'Tênis para corrida com tecnologia Air', 449.90, 60, 'Esportes', 'TENIS001');

INSERT INTO RM98047_97648_PRODUTO (NOME, DESCRICAO, PRECO, QUANTIDADE, CATEGORIA, CODIGO) VALUES
('Livro - Clean Code', 'Livro sobre boas práticas de programação', 89.90, 30, 'Livros', 'LIVRO001');

INSERT INTO RM98047_97648_PRODUTO (NOME, DESCRICAO, PRECO, QUANTIDADE, CATEGORIA, CODIGO) VALUES
('Cafeteira Elétrica', 'Cafeteira elétrica com timer programável', 179.90, 45, 'Casa', 'CAFE001');

INSERT INTO RM98047_97648_PRODUTO (NOME, DESCRICAO, PRECO, QUANTIDADE, CATEGORIA, CODIGO) VALUES
('Fone de Ouvido Bluetooth', 'Fone de ouvido sem fio com cancelamento de ruído', 399.00, 55, 'Eletrônicos', 'FONE001');

INSERT INTO RM98047_97648_PRODUTO (NOME, DESCRICAO, PRECO, QUANTIDADE, CATEGORIA, CODIGO) VALUES
('Calça Jeans', 'Calça jeans masculina modelo slim', 159.90, 80, 'Roupas', 'CALCA001');

INSERT INTO RM98047_97648_PRODUTO (NOME, DESCRICAO, PRECO, QUANTIDADE, CATEGORIA, CODIGO) VALUES
('Bola de Futebol', 'Bola oficial de futebol society', 99.90, 35, 'Esportes', 'BOLA001');

INSERT INTO RM98047_97648_PRODUTO (NOME, DESCRICAO, PRECO, QUANTIDADE, CATEGORIA, CODIGO) VALUES
('Vitamina C 1000mg', 'Suplemento vitamínico 60 cápsulas', 45.90, 120, 'Saúde', 'VIT001');

INSERT INTO RM98047_97648_PRODUTO (NOME, DESCRICAO, PRECO, QUANTIDADE, CATEGORIA, CODIGO) VALUES
('Whey Protein 1kg', 'Proteína concentrada sabor chocolate', 129.90, 90, 'Saúde', 'WHEY001');

INSERT INTO RM98047_97648_PRODUTO (NOME, DESCRICAO, PRECO, QUANTIDADE, CATEGORIA, CODIGO) VALUES
('Tablet Samsung 10 polegadas', 'Tablet Android com 64GB', 1199.00, 20, 'Eletrônicos', 'TAB001');

-- Inserir alguns produtos inativos para teste
INSERT INTO RM98047_97648_PRODUTO (NOME, DESCRICAO, PRECO, QUANTIDADE, CATEGORIA, CODIGO, ATIVO) VALUES
('Produto Descontinuado 1', 'Este produto não está mais disponível', 0.01, 0, 'Outros', 'DESC001', 0);

INSERT INTO RM98047_97648_PRODUTO (NOME, DESCRICAO, PRECO, QUANTIDADE, CATEGORIA, CODIGO, ATIVO) VALUES
('Produto Descontinuado 2', 'Este produto foi removido do catálogo', 0.01, 0, 'Outros', 'DESC002', 0);

-- Commit das transações
COMMIT;

-- Verificar se foram inseridos
SELECT COUNT(*) AS TOTAL_PRODUTOS FROM RM98047_97648_PRODUTO;
SELECT COUNT(*) AS PRODUTOS_ATIVOS FROM RM98047_97648_PRODUTO WHERE ATIVO = 1;
SELECT COUNT(*) AS PRODUTOS_INATIVOS FROM RM98047_97648_PRODUTO WHERE ATIVO = 0;
SELECT * FROM RM98047_97648_PRODUTO ORDER BY ID;
