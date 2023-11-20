namespace CentralOpticAPI.Modelos
{
    public class MProveedor
    {
        public int CodigoProveedor { get; set; }
        public string Nombre_Empresa { get; set; }
        public string? Contacto { get; set; }
        public string? Direccion { get; set; }
        public bool? Estado { get; set; }
        public string? Telefonos { get; set; }
        public string? Correos {  get; set; }
    }
}
