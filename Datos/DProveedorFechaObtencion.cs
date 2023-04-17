using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DProveedorFechaObtencion
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MProveedorFechaObtencion>> MostrarFechaObtencion()
        {
            var lista = new List<MProveedorFechaObtencion>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarFechaObtencion", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mProveedorFechaObtencion = new MProveedorFechaObtencion();
                            mProveedorFechaObtencion.IdFechaObtencion = (int)item["IdFechaObtencion"];
                            mProveedorFechaObtencion.FechaObtencion = (DateTime)item["FechaObtencion"];
                            lista.Add(mProveedorFechaObtencion);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarFechaObtencion(MProveedorFechaObtencion parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarFechaObtencion", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaObtencion", parametros.FechaObtencion);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarFechaObtencion(MProveedorFechaObtencion parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarFechaObtencion", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdFechaObtencion", parametros.IdFechaObtencion);
                    cmd.Parameters.AddWithValue("@FechaObtencion", parametros.FechaObtencion);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarFechaObtencion(MProveedorFechaObtencion parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_eliminarFechaObtencion", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdFechaObtencion", parametros.IdFechaObtencion);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
