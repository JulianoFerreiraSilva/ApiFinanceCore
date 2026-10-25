# 💰 Finance Core

### API REST para Controle Financeiro | .NET 8 • PostgreSQL • Clean Architecture • CQRS

O **Finance Core** é uma API REST desenvolvida em **C# e ASP.NET Core 8**, voltada ao gerenciamento de contas, categorias e transações financeiras.

O projeto foi desenvolvido para aplicar conceitos de engenharia de software, organização arquitetural, regras de negócio, persistência de dados e segurança em uma aplicação backend.

Além das operações financeiras, a solução disponibiliza consultas com filtros e paginação, dashboards de indicadores e mecanismos de autenticação e autorização.

---

## 🛠️ Tecnologias utilizadas

| Tecnologia | Aplicação |
|---|---|
| C# / .NET 8 | Linguagem e plataforma |
| ASP.NET Core Web API | Desenvolvimento dos endpoints REST |
| Entity Framework Core | Mapeamento objeto-relacional e persistência |
| PostgreSQL | Banco de dados relacional |
| MediatR | Implementação do padrão CQRS |
| FluentValidation | Validação de requisições |
| ASP.NET Core Identity | Gerenciamento de usuários e perfis |
| JWT Bearer | Autenticação baseada em tokens |
| Swagger / OpenAPI | Documentação e exploração da API |
| Git / GitHub | Versionamento de código |

## 🏗️ Arquitetura e padrões

O projeto utiliza uma arquitetura organizada em camadas, buscando separar responsabilidades e facilitar a manutenção.

**Domain**

Contém as entidades, enumerações e regras de negócio relacionadas ao domínio financeiro.

**Application**

Concentra os casos de uso, comandos, consultas, handlers, validações e DTOs (Data Transfer Objects).

**Infrastructure**

Responsável pelo acesso a dados, implementação de repositórios, integração com o Entity Framework Core, autenticação e serviços de infraestrutura.

**API**

Disponibiliza os controllers, endpoints HTTP, configuração de serviços e middleware.

### Padrões aplicados

- **CQRS (Command Query Responsibility Segregation):** separação entre operações de escrita e consultas, com utilização do MediatR.
- **Repository Pattern:** abstração das operações de persistência.
- **Unit of Work:** coordenação da persistência de alterações.
- **Dependency Injection:** gerenciamento de dependências entre componentes.
- **DTOs:** definição de contratos para entrada e saída de dados.
- **FluentValidation:** validação de comandos e requisições.
- **Middleware de exceções:** tratamento centralizado de erros da aplicação.

---

## 📦 Funcionalidades implementadas

### Categorias financeiras

Gerenciamento das categorias utilizadas na classificação de receitas e despesas.

- Cadastro de categorias.
- Consulta individual e listagem.
- Atualização de informações.
- Exclusão de categorias.
- Controle de situação ativa/inativa.

### Contas financeiras

Gerenciamento de contas e seus respectivos saldos.

- Cadastro de contas.
- Definição de tipo de conta.
- Registro de saldo inicial.
- Consulta e atualização.
- Exclusão de contas.
- Manutenção do saldo atual conforme as movimentações financeiras.

### Transações financeiras

Registro e gerenciamento das movimentações associadas às contas.

- Cadastro de receitas e despesas.
- Consulta de transações.
- Atualização e exclusão.
- Associação com contas e categorias.
- Atualização automática do saldo da conta.
- Estorno dos efeitos financeiros nas operações de alteração e exclusão.

O domínio também contempla o tipo de transação **Transferência**, cuja cobertura funcional deve ser considerada conforme as regras disponíveis na implementação.

### Filtros e paginação

Consultas de transações com suporte a:

- Data inicial e final.
- Conta financeira.
- Categoria.
- Tipo de transação.
- Número da página.
- Quantidade de registros por página.

### Dashboard financeiro

Disponibiliza indicadores consolidados, incluindo:

- Saldo atual total.
- Receitas do mês.
- Despesas do mês.
- Resultado financeiro mensal.
- Maior receita e maior despesa.
- Quantidade de receitas e despesas.
- Últimas transações registradas.

### Dashboard executivo

Disponibiliza consultas consolidadas para acompanhamento e análise das informações financeiras.

---

## 🔐 Autenticação e segurança

O Finance Core utiliza **ASP.NET Core Identity** e **JWT (JSON Web Token)** para autenticação e autorização.

Entre os mecanismos implementados estão:

