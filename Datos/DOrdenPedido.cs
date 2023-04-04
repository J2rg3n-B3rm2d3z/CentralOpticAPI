using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DOrdenPedido
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MOrdenPedido>> MostrarOrdenPedidos()
        {
            var lista = new List<MOrdenPedido>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarOrdenPedidos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mordenpedido = new MOrdenPedido();
                            mordenpedido.NumOrden = (int)item["NumOrden"];
                            mordenpedido.NumExamen = (int)item["NumExamen"];
                            mordenpedido.NumEmpleado = (int)item["NumEmpleado"];
                            mordenpedido.IdLaboratorio = (int)item["IdLaboratorio"];
                            mordenpedido.CodProducto = (int)item["CodProducto"];
                            mordenpedido.IdEstadoPedido = (int)item["IdEstadoPedido"];
                            mordenpedido.IdFechaPedido = (int)item["IdFechaPedido"];
                            mordenpedido.Costo = (decimal)item["Costo"];
                            if (!item.IsDBNull(item.GetOrdinal("Descripcion")))
                                mordenpedido.Descripcion = (string)item["Descripcion"];
                            lista.Add(mordenpedido);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarOrdenPedido(MOrdenPedido parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarOrdenPedido", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NumExamen", parametros.NumExamen);
                    cmd.Parameters.AddWithValue("@NumEmpleado", parametros.NumEmpleado);
                    cmd.Parameters.AddWithValue("@IdLaboratorio", parametros.IdLaboratorio);
                    cmd.Parameters.AddWithValue("@CodProducto", parametros.CodProducto);
                    cmd.Parameters.AddWithValue("@IdEstadoPedido", parametros.IdEstadoPedido);
                    cmd.Parameters.AddWithValue("@IdFechaPedido", parametros.IdFechaPedido);
                    cmd.Parameters.AddWithValue("@Costo", parametros.Costo);
                    cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.NVarChar).Value = (object)parametros.Descripcion ?? DBNull.Value;

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarOrdenPedido(MOrdenPedido parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarOrdenPedido", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NumOrden", parametros.NumOrden);
                    cmd.Parameters.AddWithValue("@NumExamen", parametros.NumExamen);
                    cmd.Parameters.AddWithValue("@NumEmpleado", parametros.NumEmpleado);
                    cmd.Parameters.AddWithValue("@IdLaboratorio", parametros.IdLaboratorio);
                    cmd.Parameters.AddWithValue("@CodProducto", parametros.CodProducto);
                    cmd.Parameters.AddWithValue("@IdEstadoPedido", parametros.IdEstadoPedido);
                    cmd.Parameters.AddWithValue("@IdFechaPedido", parametros.IdFechaPedido);
                    cmd.Parameters.AddWithValue("@Costo", parametros.Costo);
                    cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.NVarChar).Value = (object)parametros.Descripcion ?? DBNull.Value;

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarOrdenPedido(MOrdenPedido parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarOrdenPedido", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NumOrden", parametros.NumOrden);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
