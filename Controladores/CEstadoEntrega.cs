using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/estadoentrega")]
    public class CEstadoEntrega:Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MEstadoEntrega>>> Get()
        {
            var funcion = new DEstadoEntrega();
            var lista = await funcion.MostrarEstadoEntregas();
            return lista;
        }
    }
}
