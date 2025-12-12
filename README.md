# Blazor 9 - Aplikacja Webowa - Projekt Szkoleniowy

Projekt szkoleniowy demonstrujący tworzenie aplikacji webowych przy użyciu **Blazor WebAssembly 9.0** oraz **ASP.NET Core Minimal API**. Aplikacja prezentuje architekturę warstwową z separacją odpowiedzialności oraz implementację wzorców projektowych.

## 📋 Opis Projektu

Aplikacja do zarządzania klientami i produktami, zbudowana w architekturze warstwowej. Frontend wykorzystuje Blazor WebAssembly, a backend oparty jest na ASP.NET Core Minimal API. Projekt demonstruje najlepsze praktyki w tworzeniu aplikacji webowych w ekosystemie .NET 9.

## 🏗️ Architektura

Projekt składa się z pięciu głównych warstw oraz dodatkowych aplikacji:

### 1. **Domain** (Warstwa Domenowa)
- **Modele**: `Customer`, `Product`, `Region`, `BaseEntity`
- **Abstrakcje**: Interfejsy repozytoriów (`ICustomerRepository`, `IProductRepository`, `IRegionRepository`, `IEntityRepository`, `IDocumentService`)
- **Validatory**: `CustomerValidator` (FluentValidation)
- Zawiera logikę biznesową i definicje encji domenowych

### 2. **Infrastructure** (Warstwa Infrastruktury)
- **Repozytoria**: 
  - `FakeCustomerRepository` - implementacja z danymi testowymi
  - `DbCustomerRepository` - implementacja z dostępem do bazy danych
  - `FakeRegionRepository` - implementacja repozytorium regionów
- **Serwisy**:
  - `FakeDocumentService` - serwis do generowania dokumentów
- Odpowiedzialna za dostęp do danych i implementację repozytoriów

### 3. **Application** (Warstwa Aplikacyjna)
- **Serwisy HTTP**:
  - `IAsyncCustomerService` / `ApiCustomerService` - serwis dla klientów
  - `IAsyncProductService` / `ApiProductService` - serwis dla produktów
  - `IAsyncRegionService` / `ApiRegionService` - serwis dla regionów
- Warstwa pośrednicząca między prezentacją a API, zawiera logikę komunikacji z backendem

### 4. **Api** (Warstwa API)
- **ASP.NET Core Minimal API** z endpointami REST
- **Endpointy**:
  - `GET /api/customers` - lista aktywnych klientów
  - `GET /api/customers/archive` - lista zarchiwizowanych klientów
  - `GET /api/customers/{id}` - szczegóły klienta
  - `POST /api/customers` - tworzenie nowego klienta (z walidacją)
  - `PUT /api/customers/{id}` - aktualizacja klienta
  - `GET /api/regions` - lista regionów
  - `POST /api/documents` - generowanie dokumentów
- **SignalR Hub**: `DashboardHub` - komunikacja w czasie rzeczywistym
- **Background Services**: `DashboardBackgroundService` - serwis działający w tle
- **Middlewares**:
  - `LoggerMiddleware` - logowanie żądań HTTP
  - `AuthMiddleware` - autoryzacja przez nagłówek `x-secret-key`
- **Dokumentacja API**:
  - OpenAPI/Swagger: `https://localhost:7247/openapi/v1.json`
  - Scalar UI: `https://localhost:7247/scalar`
- Konfiguracja CORS dla komunikacji z Blazor WebAssembly
- Port: `https://localhost:7247`

### 5. **BlazorWebAssemblyApp** (Warstwa Prezentacji - Podstawowa)
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
- Port: `https://localhost:7283`

### 6. **MudBlazorWebAssemblyApp** (Warstwa Prezentacji - Zaawansowana)
- **Blazor Server + WebAssembly Hybrid** - aplikacja z komponentami MudBlazor
- **Strony**:
  - `/` - strona główna
  - `/dashboard` - dashboard z danymi w czasie rzeczywistym (SignalR)
  - `/customers` - lista klientów
  - `/customers/create` - tworzenie nowego klienta
  - `/customers/edit/{id}` - edycja klienta
  - `/customers/view/{id}` - szczegóły klienta
  - `/counter` - przykładowa strona z licznikiem
  - `/weather` - przykładowa strona z danymi pogodowymi
- **Komponenty**:
  - `CustomerEditForm` - formularz edycji klienta
- **Handlery HTTP**:
  - `LoggerHandler` - logowanie żądań HTTP
  - `SecretKeyHandler` - dodawanie nagłówka autoryzacji
