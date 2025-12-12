using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
     class Journal
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Pages { get; set; }

        public override string ToString()
        {
            return $"Назва: {Title}, Видавництво: {Publisher}, Дата: {ReleaseDate.ToShortDateString()}, Сторінки: {Pages}";
        }
    }

    static void Main()
    {
        Journal journal = new Journal();

        Console.Write("Назва журналу: ");
        journal.Title = Console.ReadLine();

        Console.Write("Назва видавництва: ");
        journal.Publisher = Console.ReadLine();

        Console.Write("Дата випуску (ДД.ММ.ГГГГ): ");
        journal.ReleaseDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Кількість сторінок: ");
        journal.Pages = int.Parse(Console.ReadLine());

        Console.WriteLine("\nІнформація про журнал:");
        Console.WriteLine(journal);

        // Сериализация в JSON
        string json = JsonSerializer.Serialize(journal);
        File.WriteAllText("journal.json", json);
        Console.WriteLine("\nЖурнал серіалізовано у файл journal.json");

        // Загрузка и десериализация
        string jsonFromFile = File.ReadAllText("journal.json");
        Journal loadedJournal = JsonSerializer.Deserialize<Journal>(jsonFromFile);

        Console.WriteLine("\nДесеріалізований журнал:");
        Console.WriteLine(loadedJournal);
    }
}
  