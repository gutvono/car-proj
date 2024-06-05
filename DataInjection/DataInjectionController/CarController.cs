using DataInjectionService;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService = DataInjectionService.CarService;

namespace DataInjectionController
{
    public class CarController
    {
        private CarService _service;

        public CarController() { _service = new CarService(); }

        public string Insert(Car car) => _service.Insert(car);

        public void Delete(Car car) => _service.Delete(car);

        public List<Car> GetAll() => _service.GetAll();
    }
}
