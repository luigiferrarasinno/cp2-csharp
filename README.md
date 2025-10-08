# 🏢 Sistema Completo de Gestão - Imobiliária & CRUD

Sistema completo desenvolvido em **ASP.NET Core Web API** com **Oracle Database** para gerenciamento de:
- 🏠 **Imobiliária** (Imóveis, Contratos, Visitas)
- 👥 **Clientes**
- 📦 **Produtos**
- 🔐 **Usuários e Autenticação**

---

## 👨‍💻 Desenvolvido por
- **RM 98047**: Luigi Ferrara
- **RM 97648**: Cauã de Jesus
- **Tecnologia**: ASP.NET Core 8.0 + Entity Framework Core + Oracle Database
- **Data**: Outubro de 2025

---

## 🚀 URLs de Acesso

### 🔐 Autenticação
- **Login**: http://localhost:5000/login.html

### 📊 Dashboard e Navegação
- **Dashboard Principal**: http://localhost:5000/index.html

### 🏠 Módulo Imobiliária
- **Gestão de Imóveis**: http://localhost:5000/imoveis.html
- **Gestão de Contratos**: http://localhost:5000/contratos.html
- **Agenda de Visitas**: http://localhost:5000/visitas.html

### 👥 Gestão de Dados
- **Clientes**: http://localhost:5000/clientes.html
- **Produtos**: http://localhost:5000/produtos.html
- **Usuários** (Admin): http://localhost:5000/usuarios.html

### 🔌 API Endpoints
- **Swagger/OpenAPI**: http://localhost:5000/swagger (se habilitado)
- **API Base URL**: http://localhost:5000/api

---

## 📋 Funcionalidades Principais

### 🏠 Sistema de Imobiliária

#### Imóveis
✅ Cadastro completo de imóveis (casa, apartamento, comercial, terreno, chácara, galpão)
✅ Controle de status (Disponível, Ocupado, Manutenção)
✅ Valores de venda e locação
✅ Informações detalhadas (quartos, banheiros, vagas, área)
✅ Filtros avançados por tipo, finalidade e status
✅ **Bloqueio de edição** quando há contrato ativo

#### Contratos
✅ Contratos de venda e locação
✅ Vinculação com imóvel e cliente
✅ Controle de status (Ativo, Encerrado, Cancelado)
✅ Duração e datas configuráveis
✅ **Validação**: Impede múltiplos contratos ativos no mesmo imóvel
✅ **Atualização automática** do status do imóvel

#### Visitas/Agendamento
✅ Agendamento de visitas aos imóveis
✅ Controle de horários (início e fim)
✅ **Validação de sobreposição**: Não permite agendar visitas no mesmo horário
✅ Status de visitas (Agendada, Confirmada, Realizada, Cancelada)
✅ Informações do interessado
✅ Estatísticas (visitas de hoje, agendadas, realizadas)

### 👥 Gestão de Clientes
✅ CRUD completo
✅ Validação de CPF único
✅ Validação de email único
✅ Máscaras para CPF, telefone e CEP
✅ Endereço completo

### 📦 Gestão de Produtos
✅ CRUD completo
✅ Controle de estoque (quantidade)
✅ Categorização
✅ Código único por produto
✅ Status ativo/inativo
✅ Controle de preços

### 🔐 Sistema de Autenticação
✅ Login com email e senha
✅ Sessão armazenada no LocalStorage
✅ Controle de acesso por tipo de usuário (Admin, Gestor, Usuario)
✅ Redirecionamento automático
✅ Último acesso registrado
✅ **Senhas mascaradas** por segurança

---

## 🗄️ Estrutura do Banco de Dados

### Tabelas (Prefixo: RM98047_97648_)

1. **RM98047_97648_CLIENTE**
   - Dados pessoais e endereço
   - CPF e email únicos

2. **RM98047_97648_PRODUTO**
   - Informações do produto
   - Preço, quantidade, categoria
   - Status ativo/inativo

