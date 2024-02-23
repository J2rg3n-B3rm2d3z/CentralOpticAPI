namespace CentralOpticAPI.Modelos
{
    public class MOrdenLente
    {
        public int Numero_Orden { get; set; }
        public DateTime Fecha_Emision { get; set; }
        public string? Empleado_Emisor { get; set; }
        public int Numero_Examen { get; set; }
        public DateTime Fecha_Examen { get; set; }
        public string? Paciente { get; set; }
        public string? Observacion { get; set; }
        public string? Laboratorio { get; set; }
        public string? Codigo_Producto { get; set; }
        public string? Descripcion_Producto { get; set; }
        public string Estado_OrdenLente { get; set; }
        public decimal Costo { get; set; }
    }

    public class MOrdenLenteIngreso
    {
        public int Numero_Empleado { get; set; }
        public int Numero_Examen { get; set; }
        public string Laboratorio { get; set; }
        public string Descripcion_Producto { get; set; }
        public decimal Costo { get; set; }
        public DateTime Fecha_Emision { get; set; }
    }

}
