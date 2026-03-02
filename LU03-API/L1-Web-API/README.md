# C# Web API

## API Diagram

```mermaid
graph LR
    Client((Client/Browser)) --> Request[HTTP Request: GET/POST]

    subgraph "ASP.NET Core Minimal API"
        Request --> Kestrel[Kestrel Web Server]
        Kestrel --> Routing{Routing Engine}
        Routing -->|Match Found| Map[Mapped Endpoint: app.MapGet]
        Map --> Logic[C# Handler / Lambda]
        Logic --> Serialize[System.Text.Json Serialization]
    end

    Serialize --> Response[HTTP Response: 200 OK + JSON]
    Response --> Client
```

## Creating a Project

```bash
dotnet new webapi -o FortuneCookie --use-controllers
cd FortuneCookie
dotnet run
```

## Testing the API

The project will give us a simple weather forecast API.
Test it out at `https://localhost:[PORT]/weatherforecast` or `http://localhost:[PORT]/openapi/v1.json`.

> Talk about how we will add a UI to OpenAPI later.

## Customizing the API

Add a new controller to the `Controllers` folder called [`OracleController.cs`](./Controllers/OracleController.cs)

Now look at the updated openapi spec.
Notice it automatically updated.