3. **RM98047_97648_USUARIO**
   - Autenticação
   - Tipos: Admin, Gestor, Usuario
   - Controle de último acesso

4. **RM98047_97648_IMOVEL**
   - Detalhes completos do imóvel
   - Valores de venda e locação
   - Características (quartos, banheiros, vagas, área)

5. **RM98047_97648_CONTRATO**
   - Contratos de venda/locação
   - Foreign Keys: Imóvel e Cliente
   - Controle de status e duração

6. **RM98047_97648_VISITA**
   - Agendamento de visitas
   - Foreign Keys: Imóvel e Cliente
   - Horários com validação de sobreposição

---

## 🛠️ Tecnologias Utilizadas

### Backend
- **ASP.NET Core 8.0** Web API
- **Entity Framework Core** (ORM)
- **Oracle.EntityFrameworkCore** (Provider Oracle)
- **Migrations** para versionamento do banco

### Frontend
- **HTML5, CSS3, JavaScript (ES6+)**
- **Bootstrap 5.1.3** (Design responsivo)
- **jQuery 3.6.0**
- **Font Awesome 6.0** (Ícones)
- **jQuery Mask Plugin** (Máscaras de input)

### Banco de Dados
- **Oracle Database**
- **Sequences e Triggers** (Auto increment)
- **Constraints** (Integridade referencial)
- **Foreign Keys** (Relacionamentos)

---

## 🚀 Como Executar o Projeto

### Pré-requisitos
- **.NET 8.0 SDK** instalado
- Acesso ao **Oracle Database** (oracle.fiap.com.br)
- **Visual Studio Code** ou **Visual Studio 2022**

### Passo 1: Clonar o Repositório
```bash
git clone <url-do-repositorio>
cd cp
```

### Passo 2: Configurar Connection String
O arquivo `appsettings.json` já está configurado:
```json
{
  "ConnectionStrings": {
    "OracleConnection": "User Id=rm98047;Password=201104;Data Source=oracle.fiap.com.br:1521/ORCL;"
  }
}
```

### Passo 3: Executar Migrations (Opcional)
```bash
# Aplicar migrations ao banco de dados
dotnet ef database update

# Ou executar os scripts SQL manualmente:
# - Scripts/create_tables_oracle.sql
# - Scripts/create_table_usuario.sql
# - Scripts/create_tables_imobiliaria.sql
```

### Passo 4: Instalar Dependências
```bash
dotnet restore
```

### Passo 5: Compilar o Projeto
```bash
dotnet build
```

### Passo 6: Executar a Aplicação
```bash
dotnet run
```

### Passo 7: Acessar o Sistema
Abra o navegador em: **http://localhost:5000/login.html**

**Credenciais padrão:**
- Email: `admin@sistema.com`
- Senha: `admin123`

---

## 📁 Estrutura do Projeto

```
📦 CrudApp
├── 📂 Controllers/          # Controllers da API
│   ├── AuthController.cs         # Autenticação
│   ├── ClientesController.cs     # CRUD Clientes
│   ├── ProdutosController.cs     # CRUD Produtos
│   ├── UsuariosController.cs     # CRUD Usuários
│   ├── ImoveisController.cs      # CRUD Imóveis
│   ├── ContratosController.cs    # CRUD Contratos
│   └── VisitasController.cs      # CRUD Visitas
├── 📂 Models/               # Modelos de dados
│   ├── Cliente.cs
│   ├── Produto.cs
│   ├── Usuario.cs
│   ├── Imovel.cs
│   ├── Contrato.cs
│   └── Visita.cs
├── 📂 Data/                 # Contexto EF Core
│   └── ApplicationDbContext.cs
├── 📂 Migrations/           # Migrations do EF Core
│   └── 20251008014148_InitialCreate.cs
├── 📂 wwwroot/              # Frontend (HTML/CSS/JS)
│   ├── login.html
│   ├── index.html           # Dashboard
│   ├── imoveis.html
│   ├── contratos.html
│   ├── visitas.html
│   ├── clientes.html
│   ├── produtos.html
│   └── usuarios.html
├── 📂 Scripts/              # Scripts SQL
│   ├── create_tables_oracle.sql
│   ├── create_table_usuario.sql
│   ├── create_tables_imobiliaria.sql
│   ├── insert_clientes.sql
│   └── insert_produtos.sql
└── Program.cs               # Configuração principal
```

