using System.Data;
using System.Data.SqlClient;

namespace ProyectoCoder
{
    public class VentaHandler : DbHandler
    {


        public List<Venta> GetVentas()
        {
            List<Venta> vendido = new List<Venta>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM Venta", sqlConnection))
                {
                    sqlConnection.Open();


                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // Me aseguro que haya filas que leer
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();
                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();


                                vendido.Add(venta);
                            }
                        }
                        //Solo para verificar que traiga los datos
                      foreach(Venta venta in vendido)
                        {
                            Console.WriteLine(venta.Comentarios);
                        }

                    }

                    sqlConnection.Close();
                }
            }

            return vendido;
        }
    }
}
