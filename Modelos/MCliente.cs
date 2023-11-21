namespace CentralOpticAPI.Modelos
{
    public class MCliente
    {
        public int? Codigo_Cliente { get; set; }
        public string Empresa_Asociada { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string? Cedula { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaNac { get; set; }
        public int? Edad { get; set; }
        public string? Telefonos { get; set; }
        public string? Correos { get; set; }

    }
}
