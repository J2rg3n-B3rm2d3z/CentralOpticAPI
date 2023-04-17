using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DOrdenPedido_Entrega
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MOrdenPedido_Entrega>> MostrarOrdenPedido_Entregas()
        {
            var lista = new List<MOrdenPedido_Entrega>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarOrdenPedido_Entregas", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mordenpedido_entrega = new MOrdenPedido_Entrega();
                            mordenpedido_entrega.IdOrdenPedido_Entrega = (int)item["IdOrdenPedido_Entrega"];
                            mordenpedido_entrega.NumOrden = (int)item["NumOrden"];
                            mordenpedido_entrega.CodEntrega = (int)item["CodEntrega"];

                            lista.Add(mordenpedido_entrega);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarOrdenPedido_Entrega(MOrdenPedido_Entrega parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarOrdenPedido_Entrega", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NumOrden", parametros.NumOrden);
                    cmd.Parameters.AddWithValue("@CodEntrega", parametros.CodEntrega);
                    
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarOrdenPedido_Entrega(MOrdenPedido_Entrega parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarOrdenPedido_Entrega", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdOrdenPedido_Entrega", parametros.IdOrdenPedido_Entrega);
                    cmd.Parameters.AddWithValue("@NumOrden", parametros.NumOrden);
                    cmd.Parameters.AddWithValue("@CodEntrega", parametros.CodEntrega);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarOrdenPedido_Entrega(MOrdenPedido_Entrega parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_eliminarOrdenPedido_Entrega", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdOrdenPedido_Entrega", parametros.IdOrdenPedido_Entrega);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
