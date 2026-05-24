# ClyvoCare.API

API REST desenvolvida em ASP.NET Core 8 para gerenciamento veterinário inteligente, utilizando Oracle Database e Entity Framework Core.

O projeto foi desenvolvido como solução para o Challenge da disciplina **ADVANCED BUSINESS DEVELOPMENT WITH .NET**, focando em arquitetura enterprise, organização em camadas e boas práticas de desenvolvimento backend.

---

# Tecnologias Utilizadas

- ASP.NET Core 8
- C#
- Oracle Database
- Entity Framework Core
- Swagger / OpenAPI
- Dependency Injection
- REST API
- Git & GitHub

---

# Arquitetura do Projeto

O projeto foi estruturado utilizando arquitetura em camadas:

```text
Controllers
   ↓
Services
   ↓
Entity Framework Core
   ↓
Oracle Database
```

Além disso, foram implementados:

- DTOs
- Middleware global para tratamento de erros
- Validações automáticas
- Paginação
- Filtros dinâmicos
- Busca textual
- Relacionamentos entre entidades

---

# Funcionalidades

## Tutor
- Cadastro de tutores
- Consulta de tutores
- Atualização de dados
- Remoção de tutores

---

## Pet
- Cadastro de pets
- Relacionamento com tutor
- Busca por nome
- Busca por espécie
- Paginação de resultados

---

## Consulta
- Histórico clínico dos pets
- Relacionamento entre pet e consulta
- Consulta de histórico veterinário

---

## Vacina
- Controle de vacinação
- Vacinas vencidas
- Próximas doses
- Relacionamento entre pet e vacina

---

# Recursos Avançados

- DTO Pattern
- Service Layer
- Middleware customizado
- Dependency Injection
- Tratamento global de erros
- Filtros dinâmicos
- Paginação
- Busca textual
- Includes e ThenIncludes com Entity Framework Core

---

# Documentação da API

A documentação da API é disponibilizada através do Swagger:

```bash
https://localhost:{porta}/swagger
```

---

# Como Executar o Projeto

## 1. Clonar o repositório

---

## 2. Acessar o projeto

```bash
cd clyvo-care-API
```

---

## 3. Restaurar dependências

```bash
dotnet restore
```

---

## 5. Executar a aplicação

```bash
dotnet run
```

---

# Testes da API

Os testes podem ser realizados diretamente pelo Swagger UI.

Exemplos de endpoints:

```http
GET /api/pet
GET /api/pet?nome=bolt
GET /api/vacina/vencidas
GET /api/consulta
POST /api/tutor
```

---

# Objetivo do Projeto

O objetivo do projeto é fornecer uma solução backend moderna para gerenciamento veterinário inteligente, permitindo acompanhamento clínico, gestão de vacinação e controle de histórico dos pets.

---

# 👨‍💻 Desenvolvido por

João Santana RM566063
Felipe Ribeiro RM565224

Projeto acadêmico desenvolvido para FIAP.
