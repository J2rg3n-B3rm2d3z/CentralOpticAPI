using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DEstadoEntrega
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MEstadoEntrega>> MostrarEstadoEntregas()
        {
            var lista = new List<MEstadoEntrega>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarEstadoEntregas", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mestadoentrega = new MEstadoEntrega();
                            mestadoentrega.IdEstadoEntrega = (int)item["IdEstadoEntrega"];
                            mestadoentrega.EstadoEntrega = (string)item["EstadoEntrega"];
                            lista.Add(mestadoentrega);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
