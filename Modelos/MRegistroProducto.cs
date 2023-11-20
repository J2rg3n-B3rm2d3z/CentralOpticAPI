namespace CentralOpticAPI.Modelos
{
    public class MRegistroProducto
    {
        public string? CodigoProducto { get; set; }
        public string Descripcion { get; set; }
        public string NombreEmpresa { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public decimal Costo { get; set; }
        public int Cantidad { get; set; }
        public bool? Estado { get; set; }

    }
}
