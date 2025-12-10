# Tutorial: Tworzenie aplikacji Blazor WebAssembly

## 1. Tworzenie aplikacji WebAssembly z dotnet CLI

### Wymagania wstępne
- Zainstalowany .NET 9.0 SDK lub nowszy
- Terminal/Command Prompt

### Krok 1: Sprawdzenie dostępnych szablonów Blazor

Najpierw sprawdź dostępne szablony Blazor:

```bash
dotnet new list blazor
```

### Krok 2: Utworzenie nowej aplikacji Blazor WebAssembly

Aby utworzyć podstawową aplikację Blazor WebAssembly, użyj następującego polecenia:

```bash
dotnet new blazorwasm -n MyBlazorApp -o MyBlazorApp
```

**Parametry:**
- `-n` lub `--name` - nazwa projektu
- `-o` lub `--output` - katalog docelowy (opcjonalne, domyślnie używa nazwy projektu)

### Krok 3: Uruchomienie aplikacji

Przejdź do katalogu projektu i uruchom aplikację:

```bash
cd MyBlazorApp
dotnet run
```

Aplikacja będzie dostępna pod adresem `https://localhost:5001` (lub inny port wskazany w terminalu).

### Dodatkowe opcje szablonu

Możesz również użyć dodatkowych parametrów:

```bash
# Utworzenie aplikacji z określonym interfejsem użytkownika
dotnet new blazorwasm -n MyBlazorApp --interactivity WebAssembly

# Utworzenie aplikacji z określonym frameworkiem UI
dotnet new blazorwasm -n MyBlazorApp --framework net9.0

# Utworzenie aplikacji z pustym projektem (bez przykładowych stron)
dotnet new blazorwasm -n MyBlazorApp --empty
```

### Struktura utworzonego projektu

Po utworzeniu projektu otrzymasz następującą strukturę:

```
MyBlazorApp/
├── Components/
│   ├── Layout/
│   │   └── MainLayout.razor
│   └── Pages/
│       ├── Home.razor
│       └── ...
├── wwwroot/
│   ├── css/
│   └── index.html
├── Program.cs
├── App.razor
└── MyBlazorApp.csproj
```

#### Opis poszczególnych plików i katalogów

**`MyBlazorApp.csproj`**
- Plik projektu .NET zawierający konfigurację projektu
- Definiuje zależności NuGet (np. `Microsoft.AspNetCore.Components.WebAssembly`)
- Określa wersję frameworka (.NET 9.0)
- Zawiera metadane projektu (nazwa, wersja, autor)

**`Program.cs`**
- Główny punkt wejścia aplikacji
- Konfiguruje kontener Dependency Injection
- Rejestruje serwisy (np. HttpClient, serwisy aplikacji)
- Konfiguruje routowanie i komponenty Blazor
- Uruchamia aplikację WebAssembly

**`App.razor`**
- Główny komponent aplikacji Blazor
- Definiuje router aplikacji (`<Router>`)
- Określa domyślny layout dla stron
- Zawiera konfigurację routingu i nawigacji

**`Components/Layout/MainLayout.razor`**
- Główny layout aplikacji
- Definiuje strukturę strony (nagłówek, menu, stopka)
- Zawiera komponent `<NavMenu>` do nawigacji
- Używany jako domyślny layout dla wszystkich stron
- Można utworzyć dodatkowe layouty dla różnych sekcji aplikacji

**`Components/Pages/`**
- Katalog zawierający wszystkie strony aplikacji
- Każdy plik `.razor` reprezentuje jedną stronę
- Pliki zawierają dyrektywę `@page` określającą ścieżkę URL
- Przykładowe strony:
  - `Home.razor` - strona główna (`@page "/"`)
  - `Counter.razor` - przykładowa strona z licznikiem
  - `Weather.razor` - przykładowa strona z danymi pogodowymi

**`wwwroot/`**
- Katalog zawierający pliki statyczne aplikacji
- Pliki z tego katalogu są serwowane bezpośrednio do przeglądarki
- Zawartość jest kopiowana do folderu wyjściowego podczas budowania

**`wwwroot/index.html`**
- Główny plik HTML aplikacji
- Punkt wejścia dla aplikacji Blazor WebAssembly
- Zawiera referencje do skryptów Blazor (`blazor.webassembly.js`)
- Definiuje element `<div id="app">` gdzie renderowana jest aplikacja
- Można tutaj dodać zewnętrzne skrypty, style, meta tagi

**`wwwroot/css/`**
- Katalog zawierający pliki CSS
- `app.css` - główne style aplikacji
- Można dodać dodatkowe pliki CSS dla konkretnych komponentów lub stron

