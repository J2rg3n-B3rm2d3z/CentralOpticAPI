namespace CentralOpticAPI.Modelos
{
    public class MEntregaLente
    {
        public int Codigo_Entrega { get; set; }
        public DateTime Fecha_Obtencion { get; set;}
        public int Numero_Orden { get; set; }
        public DateTime Fecha_Emision_Orden { get; set; }
        public int Numero_Examen { get; set; }
        public string? Paciente { get; set; }
        public string? Laboratorio { get; set; }
        public string? Codigo_Producto { get; set; }
        public string? Descripcion_Producto { get; set; }
        public bool Estado { get; set; }
        public string? Observacion_Entrega { get; set; }
        
    }
}
