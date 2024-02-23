using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores.Estadisticas
{
    [ApiController]
    [Route("centralopticapi/estadistica/productovendido")]
    public class CProductosVendidos : Controller
    {
        [HttpPost("{MasMenos}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MEstProductoVendido>>> Get(bool MasMenos, [FromBody] MEstadisticas parametros)
        {
            var funcion = new DEstadisticas();

            if (MasMenos)
            {
                    var lista = await funcion.EstProductosMasVendidos(parametros);
                    return lista;
            }
            else
            {
                    var lista = await funcion.EstProductosMenosVendidos(parametros);
                    return lista;
            }
        }
    }
}
