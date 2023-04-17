using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/registrobodega")]
    public class CRegistro_Bodega : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MRegistro_Bodega>>> Get()
        {
            var funcion = new DRegistro_Bodega();
            var lista = await funcion.MostrarRegistro_Bodegas();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MRegistro_Bodega parametros)
        {
            var funcion = new DRegistro_Bodega();
            await funcion.InsertarRegistro_Bodega(parametros);
        }

        [HttpPut("{IdRegistro_Bodega}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int IdRegistro_Bodega, [FromBody] MRegistro_Bodega parametros)
        {
            var funcion = new DRegistro_Bodega();
            parametros.IdRegistro_Bodega = IdRegistro_Bodega;
            await funcion.EditarRegistro_Bodega(parametros);
            return NoContent();
        }

        [HttpDelete("{IdRegistro_Bodega}")]
        [Authorize(Roles = ("Administrador"))]
        public async Task<ActionResult> Delete(int IdRegistro_Bodega)
        {
            var funcion = new DRegistro_Bodega();
            var parametros = new MRegistro_Bodega();
            parametros.IdRegistro_Bodega = IdRegistro_Bodega;
            await funcion.EliminarRegistro_Bodega(parametros);
            return NoContent();

        }
    }
}
