# HungryPizzaAPI

HungryPizzaAPI é uma API desenvolvida em .NET 8.0 para gerenciar pedidos de uma pizzaria. 
A API permite criar, consultar pedidos e obter o preço de um sabor de pizza.

## Requisitos

- .NET 8.0 SDK
- Ferramenta `dotnet-ef` para migrações do Entity Framework Core

### Estrutura do Projeto

```plaintext
HungryPizzaAPI/
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
├── appsettings.Development.json
├── appsettings.json
├── hungrypizza.db
├── HungryPizzaAPI.csproj
├── Program.cs
├── README.md
├── Requirements.txt
```

## Configurações de Debug e Tarefas

A pasta `.vscode` contém os arquivos `launch.json` e `tasks.json` que configuram o ambiente de desenvolvimento:

- **launch.json:** Configurações de depuração.
- **tasks.json:** Tarefas personalizadas para build, publish e watch.

### Usando as Configurações

1. **Build:**
   Para compilar o projeto, você pode usar a tarefa de build configurada:
   - Vá para a aba de execução (`Ctrl+Shift+B`).
   - Selecione a tarefa "build".

2. **Publish:**
   Para publicar o projeto:
   - Vá para a aba de execução (`Ctrl+Shift+B`).
   - Selecione a tarefa "publish".

3. **Watch:**
   Para executar o projeto em modo watch:
   - Vá para a aba de execução (`Ctrl+Shift+B`).
   - Selecione a tarefa "watch".

4. **Debug:**
   Para depurar o projeto:
   - Vá para a aba de depuração (`Ctrl+Shift+D`).
   - Selecione a configuração ".NET Core Launch (web)".
   - Clique no botão de play ou pressione `F5`.

## Instalação

### Clonar o Repositório

```bash
git clone https://github.com/jpvilarinho/hungry-pizza.git
cd HungryPizzaAPI
```

### Restaurar as Dependências
```bash 
dotnet restore
```

### Configuração do Banco de Dados
Adicionar a Ferramenta dotnet-ef
Caso não tenha a ferramenta dotnet-ef instalada, execute:
```bash
dotnet tool install --global dotnet-ef
```

### Adicione a migração inicial:
Adicionar Migrações e Atualizar o Banco de Dados
```bash
dotnet ef migrations add InitialCreate
```

### Atualize o banco de dados para aplicar as migrações:
```bash
dotnet ef database update
```

### Executando a Aplicação
Para rodar a aplicação, execute:
```bash
dotnet run
```
A aplicação estará disponível em http://localhost:5234. A interface Swagger UI estará disponível em http://localhost:5234/swagger.

## Endpoints
### Criar Pedido
- Endpoint: POST /api/Pedidos
- Descrição: Cria um novo pedido.
-  Exemplo de Corpo de Requisição:

```plaintext
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

- Exemplo de Resposta:
```
{
  "id": "guid-do-pedido"
}
```

### Consultar Pedido
- Endpoint: GET /api/Pedidos/{id}
- Descrição: Consulta um pedido pelo ID.
- Parâmetros: id (GUID): ID do pedido.

- Exemplo de Resposta:
```
{
  "id": "guid-do-pedido",
  "pizzas": [
    { "id": 1, "sabor1": "Mussarela", "sabor2": "Calabresa", "preco": 47.50 },
    { "id": 2, "sabor1": "Pepperoni", "preco": 55 }
  ],
  "enderecoEntrega": {
    "id": 1,
    "logradouro": "Rua A",
    "numero": "123",
    "bairro": "Centro",
    "cidade": "Cidade A",
    "estado": "Estado A",
    "cep": "12345-678"
  },
  "precoTotal": 102.50
}
```

### Obter Preço do Sabor
- Endpoint: GET /api/Pedidos/PrecoSabor/{sabor}
- Descrição: Obtém o preço de um sabor de pizza.
- Parâmetros: sabor (string): Nome do sabor da pizza.

- Exemplo de Resposta:
```
{
  "preco": 42.50
}
```

## Testando Endpoints com REST Client
Para facilitar o teste dos endpoints da API, é possível também usar o arquivo `HungryPizzaAPI.http` com a extensão REST Client.

### Configuração

1. Instale a extensão REST Client (essa aplicação foi feita no VS Code mas pode ser feita na IDE de sua preferência).
   - Procure para pela aba de Extensões (ícone de quadrado no menu lateral ou `Ctrl+Shift+X`).
   - Procure por "REST Client" e instale a extensão.

2. Abra o arquivo `HungryPizzaAPI.http`.

3. Clique nos botões "Send Request" que aparecem acima de cada solicitação HTTP para enviar a requisição e ver a resposta.

## Testes
Para rodar os testes do projeto, execute:
```bash
dotnet test
```

## Contribuições
- Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença
- Este projeto está licenciado sob a MIT License.
