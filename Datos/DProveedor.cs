using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;
using CentralOpticAPI.Controladores;

namespace CentralOpticAPI.Datos
{
    public class DProveedor
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MProveedor>> MostrarProveedor()
        {
            var lista = new List<MProveedor>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarProveedor", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mProveedor = new MProveedor();
                            mProveedor.IdProveedor = (int)item["IdProveedor"];
                            mProveedor.Nombre = (string)item["Nombre"];
                            mProveedor.Direccion = (string)item["Direccion"];
                            if (!item.IsDBNull(item.GetOrdinal("Propietario")))
                                mProveedor.Propietario = (string)item["Propietario"];
                            lista.Add(mProveedor);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarProveedor(MProveedor parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
                    cmd.Parameters.AddWithValue("@Propietario", SqlDbType.NVarChar).Value = (object)parametros.Propietario ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@Direccion", parametros.Direccion);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarProveedor(MProveedor parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdProveedor", parametros.IdProveedor);
                    cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
                    cmd.Parameters.AddWithValue("@Propietario", SqlDbType.NVarChar).Value = (object)parametros.Propietario ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@Direccion", parametros.Direccion);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarProveedor(MProveedor parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdProveedor", parametros.IdProveedor);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

    }
}

