
using ProyectoFinalCH.Model;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinalCH.Repository
{
    public static class UsuarioHandler
    {
        public const string ConnectionString = "Server=STUART\\MYSQL;Initial Catalog=SistemaGestion;Persist Security Info=False;User ID=sa;Password=root;MultipleActiveResultSets=False;Encrypt=False;Connection Timeout=30;";

        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> resultados = new List<Usuario> ();
            
        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM  Usuario", sqlConnection))
                {
                    sqlConnection.Open ();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader ())
                    {
                        if(dataReader.HasRows)
                        {
                            while (dataReader.Read ())
                            {
                                Usuario usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Nombre = dataReader["Nombre"].ToString ();
                                usuario.Apellido = dataReader["Apellido"].ToString () ;
                                usuario.Contraseña = dataReader["Contraseña"].ToString() ;
                                usuario.Mail = dataReader["Mail"].ToString();
                                
                                resultados.Add(usuario);
                            }
                        }    
                    }
                }    
            
            }
            return resultados;

        }


        public static Usuario GetUsuarioByContraseña(string nombreUsuario, string contraseña)
        {
          Usuario resultado = new Usuario();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM  Usuario" +
                    $"WHERE NombreUsuario = { nombreUsuario } " +
                    $"AND Contraseña = {contraseña}", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                                usuario.Mail = dataReader["Mail"].ToString();

                                resultado = usuario;
                            }
                        }
                    }
                    sqlConnection.Close();
                }

            }
            return resultado;

        }



       
        public static bool DeleteUsuario(int id)
        {
                
            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryDelete = "DELETE * FROM  Usuario WHERE Id = @id";

                SqlParameter sqlParameter = new SqlParameter("id", System.Data.SqlDbType.BigInt);
                sqlParameter.Value = id;
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                {
                    sqlCommand.Parameters.Add(sqlParameter);
                    int numbersOfRows = sqlCommand.ExecuteNonQuery();
                    if(numbersOfRows > 0)
                    {
                        resultado = true;
                    }
                }

                sqlConnection.Close();
            }
            return resultado;
        }



        public static bool CrearUsuario(Usuario usuario) {
            
           bool resultado = false;
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Usuario]" +
                        "(Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES" +
                        "(@nombreParameter, @apellidoParameter, @nombreUsuarioParameter, @contraseñaParameter, @mailParameter)";

                    SqlParameter nombreParameter = new SqlParameter("nombreParameter", SqlDbType.VarChar) { Value = usuario.Nombre };
                    SqlParameter apellidoParameter = new SqlParameter("apellidoParameter", SqlDbType.VarChar) { Value = usuario.Apellido };
                    SqlParameter nombreUsuarioParameter = new SqlParameter("nombreUsuarioParameter", SqlDbType.VarChar) { Value = usuario.NombreUsuario};
                    SqlParameter contraseñaParameter = new SqlParameter("contraseñaParameter", SqlDbType.VarChar) { Value = usuario.Contraseña };
                    SqlParameter mailParameter = new SqlParameter("mailParameter", SqlDbType.VarChar) { Value = usuario.Mail };


                    sqlConnection.Open();


                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(nombreParameter);
                        sqlCommand.Parameters.Add(apellidoParameter);
                        sqlCommand.Parameters.Add(nombreUsuarioParameter);
                        sqlCommand.Parameters.Add(contraseñaParameter);
                        sqlCommand.Parameters.Add(mailParameter);

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

     
        public static bool ModificarUsuario(Usuario usuario)
        {

            bool resultado = false;
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryInsert = "UPDATE  [SistemaGestion].[dbo].[Usuario]" +
                    "SET Nombre = @nombreParameter," +
                    "Apellido = @apellidoParameter," +
                    "Contraseña = @contraseñaParameter, " +
                    "NombreUsuario = @nombreUsuarioParameter, " +
                    "Mail = @mailParameter " +
                    "WHERE Id = @idParameter";

                SqlParameter nombreParameter = new SqlParameter("nombreParameter", SqlDbType.VarChar) { Value = usuario.Nombre };
                SqlParameter apellidoParameter = new SqlParameter("apellidoParameter", SqlDbType.VarChar) { Value = usuario.Apellido };
                SqlParameter contraseñaParameter = new SqlParameter("contraseñaParameter", SqlDbType.VarChar) { Value = usuario.Contraseña };
                SqlParameter nombreUsuarioParameter = new SqlParameter("nombreUsuarioParameter", SqlDbType.VarChar) { Value = usuario.NombreUsuario };
                SqlParameter mailParameter = new SqlParameter("mailParameter", SqlDbType.VarChar) { Value = usuario.Mail };
                SqlParameter idParameter = new SqlParameter("idParameter", SqlDbType.BigInt) { Value = usuario.Id };


                sqlConnection.Open();


                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(nombreParameter);
                    sqlCommand.Parameters.Add(apellidoParameter);
                    sqlCommand.Parameters.Add(contraseñaParameter);
                    sqlCommand.Parameters.Add(nombreUsuarioParameter);
                    sqlCommand.Parameters.Add(mailParameter);
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







