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
        private string Conn {  get; set; }

        public CarServiceRepository() { Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString; }

        public bool Insert(CarService carService)
        {
            bool result = false;
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                db.Execute(CarService.INSERT, carService);
                db.Close();
                result = true;
            }
            return result;
        }
    }
}
