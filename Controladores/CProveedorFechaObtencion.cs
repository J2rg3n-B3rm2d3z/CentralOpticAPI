using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/fechaobtencion")]
    [Authorize(Roles = ("Administrador"))]
    public class CProveedorFechaObtencion : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MProveedorFechaObtencion>>> Get()
        {
            var funcion = new DProveedorFechaObtencion();
            var lista = await funcion.MostrarFechaObtencion();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MProveedorFechaObtencion parametros)
        {
            var funcion = new DProveedorFechaObtencion();
            await funcion.InsertarFechaObtencion(parametros);
        }

        [HttpPut("{IdFechaObtencion}")]
        public async Task<ActionResult> Put(int IdFechaObtencion, [FromBody] MProveedorFechaObtencion parametros)
        {
            var funcion = new DProveedorFechaObtencion();
            parametros.IdFechaObtencion = IdFechaObtencion;
            await funcion.EditarFechaObtencion(parametros);
            return NoContent();
        }

        [HttpDelete("{IdFechaObtencion}")]
        public async Task<ActionResult> Delete(int IdFechaObtencion)
        {
            var funcion = new DProveedorFechaObtencion();
            var parametros = new MProveedorFechaObtencion();
            parametros.IdFechaObtencion = IdFechaObtencion;
            await funcion.EliminarFechaObtencion(parametros);
            return NoContent();

        }
    }
}
