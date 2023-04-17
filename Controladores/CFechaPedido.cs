using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/fechapedido")]
    public class CFechaPedido : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MFechaPedido>>> Get()
        {
            var funcion = new DFechaPedido();
            var lista = await funcion.MostrarFechaPedidos();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MFechaPedido parametros)
        {
            var funcion = new DFechaPedido();
            await funcion.InsertarFechaPedido(parametros);
        }

        [HttpPut("{IdFechaPedido}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int IdFechaPedido, [FromBody] MFechaPedido parametros)
        {
            var funcion = new DFechaPedido();
            parametros.IdFechaPedido = IdFechaPedido;
            await funcion.EditarFechaPedido(parametros);
            return NoContent();
        }

        [HttpDelete("{IdFechaPedido}")]
        [Authorize(Roles = ("Administrador"))]
        public async Task<ActionResult> Delete(int IdFechaPedido)
        {
            var funcion = new DFechaPedido();
            var parametros = new MFechaPedido();
            parametros.IdFechaPedido = IdFechaPedido;
            await funcion.EliminarFechaPedido(parametros);
            return NoContent();

        }
    }
}
