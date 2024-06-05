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
            "SELECT @Plate;";
        public readonly static string DELETE = "DELETE FROM CarTB WHERE Plate = @Plate;";
        public readonly static string GETALL = "SELECT (Plate, Name, ModelYear, FabricationYear, Color) FROM CarTB";

        public string Plate { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public int FabricationYear { get; set; }
        public string Color { get; set; }

        public Car() { }

        public override string ToString()
        {
            return "Placa: ".PadRight(16, '.') + Plate + "\n" + 
                "Nome: ".PadRight(16, '.') + Name + "\n" +
                "Ano modelo:".PadRight(16, '.') + ModelYear + "\n" +
                "Ano fabricação: ".PadRight(16, '.') + FabricationYear + "\n" +
                "Cor: ".PadRight(16, '.') + Color;
        }
    }
}
