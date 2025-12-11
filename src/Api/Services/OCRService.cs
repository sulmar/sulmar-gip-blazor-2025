using Tesseract;

namespace Api.Services;

// Install-Package Tesseract
public class OCRService
{
    public string Process(string imagePath = @"sample.png")
    {
        // Ścieżka do folderu z plikami .traineddata
        string tessDataPath = @"./tessdata";
        
        try
        {
            // Inicjalizacja engine (tu: język polski + angielski)
            using var engine = new TesseractEngine(tessDataPath, "pol+eng", EngineMode.Default);
            
            using var img = Pix.LoadFromFile(imagePath);
            using var page = engine.Process(img);

            Console.WriteLine("=== WYNIK OCR ===");
            Console.WriteLine(page.GetText());
            Console.WriteLine($"Pewność: {page.GetMeanConfidence()}");

            return page.GetText();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
