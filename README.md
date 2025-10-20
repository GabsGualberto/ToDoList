# API de Lista de Tarefas (To-do List)

Esta é uma API de exemplo para um sistema de **To-do List** (Lista de Tarefas), construída com **.NET 8** e **ASP.NET Core**. Ela gerencia **Assignments** (Tarefas) com nome, descrição, status, prioridade e prazos.

## 🚀 Tecnologias Principais

- .NET 8  
- ASP.NET Core (API RESTful)  
- Entity Framework Core 8 (ORM)  
- PostgreSQL (banco de dados)

## ✅ Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- **.NET 8 SDK**  
- **PostgreSQL** (local ou remoto)  
- *(Opcional)* Ferramentas de linha de comando do EF Core:

```bash
dotnet tool install --global dotnet-ef
```

## 📁 Configuração do Projeto

### 1. Clone o repositório:

```bash
git clone https://seu-repositorio.com/todolist-api.git
cd todolist-api
```

### 2. Configure a String de Conexão

Edite o arquivo `appsettings.Development.json` e ajuste a seção `ConnectionStrings`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=todolist_db;Username=postgres;Password=sua_senha_segura"
  }
}
```

## 🗄️ Configuração do Banco de Dados

Você pode configurar o banco de dados de duas formas:

### ✅ Método 1: Entity Framework Core Migrations (Recomendado)

As migrações já estão configuradas no projeto.

Para aplicar as migrações e criar o banco de dados:

```bash
dotnet ef database update
```

Esse comando irá:

- Ler a string de conexão  
- Criar o banco de dados (*se não existir*)  
- Aplicar as tabelas (como `Assignments`)  

Se precisar criar uma nova migração:

```bash
dotnet ef migrations add NomeDaSuaMigracao
```

### 🛠️ Método 2: Scripts SQL Manuais

1. **Criar o Banco de Dados:**

```sql
CREATE DATABASE todolist_db;
```

2. **Criar a Tabela (conectado ao `todolist_db`):**

```sql
CREATE TABLE "Assignments" (
    "Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(255) NOT NULL,
    "Description" TEXT,
    "Status" INTEGER DEFAULT 0,
    "Priority" INTEGER DEFAULT 0,
    "CreatedAt" TIMESTAMPTZ DEFAULT CURRENT_TIMESTAMP,
    "Deadline" TIMESTAMPTZ,
    "ModifiedAt" TIMESTAMPTZ
);
```

## ▶️ Executando a Aplicação

Após a configuração do banco de dados, execute:

```bash
dotnet run
```

A API estará disponível em:

- http://localhost:5000  
- https://localhost:5001  

A documentação Swagger estará acessível em:

```
http://localhost:5000/swagger
```

---

Feito com 💻 e .NET 8
