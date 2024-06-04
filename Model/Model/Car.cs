using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Car
    {
        public readonly static string INSERT = 
            "INSERT INTO CarTB (Plate, Name, ModelYear, FabricationYear, Color) VALUES (@Plate, @Name, @ModelYear, @FabricationYear, @Color);" +
            "SELECT CAST(scope_identity() AS INT);";

        public string Plate { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public int FabricationYear { get; set; }
        public string Color { get; set; }

        public Car() { }
    }
}
