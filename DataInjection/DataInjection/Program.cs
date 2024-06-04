using DataInjectionController;
using Microsoft.Data.SqlClient;
using Model;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        CarController _controller = new();

        Console.WriteLine("Inserindo dados do arquivo CarsDATA.json no banco SQL Server.\n" +
            "Pressione qualquer tecla para continuar...");
        Console.ReadKey();

        try
        {
            foreach (var car in GetJsonData())
            {
                _controller.Insert(car);
            }
        }
        catch (SqlException e)
        {
            Console.WriteLine("-- ERRO ao inserir carros no banco SQL...\n" +
                $"Mensagem: {e.Message}");
        }
    }


    private static List<Car> GetJsonData()
    {
        string DataDirectory = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent.Parent.FullName, "data\\CarsDATA.json");
        return JsonConvert.DeserializeObject<List<Car>>(File.ReadAllText(DataDirectory));
    }
}