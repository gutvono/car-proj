using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDIService;

namespace UDIController
{
    public class ServiceController
    {
        private ServiceService _service;

        public ServiceController() { _service = new(); }

        public int Insert(Service service) => _service.Insert(service);

        public List<Service> GetAll() => _service.GetAll();
    }
}
