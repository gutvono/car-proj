using Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace DataInjectionRepository
{
    public class CarRepository
    {
        private string Conn { get; set; }

        public CarRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public string Insert(Car car)
        {
            string Plate;
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                Plate = db.ExecuteScalar<string>(Car.INSERT, car);
                db.Close();
            }
            return Plate;
        }

        public void Delete(Car car)
        {
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                db.Execute(Car.DELETE, car.Plate);
            }
        }

        public List<Car> GetAll()
        {
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                return db.Query<Car>(Car.GETALL).AsList();
            }
        }
    }
}
