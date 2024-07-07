using FileCleaner;

internal class Program
{
  private static bool p_isCorrect;
  private static Cleaner p_cleaner = new();
  private static void Main(string[] args)
  {
    while (!p_isCorrect)
    {
      Console.Write($"Введите путь до папки: ");

      string? path = Console.ReadLine();

      if (string.IsNullOrWhiteSpace(path))
      {
        Console.WriteLine($"Путь некорректный");
      }
      else if (!Directory.Exists(path))
      {
        Console.WriteLine($"Указанного каталога не существует!");
      }
      else
      {
        p_cleaner.Clean(path);
        p_isCorrect = true;
      }
    }
  }
}