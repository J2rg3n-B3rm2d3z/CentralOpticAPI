namespace CentralOpticAPI.Modelos
{
    public class MProducto
    {
        public string? CodProducto { get; set; }
        public string Descripcion { get; set; }
        public string TipoProducto { get; set; }
        public bool? Estado{ get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }
        public int? Cantidad { get; set; }
        public int? StockMinimo { get; set; }
        public int? StockMaximo { get; set; }

    }
}
