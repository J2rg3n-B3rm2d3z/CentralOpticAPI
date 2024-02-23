using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores.Estadisticas
{
    [ApiController]
    [Route("centralopticapi/estadistica/productovendidoportipo")]
    public class CProductosVendidosPorTipo : Controller
    {
        [HttpPost("{MasMenos}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MEstProductoVendidoPorTipo>>> Get(bool MasMenos, [FromBody] MEstadisticasIngresoProductoTipo parametros)
        {
            var funcion = new DEstadisticas();

            if (MasMenos)
            {
                    var lista = await funcion.EstProductosMasVendidosPorTipo(parametros);
                    return lista;
            }
            else
            {
                    var lista = await funcion.EstProductosMenosVendidosPorTipo(parametros);
                    return lista;
            }
        }
    }
}
