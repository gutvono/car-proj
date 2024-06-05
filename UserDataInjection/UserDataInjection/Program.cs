using DataInjectionController;
using Model;
using UDIController;

class Program
{
    static void Main(string[] args)
    {
        CarController _carController = new();
        ServiceController _serviceController = new();
        CarServiceController _carServiceController = new();
        int optMainMenu, optCase1, optCase2, ServiceId;
        string Plate;

        do
        {
            Console.WriteLine("Bem vindo á sua garagem.\n" +
                "1 - Inserir novo carro;\n" +
                "2 - Inserir novo serviço;\n" +
                "0 - Sair da garagem.");
            optMainMenu = int.Parse(Console.ReadLine());

            switch (optMainMenu)
            {
                case 1:
                    Plate = _carController.Insert(GetUserCar());
                    Console.WriteLine($"Deseja vincular algum serviço ao carro inserido com a placa {Plate}?\n" +
                        $"1 - SIM;\n" +
                        $"0 - NÃO.\n");
                    optCase1 = int.Parse(Console.ReadLine());
                    if (optCase1 == 1) ShowServicesAndVinculate(Plate, _serviceController, _carServiceController);
                    break;
                case 2:
                    ServiceId = _serviceController.Insert(GetUserService());
                    Console.WriteLine($"Deseja vincular algum carro ao serviço inserido?\n" +
                        $"1 - SIM;\n" +
                        $"0 - NÃO.");
                    optCase2 = int.Parse(Console.ReadLine());
                    if (optCase2 == 2) ShowCarsAndVinculate(ServiceId, _carController, _carServiceController);
                    break;
                default:
                    break;
            }
        } while (optMainMenu != 0);
    }

    private static Car GetUserCar()
    {
        Car car = new();
        Console.Write("Placa:");
        car.Plate = Console.ReadLine();
        Console.Write("Nome:");
        car.Name = Console.ReadLine();
        Console.Write("Ano modelo:");
        car.ModelYear = int.Parse(Console.ReadLine());
        Console.Write("Ano fabricação:");
        car.FabricationYear = int.Parse(Console.ReadLine());
        Console.Write("Cor:");
        car.Color = Console.ReadLine();

        return car;
    }

    private static Service GetUserService()
    {
        Service service = new();
        Console.Write("Serviço:");
        service.Description = Console.ReadLine();

        return service;
    }

    private static void ShowServicesAndVinculate(string Plate, ServiceController serviceController, CarServiceController _carServiceController)
    {
        List<Service> services = serviceController.GetAll();
        Car CarPlate = new Car { Plate = Plate };

        foreach (var service in services) Console.WriteLine(service.ToString);

        Console.Write("Informe qual serviço será vinculado:");
        Service ServiceId = new Service() { Id = int.Parse(Console.ReadLine()) };

        _carServiceController.Insert(new CarService
        {
            Car = CarPlate,
            Service = ServiceId,
            Status = false
        });
    }

    private static void ShowCarsAndVinculate(int ServiceId, CarController carController, CarServiceController _carServiceController)
    {
        List<Car> CarsList = carController.GetAll();
        Service Service = new Service() { Id = ServiceId };

        foreach (var car in CarsList) { Console.WriteLine(car.ToString); }
        Console.Write("Informe a placa do carro que será vinculado:");
        Car Plate = new Car { Plate = Console.ReadLine() };

        _carServiceController.Insert(new CarService
        {
            Car = Plate,
            Service = Service,
            Status = false
        });
    }
}