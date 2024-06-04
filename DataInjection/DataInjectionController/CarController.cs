using DataInjectionService;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInjectionController
{
    public class CarController
    {
        private CarService _service;

        public CarController() { _service = new CarService(); }

        public int Insert(Car car) => _service.Insert(car);
    }
}
