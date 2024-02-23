using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{

    [ApiController]
    [Route("centralopticapi/proveedor")]
    public class CProveedor : Controller
    {
        [HttpGet]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task<ActionResult<List<MProveedor>>> Get()
        {
            var funcion = new DProveedor();
            var lista = await funcion.MostrarProveedor();
            return lista;
        }

        [HttpGet("{CodigoProveedor}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task<ActionResult<List<MProveedor>>> Get(string CodigoProveedor)
        {
            var funcion = new DProveedor();
            MProveedor proveedor = new MProveedor();

            if (int.TryParse(CodigoProveedor, out int CodigoProveedorInt))
            {
                proveedor.CodigoProveedor = CodigoProveedorInt;
                var lista = await funcion.MostrarProveedorById(proveedor);
                
                return lista;
            }
            else
            {
                if (bool.TryParse(CodigoProveedor, out bool CodigoProveedorBool))
                {
                    proveedor.Estado = CodigoProveedorBool;
                    var lista = await funcion.MostrarProveedorActivos(proveedor);

                    return lista;
                }
                else
                {
                    return BadRequest("El formato de peticion no es válido.");
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task Post([FromBody] MProveedor parametros)
        {
            var funcion = new DProveedor();
            await funcion.InsertarProveedor(parametros);
        }

        [HttpPut("{CodigoProveedor}")]
        [Authorize(Roles = ("Super Administrador, Administrador, Venta"))]
        public async Task<ActionResult> Put(int CodigoProveedor, [FromBody] MProveedor parametros)
        {
            var funcion = new DProveedor();
            parametros.CodigoProveedor = CodigoProveedor;
            await funcion.EditarProveedor(parametros);
            return NoContent();
        }

        //[HttpDelete("{IdProveedor}")]
        //[Authorize(Roles = ("Administrador"))]
        //public async Task<ActionResult> Delete(int IdProveedor)
        //{
        //    var funcion = new DProveedor();
        //    var parametros = new MProveedor();
        //    parametros.IdProveedor = IdProveedor;
        //    await funcion.EliminarProveedor(parametros);
        //    return NoContent();

        //}
    }
}
