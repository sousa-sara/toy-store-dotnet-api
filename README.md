# ToyStoreAPI 🧸

## Descrição do Projeto  
**ToyStoreAPI** é uma aplicação web desenvolvida em **ASP.NET Core** que fornece uma API REST para gerenciamento de brinquedos. A API permite realizar operações **CRUD** (Create, Read, Update, Delete) em um banco de dados **Oracle**.  

## Principais Características  
- Gerenciamento de brinquedos  
- Conexão com banco de dados Oracle  
- Validações de entrada de dados  
- Documentação **Swagger** para teste de endpoints  
- Tratamento de erros personalizado  

## Tecnologias Utilizadas  
- **ASP.NET Core 6.0+**  
- **Entity Framework Core**  
- **Oracle Database**  
- **Swagger/OpenAPI**  

## Estrutura do Projeto  
📂 `Controllers/ToysController.cs`: Controlador principal com endpoints CRUD

📂 `Models/Toy.cs`: Modelo de dados do brinquedo

📂 `DtoToy/Dto.cs`: Objeto de transferência de dados para validações

📂 `Data/ToyContext.cs`: Contexto do Entity Framework para configuração do banco de dados

## Endpoints Disponíveis  

| Método | Endpoint     | Descrição                        |
|--------|------------|--------------------------------|
| GET    | `/toys`      | Lista todos os brinquedos     |
| GET    | `/toys/{id}` | Busca um brinquedo específico |
| POST   | `/toys`      | Cadastra um novo brinquedo    |
| PUT    | `/toys/{id}` | Atualiza um brinquedo existente |
| DELETE | `/toys/{id}` | Remove um brinquedo          |

## Exemplo de JSON para Cadastro  

```json
{
    "nameToy": "Boneco Herói Marvel",
    "typeToy": "Ação",
    "rating": "10+",
    "toySize": "Médio",
    "price": 89.99
}
```

## Validações
**Nome do brinquedo:** Obrigatório, mínimo 2 caracteres

**Preço:** Obrigatório, maior que zero

## Execução do Projeto
```bash
git clone https://github.com/sousa-sara/toy-store-dotnet-api.git # Clonar repositório
cd ToyStoreAPI # Abrir a pasta do projeto
dotnet watch run # Comando para rodar a aplicação e abrir a interface automaticamente
```
**Verificar se a aplicação está sendo executada em: http://localhost:5259/swagger/index.html

## Dependências
- Oracle.EntityFrameworkCore

- Microsoft.EntityFrameworkCore

- Swashbuckle.AspNetCore

## Tratamento de Erros
A API fornece mensagens de erro personalizadas para diferentes cenários:

- Brinquedo não encontrado

- O nome do brinquedo é obrigatório

- O preço do brinquedo deve ser maior que zero

- Brinquedo deletado com sucesso

- Dados inválidos

- Erros de servidor

## Integrantes ToyStoreAPI
- Felipe Amador - RM553528
- Leonardo Oliveira - RM554024
- Sara Sousa - RM552656