- Autenticação de usuários.
- Geração de access tokens.
- Geração de refresh tokens.
- Controle de acesso com autorização.
- Perfis de usuário por roles.
- Rotação de refresh tokens.
- Armazenamento do hash dos refresh tokens.
- Rejeição de reutilização de refresh tokens.
- Configuração de credenciais por ambiente.
- Tratamento centralizado de exceções.

A criação inicial do usuário administrador por meio do `IdentitySeeder` é restrita ao ambiente de desenvolvimento.

**Observação:** o projeto é uma demonstração técnica de portfólio. A implementação atual não deve ser interpretada como uma solução de produção integralmente auditada.

---

## ⚙️ Configuração do ambiente

### Pré-requisitos

- .NET SDK 8.
- PostgreSQL.
- Visual Studio ou outra IDE compatível com .NET.
- Git.

### 1. Clonar o repositório

```bash
git clone https://github.com/JulianoFerreiraSilva/ApiFinanceCore.git
```

A URL definitiva será adicionada após a publicação.

### 2. Restaurar as dependências

Na pasta que contém o projeto `.csproj`, execute:

```bash
dotnet restore
```

### 3. Configurar o banco de dados

Crie um banco de dados PostgreSQL para utilização local.

O Finance Core utiliza a configuração `ConnectionStrings:DefaultConnection`, que deve ser fornecida pelo ambiente de desenvolvimento.

**Não é necessário inserir credenciais reais no `appsettings.json`.**

### 4. Configurar o User Secrets

Na pasta do projeto ASP.NET Core, execute:

```bash
dotnet user-secrets init
```

Caso o projeto já possua um `UserSecretsId` configurado, não é necessário inicializá-lo novamente.

Configure a conexão local:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=finance_core;Username=SEU_USUARIO;Password=SUA_SENHA"
```

Configure a chave de assinatura JWT:

```bash
dotnet user-secrets set "Jwt:SecretKey" "SUA_CHAVE_SECRETA_FORTE"
```

A chave deve ser gerada aleatoriamente e possuir entropia suficiente para o algoritmo de assinatura utilizado.

Configure também as credenciais do administrador de desenvolvimento:

```bash
dotnet user-secrets set "Seed:Admin:UserName" "admin@exemplo.local"
dotnet user-secrets set "Seed:Admin:Password" "SUA_SENHA_FORTE"
```

Os valores apresentados são ilustrativos e devem ser substituídos por credenciais próprias.

As demais configurações de JWT, como `Issuer`, `Audience`, `ExpirationMinutes` e `RefreshTokenExpirationDays`, são lidas da seção `Jwt` da configuração da aplicação.

O User Secrets é destinado ao desenvolvimento local e não substitui um gerenciador de segredos para ambientes de produção.

### 5. Aplicar as migrations

Com o PostgreSQL configurado, execute:

```bash
dotnet ef database update
```

O comando exige que a ferramenta `dotnet-ef` esteja disponível e deve ser executado no contexto correto do projeto e das migrations.

### 6. Executar a aplicação

```bash
dotnet run
```

A API poderá ser explorada por meio do Swagger, quando habilitado no ambiente de execução.

---

## 🧪 Validações realizadas

Durante o desenvolvimento, foram realizados testes funcionais dos principais fluxos por meio do Swagger, incluindo:

- Operações de cadastro, consulta, atualização e exclusão.
- Persistência de dados no PostgreSQL.
- Atualização e estorno de saldos.
- Filtros e paginação de transações.
- Consultas dos dashboards.
- Autenticação e acesso a endpoints protegidos.
- Geração e renovação de tokens.
- Rotação e rejeição de reutilização de refresh tokens.

Essas validações foram realizadas durante a evolução do projeto e não representam uma suíte completa de testes automatizados.

---

## 📌 Escopo e evolução

O Finance Core representa uma implementação funcional de um backend financeiro, com foco no aprendizado e na demonstração de competências técnicas.

A solução poderá servir como referência arquitetural para projetos futuros, mas este repositório público possui finalidade de **portfólio e demonstração técnica**.

A implementação publicada não inclui necessariamente todas as otimizações, controles operacionais e mecanismos de escalabilidade exigidos por uma aplicação comercial em produção.

---

## 👨‍💻 Autor

**Juliano Ferreira da Silva**

Desenvolvedor C# / .NET

GitHub: [JulianoFerreiraSilva](https://github.com/JulianoFerreiraSilva)

---

**Finance Core — Desenvolvimento backend com foco em arquitetura, regras de negócio, persistência e segurança.**
