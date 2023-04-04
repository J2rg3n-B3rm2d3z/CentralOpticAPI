using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/nombreproducto")]
    public class CNombreProducto:Controller
    {

        [HttpGet]
        public async Task<ActionResult<List<MNombreProducto>>> Get()
        {
            var funcion = new DNombreProducto();
            var lista = await funcion.MostrarNombreProductos();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MNombreProducto parametros)
        {
            var funcion = new DNombreProducto();
            await funcion.InsertarNombreProducto(parametros);
        }

        [HttpPut("{IdNombreProducto}")]
        public async Task<ActionResult> Put(int IdNombreProducto, [FromBody] MNombreProducto parametros)
        {
            var funcion = new DNombreProducto();
            parametros.IdNombreProducto = IdNombreProducto;
            await funcion.EditarNombreProducto(parametros);
            return NoContent();
        }

        [HttpDelete("{IdNombreProducto}")]
        public async Task<ActionResult> Delete(int IdNombreProducto)
        {
            var funcion = new DNombreProducto();
            var parametros = new MNombreProducto();
            parametros.IdNombreProducto = IdNombreProducto;
            await funcion.EliminarNombreProducto(parametros);
            return NoContent();

        }
    }
}
