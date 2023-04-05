using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/estadofactura")]
    [Authorize(Roles = ("Administrador"))]
    public class CEstadoFactura : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MEstadoFactura>>> Get()
        {
            var funcion = new DEstadoFactura();
            var lista = await funcion.MostrarEstadoFacturas();
            return lista;
        }
    }
}
