using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/producto")]
    [Authorize(Roles = ("Administrador"))]
    public class CProducto:Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MProducto>>> Get()
        {
            var funcion = new DProducto();
            var lista = await funcion.MostrarProductos();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MProducto parametros)
        {
            var funcion = new DProducto();
            await funcion.InsertarProducto(parametros);
        }

        [HttpPut("{CodProducto}")]
        public async Task<ActionResult> Put(int CodProducto, [FromBody] MProducto parametros)
        {
            var funcion = new DProducto();
            parametros.CodProducto = CodProducto;
            await funcion.EditarProducto(parametros);
            return NoContent();
        }

        [HttpDelete("{CodProducto}")]
        public async Task<ActionResult> Delete(int CodProducto)
        {
            var funcion = new DProducto();
            var parametros = new MProducto();
            parametros.CodProducto = CodProducto;
            await funcion.EliminarProducto(parametros);
            return NoContent();

        }
    }
}
