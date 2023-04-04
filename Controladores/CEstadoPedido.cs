using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/estadopedido")]
    public class CEstadoPedido:Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MEstadoPedido>>> Get()
        {
            var funcion = new DEstadoPedido();
            var lista = await funcion.MostrarEstadoPedido();
            return lista;
        }
    }
}
