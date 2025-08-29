# 📦 ApiCatalogo
API REST para gerenciamento de catálogo de produtos e categorias, construída com .NET 8 e EF Core, seguindo boas práticas de mercado (validação automática, async/await, logging e tratamento de erros).

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
# 📌 informações sobre origem da Api
Essa api foi feita baseada em um projeto de um curso, porem com melhorias e boas praticas implementadas.
## 📌 Melhorias implementadas

Durante o desenvolvimento, além de aplicar o que foi ensinado no curso, adicionei boas práticas comuns em projetos reais de mercado:

- ✅ **Uso de métodos assíncronos (`async/await`)** para maior escalabilidade e melhor performance.
- ✅ **Tratamento de erros centralizado** com middleware global, evitando repetição de `try/catch` em cada controller.
- ✅ **Validação automática de modelos** via `[ApiController]` e Data Annotations (ex: `[Required]`, `[StringLength]`).
- ✅ **Status codes adequados** (`201 Created`, `204 NoContent`, `404 NotFound`) seguindo boas práticas REST.
- ✅ **Logging estruturado** com `ILogger` para facilitar monitoramento e debug.
- ✅ **Tratamento de concorrência** em operações `PUT` usando `DbUpdateConcurrencyException`.

# 📖 Documentação via Swagger
O Swagger UI é habilitado automaticamente no ambiente de desenvolvimento.
Para acessar, rode a aplicação.

### Exemplo de visualização:
<img width="1827" height="1004" alt="image" src="https://github.com/user-attachments/assets/e3791a27-5d35-4126-a698-879e37d01ca3" />

### Exemplo de requisição no Swagger:
<img width="1536" height="870" alt="image" src="https://github.com/user-attachments/assets/a522f7dc-e997-45c1-a23c-b8a29e447642" />



# 🔒 Segurança e Boas Práticas
- Nunca exponha senhas em arquivos versionados.
- Utilize User Secrets (em dev) ou variáveis de ambiente (em produção).

## 🪪 Licença
Você pode usar, modificar e melhorar esse projeto livremente.
