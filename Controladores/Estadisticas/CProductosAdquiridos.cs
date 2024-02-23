using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores.Estadisticas
{
    [ApiController]
    [Route("centralopticapi/estadistica/productoadquirido")]
    public class CProductosAdquiridos : Controller
    {
        [HttpPost("{MasMenos}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MEstProductoAdquirido>>> Get(bool MasMenos, [FromBody] MEstadisticas parametros)
        {
            var funcion = new DEstadisticas();

            if (MasMenos)
            {
                    var lista = await funcion.EstProductosMasAdquiridos(parametros);
                    return lista;
            }
            else
            {
                    var lista = await funcion.EstProductosMenosAdquiridos(parametros);
                    return lista;
            }
        }
    }
}
