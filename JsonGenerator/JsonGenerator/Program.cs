using Model;
using Newtonsoft.Json;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        int opt = 0;
        do
        {
            Console.Clear();
            List<Car> CarsList = GenerateCars();
            string DataDirectory = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.Parent.FullName, "data");
            GenerateJson(CarsList, DataDirectory);
            Console.WriteLine(CarsList.ToString());

            Console.WriteLine("Gerar novo arquivo:\n" +
                "1 - SIM;\n" +
                "2 - NÃO");
            opt = int.Parse(Console.ReadLine());
        } while (opt != 2);
    }

    static List<Car> GenerateCars()
    {
        List<Car> cars = new();
        string[] colors() => ["Branco", "Vermelho", "Preto", "Prata"];

        for (int i = 0; i < 30; i++)
        {
            int Year = new Random().Next(2000, 2025);
            int Color = new Random().Next(0, 4);

            cars.Add(new Car
            {
                Plate = $"PLATE{i}",
                Name = $"Name{i}",
                ModelYear = Year,
                FabricationYear = Year - 1,
                Color = colors()[Color]
            });
        }

        return cars;
    }

    static void GenerateJson(List<Car> entities, string baseFilePath)
    {
        string filePath = Path.Combine(baseFilePath, "CarsDATA.json");
        File.Delete(filePath);
        string json = JsonConvert.SerializeObject(entities, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(filePath, json);
        Console.WriteLine($"JSON file generated at {filePath}");
    }
}