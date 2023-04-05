using CentralOpticAPI.Datos;
using CentralOpticAPI.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CentralOpticAPI.Controladores
{
    [ApiController]
    [Route("centralopticapi/acceso")]
    public class CAcceso : Controller
    {
        private readonly IConfiguration _config;
        public CAcceso(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarioActivo = ObtenerUsuarioActivo();
            return Ok(usuarioActivo);
        }


        [HttpPost]
        public async Task<IActionResult> Login(MAcceso mAcceso)
        {
            var funcion = new DUsuario();

            var lista = await funcion.MostrarUsuarios();

            var usuario = Autenticacion(mAcceso,lista);

            if (usuario != null)
            {
                //Crear el token

                var token = Generar(usuario);

                return Ok(token);
            }

            return NotFound("No existe usuario encontrado");
        }

        private MUsuario Autenticacion(MAcceso mAcceso, List<MUsuario> lista)
        {

            byte[] claveEncriptada = System.Text.Encoding.UTF8.GetBytes(mAcceso.Clave);
            mAcceso.Clave = Convert.ToBase64String(claveEncriptada);

            var currentUser = lista.FirstOrDefault(usuario => usuario.NombreUsuario == mAcceso.NombreUsuario
            && usuario.Clave == mAcceso.Clave);

            //var currentUser = ConstanteUsuario.usuarios.FirstOrDefault(usuario => usuario.NombreUsuario == mAcceso.NombreUsuario
            //&& usuario.Clave == mAcceso.Clave);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }

        private string Generar(MUsuario usuario)
        {
            var llavedeseguridad = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credenciales = new SigningCredentials(llavedeseguridad, SecurityAlgorithms.HmacSha256);

            //Crear las reclamaciones

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.NombreUsuario),
                new Claim(ClaimTypes.Email, usuario.Correo),
                new Claim(ClaimTypes.GivenName, usuario.Nombres),
                new Claim(ClaimTypes.Surname, usuario.Apellidos),
                new Claim(ClaimTypes.Role, usuario.Rol)
            };

            //Crear el token

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credenciales);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private MUsuario ObtenerUsuarioActivo()
        {
            var identidad = HttpContext.User.Identity as ClaimsIdentity;

            if (identidad != null)
            {
                var usuarioClaims = identidad.Claims;

                return new MUsuario
                {
                    NombreUsuario = usuarioClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Correo = usuarioClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    Nombres = usuarioClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    Apellidos = usuarioClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Rol = usuarioClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
                };
            }
            return null;
        }
    }
}

