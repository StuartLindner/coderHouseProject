using Microsoft.AspNetCore.Mvc;
using ProyectoFinalCH.Controllers.DTOS;
using ProyectoFinalCH.Model;
using ProyectoFinalCH.Repository;
namespace ProyectoFinalCH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController
    {

        [HttpGet(Name = "GetVentas")]
        public List<Venta> GetVentas()
        {
            return VentaHandler.GetVentas();
        }

        [HttpPost]
        public bool CrearVenta([FromBody] VentaDTO venta)
        {

            
            try
            {
               int lastId =  VentaHandler.CrearVenta(new Venta
                {

                    Comentarios = venta.venta.Comentarios
                    
                });



                foreach (var v in venta.productos)
                {
                    ProductoVendidoHandler.CrearProductoVendido(new ProductoVendido
                    {
                     
                        Stock = v.Stock,
                        IdProducto = v.IdProducto,
                        IdVenta = lastId                      
                    });

                    Producto productoAux = ProductoHandler.GetProductosById(v.Id);

                    ProductoHandler.ModificarProducto(new Producto
                    {
                        Id = v.Id,
                        Stock = (productoAux.Stock - v.Stock),
                        Costo = productoAux.Costo,
                        PrecioVenta = productoAux.PrecioVenta,
                        IdUsuario = productoAux.IdUsuario,
                        Descripciones = productoAux.Descripciones

                    });
                    
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }



        }

    }
}
