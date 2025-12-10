namespace Api.Extensions;

public static class DateTimeExtensions
{
    // Metoda rozszerzajaca (Extension Methods)
    // Dokleja funkcję do istniejacego typu np. DateTime
    // Warunki, ktore trzeba spelnic:
    // 1. Klasa musi byc statyczna (static class)
    // 2. Metoda musi byc statyczna (public static)
    // 3. Slowo kluczowe this 
    public static bool IsHoliday(this DateTime date) 
    {
        return date == DateTime.Parse("2025-12-10");
    }
}
