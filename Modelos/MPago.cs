namespace CentralOpticAPI.Modelos
{
    public class MPago
    {
        public int IdPago { get; set; }
        public int NumFactura { get; set;}
        public int IdFechaPago { get; set;}
        public decimal Monto { get; set;}
        public bool TipoPago { get; set;}
    }
}
