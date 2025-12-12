# 📊 Zadanie: Dashboard

## 🧩 Cel:
Twoim zadaniem jest stworzenie wielokrotnego komponentu Blazora (InfoCard.razor), który posłuży jako element dashboardu prezentujący kluczowe dane – takie jak liczba klientów, produktów, status systemu itp. Celem jest przećwiczenie tworzenia komponentu wielokrotnego użytku.

## 🖼️ Szkic: 
  ![alt text](dashboard.png)

---

## ✅ Wymagania funkcjonalne:
1. **Komponent** `InfoCard.razor`
Stwórz komponent, który wyświetla przekazane dane w formie estetycznego „boxa”.

Parametry komponentu:
  - Tytuł (string) – etykieta informacji
  - Wartość (string lub liczba) – główna dana
    - Ikona (opcjonalna)  – emoji lub ikona z biblioteki (np. 🛒, 👤, ✅)
  

2. **Strona** `Dashboard.razor` 
Użyj komponentu `InfoCard.razor` co najmniej cztery razy z różnymi danymi w układzie siatki 4 kolumn

**Przykładowe karty:**
- 👤 Liczba klientów: `125`
- 🛒 Liczba produktów: `58`
- 💰 Średnia cena produktu: `48,90 zł`
- ✅ Status systemu: `Online`


--- 

## 💡 Wskazówki
- W celu optymalizacji utwórz endpoint Api `/api/dashboard` do pobierania tych danych za pomocą jednego requestu


### 👉 Przy projektowaniu układu pomocny może być:
- [MudGrid](https://mudblazor.com/components/grid#api) 
- [MudCard](https://mudblazor.com/components/card#api) 
- [MudIcon](https://mudblazor.com/components/icons#api) 


---


## ⏱️ Czas realizacji: **45 minut**


W razie pytań — zapytaj prowadzącego 🙂