using Microsoft.AspNetCore.Mvc;
using ProyectoFinalCH.Controllers.DTOS;
using ProyectoFinalCH.Model;
using ProyectoFinalCH.Repository;
using static ProyectoFinalCH.Controllers.DTOS.PostProducto;

namespace ProyectoFinalCH.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProductos")]
        public List<Producto> GetProductos()
        {
            return ProductoHandler.GetProductos();
        }
    


    //crear Producto
    [HttpPost]
    public bool CrearProducto([FromBody] PostProducto producto)
    {
        try
        {
            return ProductoHandler.CrearProducto(new Producto
            {
                Id = producto.Id,
                Descripciones = producto.Descripciones,
                Costo = producto.Costo,
                PrecioVenta = producto.PrecioVenta,
                Stock = producto.Stock,
                IdUsuario = producto.IdUsuario,
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;

        }
    }


        //actualizar usuario
        [HttpPut]
        public bool ModificarProducto([FromBody] PutProducto producto)
        {
            return ProductoHandler.ModificarProducto(new Producto
            {
                Id = producto.Id,
                Descripciones = producto.Descripciones,
                Costo = producto.Costo,
                PrecioVenta = producto.PrecioVenta,
                Stock = producto.Stock,
                IdUsuario = producto.IdUsuario,

            }); ;

        }
    }


}

