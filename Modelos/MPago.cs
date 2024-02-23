namespace CentralOpticAPI.Modelos
{
    public class MPago
    {
        public int? Id_Pago { get; set; }
        public bool? Estado { get; set;}
        public int Numero_Factura { get; set;}
        public string? Estado_Factura { get; set;}
        public string? Tipo_Factura { get; set;}
        public string? Cliente_Factura { get; set;}
        public string? Tipo_Pago { get; set;}
        public decimal? Abono { get; set;}
        public DateTime? Fecha_Pago { get; set;}
        public string? Descripcion { get; set;}
    }
}
