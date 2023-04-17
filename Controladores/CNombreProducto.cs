using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/nombreproducto")]
    public class CNombreProducto:Controller
    {

        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MNombreProducto>>> Get()
        {
            var funcion = new DNombreProducto();
            var lista = await funcion.MostrarNombreProductos();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MNombreProducto parametros)
        {
            var funcion = new DNombreProducto();
            await funcion.InsertarNombreProducto(parametros);
        }

        [HttpPut("{IdNombreProducto}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int IdNombreProducto, [FromBody] MNombreProducto parametros)
        {
            var funcion = new DNombreProducto();
            parametros.IdNombreProducto = IdNombreProducto;
            await funcion.EditarNombreProducto(parametros);
            return NoContent();
        }

        [HttpDelete("{IdNombreProducto}")]
        [Authorize(Roles = ("Administrador"))]
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
