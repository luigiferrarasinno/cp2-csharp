# 📦 GUIA DE MIGRATIONS - Entity Framework Core

## ✅ Migrations Criadas com Sucesso!

As migrations foram configuradas e criadas para o projeto **CrudApp** com **Oracle Database**.

---

## 📋 Migration Criada

### **InitialCreate** (20251008014148)
Criada em: **07 de Outubro de 2025**

Esta migration cria **6 tabelas** no banco de dados Oracle:

| # | Tabela | Descrição |
|---|--------|-----------|
| 1 | `RM98047_97648_CLIENTE` | Cadastro de clientes |
| 2 | `RM98047_97648_PRODUTO` | Cadastro de produtos |
| 3 | `RM98047_97648_USUARIO` | Usuários do sistema (login) |
| 4 | `RM98047_97648_IMOVEL` | Imóveis para venda/locação |
| 5 | `RM98047_97648_CONTRATO` | Contratos de venda/locação |
| 6 | `RM98047_97648_VISITA` | Agendamento de visitas |

---

## 🗂️ Estrutura de Arquivos Criados

```
📁 Migrations/
├── 📄 20251008014148_InitialCreate.cs
├── 📄 20251008014148_InitialCreate.Designer.cs
└── 📄 ApplicationDbContextModelSnapshot.cs
```

### Descrição dos arquivos:

- **`InitialCreate.cs`**: Contém os métodos `Up()` e `Down()` para criar/reverter as tabelas
- **`InitialCreate.Designer.cs`**: Metadados da migration
- **`ApplicationDbContextModelSnapshot.cs`**: Snapshot do modelo atual do banco de dados

---

## 🔧 Comandos Úteis de Migrations

### 1️⃣ **Criar uma nova migration**
```bash
dotnet ef migrations add NomeDaMigration
```

Exemplo:
```bash
dotnet ef migrations add AdicionarCampoTelefoneCliente
```

### 2️⃣ **Aplicar migrations ao banco de dados**
```bash
dotnet ef database update
```

### 3️⃣ **Listar todas as migrations**
```bash
dotnet ef migrations list
```

### 4️⃣ **Reverter a última migration**
```bash
dotnet ef migrations remove
```

⚠️ **Atenção**: Só funciona se a migration ainda não foi aplicada ao banco!

### 5️⃣ **Reverter para uma migration específica**
```bash
dotnet ef database update NomeDaMigration
```

Exemplo (reverter para antes da InitialCreate):
```bash
dotnet ef database update 0
```

### 6️⃣ **Gerar script SQL da migration**
```bash
dotnet ef migrations script
```

Para salvar em arquivo:
```bash
dotnet ef migrations script > migration.sql
```

### 7️⃣ **Ver detalhes do banco de dados**
```bash
dotnet ef dbcontext info
```

### 8️⃣ **Gerar modelo a partir do banco existente (Reverse Engineering)**
```bash
dotnet ef dbcontext scaffold "ConnectionString" Oracle.EntityFrameworkCore -o Models
```

---

## 🎯 Como Usar Migrations no Desenvolvimento

### Cenário 1: Adicionar um novo campo

**Exemplo**: Adicionar campo "DataNascimento" no Cliente

1. Edite o modelo `Models/Cliente.cs`:
```csharp
public DateTime? DataNascimento { get; set; }
```

2. Crie a migration:
```bash
dotnet ef migrations add AdicionarDataNascimentoCliente
```

3. Aplique ao banco:
```bash
dotnet ef database update
```

### Cenário 2: Criar uma nova tabela

**Exemplo**: Criar tabela de Fornecedores

1. Crie o modelo `Models/Fornecedor.cs`

2. Adicione no `DbContext`:
```csharp
public DbSet<Fornecedor> Fornecedores { get; set; }
```

3. Configure no `OnModelCreating`:
```csharp
modelBuilder.Entity<Fornecedor>(entity =>
{
    entity.ToTable("RM98047_97648_FORNECEDOR", "RM98047");
    // ... configurações
});
```

