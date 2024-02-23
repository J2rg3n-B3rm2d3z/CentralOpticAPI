using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores.Estadisticas
{
    [ApiController]
    [Route("centralopticapi/estadistica/rolrecurrente")]
    public class CRolesRecurrentes : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MEstRolesFrecuentes>>> Get()
        {
            var funcion = new DEstadisticas();
            var lista = await funcion.EstRolesMasFrecuentes();
            return lista;
        }
    }
}
