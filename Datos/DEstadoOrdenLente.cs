using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DEstadoOrdenLente
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MEstadoOrdenLente>> MostrarEstadoPedido()
        {
            var lista = new List<MEstadoOrdenLente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarEstadoOrdenLente", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mestadopedido = new MEstadoOrdenLente();
                            mestadopedido.Id_EstadoOrdenLente = (int)item["Id_EstadoOrdenLente"];
                            mestadopedido.Estado_OrdenLente = (string)item["Estado_OrdenLente"];
                            lista.Add(mestadopedido);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MEstadoOrdenLente>> MostrarEstadoPedidoById(MEstadoOrdenLente parametros)
        {
            var lista = new List<MEstadoOrdenLente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarEstadoOrdenLenteById", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_EstadoOrdenLente", parametros.Id_EstadoOrdenLente);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mestadopedido = new MEstadoOrdenLente();
                            mestadopedido.Id_EstadoOrdenLente = (int)item["Id_EstadoOrdenLente"];
                            mestadopedido.Estado_OrdenLente = (string)item["Estado_OrdenLente"];
                            lista.Add(mestadopedido);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