- **Funkcjonalności**:
  - Integracja z MudBlazor UI
  - LocalStorage (Blazored.LocalStorage)
  - Obsługa SignalR dla dashboardu
- Port: `https://localhost:7194`

### 7. **ConsoleApp** (Aplikacja Konsolowa)
- Prosta aplikacja konsolowa demonstrująca podstawy .NET

## 🛠️ Technologie

- **.NET 9.0**
- **Blazor WebAssembly 9.0.11**
- **Blazor Server** (w MudBlazorWebAssemblyApp)
- **ASP.NET Core Minimal API**
- **SignalR** - komunikacja w czasie rzeczywistym
- **MudBlazor** - biblioteka komponentów UI
- **FluentValidation** - walidacja danych
- **Scalar** - dokumentacja API
- **OpenAPI/Swagger** - dokumentacja API
- **Blazored.LocalStorage** - przechowywanie danych lokalnie
- **Bootstrap** (dla stylów UI w BlazorWebAssemblyApp)
- **HttpClient** (dla komunikacji z API)

## 📦 Struktura Projektu

```
sulmar-gip-blazor-2025/
├── src/
│   ├── Api/                              # Backend API
│   │   ├── BackgroundServices/           # Serwisy działające w tle
│   │   ├── Endpoints/                    # Endpointy REST API
│   │   ├── Hubs/                         # SignalR Hubs
│   │   ├── Middlewares/                  # Middleware'y HTTP
│   │   ├── Services/                     # Serwisy API (np. OCR)
│   │   └── Extensions/                   # Metody rozszerzające
│   ├── Application/                      # Warstwa aplikacyjna
│   │   └── Services/                     # Serwisy HTTP dla komunikacji z API
│   ├── BlazorWebAssemblyApp/             # Frontend Blazor WebAssembly (podstawowy)
│   │   ├── Pages/                        # Strony aplikacji
│   │   ├── Shared/                       # Komponenty współdzielone
│   │   └── Layout/                       # Layouty aplikacji
│   ├── MudBlazorWebAssemblyApp/          # Frontend z MudBlazor (zaawansowany)
│   │   ├── MudBlazorWebAssemblyApp/      # Projekt serwera Blazor
│   │   └── MudBlazorWebAssemblyApp.Client/ # Projekt klienta WebAssembly
│   ├── Domain/                           # Warstwa domenowa
│   │   ├── Models/                       # Modele domenowe
│   │   └── Abstractions/                 # Interfejsy repozytoriów
│   ├── Infrastructure/                   # Warstwa infrastruktury
│   │   └── [Repozytoria i serwisy]      # Implementacje repozytoriów
│   └── ConsoleApp/                       # Aplikacja konsolowa
├── docs/                                 # Dokumentacja szkoleniowa
└── exercises/                            # Materiały ćwiczeniowe
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

4. **Opcjonalnie: Uruchom aplikację MudBlazor** (w trzecim terminalu):
   ```bash
   cd src/MudBlazorWebAssemblyApp/MudBlazorWebAssemblyApp
   dotnet run
   ```
   Aplikacja będzie dostępna pod adresem: `https://localhost:7194`

5. **Otwórz przeglądarkę** i przejdź do:
   - `https://localhost:7283` - BlazorWebAssemblyApp (podstawowa)
   - `https://localhost:7194` - MudBlazorWebAssemblyApp (zaawansowana)
   - `https://localhost:7247/scalar` - Dokumentacja API (Scalar UI)
   - `https://localhost:7247/openapi/v1.json` - OpenAPI specyfikacja

## 📚 Funkcjonalności

### Zarządzanie Klientami
- Wyświetlanie listy aktywnych klientów
- Wyświetlanie archiwum klientów
- Przeglądanie szczegółów klienta
- Tworzenie nowych klientów (z walidacją FluentValidation)
- Edycja istniejących klientów
- Filtrowanie aktywnych/zarchiwizowanych klientów
- Powiązanie klientów z regionami

### Zarządzanie Produktami
- Wyświetlanie listy produktów
- Informacje o produktach (nazwa, opis, kolor, cena)

### Zarządzanie Regionami
- Wyświetlanie listy regionów
- Powiązanie regionów z klientami

### Dashboard (SignalR)
- Dashboard w czasie rzeczywistym z danymi z serwera
- Automatyczne aktualizacje przez SignalR
- Background service generujący dane w tle

