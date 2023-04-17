using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/marca")]
    public class CMarca : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MMarca>>> Get()
        {
            var funcion = new DMarca();
            var lista = await funcion.MostrarMarcas();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MMarca parametros)
        {
            var funcion = new DMarca();
            await funcion.InsertarMarca(parametros);
        }

        [HttpPut("{IdMarca}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int IdMarca, [FromBody] MMarca parametros)
        {
            var funcion = new DMarca();
            parametros.IdMarca = IdMarca;
            await funcion.EditarMarca(parametros);
            return NoContent();
        }

        [HttpDelete("{IdMarca}")]
        [Authorize(Roles = ("Administrador"))]
        public async Task<ActionResult> Delete(int IdMarca)
        {
            var funcion = new DMarca();
            var parametros = new MMarca();
            parametros.IdMarca = IdMarca;
            await funcion.EliminarMarca(parametros);
            return NoContent();

        }
    }
}
