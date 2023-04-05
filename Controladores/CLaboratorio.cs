using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/laboratorio")]
    [Authorize(Roles = ("Administrador"))]
    public class CLaboratorio:Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MLaboratorio>>> Get()
        {
            var funcion = new DLaboratorio();
            var lista = await funcion.MostrarLaboratorios();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MLaboratorio parametros)
        {
            var funcion = new DLaboratorio();
            await funcion.InsertarLaboratorio(parametros);
        }

        [HttpPut("{IdLaboratorio}")]
        public async Task<ActionResult> Put(int IdLaboratorio, [FromBody] MLaboratorio parametros)
        {
            var funcion = new DLaboratorio();
            parametros.IdLaboratorio = IdLaboratorio;
            await funcion.EditarLaboratorio(parametros);
            return NoContent();
        }

        [HttpDelete("{IdLaboratorio}")]
        public async Task<ActionResult> Delete(int IdLaboratorio)
        {
            var funcion = new DLaboratorio();
            var parametros = new MLaboratorio();
            parametros.IdLaboratorio = IdLaboratorio;
            await funcion.EliminarLaboratorio(parametros);
            return NoContent();
        }
    }
}
