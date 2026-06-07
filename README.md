# 📚 Gerenciador de Livraria API

API RESTful para gerenciamento de livros em uma livraria, desenvolvida com ASP.NET Core 8 seguindo o padrão de arquitetura em camadas e o princípio de Use Cases.

---

## 🚀 Tecnologias

- [.NET 8](https://dotnet.microsoft.com/)
- ASP.NET Core Web API
- Swagger / OpenAPI
- Armazenamento em memória (in-memory)

---

## 🏗️ Arquitetura

O projeto é dividido em três camadas:

```
GerenciadorDeLivariaApi/
├── GerenciadorDeLivariaApi/     # Camada de apresentação (Controllers, configuração da aplicação)
├── Book.Application/            # Camada de aplicação (Use Cases, Entities, Repository, Validators)
└── Book.Communication/          # Camada de comunicação (Requests, Responses, Enums)
```

---

## 📋 Endpoints

Base URL: `http://localhost:{porta}/api/book`

| Método   | Rota           | Descrição                    | Status de Sucesso |
|----------|----------------|------------------------------|-------------------|
| `POST`   | `/api/book`    | Cadastrar um novo livro       | `201 Created`     |
| `GET`    | `/api/book`    | Listar todos os livros        | `200 OK`          |
| `GET`    | `/api/book/{id}` | Buscar livro por ID         | `200 OK`          |
| `PUT`    | `/api/book/{id}` | Atualizar dados de um livro | `204 No Content`  |
| `DELETE` | `/api/book/{id}` | Remover um livro            | `204 No Content`  |

---

## 📦 Modelo de Livro

```json
{
  "title": "O Senhor dos Anéis",
  "author": "J.R.R. Tolkien",
  "genre": "Ficcao",
  "price": 49.90,
  "stock": 10
}
```

### Campos

| Campo    | Tipo      | Obrigatório | Descrição                              |
|----------|-----------|-------------|----------------------------------------|
| `title`  | `string`  | ✅          | Título do livro (2–120 caracteres)     |
| `author` | `string`  | ❌          | Nome do autor (2–120 caracteres)       |
| `genre`  | `enum`    | ✅          | Gênero do livro (ver tabela abaixo)    |
| `price`  | `decimal` | ✅          | Preço do livro (≥ 0)                   |
| `stock`  | `int`     | ✅          | Quantidade em estoque (≥ 0)            |

### Gêneros disponíveis (`BookGenreEnum`)

| Valor       | Descrição     |
|-------------|---------------|
| `Outro`     | Outros        |
| `Ficcao`    | Ficção        |
| `Romance`   | Romance       |
| `Misterio`  | Mistério      |
| `Terror`    | Terror        |

---

## ▶️ Como executar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Passos

```bash
# Clone o repositório
git clone https://github.com/VitorBotome/GerenciadorDeLivariaApi.git
cd GerenciadorDeLivariaApi

# Restaure as dependências
dotnet restore

# Execute o projeto
dotnet run --project GerenciadorDeLivariaApi/GerenciadorDeLivariaApi.csproj
```

A API estará disponível em `https://localhost:{porta}`. A documentação interativa via Swagger estará acessível em:

```
https://localhost:{porta}/swagger
```

---

## 📖 Exemplos de uso

### Cadastrar um livro

```http
POST /api/book
Content-Type: application/json

{
  "title": "Dom Casmurro",
  "author": "Machado de Assis",
  "genre": "Romance",
  "price": 29.90,
  "stock": 5
}
```

### Listar todos os livros

```http
GET /api/book
```

### Buscar livro por ID

```http
GET /api/book/3fa85f64-5717-4562-b3fc-2c963f66afa6
```

### Atualizar um livro

```http
PUT /api/book/3fa85f64-5717-4562-b3fc-2c963f66afa6
Content-Type: application/json

{
  "title": "Dom Casmurro",
  "author": "Machado de Assis",
  "genre": "Romance",
  "price": 34.90,
  "stock": 8
}
```

### Deletar um livro

```http
DELETE /api/book/3fa85f64-5717-4562-b3fc-2c963f66afa6
```

---

## ⚠️ Observações

- Os dados são armazenados **em memória**, ou seja, serão perdidos ao reiniciar a aplicação. Não há integração com banco de dados neste momento.
- O Swagger está habilitado apenas no ambiente de desenvolvimento.

---

## 👤 Autor

Desenvolvido por **Vitor Botome**.
