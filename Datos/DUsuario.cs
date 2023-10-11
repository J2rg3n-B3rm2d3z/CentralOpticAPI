using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;
using CentralOpticAPI.Controladores;

namespace CentralOpticAPI.Datos
{
    public class DUsuario
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MUsuario>> MostrarUsuarios()
        {
            var lista = new List<MUsuario>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarUsuarios", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var musuario = new MUsuario();
                            musuario.IdUsuario = (int)item["Numero_Usuario"];
                            musuario.NombreUsuario = (string)item["Nombre_Usuario"];
                            musuario.Clave = (string)item["Clave"];
                            musuario.Correo = (string)item["Correos"];
                            musuario.Rol = (string)item["Rol"];
                            musuario.Nombres = (string)item["Nombres"];
                            musuario.Apellidos = (string)item["Apellidos"];
                            musuario.Estado = (bool)item["Estado"];

                            //byte[] clave = Convert.FromBase64String(musuario.Clave);
                            //musuario.Clave = System.Text.Encoding.UTF8.GetString(clave);

                            lista.Add(musuario);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MUsuario>> MostrarUsuariosById(MUsuario parametros)
        {
            var lista = new List<MUsuario>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarUsuariosById", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Numero_Usuario", parametros.IdUsuario);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var musuario = new MUsuario();
                            musuario.IdUsuario = (int)item["Numero_Usuario"];
                            musuario.NombreUsuario = (string)item["Nombre_Usuario"];
                            musuario.Clave = (string)item["Clave"];
                            musuario.Correo = (string)item["Correos"];
                            musuario.Rol = (string)item["Rol"];
                            musuario.Nombres = (string)item["Nombres"];
                            musuario.Apellidos = (string)item["Apellidos"];
                            musuario.Estado = (bool)item["Estado"];

                            //byte[] clave = Convert.FromBase64String(musuario.Clave);
                            //musuario.Clave = System.Text.Encoding.UTF8.GetString(clave);

                            lista.Add(musuario);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarUsuario(MUsuarioIngreso parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                byte[] claveEncriptada = System.Text.Encoding.UTF8.GetBytes(parametros.Clave);
                parametros.Clave = Convert.ToBase64String(claveEncriptada);

                using (var cmd = new SqlCommand("SP_insertarUsuario", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre_Usuario", parametros.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Clave", parametros.Clave);
                    cmd.Parameters.AddWithValue("@Rol", parametros.Rol);
                    cmd.Parameters.AddWithValue("@Numero_Empleado", parametros.NumeroEmpleado);
                    cmd.Parameters.AddWithValue("@Estado", parametros.Estado);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
        public async Task EditarUsuario(MUsuarioIngreso parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarUsuario", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Numero_Usuario", parametros.IdUsuario);
                    cmd.Parameters.AddWithValue("@Nombre_Usuario", parametros.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Rol", parametros.Rol);
                    cmd.Parameters.AddWithValue("@Numero_Empleado", parametros.NumeroEmpleado);
                    cmd.Parameters.AddWithValue("@Estado", parametros.Estado);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EditarClaveUsuario(MUsuarioIngreso parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {

                byte[] claveEncriptada = System.Text.Encoding.UTF8.GetBytes(parametros.Clave);
                parametros.Clave = Convert.ToBase64String(claveEncriptada);

                    using (var cmd = new SqlCommand("SP_editarClaveUsuario", sql))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Numero_Usuario", parametros.IdUsuario);
                        cmd.Parameters.AddWithValue("@Clave", parametros.Clave);

                        await sql.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
            }
        }

        //public async Task EliminarUsuario(MUsuario parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarUsuario", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdUsuario", parametros.IdUsuario);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

    }
}
