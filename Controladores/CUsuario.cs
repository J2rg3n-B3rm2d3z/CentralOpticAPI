using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/usuario")]
    [Authorize(Roles = ("Super Administrador"))]
    public class CUsuario : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MUsuario>>> Get()
        {
            var funcion = new DUsuario();
            var lista = await funcion.MostrarUsuarios();
            foreach (var item in lista)
            {
                item.Clave = null;
            }
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MUsuario parametros)
        {
            var funcion = new DUsuario();
            byte[] claveEncriptada = System.Text.Encoding.UTF8.GetBytes(parametros.Clave);
            parametros.Clave = Convert.ToBase64String(claveEncriptada);

            await funcion.InsertarUsuario(parametros);
        }

        [HttpPut("{IdUsuario}")]
        public async Task<ActionResult> Put(int IdUsuario, [FromBody] MUsuario parametros)
        {
            var funcion = new DUsuario();
            parametros.IdUsuario = IdUsuario;
            byte[] claveEncriptada = System.Text.Encoding.UTF8.GetBytes(parametros.Clave);
            parametros.Clave = Convert.ToBase64String(claveEncriptada);
            await funcion.EditarUsuario(parametros);
            return NoContent();
        }

        [HttpDelete("{IdUsuario}")]
        public async Task<ActionResult> Delete(int IdUsuario)
        {
            var funcion = new DUsuario();
            var parametros = new MUsuario();
            parametros.IdUsuario = IdUsuario;
            await funcion.EliminarUsuario(parametros);
            return NoContent();
        }
    }
}
