using DataInjectionController;
using Model;
using System.Xml.Serialization;
using UDIController;

class Program
{
    static void Main(string[] args)
    {
        CarController carController = new();
        CarServiceController carServiceController = new();

        var CarsWithService = carServiceController.GetAllCarsWithService();
        GenerateXml("CarsWithService", CarsWithService);

        var CarsList = carController.GetAll();
        GenerateXml("RedCars", CarsList.FindAll(car => car.Color == "Vermelho"));
        GenerateXml("CarsByFabricationYear", CarsList.FindAll(car => car.FabricationYear <= 2011 && car.FabricationYear >= 2010 ));
    }

    static void GenerateXml(string FileName, List<Car> CarsList)
    {
        string DataDirectory = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.Parent.FullName, "data");
        string filePath = Path.Combine(DataDirectory, FileName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Car>));
        using (var writer = new StreamWriter(filePath))
        {
            xmlSerializer.Serialize(writer, CarsList);
        }
        Console.WriteLine($"XML file generated at {filePath}");
    }
}