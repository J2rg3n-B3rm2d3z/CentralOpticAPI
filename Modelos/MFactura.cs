namespace CentralOpticAPI.Modelos
{
    public class MFactura
    {
        public int NumFactura { get; set; }
        public int IdEstadoFactura { get; set; }
        public int IdFechaFactura { get; set; }
        public int NumEmpleado { get; set; }
        public int CodCliente { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Descuento { get; set;}
    }
}
