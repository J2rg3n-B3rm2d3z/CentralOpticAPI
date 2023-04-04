namespace CentralOpticAPI.Modelos
{
    public class MProveedor_Producto
    {
        public int IdProveedor_Producto { get; set; }
        public int IdProveedor { get; set; }
        public int CodProducto { get; set; }
        public int IdFechaObtencion { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }

    }
}
