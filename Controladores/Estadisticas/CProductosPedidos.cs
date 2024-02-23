using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores.Estadisticas
{
    [ApiController]
    [Route("centralopticapi/estadistica/productopedido")]
    public class CProductosPedidos : Controller
    {
        [HttpPost("{MasMenos}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Optometrista, Venta"))]
        public async Task<ActionResult<List<MEstProductoPedidos>>> Get(bool MasMenos, [FromBody] MEstadisticas parametros)
        {
            var funcion = new DEstadisticas();

            if (MasMenos)
            {
                    var lista = await funcion.EstProductosConMasPedidos(parametros);
                    return lista;
            }
            else
            {
                    var lista = await funcion.EstProductosConMenosPedidos(parametros);
                    return lista;
            }
        }
    }
}
