using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/fechafactura")]
    public class CFechaFactura : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MFechaFactura>>> Get()
        {
            var funcion = new DFechaFactura();
            var lista = await funcion.MostrarFechaFacturas();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MFechaFactura parametros)
        {
            var funcion = new DFechaFactura();
            await funcion.InsertarFechaFactura(parametros);
        }

        [HttpPut("{IdFechaFactura}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int IdFechaFactura, [FromBody] MFechaFactura parametros)
        {
            var funcion = new DFechaFactura();
            parametros.IdFechaFactura = IdFechaFactura;
            await funcion.EditarFechaFactura(parametros);
            return NoContent();
        }

        [HttpDelete("{IdFechaFactura}")]
        [Authorize(Roles = ("Administrador"))]
        public async Task<ActionResult> Delete(int IdFechaFactura)
        {
            var funcion = new DFechaFactura();
            var parametros = new MFechaFactura();
            parametros.IdFechaFactura = IdFechaFactura;
            await funcion.EliminarFechaFactura(parametros);
            return NoContent();

        }
    }
}
