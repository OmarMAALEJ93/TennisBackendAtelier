# TennisBackendAtelier

REST API built with ASP.NET Core 8 for managing tennis player statistics.

🚀 **Live demo**: https://tennis-api-zf9n.onrender.com/swagger

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Getting Started

```bash
cd TennisBackendAtelier
dotnet run
```

Swagger UI: `http://localhost:5268/swagger`

## Run with Docker

```bash
docker build -t tennis-api .
docker run -p 8080:8080 tennis-api
```

API available at: `http://localhost:8080`

Swagger UI: `http://localhost:8080/swagger`

## Run Tests

```bash
dotnet test
```

## Endpoints

| Method | URL | Description |
|--------|-----|-------------|
| GET | `/api/players` | Get all players sorted by rank |
| GET | `/api/players/{id}` | Get player by ID |
| POST | `/api/players` | Add a new player |
| GET | `/api/statistics` | Get statistics (best country, avg BMI, median height) |

## Architecture

```
TennisBackendAtelier/
├── Controllers/        # REST endpoints
├── Services/           # Business logic
├── Repositories/       # Data access (JSON)
├── Interfaces/         # Abstractions (DI)
├── Models/             # Records (Player, Country, PlayerData)
├── Extensions/         # IServiceCollection extensions
├── Data/               # JSON dataset (headtohead.json)
└── Program.cs          # Pipeline configuration
```

## Design Principles

- **SOLID**: dependency inversion, interfaces, single responsibility
- **Records**: immutability and reduced boilerplate
- **Layered Architecture**: Controller → Service → Repository