---

## 🔗 Endpoints da API REST

### Autenticação
- `POST /api/auth/login` - Login de usuário
- `POST /api/auth/logout` - Logout de usuário

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

### Usuários
- `GET /api/usuarios` - Listar todos
- `GET /api/usuarios/{id}` - Buscar por ID
- `POST /api/usuarios` - Criar novo
- `PUT /api/usuarios/{id}` - Atualizar
- `DELETE /api/usuarios/{id}` - Excluir

### Imóveis
- `GET /api/imoveis` - Listar todos
- `GET /api/imoveis/{id}` - Buscar por ID
- `GET /api/imoveis/disponiveis` - Listar disponíveis
- `POST /api/imoveis` - Criar novo
- `PUT /api/imoveis/{id}` - Atualizar
- `DELETE /api/imoveis/{id}` - Excluir

### Contratos
- `GET /api/contratos` - Listar todos
- `GET /api/contratos/{id}` - Buscar por ID
- `GET /api/contratos/ativos` - Listar ativos
- `POST /api/contratos` - Criar novo
- `PUT /api/contratos/{id}` - Atualizar
- `DELETE /api/contratos/{id}` - Excluir

### Visitas
- `GET /api/visitas` - Listar todas
- `GET /api/visitas/{id}` - Buscar por ID
- `GET /api/visitas/agendadas` - Listar agendadas
- `POST /api/visitas` - Criar nova
- `PUT /api/visitas/{id}` - Atualizar
- `DELETE /api/visitas/{id}` - Excluir

---

## 📊 Regras de Negócio Implementadas

### ✅ Regra 1: Validação de Sobreposição de Visitas
O sistema **NÃO permite** agendar visitas que se sobreponham em horário para o mesmo imóvel.

**Exemplo:**
- Visita 1: 09:00 - 10:00 ✅
- Visita 2: 10:00 - 11:00 ✅ (Permitido)
- Visita 3: 09:30 - 10:30 ❌ (Negado - sobrepõe a Visita 1)

### ✅ Regra 2: Contrato Ativo Bloqueia Alterações Indevidas
Quando um imóvel possui **contrato ativo**, alterações em campos críticos são **bloqueadas**:
- Título
- Descrição
- Tipo de imóvel
- Finalidade
- Valores (venda/locação)
- Endereço

**Campos permitidos:** Status e observações administrativas

### ✅ Regra 3: Validações de Unicidade
- **CPF de Cliente**: Único
- **Email de Cliente**: Único
- **Email de Usuário**: Único
- **Código de Produto**: Único (quando informado)
- **Número de Contrato**: Único

### ✅ Regra 4: Controle de Status de Imóvel
- Ao criar contrato ativo → Imóvel passa para "Ocupado"
- Ao encerrar/cancelar contrato → Imóvel volta para "Disponível"
- Não permite excluir imóvel com contrato ativo

---

## 🎨 Interface do Usuário

- **Design Moderno**: Bootstrap 5 com gradientes e sombras
- **Responsivo**: Funciona em desktop, tablet e mobile
- **Sidebar Navegação**: Menu lateral com ícones
- **Modais**: Formulários em modais para melhor UX
- **Validações**: Client-side e server-side
- **Máscaras**: CPF, telefone, CEP formatados automaticamente
- **Feedback Visual**: Badges de status coloridos
- **Estatísticas**: Cards com contadores no dashboard

---

## 🔒 Segurança

