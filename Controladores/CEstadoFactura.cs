using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/estadofactura")]
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
