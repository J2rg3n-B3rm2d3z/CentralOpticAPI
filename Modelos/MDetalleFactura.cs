namespace CentralOpticAPI.Modelos
{
    public class MDetalleFactura
    {
        public int IdDetalleFactura { get; set; }
        public int NumFactura { get; set; }
        public int CodProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUni { get; set; }

    }
}
