# 🚀 Instruções de Uso - CRUD App

## ✅ Projeto Criado com Sucesso!

Seu sistema CRUD completo está funcionando! A aplicação já está rodando em **http://localhost:5000**

## 📋 O que foi criado:

### 🔧 **Backend (ASP.NET Core 8.0)**
- ✅ API REST completa para Clientes e Produtos
- ✅ Entity Framework configurado com Oracle
- ✅ Controllers com CRUD completo
- ✅ Validações server-side
- ✅ Swagger para documentação da API

### 🎨 **Frontend (HTML + Bootstrap)**  
- ✅ Dashboard com estatísticas
- ✅ Tela de gestão de Clientes com modais
- ✅ Tela de gestão de Produtos com modais
- ✅ Design responsivo e moderno
- ✅ Validações client-side com máscaras

### 🗄️ **Banco de Dados Oracle**
- ✅ Script SQL completo em `Scripts/create_tables_oracle.sql`
- ✅ Tabelas com prefixo `RM98047_97648_`
- ✅ Sequences e Triggers para auto incremento
- ✅ Dados de exemplo incluídos
- ✅ Constraints de integridade

## 🔗 **URLs da Aplicação:**

| Funcionalidade | URL |
|---|---|
| **Dashboard** | http://localhost:5000/index.html |
| **Clientes** | http://localhost:5000/clientes.html |
| **Produtos** | http://localhost:5000/produtos.html |
| **API Swagger** | http://localhost:5000/swagger |

## 📊 **APIs Disponíveis:**

### Clientes
- `GET /api/clientes` - Listar todos
- `GET /api/clientes/{id}` - Buscar por ID  
- `POST /api/clientes` - Criar novo
- `PUT /api/clientes/{id}` - Atualizar
- `DELETE /api/clientes/{id}` - Excluir

### Produtos
- `GET /api/produtos` - Listar todos
- `GET /api/produtos/{id}` - Buscar por ID
- `POST /api/produtos` - Criar novo  
- `PUT /api/produtos/{id}` - Atualizar
- `DELETE /api/produtos/{id}` - Excluir

## ⚡ **Próximos Passos:**

### 1. **Configurar o Banco Oracle**
Execute o script `Scripts/create_tables_oracle.sql` no seu Oracle Database:
```sql
-- Conecte-se como rm98047 e execute todo o script
-- Ele criará as tabelas, sequences, triggers e dados de exemplo
-- IMPORTANTE: O script já está corrigido com CEPs sem hífen (8 dígitos)
```

**Nota:** Se você encontrar erros relacionados ao CEP, certifique-se de que está usando o script atualizado que remove os hífens dos CEPs (ex: `01234567` ao invés de `01234-567`).

### 2. **Testar a Aplicação**
- Acesse http://localhost:5000
- Teste o CRUD de Clientes e Produtos  
- Verifique a API no Swagger

### 3. **Personalizar (Opcional)**
- Modifique os estilos CSS no layout
- Adicione novas validações
- Inclua novos campos nas entidades

## 🛠️ **Comandos Úteis:**

```bash
# Parar a aplicação
Ctrl + C

# Executar novamente
dotnet run

# Compilar  
dotnet build

# Restaurar pacotes
dotnet restore

# Fazer migration (se necessário)
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## 🎯 **Funcionalidades Implementadas:**

### ✅ **Dashboard**
- Contador de clientes e produtos
- Cards com estatísticas
- Links para gestão

### ✅ **Gestão de Clientes**
- Formulário completo com validações
- Máscara para CPF, telefone e CEP
- Listagem com ações de editar/excluir
- Validação de CPF e email únicos

### ✅ **Gestão de Produtos**  
- Controle de preço e quantidade
- Categorização de produtos
- Status ativo/inativo
- Código único por produto

### ✅ **Recursos Técnicos**
- API RESTful com padrões HTTP
- Entity Framework com Oracle
- Frontend responsivo
- CORS habilitado para desenvolvimento
- Tratamento de erros

## 🔧 **Estrutura das Tabelas Oracle:**

```sql
RM98047_97648_CLIENTE:
- ID, NOME, CPF, EMAIL, TELEFONE
- ENDERECO, CIDADE, ESTADO, CEP  
- DATA_CADASTRO

RM98047_97648_PRODUTO:  
- ID, NOME, DESCRICAO, PRECO
- QUANTIDADE, CATEGORIA, CODIGO
- DATA_CADASTRO, ATIVO
```

## 🎉 **Parabéns!**

Seu sistema CRUD completo está pronto para uso! 

**Connection String configurada:**
```
User Id=rm98047;Password=201104;Data Source=oracle.fiap.com.br:1521/ORCL;
```

Execute o script SQL e comece a usar sua aplicação! 🚀