4. Crie a migration:
```bash
dotnet ef migrations add AdicionarTabelaFornecedor
```

5. Aplique ao banco:
```bash
dotnet ef database update
```

### Cenário 3: Alterar tipo de coluna

**Exemplo**: Aumentar tamanho do campo Nome de 100 para 200

1. Edite o modelo:
```csharp
[StringLength(200)]
public string Nome { get; set; }
```

2. Atualize o DbContext:
```csharp
entity.Property(e => e.Nome).HasMaxLength(200);
```

3. Crie a migration:
```bash
dotnet ef migrations add AumentarTamanhoNomeCliente
```

4. Aplique ao banco:
```bash
dotnet ef database update
```

---

## ⚠️ Migrations vs Scripts SQL Manuais

### **Opção 1: Usar Migrations (Recomendado para desenvolvimento)**

✅ **Vantagens**:
- Versionamento automático
- Fácil rollback
- Sincronização entre código e banco
- Funciona em diferentes ambientes

❌ **Desvantagens**:
- Pode gerar scripts complexos
- Requer permissões no banco

### **Opção 2: Scripts SQL Manuais (Usado neste projeto)**

✅ **Vantagens**:
- Controle total do SQL
- Triggers e Sequences customizados
- Ideal para bancos existentes

❌ **Desvantagens**:
- Sem versionamento automático
- Rollback manual

### **🎯 Estratégia Recomendada para Este Projeto**

Como você já tem os **scripts SQL criados manualmente** em `Scripts/`:
- `create_tables_oracle.sql`
- `create_table_usuario.sql`
- `create_tables_imobiliaria.sql`

**Recomendação**:
1. **Use os scripts SQL manuais** para criar a estrutura inicial no Oracle
2. **Use Migrations** apenas para **alterações futuras** durante o desenvolvimento
3. No **ambiente de produção**, execute os scripts SQL manuais

---

## 🔄 Workflow Recomendado

### Ambiente de **Desenvolvimento**:

```bash
# 1. Fazer alterações nos Models
# 2. Criar migration
dotnet ef migrations add DescricaoDaAlteracao

# 3. Aplicar ao banco local
dotnet ef database update

# 4. Testar a aplicação
dotnet run
```

### Ambiente de **Produção**:

```bash
# 1. Gerar script SQL da migration
dotnet ef migrations script > Scripts/migration_producao.sql

# 2. Revisar o script SQL manualmente

# 3. Executar no banco de produção via SQL Developer ou SQL*Plus
```

---

## 📊 Estrutura das Tabelas Criadas

### 1. **RM98047_97648_CLIENTE**
```sql
ID (NUMBER) - PK, Auto Increment
NOME (NVARCHAR2(100))
CPF (NVARCHAR2(14))
EMAIL (NVARCHAR2(100))
TELEFONE (NVARCHAR2(15))
ENDERECO (NVARCHAR2(200))
CIDADE (NVARCHAR2(50))
ESTADO (NVARCHAR2(2))
CEP (NVARCHAR2(8))
DATA_CADASTRO (TIMESTAMP)
```

### 2. **RM98047_97648_PRODUTO**
```sql
ID (NUMBER) - PK, Auto Increment
NOME (NVARCHAR2(100))
DESCRICAO (NVARCHAR2(500))
PRECO (DECIMAL(10,2))
QUANTIDADE (NUMBER)
CATEGORIA (NVARCHAR2(50))
CODIGO (NVARCHAR2(20))
DATA_CADASTRO (TIMESTAMP)
ATIVO (NUMBER(1)) - Boolean
```

### 3. **RM98047_97648_USUARIO**
```sql
ID (NUMBER) - PK, Auto Increment
NOME (NVARCHAR2(100))
EMAIL (NVARCHAR2(100))
SENHA (NVARCHAR2(255))
TIPO (NVARCHAR2(20))
ATIVO (NUMBER(1)) - Boolean
DATA_CADASTRO (TIMESTAMP)
ULTIMO_ACESSO (TIMESTAMP)
```

