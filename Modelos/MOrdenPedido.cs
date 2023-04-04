namespace CentralOpticAPI.Modelos
{
    public class MOrdenPedido
    {
        public int NumOrden { get; set; }
        public int NumExamen { get; set; }
        public int NumEmpleado { get; set; }
        public int IdLaboratorio { get; set; }
        public int CodProducto { get; set; }
        public int IdEstadoPedido { get; set; }
        public int IdFechaPedido { get; set; }
        public decimal Costo { get; set; }
        public string? Descripcion { get; set; }
    }
}
