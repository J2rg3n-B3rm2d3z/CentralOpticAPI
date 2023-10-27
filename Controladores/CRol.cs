using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/rol")]
    public class CRol : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MRol>>> Get()
        {
            var funcion = new DRol();
            var lista = await funcion.MostrarRoles();
            return lista;
        }

        [HttpGet("{IdRol}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MRol>>> Get(int IdRol)
        {
            var funcion = new DRol();
            MRol rol = new MRol();
            rol.idRol = IdRol;
            var lista = await funcion.MostrarRolesById(rol);
            return lista;
        }
    }
}
