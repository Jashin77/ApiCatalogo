# 📦 ApiCatalogo
Uma API REST desenvolvida em **ASP.NET Core 8** com **Entity Framework Core** e **MySQL**, que permite gerenciar um catálogo de **Produtos** e **Categorias**.  
A API utiliza **Swagger** para documentação e testes interativos.

---

## 🚀 Tecnologias Utilizadas
- [.NET 8](https://dotnet.microsoft.com/)
- [ASP.NET Core Web API](https://learn.microsoft.com/aspnet/core/web-api)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [MySQL](https://www.mysql.com/)
- [Swagger / Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)

---

## ⚙️ Configuração do Projeto

1. **Clone o repositório:**
```bash
git clone https://github.com/Jashin77/ApiCatalogo.git
   cd ApiCatalogo
```
2. Configuração do banco de dados:
- Crie um banco no MySQL (ex.: ApiCatalogo).
- Configure o appsettings.json.
- Configure a String de conexão com seus dados
```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=ApiCatalogo;user=seu_usuario;password=sua_senha"
  }
}
```
3. Executar as migrações
```bash
dotnet ef database update
```
4.Rodar a aplicação(recomendação,rodar no Visual Studio):
```bash
dotnet run
```
---
# 📑 Endpoints Principais
🔹 Categorias
- GET /Categorias → Lista todas as categorias
- GET /Categorias/{id} → Obtém uma categoria pelo ID
- GET /Categorias/produtos → Lista categorias com seus produtos (até ID ≤ 5)
- POST /Categorias → Cria uma nova categoria
- PUT /Categorias/{id} → Atualiza uma categoria existente
- DELETE /Categorias/{id} → Remove uma categoria

🔹 Produtos
- GET /Produtos → Lista todos os produtos
- GET /Produtos/{id} → Obtém um produto pelo ID
- POST /Produtos → Cria um novo produto
- PUT /Produtos/{id} → Atualiza um produto existente
- DELETE /Produtos/{id} → Remove um produto

# 🗂️ Estrutura do Projeto
```bash
ApiCatalogo/
│-- Program.cs              # Configuração inicial da aplicação
│-- Models/
│   ├── Categoria.cs        # Entidade Categoria
│   └── Produto.cs          # Entidade Produto
│-- Controllers/
│   ├── CategoriasController.cs
│   └── ProdutosController.cs
│-- Context/
│   └── AppDbContext.cs     # Configuração do EF Core e DbSets
```
# 📖 Documentação via Swagger
O Swagger UI é habilitado automaticamente no ambiente de desenvolvimento.
Para acessar, rode a aplicação.

# 🔒 Segurança e Boas Práticas
- Nunca exponha senhas em arquivos versionados.
- Utilize User Secrets (em dev) ou variáveis de ambiente (em produção).

## 🪪 Licença
Você pode usar, modificar e melhorar esse projeto livremente.
