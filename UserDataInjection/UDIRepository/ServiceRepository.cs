using Dapper;
using Microsoft.Data.SqlClient;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDIRepository
{
    public class ServiceRepository
    {
        private string Conn { get; set; }

        public ServiceRepository() { Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString; }

        public int Insert(Service service)
        {
            int IdService = 0;
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                IdService = db.ExecuteScalar<int>(Service.INSERT, service);
                db.Close();
            }
            return IdService;
        }

        public List<Service> GetAll()
        {
            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                var serviceList = db.Query<Service>(Service.GETALL).AsList();
                db.Close();
                return serviceList;
            }
        }
    }
}
