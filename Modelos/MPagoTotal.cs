namespace CentralOpticAPI.Modelos
{
    public class MPagoTotal
    {
        public int Numero_Factura { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Cliente_Factura { get; set; }
        public string Estado_Factura { get; set; }
        public string Tipo_Factura { get; set; }
        public decimal Subtotal_Factura { get; set;}
        public decimal Total_Factura { get; set; }
        public decimal Total_Pagado { get; set; }
        public decimal Faltante { get; set; }
    }
}
