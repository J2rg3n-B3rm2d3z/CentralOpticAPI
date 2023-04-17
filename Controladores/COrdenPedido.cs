using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/ordenpedido")]
    public class COrdenPedido : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MOrdenPedido>>> Get()
        {
            var funcion = new DOrdenPedido();
            var lista = await funcion.MostrarOrdenPedidos();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MOrdenPedido parametros)
        {
            var funcion = new DOrdenPedido();
            await funcion.InsertarOrdenPedido(parametros);
        }

        [HttpPut("{NumOrden}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int NumOrden, [FromBody] MOrdenPedido parametros)
        {
            var funcion = new DOrdenPedido();
            parametros.NumOrden = NumOrden;
            await funcion.EditarOrdenPedido(parametros);
            return NoContent();
        }

        [HttpDelete("{NumOrden}")]
        [Authorize(Roles = ("Administrador"))]
        public async Task<ActionResult> Delete(int NumOrden)
        {
            var funcion = new DOrdenPedido();
            var parametros = new MOrdenPedido();
            parametros.NumOrden = NumOrden;
            await funcion.EliminarOrdenPedido(parametros);
            return NoContent();

        }
    }
}
