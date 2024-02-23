using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores.Estadisticas
{
    [ApiController]
    [Route("centralopticapi/estadistica/beneficios")]
    public class CIngresoVsGastos : Controller
    {
        [HttpPost]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MEstIngresosVsGastos>>> Get([FromBody] MEstadisticas parametros)
        {
            var funcion = new DEstadisticas();
            var lista = await funcion.EstSP_EstIngresosVsGastos(parametros);
            return lista;
        }
    }
}
