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
        private string Conn {  get; set; }

        public CarRepository() 
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public int Insert(Car car)
        {
            int Plate = 0;
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                Plate = db.ExecuteScalar<int>(Car.INSERT, car);
                db.Close();
            }
            return Plate;
        }
    }
}