- ✅ Validação de autenticação em todas as páginas
- ✅ Senhas mascaradas no retorno da API
- ✅ Controle de acesso por tipo de usuário
- ✅ Validações server-side para todos os inputs
- ✅ CORS configurado (desenvolvimento)
- ⚠️ **Produção**: Implementar JWT, HTTPS e hash de senhas (BCrypt)

---

## 📝 Scripts SQL Disponíveis

### Criar Tabelas
1. `Scripts/create_tables_oracle.sql` - Clientes e Produtos
2. `Scripts/create_table_usuario.sql` - Usuários
3. `Scripts/create_tables_imobiliaria.sql` - Imóveis, Contratos, Visitas

### Popular com Dados
1. `Scripts/insert_clientes.sql` - Clientes de exemplo
2. `Scripts/insert_produtos.sql` - Produtos de exemplo

### Verificar Migrations
1. `Scripts/verificar_migrations.sql` - Consulta tabelas criadas

---

## 🧪 Como Testar

### 1. Login
1. Acesse: http://localhost:5000/login.html
2. Use: `admin@sistema.com` / `admin123`
3. Será redirecionado ao dashboard

### 2. Cadastrar Imóvel
1. Acesse: http://localhost:5000/imoveis.html
2. Clique em "Novo Imóvel"
3. Preencha os dados
4. Salve

### 3. Agendar Visita
1. Acesse: http://localhost:5000/visitas.html
2. Clique em "Agendar Visita"
3. Selecione imóvel, cliente, data e horário
4. Teste a validação de sobreposição

### 4. Criar Contrato
1. Acesse: http://localhost:5000/contratos.html
2. Clique em "Novo Contrato"
3. Selecione imóvel disponível e cliente
4. Observe que o imóvel muda para "Ocupado"

---

## 📚 Comandos Úteis

### Entity Framework Migrations
```bash
# Criar nova migration
dotnet ef migrations add NomeDaMigration

# Aplicar migrations
dotnet ef database update

# Remover última migration
dotnet ef migrations remove

# Listar migrations
dotnet ef migrations list

# Gerar script SQL
dotnet ef migrations script
```

### Executar Aplicação
```bash
# Modo desenvolvimento
dotnet run

# Modo watch (auto-reload)
dotnet watch run

# Build
dotnet build

# Clean
dotnet clean
```

---

## 🐛 Troubleshooting

### Erro de Conexão com Oracle
- Verifique se a VPN da FIAP está ativa
- Confirme credenciais: `rm98047` / `201104`
- Teste conexão com SQL Developer

### Tabelas não encontradas
- Execute os scripts SQL manualmente OU
- Execute: `dotnet ef database update`

### Erro de autenticação
- Execute: `Scripts/create_table_usuario.sql`
- Verifique se o usuário admin foi criado

### Erro ao salvar visitas
- Certifique-se que a hora de início é menor que a hora de fim
- Verifique se não há sobreposição com outra visita

---

## 📈 Melhorias Futuras

- [ ] Implementar JWT para autenticação
- [ ] Hash de senhas com BCrypt
- [ ] Upload de imagens de imóveis
- [ ] Relatórios em PDF
- [ ] Envio de emails (confirmação de visitas)
- [ ] Dashboard com gráficos (Chart.js)
- [ ] Paginação nas listagens
- [ ] Filtros avançados
- [ ] Exportação para Excel
- [ ] Logs de auditoria
- [ ] Testes unitários e de integração

---

## 📞 Suporte

Para dúvidas ou problemas:
1. Verifique a documentação
2. Consulte os arquivos em `Scripts/`
3. Revise os logs do terminal
4. Verifique o console do navegador (F12)

---

## 📄 Licença

Projeto desenvolvido para fins acadêmicos - FIAP 2025

---

## 🎉 Status do Projeto

✅ **100% Funcional**
- ✅ Backend completo
- ✅ Frontend responsivo
- ✅ Banco de dados configurado
- ✅ Migrations criadas
- ✅ Validações implementadas
- ✅ Regras de negócio ativas
- ✅ Autenticação funcionando

**Última atualização:** Outubro de 2025
