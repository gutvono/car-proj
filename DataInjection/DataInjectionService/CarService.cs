using DataInjectionRepository;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInjectionService
{
    public class CarService
    {
        private CarRepository _repository;

        public CarService() { _repository = new CarRepository(); }

        public int Insert(Car car) => _repository.Insert(car);
    }
}
