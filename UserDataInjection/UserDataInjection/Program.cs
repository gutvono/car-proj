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
        int optMainMenu, optCase1, optCase2;

        do
        {
            Console.WriteLine("Bem vindo á sua garagem.\n" +
                "1 - Atribuir serviço a um carro;\n" +
                "2 - Inserir novo serviço;\n" +
                "0 - Sair da garagem.");
            optMainMenu = int.Parse(Console.ReadLine());

            switch (optMainMenu)
            {
                case 1:
                    //SELECIONA CARRO
                    var CarsList = _carController.GetAll();
                    CarsList.ForEach(car => Console.WriteLine(car));
                    Console.Write("Digite a placa do carro no qual será vinculado um serviço:");
                    string Plate = Console.ReadLine();

                    //SELECIONA SERVICO
                    var ServiceList = _serviceController.GetAll();
                    ServiceList.ForEach(service => Console.WriteLine(service));
                    Console.WriteLine("Informe o ID do serviço escolhido:");
                    int ServiceId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Este serviço está em andamento?" +
                        "1 - SIM" +
                        "0 - NÃO");
                    bool Status = int.Parse(Console.ReadLine()) == 1 ? true : false;
                    CarService carService = new CarService
                    {
                        Car = new Car { Plate = Plate },
                        Service = new Service { Id = ServiceId },
                        Status = Status
                    };

                    //INSERIR
                    _carServiceController.Insert(carService);
                    break;
                case 2:
                    ServiceId = _serviceController.Insert(GetUserService());
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

    //private static void Vinculate(Car Car, ServiceController serviceController, CarServiceController _carServiceController)
    //{
    //    List<Service> services = serviceController.GetAll();

    //    foreach (var service in services) Console.WriteLine(service.ToString);

    //    Console.Write("Informe qual serviço será vinculado:");
    //    Service ServiceId = new Service() { Id = int.Parse(Console.ReadLine()) };

    //    _carServiceController.Insert(new CarService
    //    {
    //        Car = CarPlate,
    //        Service = ServiceId,
    //        Status = false
    //    });
    //}

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