using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/proveedorproducto")]
    public class CProveedor_Producto : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult<List<MProveedor_Producto>>> Get()
        {
            var funcion = new DProveedor_Producto();
            var lista = await funcion.MostrarProveedor_Productos();
            return lista;
        }

        [HttpPost]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task Post([FromBody] MProveedor_Producto parametros)
        {
            var funcion = new DProveedor_Producto();
            await funcion.InsertarProveedor_Producto(parametros);
        }

        [HttpPut("{IdProveedor_Producto}")]
        [Authorize(Roles = ("Administrador, Empleado"))]
        public async Task<ActionResult> Put(int IdProveedor_Producto, [FromBody] MProveedor_Producto parametros)
        {
            var funcion = new DProveedor_Producto();
            parametros.IdProveedor_Producto = IdProveedor_Producto;
            await funcion.EditarProveedor_Producto(parametros);
            return NoContent();
        }

        [HttpDelete("{IdProveedor_Producto}")]
        [Authorize(Roles = ("Administrador"))]
        public async Task<ActionResult> Delete(int IdProveedor_Producto)
        {
            var funcion = new DProveedor_Producto();
            var parametros = new MProveedor_Producto();
            parametros.IdProveedor_Producto = IdProveedor_Producto;
            await funcion.EliminarProveedor_Producto(parametros);
            return NoContent();
        }
    }
}
