<!-- Use this file to provide workspace-specific custom instructions to Copilot. For more details, visit https://code.visualstudio.com/docs/copilot/copilot-customization#_use-a-githubcopilotinstructionsmd-file -->

# Instruções do Projeto CRUD App

Este é um projeto ASP.NET Core Web API com Entity Framework e Oracle Database para gerenciamento de Clientes e Produtos.

## Contexto do Projeto
- **Tecnologia**: ASP.NET Core 8.0 Web API
- **Banco**: Oracle Database com Entity Framework Core
- **Frontend**: HTML, CSS, JavaScript, Bootstrap 5
- **Padrão**: CRUD completo com interface web

## Convenções do Código
- Use português para nomes de propriedades e comentários
- Prefixo das tabelas: `RM98047_97648_`
- Padrão Repository/Controller para API
- Views com Bootstrap e jQuery para interface

## Estrutura
- `Models/`: Entidades Cliente e Produto
- `Controllers/`: APIs REST e Controllers MVC
- `Data/`: DbContext do Entity Framework
- `Views/`: Interface HTML com formulários modais
- `Scripts/`: Scripts SQL Oracle

## Configurações Importantes
- Connection String Oracle: `User Id=rm98047;Password=201104;Data Source=oracle.fiap.com.br:1521/ORCL;`
- Auto increment via Sequences e Triggers Oracle
- Validações tanto client-side quanto server-side
- CORS habilitado para desenvolvimento
