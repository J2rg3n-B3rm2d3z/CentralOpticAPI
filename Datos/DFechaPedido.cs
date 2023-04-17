using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DFechaPedido
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MFechaPedido>> MostrarFechaPedidos()
        {
            var lista = new List<MFechaPedido>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarFechaPedidos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mfechapedido = new MFechaPedido();
                            mfechapedido.IdFechaPedido = (int)item["IdFechaPedido"];
                            mfechapedido.FechaPedido = (DateTime)item["FechaPedido"];
                            lista.Add(mfechapedido);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarFechaPedido(MFechaPedido parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarFechaPedido", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaPedido", parametros.FechaPedido);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarFechaPedido(MFechaPedido parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarFechaPedido", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdFechaPedido", parametros.IdFechaPedido);
                    cmd.Parameters.AddWithValue("@FechaPedido", parametros.FechaPedido);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarFechaPedido(MFechaPedido parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_eliminarFechaPedido", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdFechaPedido", parametros.IdFechaPedido);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
