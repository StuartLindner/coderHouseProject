using System.Data;
using System.Data.SqlClient;

namespace ProyectoCoder
{
    public class UsuarioHandler : DbHandler
    {
        public List<Usuario> GetUsu()
        {
            List<Usuario> usu = new List<Usuario>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // Me aseguro que haya filas que leer
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

                                usu.Add(usuario);

                            }
                        }
                        //Solo para verificar que traiga los datos
                      foreach(Usuario usuario in usu)
                        {
                            Console.WriteLine(usuario.Nombre);
                        }

                    }

                    sqlConnection.Close();
                }
            }

            return usu;
        }
    

    public List<Usuario> GetUsuarios(String Us, String Contra)
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                   "SELECT * FROM Usuario WHERE NombreUsuario ='" + Us + " '  AND Contraseña ='" + Contra +"'", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // Me aseguro que haya filas que leer
                        if (dataReader.HasRows)
                        {
                            Usuario usuario = new Usuario();
                            while (dataReader.Read())
                            {
                            

                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                usuario.Nombre = dataReader["Nombre"].ToString();
                                usuario.Apellido = dataReader["Apellido"].ToString();
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                                usuario.Mail = dataReader["Mail"].ToString();
                            }
                              Console.WriteLine(usuario.ToString());
                        } else
                        {
                            Console.WriteLine("No hay Usuarios Creados");
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return usuarios;
        }



        
    }
}
