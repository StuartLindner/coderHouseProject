using Microsoft.AspNetCore.Mvc;
using ProyectoFinalCH.Controllers.DTOS;
using ProyectoFinalCH.Model;
using ProyectoFinalCH.Repository;
using static ProyectoFinalCH.Controllers.DTOS.PostUsuario;

namespace ProyectoFinalCH.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name= "GetUsuarios" )]
       public List<Usuario> GetUsuarios()
        {
            return UsuarioHandler.GetUsuarios();
        }



        //Usuario y contraseña
        [HttpGet("{nombreUsuario}/{contraseña}")]
        public bool Login(string nombreUsuario, string contraseña)
        {

            Usuario usuario = UsuarioHandler.GetUsuarioByContraseña(nombreUsuario, contraseña);
            if(usuario.Nombre == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        //eliminar usuario
        [HttpDelete]
        public bool DeleteUsuario([FromBody]int id)
        {
            try { 
            return UsuarioHandler.DeleteUsuario(id);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }



        //actualizar usuario
        [HttpPut]
        public bool ModificarUsuario([FromBody] PutUsuario usuario)
        {
            return UsuarioHandler.ModificarUsuario(new Usuario
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Contraseña = usuario.Contraseña,
                NombreUsuario = usuario.NombeUsuario,
                Mail = usuario.Mail
                
            }); ;

        }

        //crear usuario
        [HttpPost]
        public bool CrearUsuario([FromBody] PostUsuario usuario)
        {


            try
            {
                return UsuarioHandler.CrearUsuario(new Usuario
                {
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Contraseña = usuario.Contraseña,
                    Mail = usuario.Mail,
                    NombreUsuario = usuario.NombreUsuario,
                });
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
                
            }
          
        }
    }
}
