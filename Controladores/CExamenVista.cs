using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/examenvista")]
    public class CExamenVista : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MExamenVista>>> Get()
        {
            var funcion = new DExamenVista();
            var lista = await funcion.MostrarExamenVista();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MExamenVista parametros)
        {
            var funcion = new DExamenVista();
            await funcion.InsertarExamenVista(parametros);
        }

        [HttpPut("{NumExamenVista}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int NumExamenVista, [FromBody] MExamenVista parametros)
        {
            var funcion = new DExamenVista();
            parametros.NumExamen = NumExamenVista;
            await funcion.EditarExamenVista(parametros);
            return NoContent();
        }

        [HttpDelete("{NumExamenVista}")]
        [Authorize(Roles = ("Administrador"))]
        public async Task<ActionResult> Delete(int NumExamenVista)
        {
            var funcion = new DExamenVista();
            var parametros = new MExamenVista();
            parametros.NumExamen = NumExamenVista;
            await funcion.EliminarExamenVista(parametros);
            return NoContent();

        }
    }
}
