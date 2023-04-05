using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/ordenpedidoentrega")]
    [Authorize(Roles = ("Administrador"))]
    public class COrdenPedido_Entrega : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MOrdenPedido_Entrega>>> Get()
        {
            var funcion = new DOrdenPedido_Entrega();
            var lista = await funcion.MostrarOrdenPedido_Entregas();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MOrdenPedido_Entrega parametros)
        {
            var funcion = new DOrdenPedido_Entrega();
            await funcion.InsertarOrdenPedido_Entrega(parametros);
        }

        [HttpPut("{IdOrdenPedido_Entrega}")]
        public async Task<ActionResult> Put(int IdOrdenPedido_Entrega, [FromBody] MOrdenPedido_Entrega parametros)
        {
            var funcion = new DOrdenPedido_Entrega();
            parametros.IdOrdenPedido_Entrega = IdOrdenPedido_Entrega;
            await funcion.EditarOrdenPedido_Entrega(parametros);
            return NoContent();
        }

        [HttpDelete("{IdOrdenPedido_Entrega}")]
        public async Task<ActionResult> Delete(int IdOrdenPedido_Entrega)
        {
            var funcion = new DOrdenPedido_Entrega();
            var parametros = new MOrdenPedido_Entrega();
            parametros.IdOrdenPedido_Entrega = IdOrdenPedido_Entrega;
            await funcion.EliminarOrdenPedido_Entrega(parametros);
            return NoContent();
        }
    }
}
