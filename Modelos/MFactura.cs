namespace CentralOpticAPI.Modelos
{
    public class MFactura
    {
        public int NumFactura { get; set; }
        public DateTime Fecha_Emision { get; set; }
        public string Estado_Factura { get; set; }
        public string Tipo_Factura { get; set; }
        public bool TipoVenta { get; set; }
        public string Emisor { get; set; }
        public string Numero_Ruc { get; set; }
        public string Empresa_Asociada { get; set; }
        public string Cliente { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Descuento { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Total { get; set; }
        public decimal? Total_Pagado { get; set; }
        public decimal? Faltante { get; set; }
        public string? Descripcion_Credito { get; set; }


        public string? Paciente { get; set; }
        public string? Observacion { get; set; }
        public decimal? SPHIz { get; set; }
        public decimal? CYLIz { get; set; }
        public decimal? ADDIz { get; set; }
        public int? EJEIz { get; set; }
        public int? DPIz { get; set; }
        public int? ALTIz { get; set; }
        public decimal? SPHDe { get; set; }
        public decimal? CYLDe { get; set; }
        public decimal? ADDDe { get; set; }
        public int? EJEDe { get; set; }
        public int? DPDe { get; set; }
        public int? ALTDe { get; set; }

    }

    public class MFacturaIngreso
    {
        public int? NumFactura { get; set; }
        public string Estado_Factura { get; set; }
        public string? Tipo_Factura { get; set; }
        public int NumeroEmpleado { get; set; }
        public int Codigo_Cliente { get; set; }
        public int? NumExamen { get; set; }
        public bool TipoVenta { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Descuento { get; set; }
        public DateTime Fecha_Emision { get; set; }
        public string? Descripcion_Credito { get; set; }
    }
}