### 4. **RM98047_97648_IMOVEL**
```sql
ID (NUMBER) - PK, Auto Increment
TITULO (NVARCHAR2(100))
DESCRICAO (NVARCHAR2(500))
TIPO_IMOVEL (NVARCHAR2(20))
FINALIDADE (NVARCHAR2(20))
VALOR_VENDA (DECIMAL(12,2))
VALOR_LOCACAO (DECIMAL(10,2))
ENDERECO (NVARCHAR2(200))
BAIRRO (NVARCHAR2(50))
CIDADE (NVARCHAR2(50))
ESTADO (NVARCHAR2(2))
CEP (NVARCHAR2(8))
QUARTOS (NUMBER(3))
BANHEIROS (NUMBER(3))
VAGAS (NUMBER(3))
AREA_TOTAL (DECIMAL(10,2))
AREA_CONSTRUIDA (DECIMAL(10,2))
PROPRIETARIO (NVARCHAR2(100))
TELEFONE_PROPRIETARIO (NVARCHAR2(15))
STATUS (NVARCHAR2(20))
ATIVO (NUMBER(1)) - Boolean
DATA_CADASTRO (TIMESTAMP)
```

### 5. **RM98047_97648_CONTRATO**
```sql
ID (NUMBER) - PK, Auto Increment
IMOVEL_ID (NUMBER) - FK
CLIENTE_ID (NUMBER) - FK
TIPO_CONTRATO (NVARCHAR2(20))
NUMERO_CONTRATO (NVARCHAR2(30))
VALOR (DECIMAL(12,2))
DATA_INICIO (TIMESTAMP)
DATA_FIM (TIMESTAMP)
DURACAO_MESES (NUMBER(5))
STATUS (NVARCHAR2(20))
OBSERVACOES (NVARCHAR2(500))
DATA_CADASTRO (TIMESTAMP)
```

### 6. **RM98047_97648_VISITA**
```sql
ID (NUMBER) - PK, Auto Increment
IMOVEL_ID (NUMBER) - FK
CLIENTE_ID (NUMBER) - FK
DATA_VISITA (TIMESTAMP)
HORA_INICIO (TIMESTAMP)
HORA_FIM (TIMESTAMP)
STATUS (NVARCHAR2(20))
NOME_INTERESSADO (NVARCHAR2(100))
TELEFONE_INTERESSADO (NVARCHAR2(15))
EMAIL_INTERESSADO (NVARCHAR2(100))
OBSERVACOES (NVARCHAR2(500))
DATA_CADASTRO (TIMESTAMP)
```

---

## 🚨 Troubleshooting

### Erro: "Build failed"
```bash
# Limpar e rebuildar
dotnet clean
dotnet build
dotnet ef migrations add NomeDaMigration
```

### Erro: "No DbContext was found"
```bash
# Especificar o contexto
dotnet ef migrations add NomeDaMigration --context ApplicationDbContext
```

### Erro: "Unable to create an object of type 'ApplicationDbContext'"
- Verifique se a connection string está correta em `appsettings.json`
- Verifique se o Oracle está acessível

### Erro: "A connection was successfully established... but then an error occurred"
- Verifique se o banco Oracle está rodando
- Verifique firewall/VPN
- Teste a connection string manualmente

---

## 📚 Referências

- [EF Core Migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/)
- [Oracle Provider for EF Core](https://www.oracle.com/database/technologies/appdev/dotnet/odp.html)
- [EF Core CLI Reference](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

---

## ✅ Status Atual

- ✅ Migrations configuradas
- ✅ InitialCreate migration criada
- ✅ 6 tabelas mapeadas
- ✅ Pronto para aplicar ao banco de dados

**Para aplicar ao banco Oracle**:
```bash
dotnet ef database update
```

**Ou use os scripts SQL manuais** em `Scripts/` para manter o controle total! 🎯
