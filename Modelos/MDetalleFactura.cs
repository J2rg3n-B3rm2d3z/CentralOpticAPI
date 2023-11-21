namespace CentralOpticAPI.Modelos
{
    public class MDetalleFactura
    {
        public int NumFactura { get; set; }
        public string? Codigo_Producto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio_Unitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Monto { get; set; }

    }
}
