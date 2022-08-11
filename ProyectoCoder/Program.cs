
namespace ProyectoCoder;
public class ProbarObjetos
{
    static void Main(string[] args)
    {
        ProductoHandler productoHandler = new ProductoHandler();
        productoHandler.GetProductos();

        UsuarioHandler usuarioHandler = new UsuarioHandler();
        usuarioHandler.GetUsu();
        usuarioHandler.GetUsuarios("Stuart","123");

        ProductoVendidoHandler productoVendidoHandler = new ProductoVendidoHandler();
        productoVendidoHandler.GetProductosVendidos();

        VentaHandler ventaHandler = new VentaHandler();
        ventaHandler.GetVentas();

    }
}