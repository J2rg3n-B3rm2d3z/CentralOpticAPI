using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;
using CentralOpticAPI.Controladores;

namespace CentralOpticAPI.Datos
{
    public class DEntrega
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MEntrega>> MostrarEntregas()
        {
            var lista = new List<MEntrega>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarEntregas", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mentrega = new MEntrega();
                            mentrega.CodEntrega = (int)item["CodEntrega"];
                            mentrega.IdEstadoEntrega = (int)item["IdEstadoEntrega"];
                            mentrega.FechaEntrega = (DateTime)item["FechaEntrega"];
                            if (!item.IsDBNull(item.GetOrdinal("Descripcion")))
                                mentrega.Descripcion = (string)item["Descripcion"];
                            lista.Add(mentrega);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarEntrega(MEntrega parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarEntrega", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdEstadoEntrega", parametros.IdEstadoEntrega);
                    cmd.Parameters.AddWithValue("@FechaEntrega", parametros.FechaEntrega);
                    cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.NVarChar).Value = (object)parametros.Descripcion ?? DBNull.Value;

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarEntrega(MEntrega parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarEntrega", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CodEntrega", parametros.CodEntrega);
                    cmd.Parameters.AddWithValue("@IdEstadoEntrega", parametros.IdEstadoEntrega);
                    cmd.Parameters.AddWithValue("@FechaEntrega", parametros.FechaEntrega);
                    cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.NVarChar).Value = (object)parametros.Descripcion ?? DBNull.Value;

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarEntrega(MEntrega parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarEntrega", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CodEntrega", parametros.CodEntrega);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

    }
}