### Dokumentacja API
- Interaktywna dokumentacja API w Scalar UI
- OpenAPI/Swagger specyfikacja
- Testowanie endpointów bezpośrednio z dokumentacji

## 🎯 Wzorce Projektowe

Projekt demonstruje następujące wzorce i praktyki:

- **Repository Pattern** - abstrakcja dostępu do danych
- **Dependency Injection** - wstrzykiwanie zależności
- **Service Layer** - warstwa serwisów dla logiki biznesowej
- **Clean Architecture** - separacja warstw i odpowiedzialności
- **Async/Await** - asynchroniczne operacje I/O
- **Component-Based Architecture** - komponenty Blazor
- **Extension Methods** - metody rozszerzające (np. `DateTimeExtensions`, `IEndpointRouteBuilder`)
- **Middleware Pattern** - przetwarzanie żądań HTTP w pipeline
- **Background Services** - długotrwałe zadania działające w tle
- **SignalR Hub Pattern** - komunikacja dwukierunkowa w czasie rzeczywistym
- **HTTP Message Handlers** - przetwarzanie żądań HTTP w kliencie
- **Validation Pattern** - walidacja danych z użyciem FluentValidation

## 📝 Modele Danych

### Customer
- `Id` (int) - identyfikator
- `Name` (string) - nazwa klienta
- `Email` (string) - adres email
- `Code` (string) - kod klienta
- `Region` (Region?) - powiązany region (opcjonalne)
- `Birthday` (DateTime?) - data urodzenia (opcjonalne)
- `Salary` (decimal) - wynagrodzenie
- `IsArchived` (bool) - czy zarchiwizowany
- `Password` (string) - hasło
- `ConfirmPassword` (string) - potwierdzenie hasła
- `Newsletter` (bool) - zgoda na newsletter

### Product
- `Id` (int) - identyfikator
- `Name` (string) - nazwa produktu
- `Description` (string) - opis
- `Color` (string) - kolor
- `UnitPrice` (decimal) - cena jednostkowa

### Region
- `Id` (int) - identyfikator
- `Name` (string) - nazwa regionu

## 🔧 Konfiguracja

### API (`appsettings.json`)
- Konfiguracja connection string dla bazy danych (`MyConnection`)
- Ustawienia CORS dla portów `7283` i `7194`
- Konfiguracja SignalR

### API (`Program.cs`)
- Rejestracja repozytoriów i serwisów
- Konfiguracja CORS
- Rejestracja OpenAPI i Scalar
- Konfiguracja SignalR Hub
- Rejestracja Background Services
- Middleware'y: Logger, Auth (Secret Key)
- FluentValidation dla modeli

### BlazorWebAssemblyApp (`Program.cs`)
- Konfiguracja HttpClient z BaseAddress
- Rejestracja serwisów HTTP dla API (`ApiCustomerService`, `ApiProductService`)
- Konfiguracja routingu i komponentów

### MudBlazorWebAssemblyApp (`Program.cs`)
- Konfiguracja Blazor Server + WebAssembly Hybrid
- Rejestracja MudBlazor Services
- Konfiguracja HttpClient z Message Handlers (Logger, SecretKey)
- Rejestracja serwisów HTTP dla API (`ApiCustomerService`, `ApiProductService`, `ApiRegionService`)
- Konfiguracja Blazored.LocalStorage

## 📖 Materiały Szkoleniowe

Projekt zawiera materiały szkoleniowe w katalogach:
- `docs/` - dokumentacja i diagramy
- `exercises/` - ćwiczenia praktyczne

## 🎓 Cel Szkoleniowy

Projekt został stworzony w ramach szkolenia z tworzenia aplikacji webowych w Blazor 9 i demonstruje:
- Podstawy Blazor WebAssembly
- Blazor Server + WebAssembly Hybrid
- Architekturę warstwową aplikacji .NET (Domain, Infrastructure, Application, Api, Presentation)
- Komunikację frontend-backend przez REST API
- SignalR - komunikację w czasie rzeczywistym
- Middleware'y i Background Services
- Walidację danych z FluentValidation
- Dokumentację API z OpenAPI/Scalar
- Wzorce projektowe w praktyce
- Pracę z komponentami i routowaniem w Blazor
- Integrację z bibliotekami UI (MudBlazor)
- HTTP Message Handlers
- Extension Methods
- LocalStorage w aplikacjach Blazor

## 📄 Licencja

Projekt szkoleniowy - do użytku edukacyjnego.

## 👨‍💻 Autor

Marcin Sulecki. Projekt stworzony w ramach szkolenia z Blazor 9.

