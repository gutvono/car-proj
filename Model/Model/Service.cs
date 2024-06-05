using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Service
    {
        public readonly static string INSERT =
            "INSERT INTO ServiceTB (Description) VALUES (@Description);" +
            "SELECT CAST(scope_identity() AS INT);";
        public readonly static string GETALL = "SELECT Id, Description FROM ServiceTB;";

        public int Id { get; set; }
        public string Description { get; set; }

        public Service() { }

        public override string ToString()
        {
            return $"ID: {Id}".PadRight(3) + $" - Descrição do serviço: {Description}";
        }
    }
}
