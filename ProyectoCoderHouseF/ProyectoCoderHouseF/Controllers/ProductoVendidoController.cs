using Microsoft.AspNetCore.Mvc;
using ProyectoFinalCH.Model;
using ProyectoFinalCH.Repository;

namespace ProyectoFinalCH.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet(Name = "GetProductosVendidos")]
        public List<ProductoVendido> GetProductosVendidos()
        {
            return ProductoVendidoHandler.GetProductosVendidos();
        }
    }
}