**`Properties/launchSettings.json`** (opcjonalnie)
- Konfiguracja uruchamiania aplikacji
- Definiuje profile uruchomieniowe
- Zawiera ustawienia portów, adresów URL, zmiennych środowiskowych
- Używany przez `dotnet run` i IDE

**`_Imports.razor`** (opcjonalnie)
- Plik z globalnymi importami dla komponentów Razor
- Zawiera dyrektywy `@using` dostępne we wszystkich komponentach
- Upraszcza kod - nie trzeba importować przestrzeni nazw w każdym pliku

---

## 2. Tworzenie aplikacji WebAssembly z MudBlazor

### Wymagania wstępne
- Zainstalowany .NET 9.0 SDK lub nowszy
- Terminal/Command Prompt

### Krok 1: Instalacja szablonów MudBlazor

Najpierw zainstaluj szablony MudBlazor:

```bash
dotnet new install MudBlazor.Templates
```

To polecenie instaluje szablony MudBlazor, które umożliwiają szybkie tworzenie aplikacji z prekonfigurowanym MudBlazor.

### Krok 2: Utworzenie aplikacji z MudBlazor

Utwórz nową aplikację Blazor WebAssembly z MudBlazor używając następującego polecenia:

```bash
dotnet new mudblazor --interactivity WebAssembly --name MyApplication --all-interactive
```

**Parametry:**
- `--interactivity WebAssembly` - określa tryb interaktywności jako WebAssembly
- `--name MyApplication` - nazwa projektu (możesz zmienić na dowolną)
- `--all-interactive` - wszystkie komponenty będą interaktywne

### Alternatywne opcje interaktywności

MudBlazor oferuje różne tryby interaktywności:

```bash
# WebAssembly (wszystko działa po stronie klienta)
dotnet new mudblazor --interactivity WebAssembly --name MyApp

# Server (komponenty renderowane po stronie serwera)
dotnet new mudblazor --interactivity Server --name MyApp

# Auto (automatyczny wybór)
dotnet new mudblazor --interactivity Auto --name MyApp

# None (bez interaktywności)
dotnet new mudblazor --interactivity None --name MyApp
```

### Krok 3: Uruchomienie aplikacji

Przejdź do katalogu projektu i uruchom aplikację:

```bash
cd MyApplication
dotnet run
```

### Co zawiera szablon MudBlazor?

Szablon MudBlazor automatycznie konfiguruje:

- **MudBlazor** - biblioteka komponentów UI
- **Prekonfigurowane komponenty** - gotowe komponenty MudBlazor
- **Stylowanie** - wstępnie skonfigurowane style
- **Nawigacja** - menu nawigacyjne z MudBlazor
- **Layout** - główny layout z MudBlazor

### Struktura utworzonego projektu

Po utworzeniu projektu otrzymasz strukturę podobną do:

```
MyApplication/
├── Components/
│   ├── Layout/
│   │   └── MainLayout.razor
│   └── Pages/
│       ├── Index.razor
│       └── ...
├── wwwroot/
│   ├── css/
│   └── index.html
├── Program.cs
├── App.razor
└── MyApplication.csproj
```

#### Opis poszczególnych plików i katalogów

**`MyApplication.csproj`**
- Plik projektu .NET zawierający konfigurację projektu
- Zawiera referencję do pakietu NuGet `MudBlazor`
- Definiuje zależności WebAssembly
- Określa wersję frameworka (.NET 9.0)
- Zawiera metadane projektu

**`Program.cs`**
- Główny punkt wejścia aplikacji
- Konfiguruje MudBlazor: `builder.Services.AddMudServices()`
- Rejestruje serwisy MudBlazor (Dialog, Snackbar, ResizeListener, itp.)
- Konfiguruje HttpClient dla komunikacji z API (jeśli potrzebne)
- Uruchamia aplikację WebAssembly

**`App.razor`**
- Główny komponent aplikacji Blazor
- Zawiera komponent `<MudThemeProvider />` dla zarządzania motywami MudBlazor
- Definiuje router aplikacji (`<Router>`)
- Określa domyślny layout dla stron
- Może zawierać komponenty MudBlazor jak `<MudDialogProvider />` i `<MudSnackbarProvider />`

**`Components/Layout/MainLayout.razor`**
- Główny layout aplikacji z komponentami MudBlazor
- Zawiera komponenty MudBlazor:
  - `<MudAppBar>` - pasek aplikacji
  - `<MudDrawer>` - menu boczne (drawer)
  - `<MudMainContent>` - główna zawartość strony
- Używa komponentów MudBlazor do nawigacji (`<MudNavLink>`)
- Zawiera konfigurację motywu (jasny/ciemny tryb)

