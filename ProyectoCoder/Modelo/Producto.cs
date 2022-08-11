using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCoder;

    public class Producto
    {
        public int Id { get; set; }
        public string Descripciones { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }

        public int IdUsuario { get; set; }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contraseña { get; set; }
        public string NombreUsuario { get; set; }
        public string Mail { get; set; }

        public override string ToString()
         {
        return "Nombre: " + NombreUsuario + " " + "Contraseña: " + Contraseña;
        }
}
        public class ProductoVendido
        {
            public int Id { get; set; }
            public string Stock { get; set; }
            public double IdProducto { get; set; }
            public double IdVenta { get; set; }

        }
        public class Venta
        {
            public int Id { get; set; }
            public string Comentarios { get; set; }
        }


