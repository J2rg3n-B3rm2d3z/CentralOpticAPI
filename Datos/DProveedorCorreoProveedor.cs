using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DProveedorCorreoProveedor
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MProveedorCorreoProveedor>> MostrarCorreoProveedor()
        {
            var lista = new List<MProveedorCorreoProveedor>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarCorreoProveedor", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mProveedorCorreoProveedor = new MProveedorCorreoProveedor();
                            mProveedorCorreoProveedor.IdCorreoProveedor = (int)item["IdCorreoProveedor"];
                            mProveedorCorreoProveedor.IdProveedor = (int)item["IdProveedor"];
                            mProveedorCorreoProveedor.Correo = (string)item["Correo"];
                            lista.Add(mProveedorCorreoProveedor);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarCorreoProveedor(MProveedorCorreoProveedor parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarCorreoProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCorreoProveedor", parametros.IdCorreoProveedor);
                    cmd.Parameters.AddWithValue("@Numempleado", parametros.IdProveedor);
                    cmd.Parameters.AddWithValue("@Correo", parametros.Correo);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarCorreoProveedor(MProveedorCorreoProveedor parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarCorreoProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdCorreoProveedor", parametros.IdCorreoProveedor);
                    cmd.Parameters.AddWithValue("@Propietario", parametros.IdProveedor);
                    cmd.Parameters.AddWithValue("@Direccion", parametros.Correo);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarCorreoProveedor(MProveedorCorreoProveedor parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarCorreoProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdCorreoProveedor", parametros.IdCorreoProveedor);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
