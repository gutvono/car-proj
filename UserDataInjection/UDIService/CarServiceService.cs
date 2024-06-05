using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDIRepository;

namespace UDIService
{
    public class CarServiceService
    {
        private CarServiceRepository _repository;

        public CarServiceService() { _repository = new CarServiceRepository(); }

        public bool Insert(CarService carService) => _repository.Insert(carService);

        public List<Car> GetAllCarsWithService() => _repository.GetAllCarsWithService();
    }
}
