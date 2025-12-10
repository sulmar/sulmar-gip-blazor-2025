# Blazor 9 - Aplikacja Webowa - Projekt Szkoleniowy

Projekt szkoleniowy demonstrujący tworzenie aplikacji webowych przy użyciu **Blazor WebAssembly 9.0** oraz **ASP.NET Core Minimal API**. Aplikacja prezentuje architekturę warstwową z separacją odpowiedzialności oraz implementację wzorców projektowych.

## 📋 Opis Projektu

Aplikacja do zarządzania klientami i produktami, zbudowana w architekturze warstwowej. Frontend wykorzystuje Blazor WebAssembly, a backend oparty jest na ASP.NET Core Minimal API. Projekt demonstruje najlepsze praktyki w tworzeniu aplikacji webowych w ekosystemie .NET 9.

## 🏗️ Architektura

Projekt składa się z czterech głównych warstw:

### 1. **Domain** (Warstwa Domenowa)
- **Modele**: `Customer`, `Product`, `BaseEntity`
- **Abstrakcje**: Interfejsy repozytoriów (`ICustomerRepository`, `IProductRepository`, `IEntityRepository`)
- Zawiera logikę biznesową i definicje encji domenowych

### 2. **Infrastructure** (Warstwa Infrastruktury)
- **Repozytoria**: 
  - `FakeCustomerRepository` - implementacja z danymi testowymi
  - `DbCustomerRepository` - implementacja z dostępem do bazy danych
- Odpowiedzialna za dostęp do danych i implementację repozytoriów

### 3. **Api** (Warstwa API)
- **ASP.NET Core Minimal API** z endpointami REST
- Endpointy:
  - `GET /api/customers` - lista aktywnych klientów
  - `GET /api/customers/archive` - lista zarchiwizowanych klientów
  - `GET /api/customers/{id}` - szczegóły klienta
  - `GET /api/products` - lista produktów
- Konfiguracja CORS dla komunikacji z Blazor WebAssembly
- Port: `https://localhost:7247`

### 4. **BlazorWebAssemblyApp** (Warstwa Prezentacji)
- **Blazor WebAssembly 9.0** - aplikacja kliencka
- **Strony**:
  - `/` - strona główna
  - `/customers` - lista klientów
  - `/customers/archive` - archiwum klientów
  - `/customers/{id}` - szczegóły klienta
  - `/products` - lista produktów
  - `/counter` - przykładowa strona z licznikiem
  - `/weather` - przykładowa strona z danymi pogodowymi
- **Komponenty współdzielone**:
  - `CustomersTable` - tabela klientów
  - `ProductsTable` - tabela produktów
  - `ItemsTable` - uniwersalna tabela elementów
  - `Header` - nagłówek strony
  - `NavMenu` - menu nawigacyjne
- **Serwisy**:
  - `IAsyncCustomerService` / `ApiCustomerService` - serwis dla klientów
  - `IAsyncProductService` / `ApiProductService` - serwis dla produktów
- Port: `https://localhost:7283`

## 🛠️ Technologie

- **.NET 9.0**
- **Blazor WebAssembly 9.0.11**
- **ASP.NET Core Minimal API**
- **Bootstrap** (dla stylów UI)
- **HttpClient** (dla komunikacji z API)

## 📦 Struktura Projektu

```
sulmar-gip-blazor-2025/
├── src/
│   ├── Api/                    # Backend API
│   ├── BlazorWebAssemblyApp/   # Frontend Blazor WebAssembly
│   ├── Domain/                 # Warstwa domenowa
│   └── Infrastructure/         # Warstwa infrastruktury
├── docs/                       # Dokumentacja szkoleniowa
└── exercises/                  # Materiały ćwiczeniowe
```

## 🚀 Uruchomienie Projektu

### Wymagania wstępne
- .NET 9.0 SDK
- IDE z obsługą .NET (Visual Studio, Rider, VS Code)

### Kroki uruchomienia

1. **Sklonuj repozytorium** (jeśli jeszcze tego nie zrobiłeś)

2. **Uruchom API** (w jednym terminalu):
   ```bash
   cd src/Api
   dotnet run
   ```
   API będzie dostępne pod adresem: `https://localhost:7247`

3. **Uruchom aplikację Blazor WebAssembly** (w drugim terminalu):
   ```bash
   cd src/BlazorWebAssemblyApp
   dotnet run
   ```
   Aplikacja będzie dostępna pod adresem: `https://localhost:7283`

4. **Otwórz przeglądarkę** i przejdź do `https://localhost:7283`

## 📚 Funkcjonalności

### Zarządzanie Klientami
- Wyświetlanie listy aktywnych klientów
- Wyświetlanie archiwum klientów
- Przeglądanie szczegółów klienta
- Filtrowanie aktywnych/zarchiwizowanych klientów

### Zarządzanie Produktami
- Wyświetlanie listy produktów
- Informacje o produktach (nazwa, opis, kolor, cena)

## 🎯 Wzorce Projektowe

Projekt demonstruje następujące wzorce i praktyki:

- **Repository Pattern** - abstrakcja dostępu do danych
- **Dependency Injection** - wstrzykiwanie zależności
- **Service Layer** - warstwa serwisów dla logiki biznesowej
- **Clean Architecture** - separacja warstw i odpowiedzialności
- **Async/Await** - asynchroniczne operacje I/O
- **Component-Based Architecture** - komponenty Blazor

## 📝 Modele Danych

### Customer
- `Id` (int) - identyfikator
- `Name` (string) - nazwa klienta
- `Email` (string) - adres email
- `IsArchived` (bool) - czy zarchiwizowany

### Product
- `Id` (int) - identyfikator
- `Name` (string) - nazwa produktu
- `Description` (string) - opis
- `Color` (string) - kolor
- `UnitPrice` (decimal) - cena jednostkowa

## 🔧 Konfiguracja

### API (`appsettings.json`)
- Konfiguracja connection string dla bazy danych
- Ustawienia CORS

### Blazor WebAssembly (`Program.cs`)
- Konfiguracja HttpClient z BaseAddress
- Rejestracja serwisów HTTP dla API
- Konfiguracja routingu i komponentów

## 📖 Materiały Szkoleniowe

Projekt zawiera materiały szkoleniowe w katalogach:
- `docs/` - dokumentacja i diagramy
- `exercises/` - ćwiczenia praktyczne

## 🎓 Cel Szkoleniowy

Projekt został stworzony w ramach szkolenia z tworzenia aplikacji webowych w Blazor 9 i demonstruje:
- Podstawy Blazor WebAssembly
- Architekturę warstwową aplikacji .NET
- Komunikację frontend-backend przez REST API
- Wzorce projektowe w praktyce
- Pracę z komponentami i routowaniem w Blazor

## 📄 Licencja

Projekt szkoleniowy - do użytku edukacyjnego.

## 👨‍💻 Autor

Projekt stworzony w ramach szkolenia z Blazor 9.

