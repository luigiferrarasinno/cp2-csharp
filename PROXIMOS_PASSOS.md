# 🚀 PRÓXIMOS PASSOS - Sistema CRUD com Login

## ✅ STATUS ATUAL
- ✅ **Compilação bem-sucedida!**
- ✅ **Aplicação rodando** em http://localhost:5000
- ✅ **Código completo** com Login e CRUD de Clientes, Produtos e Usuários
- ⏳ **Falta executar** o script SQL para criar a tabela de Usuários no Oracle

---

## 📋 PASSO 1: Executar Script SQL no Oracle

### Conectar ao Oracle Database
- **Servidor**: `oracle.fiap.com.br:1521/ORCL`
- **Usuário**: `rm98047`
- **Senha**: `201104`

### Script a Executar
Abra o arquivo `Scripts/create_table_usuario.sql` no SQL Developer ou SQL*Plus e execute-o.

**O que o script faz:**
1. ✅ Cria a tabela `RM98047_97648_USUARIO`
2. ✅ Cria a sequence `SEQ_RM98047_97648_USUARIO`
3. ✅ Cria o trigger para auto-increment
4. ✅ Insere 5 usuários de exemplo

**Usuários criados:**
- **Admin**: `admin@sistema.com` / senha: `admin123`
- **João Silva**: `joao@email.com` / senha: `user123`
- **Maria Santos**: `maria@email.com` / senha: `gestor123`
- **Pedro Oliveira**: `pedro@email.com` / senha: `pedro123`
- **Ana Costa**: `ana@email.com` / senha: `ana123`

---

## 🧪 PASSO 2: Testar a Aplicação

### 1. Acessar a tela de Login
Abra no navegador: **http://localhost:5000/login.html**

### 2. Fazer Login
Use as credenciais:
- **Email**: `admin@sistema.com`
- **Senha**: `admin123`

### 3. Testar o Dashboard
Após o login, você será redirecionado para: **http://localhost:5000/index.html**

### 4. Testar CRUD de Clientes
Acesse: **http://localhost:5000/clientes.html**
- ✅ Listar clientes
- ✅ Adicionar novo cliente
- ✅ Editar cliente existente
- ✅ Excluir cliente

### 5. Testar CRUD de Produtos
Acesse: **http://localhost:5000/produtos.html**
- ✅ Listar produtos
- ✅ Adicionar novo produto
- ✅ Editar produto existente
- ✅ Excluir produto

### 6. Testar CRUD de Usuários (Apenas Admin)
Acesse: **http://localhost:5000/usuarios.html**
- ✅ Listar usuários
- ✅ Adicionar novo usuário
- ✅ Editar usuário existente
- ✅ Excluir usuário
- ✅ **Atenção**: Senhas são mascaradas como "****" por segurança

---

## 🔐 FUNCIONALIDADES DO SISTEMA

### Sistema de Autenticação
- ✅ Login com email e senha
- ✅ Validação de credenciais no banco Oracle
- ✅ Sessão armazenada no LocalStorage
- ✅ Redirecionamento automático se não autenticado
- ✅ Último acesso atualizado no banco

### Controle de Acesso
- ✅ Menu "Usuários" visível apenas para **Admin**
- ✅ Tipos de usuário: Admin, Gestor, Usuario
- ✅ Validação de tipo de usuário no frontend

### Interface
- ✅ Design moderno com Bootstrap 5
- ✅ Sidebar responsiva
- ✅ Formulários modais
- ✅ Validações client-side e server-side
- ✅ Máscaras para CPF, telefone, CEP

---

## 📊 ESTRUTURA DO BANCO DE DADOS

### Tabelas Criadas
1. **RM98047_97648_CLIENTE** (Clientes)
2. **RM98047_97648_PRODUTO** (Produtos)
3. **RM98047_97648_USUARIO** (Usuários) ⬅️ **Executar script SQL**

### Prefixo das Tabelas
`RM98047_97648_`

### Schema Oracle
`RM98047`

---

## 🛠️ COMANDOS ÚTEIS

### Parar a aplicação
```cmd
taskkill /F /IM CrudApp.exe
```

### Executar a aplicação
```cmd
cd c:\Users\labsfiap\Downloads\cp
dotnet run
```

### Recompilar
```cmd
cd c:\Users\labsfiap\Downloads\cp
dotnet clean
dotnet build
dotnet run
```

### Ver logs da aplicação
Verifique o terminal onde executou `dotnet run`

---

## 🐛 TROUBLESHOOTING

### Erro ao conectar ao Oracle
- ✅ Verificar se a connection string está correta em `appsettings.json`
- ✅ Verificar firewall/VPN da FIAP
- ✅ Testar conexão com SQL Developer primeiro

### Erro "Cannot access a disposed object"
- ✅ Verificar se o DbContext está sendo usado corretamente
- ✅ Recompilar a aplicação

### Tabela não encontrada
- ✅ Executar o script SQL `create_table_usuario.sql`
- ✅ Verificar se o schema `RM98047` está correto
- ✅ Verificar se o prefixo da tabela está correto

### Login não funciona
- ✅ Verificar se a tabela USUARIO foi criada
- ✅ Verificar se os dados de exemplo foram inseridos
- ✅ Verificar console do navegador (F12) para erros JavaScript
- ✅ Verificar Network tab do navegador para ver se a API retorna 200

---

## 📁 ARQUIVOS IMPORTANTES

### Backend (C#)
- `Models/Usuario.cs` - Model de Usuário
- `Controllers/AuthController.cs` - Controller de autenticação
- `Controllers/UsuariosController.cs` - CRUD de usuários
- `Data/ApplicationDbContext.cs` - Contexto do EF Core

### Frontend (HTML/JS)
- `wwwroot/login.html` - Tela de login
- `wwwroot/index.html` - Dashboard
- `wwwroot/usuarios.html` - CRUD de usuários
- `wwwroot/clientes.html` - CRUD de clientes
- `wwwroot/produtos.html` - CRUD de produtos

### Scripts SQL
- `Scripts/create_table_usuario.sql` - **EXECUTAR ESTE SCRIPT**
- `Scripts/create_tables_oracle.sql` - Tabelas Cliente e Produto
- `Scripts/insert_clientes.sql` - Dados de exemplo
- `Scripts/insert_produtos.sql` - Dados de exemplo

---

## ✨ PRÓXIMAS MELHORIAS SUGERIDAS

1. **Segurança**
   - Hash de senhas com BCrypt
   - JWT Token para autenticação
   - HTTPS em produção

2. **Funcionalidades**
   - Recuperação de senha
   - Alteração de senha
   - Perfil do usuário
   - Logs de auditoria

3. **Interface**
   - Paginação nas listagens
   - Filtros avançados
   - Exportar para Excel/PDF
   - Dashboard com gráficos

---

## 📞 SUPORTE

Se encontrar problemas:
1. Verifique os logs no terminal
2. Verifique o console do navegador (F12)
3. Verifique se o Oracle está acessível
4. Recompile a aplicação

**Boa sorte com o teste! 🚀**
