namespace ProyectoFinalCH.Controllers.DTOS
{
    public class VentaDTO
    {
        public int IdUsuario { get; set; }
        public List<PostProductoVendido> productos { get; set; }
        public VentaDTO()
        {
            this.productos = new List<PostProductoVendido>();  
        }

        public PostVenta venta { get; set; }
    }  
}
