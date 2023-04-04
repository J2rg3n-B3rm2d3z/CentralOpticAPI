using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DEstadoFactura
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MEstadoFactura>> MostrarEstadoFacturas()
        {
            var lista = new List<MEstadoFactura>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarEstadoFacturas", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mestadofactura = new MEstadoFactura();
                            mestadofactura.IdEstadoFactura = (int)item["IdEstadoFactura"];
                            mestadofactura.EstadoFactura = (string)item["EstadoFactura"];
                            lista.Add(mestadofactura);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
