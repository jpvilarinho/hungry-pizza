# hungry-pizza

hungry-pizza (HungryPizzaAPI) é uma API REST desenvolvida em **.NET 9** para gerenciamento de pedidos de uma pizzaria.

## Objetivo

O projeto foi criado como parte de um teste técnico backend e implementa regras de negócio completas, persistência em banco SQLite, documentação via Swagger e testes automatizados.

## Requisitos

- .NET 9 SDK
- Ambiente compatível com Linux (cross-platform)

### Estrutura do Projeto

```plaintext
hungry-pizza/
├── Controllers/
│   └── PedidosController.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Migrations/
├── Models/
│   └── Pedido.cs
│   └── Pizza.cs
│   └── EnderecoEntrega.cs
├── Properties/
    └── launchSettings.json
├── Tests/
    └── IntegrationTest.cs
    └── PedidoTest.cs
├── appsettings.development.json
├── appsettings.json
├── HungryPizzaAPI.csproj
├── Program.cs
├── README.md
├── Requirements.txt
```

## Executando o Projeto

### Clonar o repositório

```bash
git clone https://github.com/jpvilarinho/hungry-pizza.git
cd hungry-pizza
```

### Restaurar dependências

```bash
dotnet restore hungry-pizza.sln
```

### Criar banco de dados

O projeto utiliza SQLite local.

Se desejar usar migrations:

```bash
dotnet tool install --global dotnet-ef
dotnet ef database update
```

(Obs: o arquivo hungrypizza.db é gerado localmente e ignorado pelo git.)

### Rodar a aplicação

```bash
dotnet run
```

A API ficará disponível em: <http://localhost:5234>

Pelo Swagger UI: <http://localhost:5234>

### Endpoints

- Criar Pedido

```json
POST /api/Pedidos

{
  "pizzas": [
    { "sabor1": "Mussarela", "sabor2": "Calabresa" },
    { "sabor1": "Pepperoni" }
  ],
  "enderecoEntrega": {
    "logradouro": "Rua A",
    "numero": "123",
    "bairro": "Centro",
    "cidade": "Cidade A",
    "estado": "Estado A",
    "cep": "12345-678"
  }
}
```

Resposta:

```json
"guid-do-pedido"
```

- Consultar Pedido

```json
GET /api/Pedidos/{id}
```

- Obter preço de um sabor

```json
GET /api/Pedidos/PrecoSabor/{sabor}
```

- Resposta:

```json
42.50
```

### Testes

O projeto contém testes unitários e de integração.

Executar:

```bash
dotnet test hungry-pizza.sln
```

### Regras de Negócio Implementadas

- Pedido deve conter entre 1 e 10 pizzas
- Cada pizza pode ter até dois sabores
- Pizza com dois sabores tem preço médio
- Identificador único gerado automaticamente
- Endereço obrigatório
- Sem cobrança de frete
- Consulta de pedidos por ID
