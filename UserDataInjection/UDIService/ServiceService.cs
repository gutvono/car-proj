using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDIRepository;

namespace UDIService
{
    public class ServiceService
    {
        private ServiceRepository _repository;

        public ServiceService() { _repository = new(); }

        public int Insert (Service service) => _repository.Insert(service);

        public List<Service> GetAll() => _repository.GetAll();
    }
}
