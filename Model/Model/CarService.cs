using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CarService
    {
        public readonly static string INSERT = "INSERT INTO CarServiceTB (CarId, ServiceId, Status) VALUES (@CarId, @ServiceId, @Status)";

        public int? Id { get; set; }
        public Car Car { get; set; }
        public Service Service { get; set; }
        public bool Status { get; set; }

        public CarService() { }
    }
}
