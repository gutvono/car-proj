using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dapper;

namespace UDIRepository
{
    public class CarServiceRepository
    {
        private string Conn { get; set; }

        public CarServiceRepository() { Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString; }

        public bool Insert(CarService carService)
        {
            bool result = false;
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                db.Execute(CarService.INSERT, new { carService.Car.Plate, carService.Service.Id, carService.Status });
                db.Close();
                result = true;
            }
            return result;
        }

        public List<Car> GetAllCarsWithService()
        {
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                var CarsList = db.Query(CarService.CARSWITHSERVICE);
                List<Car> NewCarsList = new ();
                foreach (var item in CarsList)
                {
                    NewCarsList.Add(new Car
                    {
                        Plate = item.Plate,
                        Name = item.Name,
                        ModelYear = item.ModelYear,
                        FabricationYear = item.FabricationYear,
                        Color = item.Color
                    });
                }
                return NewCarsList;
            }
        }
    }
}