**`Components/Pages/`**
- Katalog zawierający wszystkie strony aplikacji
- Każdy plik `.razor` reprezentuje jedną stronę
- Strony używają komponentów MudBlazor (np. `<MudCard>`, `<MudButton>`, `<MudTextField>`)
- Przykładowe strony:
  - `Index.razor` - strona główna z przykładowymi komponentami MudBlazor
  - Inne strony demonstrujące różne komponenty MudBlazor

**`wwwroot/`**
- Katalog zawierający pliki statyczne aplikacji
- Pliki z tego katalogu są serwowane bezpośrednio do przeglądarki

**`wwwroot/index.html`**
- Główny plik HTML aplikacji
- Punkt wejścia dla aplikacji Blazor WebAssembly
- Zawiera referencje do skryptów Blazor (`blazor.webassembly.js`)
- Zawiera linki do fontów Material Icons (używanych przez MudBlazor)
- Definiuje element `<div id="app">` gdzie renderowana jest aplikacja

**`wwwroot/css/`**
- Katalog zawierający pliki CSS
- `app.css` - główne style aplikacji
- Można tutaj dodać własne style, które będą współgrać z MudBlazor

**`Properties/launchSettings.json`** (opcjonalnie)
- Konfiguracja uruchamiania aplikacji
- Definiuje profile uruchomieniowe
- Zawiera ustawienia portów i adresów URL
- Używany przez `dotnet run` i IDE

**`_Imports.razor`** (opcjonalnie)
- Plik z globalnymi importami dla komponentów Razor
- Zawiera `@using MudBlazor` - umożliwia używanie komponentów MudBlazor bez pełnej ścieżki
- Zawiera inne przestrzenie nazw używane w aplikacji

**Dodatkowe pliki w projekcie MudBlazor:**
- Pliki konfiguracyjne MudBlazor mogą być w osobnych plikach lub w `Program.cs`
- Tematy MudBlazor mogą być zdefiniowane w osobnym pliku lub bezpośrednio w `MainLayout.razor`

### Krok 4: Dodatkowa konfiguracja MudBlazor

Po utworzeniu projektu, w pliku `Program.cs` znajdziesz już skonfigurowane MudBlazor:

```csharp
builder.Services.AddMudServices();
```

W pliku `App.razor` lub `MainLayout.razor` znajdziesz również referencję do MudThemeProvider:

```razor
<MudThemeProvider />
```

### Przydatne zasoby MudBlazor

- **Dokumentacja**: https://mudblazor.com/
- **Komponenty**: https://mudblazor.com/components
- **Tematy**: https://mudblazor.com/features/theming

---

## Porównanie podejść

| Aspekt | Standardowy Blazor WebAssembly | MudBlazor Template |
|--------|-------------------------------|-------------------|
| **Instalacja** | `dotnet new blazorwasm` | `dotnet new install MudBlazor.Templates` + `dotnet new mudblazor` |
| **Komponenty UI** | Podstawowe HTML/CSS | Bogata biblioteka komponentów MudBlazor |
| **Stylowanie** | Własne style lub Bootstrap | Material Design z MudBlazor |
| **Czas konfiguracji** | Szybki start | Automatyczna konfiguracja MudBlazor |
| **Złożoność** | Prostsza struktura | Więcej gotowych komponentów |

---

## Następne kroki

Po utworzeniu aplikacji możesz:

1. **Dodać nowe strony** - utwórz pliki `.razor` w katalogu `Pages`
2. **Skonfigurować routing** - edytuj `App.razor` lub dodaj `@page` dyrektywy
3. **Dodać serwisy** - zarejestruj serwisy w `Program.cs`
4. **Skonfigurować HttpClient** - dla komunikacji z API
5. **Dostosować style** - edytuj pliki CSS lub skonfiguruj MudTheme

---

## Rozwiązywanie problemów

### Problem: Szablon MudBlazor nie jest dostępny

**Rozwiązanie:**
```bash
dotnet new install MudBlazor.Templates
```

### Problem: Błędy kompilacji po utworzeniu projektu

**Rozwiązanie:**
```bash
dotnet restore
dotnet build
```

### Problem: Port już zajęty

**Rozwiązanie:**
Edytuj plik `Properties/launchSettings.json` i zmień port w sekcji `applicationUrl`.

---

## Podsumowanie

- **Standardowy Blazor WebAssembly**: Idealny do nauki podstaw Blazor i prostych aplikacji
- **MudBlazor Template**: Idealny do szybkiego tworzenia aplikacji z bogatym UI i gotowymi komponentami Material Design

Oba podejścia są poprawne - wybór zależy od potrzeb projektu i preferencji zespołu.
