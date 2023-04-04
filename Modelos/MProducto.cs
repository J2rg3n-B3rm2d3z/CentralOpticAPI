namespace CentralOpticAPI.Modelos
{
    public class MProducto
    {
        public int CodProducto { get; set; }
        public int IdMarca { get; set; }
        public int IdNombreProducto{ get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioActual { get; set; }
        public bool EstadoProducto { get; set; }

    }
}
