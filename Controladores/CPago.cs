using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/pago")]
    public class CPago : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MPago>>> Get()
        {
            var funcion = new DPago();
            var lista = await funcion.MostrarPago();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MPago parametros)
        {
            var funcion = new DPago();
            await funcion.InsertarPago(parametros);
        }

        [HttpPut("{IdPago}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int IdPago, [FromBody] MPago parametros)
        {
            var funcion = new DPago();
            parametros.IdPago = IdPago;
            await funcion.EditarPago(parametros);
            return NoContent();
        }

        [HttpDelete("{IdPago}")]
        [Authorize(Roles = ("Administrador"))]
        public async Task<ActionResult> Delete(int IdPago)
        {
            var funcion = new DPago();
            var parametros = new MPago();
            parametros.IdPago = IdPago;
            await funcion.EliminarPago(parametros);
            return NoContent();

        }
    }
}
