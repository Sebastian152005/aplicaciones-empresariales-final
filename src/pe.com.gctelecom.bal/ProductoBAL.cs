using pe.com.gctelecom.bo;
using pe.com.gctelecom.dal;

namespace pe.com.gctelecom.bal
{
    public class ProductoBAL
    {
        private ProductoDAL ProductoDAL = new ProductoDAL();

        public List<ProductoBO> ObtenerProductosHabilitados()
        {
            return ProductoDAL.ObtenerProductos(true);
        }

        public List<ProductoBO> ObtenerTodosProductos()
        {
            return ProductoDAL.ObtenerProductos();
        }

        public bool CrearProducto(ProductoBO Producto)
        {
            return ProductoDAL.CrearProducto(Producto);
        }

        public bool ActualizarProducto(ProductoBO Producto)
        {
            return ProductoDAL.ActualizarProducto(Producto);
        }

        public bool BorrarProducto(int ProductoId)
        {
            return ProductoDAL.ActivarDesactivarProducto(ProductoId, false);
        }

        public bool HabilitarProducto(int ProductoId)
        {
            return ProductoDAL.ActivarDesactivarProducto(ProductoId, true);
        }

        public int ObtenerSiguienteProductoId()
        {
            return ProductoDAL.ObtenerSiguienteProductoId();
        }
    }
}
