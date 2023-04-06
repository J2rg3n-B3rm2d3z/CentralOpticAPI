using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DProveedorTelefonoProveedor
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MProveedorTelefonoProveedor>> MostrarTelefonoProveedor()
        {
            var lista = new List<MProveedorTelefonoProveedor>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarTelefonoProveedor", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mProveedorTelefonoProveedor = new MProveedorTelefonoProveedor();
                            mProveedorTelefonoProveedor.IdTelefonoProveedor = (int)item["IdTelefonoProveedor"];
                            mProveedorTelefonoProveedor.IdProveedor = (int)item["IdProveedor"];
                            mProveedorTelefonoProveedor.Telefono = (string)item["Telefono"];
                            lista.Add(mProveedorTelefonoProveedor);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarTelefonoProveedor(MProveedorTelefonoProveedor parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarTelefonoProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdTelefonoProveedor", parametros.IdTelefonoProveedor);
                    cmd.Parameters.AddWithValue("@Numempleado", parametros.IdProveedor);
                    cmd.Parameters.AddWithValue("@Telefono", parametros.Telefono);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarTelefonoProveedor(MProveedorTelefonoProveedor parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarTelefonoProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdTelefonoProveedor", parametros.IdTelefonoProveedor);
                    cmd.Parameters.AddWithValue("@Propietario", parametros.IdProveedor);
                    cmd.Parameters.AddWithValue("@Direccion", parametros.Telefono);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarTelefonoProveedor(MProveedorTelefonoProveedor parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarTelefonoProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdTelefonoProveedor", parametros.IdTelefonoProveedor);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
