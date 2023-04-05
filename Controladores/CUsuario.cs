using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/usuario")]
    [Authorize(Roles = ("Administrador"))]
    public class CUsuario : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<MUsuario>>> Get()
        {
            var funcion = new DUsuario();
            var lista = await funcion.MostrarUsuarios();
            return lista;
        }

        //[HttpPost]
        //public async Task Post([FromBody] MUsuario parametros)
        //{
        //    var funcion = new DUsuario();
        //    byte[] claveEncriptada = System.Text.Encoding.UTF8.GetBytes(parametros.Clave);
        //    parametros.Clave = Convert.ToBase64String(claveEncriptada);

        //    await funcion.InsertarUsuario(parametros);
        //}


    }
}
