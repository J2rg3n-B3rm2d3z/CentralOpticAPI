using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data;
using System.Data.SqlClient;

namespace CentralOpticAPI.Datos
{
    public class DExamenVistaFechaExamen
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MExamenVistaFechaExamen>> MostrarFechaObtencion()
        {
            var lista = new List<MExamenVistaFechaExamen>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarFechaExamen", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mExamenVistaFechaExamen = new MExamenVistaFechaExamen();
                            mExamenVistaFechaExamen.IdFechaExamen = (int)item["IdFechaExamen"];
                            mExamenVistaFechaExamen.FechaExamen = (DateTime)item["FechaExamen"];
                            lista.Add(mExamenVistaFechaExamen);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarFechaPago(MExamenVistaFechaExamen parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarFechaExamen", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaExamen", parametros.FechaExamen);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarFechaPago(MExamenVistaFechaExamen parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarFechaExamen", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdFechaExamen", parametros.IdFechaExamen);
                    cmd.Parameters.AddWithValue("@FechaExamen", parametros.FechaExamen);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarFechaPago(MExamenVistaFechaExamen parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_eliminarFechaExamen", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdFechaExamen", parametros.IdFechaExamen);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
