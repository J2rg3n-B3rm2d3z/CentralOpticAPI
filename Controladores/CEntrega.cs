using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/entrega")]
    public class CEntrega : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MEntrega>>> Get()
        {
            var funcion = new DEntrega();
            var lista = await funcion.MostrarEntregas();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MEntrega parametros)
        {
            var funcion = new DEntrega();
            await funcion.InsertarEntrega(parametros);
        }

        [HttpPut("{CodEntrega}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int CodEntrega, [FromBody] MEntrega parametros)
        {
            var funcion = new DEntrega();
            parametros.CodEntrega = CodEntrega;
            await funcion.EditarEntrega(parametros);
            return NoContent();
        }

        [HttpDelete("{CodEntrega}")]
        [Authorize(Roles = ("Administrador"))]
        public async Task<ActionResult> Delete(int CodEntrega)
        {
            var funcion = new DEntrega();
            var parametros = new MEntrega();
            parametros.CodEntrega = CodEntrega;
            await funcion.EliminarEntrega(parametros);
            return NoContent();
        }
    }
}
