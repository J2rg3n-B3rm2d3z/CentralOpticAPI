namespace CentralOpticAPI.Modelos
{
    public class MEmpleado
    {
        public int? NumEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }  
        public string Direccion { get; set;}
        public DateTime FechaNac { get; set; }
        public int? Edad { get; set; }
        public string? Telefonos { get; set; }
        public string? Correos { get; set; }
        public bool? Estado {  get; set; }
    }
}
