# CRUD App - Sistema de Gestão de Clientes e Produtos

Este é um sistema completo de CRUD (Create, Read, Update, Delete) desenvolvido em ASP.NET Core Web API com interface HTML para gerenciamento de Clientes e Produtos, utilizando Oracle Database.

## 🏗️ Arquitetura do Projeto

- **Backend**: ASP.NET Core Web API (.NET 8.0)
- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap 5
- **Banco de Dados**: Oracle Database
- **ORM**: Entity Framework Core com Oracle Provider

## 📋 Funcionalidades

### Gestão de Clientes
- ✅ Cadastrar novos clientes
- ✅ Listar todos os clientes
- ✅ Editar informações do cliente
- ✅ Excluir clientes
- ✅ Validação de CPF único
- ✅ Validação de email único
- ✅ Máscaras para CPF, telefone e CEP

### Gestão de Produtos
- ✅ Cadastrar novos produtos
- ✅ Listar todos os produtos
- ✅ Editar informações do produto
- ✅ Excluir produtos
- ✅ Controle de estoque (quantidade)
- ✅ Categorização de produtos
- ✅ Status ativo/inativo
- ✅ Código único por produto

### Interface Web
- ✅ Dashboard com estatísticas
- ✅ Design responsivo e moderno
- ✅ Navegação intuitiva
- ✅ Modais para formulários
- ✅ Validação client-side e server-side

## 🗄️ Estrutura do Banco de Dados

### Tabelas Criadas (com prefixo RM98047_97648)

#### RM98047_97648_CLIENTE
```sql
- ID (NUMBER) - Chave primária, auto incremento
- NOME (VARCHAR2(100)) - Nome completo
- CPF (VARCHAR2(14)) - CPF único
- EMAIL (VARCHAR2(100)) - Email único  
- TELEFONE (VARCHAR2(15)) - Telefone
- ENDERECO (VARCHAR2(200)) - Endereço completo
- CIDADE (VARCHAR2(50)) - Cidade
- ESTADO (VARCHAR2(2)) - UF
- CEP (VARCHAR2(8)) - CEP
- DATA_CADASTRO (DATE) - Data de cadastro automática
```

#### RM98047_97648_PRODUTO
```sql
- ID (NUMBER) - Chave primária, auto incremento
- NOME (VARCHAR2(100)) - Nome do produto
- DESCRICAO (VARCHAR2(500)) - Descrição detalhada
- PRECO (NUMBER(10,2)) - Preço
- QUANTIDADE (NUMBER(10)) - Quantidade em estoque
- CATEGORIA (VARCHAR2(50)) - Categoria do produto
- CODIGO (VARCHAR2(20)) - Código único do produto
- DATA_CADASTRO (DATE) - Data de cadastro automática
- ATIVO (NUMBER(1)) - Status ativo/inativo (1/0)
```

## ⚙️ Configuração do Banco de Dados

A conexão com o Oracle está configurada com:
```csharp
User Id=rm98047;Password=201104;Data Source=oracle.fiap.com.br:1521/ORCL;
```

## 📁 Estrutura de Arquivos

```
📦 CrudApp
├── 📂 Controllers/          # Controllers da API e Views
│   ├── ClientesController.cs    # API CRUD Clientes
│   ├── ProdutosController.cs    # API CRUD Produtos  
│   └── HomeController.cs        # Controller das Views
├── 📂 Models/              # Modelos de dados
│   ├── Cliente.cs              # Modelo Cliente
│   └── Produto.cs              # Modelo Produto
├── 📂 Data/                # Contexto do Entity Framework
│   └── ApplicationDbContext.cs  # DbContext principal
├── 📂 Views/               # Views HTML
│   ├── 📂 Home/
│   │   ├── Index.cshtml        # Dashboard
│   │   ├── Clientes.cshtml     # Gestão de Clientes
│   │   └── Produtos.cshtml     # Gestão de Produtos
│   ├── 📂 Shared/
│   │   └── _Layout.cshtml      # Layout principal
│   ├── _ViewStart.cshtml
│   └── _ViewImports.cshtml
├── 📂 Scripts/             # Scripts SQL
│   └── create_tables_oracle.sql # Scripts de criação das tabelas
└── Program.cs              # Configuração principal
```

## 🚀 Como Executar

### 1. Pré-requisitos
- .NET 8.0 SDK
- Acesso ao Oracle Database (oracle.fiap.com.br)

### 2. Configurar o Banco de Dados
Execute o script SQL localizado em `Scripts/create_tables_oracle.sql` no seu Oracle Database.

**Importante:** O script já está corrigido com CEPs sem hífen (8 caracteres).

### 3. Executar a Aplicação
```bash
dotnet restore
dotnet build
dotnet run
```

### 4. Acessar a Aplicação
- **Dashboard**: http://localhost:5000/index.html
- **Clientes**: http://localhost:5000/clientes.html
- **Produtos**: http://localhost:5000/produtos.html
- **API Swagger**: http://localhost:5000/swagger

## 🔗 Endpoints da API

### Clientes
- `GET /api/clientes` - Listar todos os clientes
- `GET /api/clientes/{id}` - Buscar cliente por ID
- `POST /api/clientes` - Criar novo cliente
- `PUT /api/clientes/{id}` - Atualizar cliente
- `DELETE /api/clientes/{id}` - Excluir cliente

### Produtos
- `GET /api/produtos` - Listar todos os produtos
- `GET /api/produtos/{id}` - Buscar produto por ID  
- `POST /api/produtos` - Criar novo produto
- `PUT /api/produtos/{id}` - Atualizar produto
- `DELETE /api/produtos/{id}` - Excluir produto

## 🎨 Tecnologias Utilizadas

### Backend
- ASP.NET Core 8.0
- Entity Framework Core
- Oracle.EntityFrameworkCore
- Swagger/OpenAPI

### Frontend  
- HTML5
- CSS3
- JavaScript (ES6+)
- jQuery
- Bootstrap 5.1.3
- Font Awesome 6.0

### Banco de Dados
- Oracle Database
- Sequences e Triggers para auto incremento
- Constraints para integridade dos dados

## 📝 Exemplos de Uso

### Criar Cliente via API
```json
POST /api/clientes
Content-Type: application/json

{
  "nome": "João Silva",
  "cpf": "123.456.789-00",
  "email": "joao@email.com", 
  "telefone": "(11) 99999-1234",
  "endereco": "Rua das Flores, 123",
  "cidade": "São Paulo",
  "estado": "SP",
  "cep": "01234-567"
}
```

### Criar Produto via API  
```json
POST /api/produtos
Content-Type: application/json

{
  "nome": "Smartphone Samsung",
  "descricao": "Smartphone com 128GB",
  "preco": 899.99,
  "quantidade": 50,
  "categoria": "Eletrônicos", 
  "codigo": "SMART001",
  "ativo": true
}
```

## 🔒 Validações Implementadas

### Cliente
- Nome obrigatório (máx. 100 caracteres)
- CPF obrigatório e único (formato XXX.XXX.XXX-XX)
- Email obrigatório, único e válido
- Estado limitado a siglas válidas (SP, RJ, etc.)

### Produto
- Nome obrigatório (máx. 100 caracteres)
- Preço obrigatório e >= 0
- Quantidade obrigatória e >= 0  
- Código único quando informado
- Status ativo/inativo (boolean)

## 👨‍💻 Desenvolvido por
- **RM**: 98047/97648
- **Tecnologia**: ASP.NET Core + Oracle Database
- **Data**: 2025
"# cp2-csharp" 
