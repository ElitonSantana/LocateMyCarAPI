# LocateMyCarAPI

## Visão Geral
O projeto LocateMyCarAPI é uma aplicação em C# que oferece uma API para o gerenciamento de informações de veículos e seus detalhes.

## Pré-requisitos
Certifique-se de ter os seguintes itens instalados antes de executar a aplicação:

- [.NET SDK](https://dotnet.microsoft.com/download)
- Visual Studio ou qualquer ambiente de desenvolvimento C# preferido

## Arquitetura do Projeto
- Domain-Driven Design ( DDD );

## Endpoints da API

### Veículos

- #### Obter todos os veículos
```http
GET /api/Vehicle
 ```
- #### Obter um veículo específico por ID
```http
GET /api/Vehicle/{id}
```
- #### Criar um novo veículo
```http
POST /api/Vehicle
```
- #### Atualizar um veículo por ID
```http
PUT /api/Vehicle/{id}
```
- #### Excluir um veículo por ID
```http
DELETE /api/Vehicle/{id}
```
- #### Obter os principais veículos
```http
GET /api/Vehicle/GetTopVehicles
```
### Detalhes do Veículo

- #### Obter detalhes de um veículo específico por ID
```http
GET /api/VehicleDetails/{id}
```

- #### Criar novos detalhes de veículo
```http
POST /api/VehicleDetails
```
- #### Atualizar detalhes de veículo por ID
```http
PUT /api/VehicleDetails/{id}
```
- #### Excluir detalhes de veículo por ID
```http
DELETE /api/VehicleDetails/{id}
```
## Iniciando
1. Clone o repositório em sua máquina local:

   ```bash
   git clone https://github.com/ElitonSantana/LocateMyCarAPI.git
Abra o projeto no Visual Studio ou seu ambiente de desenvolvimento C# preferido.

Compile e execute a aplicação.

Utilize os endpoints da API para realizar operações CRUD em veículos e detalhes de veículos.
Certifique-se de fornecer dados de entrada válidos para operações bem-sucedidas.

## Tags
- C#
- ASP.NET Core
- API
- CRUD
- Entity Framework
- MVC
- RESTful
- Middleware
- JSON
- Swagger
- .NET SDK
- Stored Procedures

## Tecnologias
- ASP.NET Core
- Entity Framework Core
- Newtonsoft.Json
- Microsoft.Extensions.DependencyInjection
- Swagger UI
