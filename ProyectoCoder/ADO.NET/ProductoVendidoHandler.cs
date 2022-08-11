using System.Data;
using System.Data.SqlClient;


namespace ProyectoCoder
{
    public class ProductoVendidoHandler : DbHandler { 
     public List<ProductoVendido> GetProductosVendidos()
    {
        List<ProductoVendido> productoVendidos = new List<ProductoVendido>();
        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
        {
            using (SqlCommand sqlCommand = new SqlCommand(
                "SELECT * FROM ProductoVendido", sqlConnection))
            {
                sqlConnection.Open();

                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    // Me aseguro que haya filas que leer
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            ProductoVendido productoV = new ProductoVendido();
                                productoV.Id = Convert.ToInt32(dataReader["Id"]);
                                productoV.Stock = dataReader["Stock"].ToString();
                                productoV.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productoV.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);

                                productoVendidos.Add(productoV);
                        }
                    }
                    //Solo para verificar que traiga los datos
                  foreach(ProductoVendido productoV in productoVendidos)
                    {   
                        Console.WriteLine(productoV.Stock);
                    }

                }

                sqlConnection.Close();
            }
        }

        return productoVendidos;
    }
   }
}



