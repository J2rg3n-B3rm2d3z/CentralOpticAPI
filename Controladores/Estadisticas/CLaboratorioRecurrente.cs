using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores.Estadisticas
{
    [ApiController]
    [Route("centralopticapi/estadistica/laboratoriorecurrente")]
    public class CLaboartorioRecurrente : Controller
    {
        [HttpPost("{MasMenos}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MEstLaboratorioRecurrente>>> Get(bool MasMenos, [FromBody] MEstadisticas parametros)
        {
            var funcion = new DEstadisticas();

            if (MasMenos)
            {
                    var lista = await funcion.EstLaboratoriosMasRecurrentes(parametros);
                    return lista;
            }
            else
            {
                    var lista = await funcion.EstLaboratoriosMenosRecurrentes(parametros);
                    return lista;
            }
        }
    }
}
