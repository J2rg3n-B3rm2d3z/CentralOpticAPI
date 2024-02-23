﻿namespace CentralOpticAPI.Modelos
{
    public class MUsuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string? Clave { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }
        public int Numero_Empleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public bool Estado { get; set; }
    }

    public class MUsuarioIngreso
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public int NumeroEmpleado { get; set; }
        public string? Clave { get; set; }
        public string Rol { get; set; }
        public bool Estado { get; set; }
    }
}
