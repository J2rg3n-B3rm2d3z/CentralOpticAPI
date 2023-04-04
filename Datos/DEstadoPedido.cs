using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DEstadoPedido
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MEstadoPedido>> MostrarEstadoPedido()
        {
            var lista = new List<MEstadoPedido>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarEstadoPedidos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mestadopedido = new MEstadoPedido();
                            mestadopedido.IdEstadoPedido = (int)item["IdEstadoPedido"];
                            mestadopedido.EstadoPedido = (string)item["EstadoPedido"];
                            lista.Add(mestadopedido);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
