using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCleaner
{
  internal class Cleaner
  {
    public void Clean(string _path)
    {
      try
      {
        DirectoryInfo dir = new DirectoryInfo(_path);

        foreach (var subdir in dir.GetDirectories())
        {
          if ((DateTime.Now - subdir.LastWriteTime) > (DateTime.Now - DateTime.Now.AddMinutes(-30)))
          {
            Console.WriteLine($"Папка {subdir.Name} использовалась более 30 минут назад --> удаляем");
            subdir.Delete(true);
          }
          else
          {
            Console.WriteLine($"Папка {subdir.Name} использовалась менее 30 минут назад --> пусть живет");
          }
        }

        foreach (var file in dir.GetFiles())
        {
          if ((DateTime.Now - file.LastWriteTime) > (DateTime.Now - DateTime.Now.AddMinutes(-30)))
          {
            Console.WriteLine($"Файл {file.Name} использовался более 30 минут назад --> удаляем");
            file.Delete();
          }
          else
          {
            Console.WriteLine($"Файл {file.Name} использовался менее 30 минут назад --> пусть живет");
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }
  }
}
