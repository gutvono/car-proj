using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CarService
    {
        public readonly static string INSERT = "INSERT INTO CarServiceTB (CarId, ServiceId, Status) VALUES (@Plate, @Id, @Status)";
        public readonly static string CARSWITHSERVICE = "" +
            "SELECT CarTB.Plate, CarTB.Name, CarTB.ModelYear, CarTB.FabricationYear, CarTB.Color " +
            "FROM CarServiceTB " +
            "INNER JOIN CarTB ON CarServiceTB.CarId = CarTb.Plate " +
            "WHERE CarServiceTB.[Status] = 1;";

        public int? Id { get; set; }
        public Car Car { get; set; }
        public Service Service { get; set; }
        public bool Status { get; set; }

        public CarService() { }
    }
}
