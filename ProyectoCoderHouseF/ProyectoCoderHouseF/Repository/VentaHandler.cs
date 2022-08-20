using ProyectoFinalCH.Model;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinalCH.Repository
{
    public static class VentaHandler
    {

        public const string ConnectionString = "Server=STUART\\MYSQL;Initial Catalog=SistemaGestion;Persist Security Info=False;User ID=sa;Password=root;MultipleActiveResultSets=False;Encrypt=False;Connection Timeout=30;";

        public static List<Venta> GetVentas()
        {
            List<Venta> resultados = new List<Venta>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM  Venta", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();
                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();
                                
                               

                                resultados.Add(venta);
                            }
                        }
                    }
                }

            }
            return resultados;

        }

        public static Int32 CrearVenta(Venta venta)
        {

            Int32 resultado = 0;
          
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Venta]" +
                    "( Comentarios) VALUES" +
                    "(@comentariosParameter); SELECT SCOPE_IDENTITY()";

                SqlParameter comentariosParameter = new SqlParameter("comentariosParameter", SqlDbType.VarChar) { Value = venta.Comentarios };
               
                sqlConnection.Open();

                SqlCommand  sqlCommand = new(queryInsert, sqlConnection);
               
                 sqlCommand.Parameters.Add(comentariosParameter);

                  resultado = Convert.ToInt32( sqlCommand.ExecuteScalar());

                   
                


                sqlConnection.Close();
            }
            return resultado;
        }



        public static bool ModificarVenta(Venta venta, Producto producto)
        {

            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "UPDATE  [SistemaGestion].[dbo].[Venta]" +
                    "SET Comentarios = @comentariosParameter" +
                    "WHERE Id = @idParameter";

                SqlParameter comentariosParameter = new SqlParameter("comentariosParameter", SqlDbType.VarChar) { Value = venta.Comentarios };
                SqlParameter idParameter = new SqlParameter("idParameter", SqlDbType.BigInt) { Value = venta.Id };
            

                sqlConnection.Open();


                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(comentariosParameter);
                    sqlCommand.Parameters.Add(idParameter);


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
