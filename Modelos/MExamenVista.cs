namespace CentralOpticAPI.Modelos
{
    public class MExamenVista
    {
        public int NumExamen { get; set; }
        public bool Estado { get; set; }
        public string Empleado { get; set; }
        public string Paciente { get; set; }
        public DateTime Fecha_Realizacion { get; set; }
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

    public class MExamenVistaIngreso
    {
        public int NumExamen { get; set; }
        public bool Estado { get; set; }
        public int NumEmpleado { get; set; }
        public int Codigo_Cliente { get; set; }
        public DateTime Fecha_Realizacion { get; set; }
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

}
