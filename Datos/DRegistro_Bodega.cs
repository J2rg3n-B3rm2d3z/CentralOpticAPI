using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DRegistro_Bodega
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MRegistro_Bodega>> MostrarRegistro_Bodegas()
        {
            var lista = new List<MRegistro_Bodega>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarRegistro_Bodegas", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mregistro_bodega = new MRegistro_Bodega();
                            mregistro_bodega.IdRegistro_Bodega = (int)item["IdRegistro_Bodega"];
                            mregistro_bodega.IdBodega = (int)item["IdBodega"];
                            mregistro_bodega.CodProducto = (int)item["CodProducto"];
                            mregistro_bodega.Cantidad = (int)item["Cantidad"];
                            lista.Add(mregistro_bodega);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarRegistro_Bodega(MRegistro_Bodega parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarRegistro_Bodega", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdBodega", parametros.IdBodega);
                    cmd.Parameters.AddWithValue("@CodProducto", parametros.CodProducto);
                    cmd.Parameters.AddWithValue("@Cantidad", parametros.Cantidad);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarRegistro_Bodega(MRegistro_Bodega parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarRegistro_Bodega", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdRegistro_Bodega", parametros.IdRegistro_Bodega);
                    cmd.Parameters.AddWithValue("@IdBodega", parametros.IdBodega);
                    cmd.Parameters.AddWithValue("@CodProducto", parametros.CodProducto);
                    cmd.Parameters.AddWithValue("@Cantidad", parametros.Cantidad);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarRegistro_Bodega(MRegistro_Bodega parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_eliminarRegistro_Bodega", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdRegistro_Bodega", parametros.IdRegistro_Bodega);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
