using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/factura")]
    public class CFactura :Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MFactura>>> Get()
        {
            var funcion = new DFactura();
            var lista = await funcion.MostrarFacturas();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MFactura parametros)
        {
            var funcion = new DFactura();
            await funcion.InsertarFactura(parametros);
        }

        [HttpPut("{NumFactura}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int NumFactura, [FromBody] MFactura parametros)
        {
            var funcion = new DFactura();
            parametros.NumFactura = NumFactura;
            await funcion.EditarFactura(parametros);
            return NoContent();
        }

        [HttpDelete("{NumFactura}")]
        [Authorize(Roles = ("Administrador"))]
        public async Task<ActionResult> Delete(int NumFactura)
        {
            var funcion = new DFactura();
            var parametros = new MFactura();
            parametros.NumFactura = NumFactura;
            await funcion.EliminarFactura(parametros);
            return NoContent();

        }
    }
}
