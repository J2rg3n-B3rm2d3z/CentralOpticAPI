namespace CentralOpticAPI.Modelos
{
    public class MExamenVista
    {
        public int NumExamen { get; set; }
        public int CodCliente { get; set; }
        public int IdFechaExamen { get; set; }
        public decimal OjoIzquierdo { get; set; }
        public decimal OjoDerecho { get; set; }
        public string? DescripLenteIzq { get; set; }
        public string? DescripLenteDer { get; set; }

    }
}
