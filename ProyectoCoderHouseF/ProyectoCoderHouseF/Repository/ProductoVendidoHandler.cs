using ProyectoFinalCH.Model;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinalCH.Repository
{
    public static class ProductoVendidoHandler
    {
        public const string ConnectionString = "Server=STUART\\MYSQL;Initial Catalog=SistemaGestion;Persist Security Info=False;User ID=sa;Password=root;MultipleActiveResultSets=False;Encrypt=False;Connection Timeout=30;";

        public static List<ProductoVendido> GetProductosVendidos()
        {
            List<ProductoVendido> resultados = new List<ProductoVendido>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM  ProductoVendido", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();
                                productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                productoVendido.Stock = Convert.ToInt32( dataReader["Stock"]);
                                productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);

                                resultados.Add(productoVendido);
                            }
                        }
                    }
                }

            }
            return resultados;

        }

        public static bool CrearProductoVendido(ProductoVendido productoVendido)
        {

            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[ProductoVendido]" +
                    "( Stock, IdProducto, IdVenta) VALUES" +
                    "( @stockParameter,@idProductoParameter, @idVentaParameter)";

                SqlParameter stockParameter = new SqlParameter("stockParameter", SqlDbType.BigInt) { Value = productoVendido.Stock };
                SqlParameter idProductoParameter = new SqlParameter("idProductoParameter", SqlDbType.BigInt) { Value = productoVendido.IdProducto };
                SqlParameter idVentaParameter = new SqlParameter("idVentaParameter", SqlDbType.BigInt) { Value = productoVendido.IdVenta };

                sqlConnection.Open();


                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                   
                    sqlCommand.Parameters.Add(stockParameter);
                    sqlCommand.Parameters.Add(idProductoParameter);
                    sqlCommand.Parameters.Add(idVentaParameter);


                    int numbersOfRows = sqlCommand.ExecuteNonQuery();

                    if (numbersOfRows > 0)
                    {
                        resultado = true;
                    }
                }
                sqlConnection.Close();
            }
            return resultado;
        }

    }

}


