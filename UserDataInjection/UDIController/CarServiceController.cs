using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDIService;

namespace UDIController
{
    public class CarServiceController
    {
        private CarServiceService _service;

        public CarServiceController() { _service = new(); }

        public bool Insert(CarService carService) => _service.Insert(carService);
    }
}
