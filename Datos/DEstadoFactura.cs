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
                using (var cmd = new SqlCommand("SP_mostrarEstadoFactura", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mestadofactura = new MEstadoFactura();
                            mestadofactura.IdEstadoFactura = (int)item["Id_EstadoFactura"];
                            mestadofactura.EstadoFactura = (string)item["Estado_Factura"];
                            lista.Add(mestadofactura);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MEstadoFactura>> MostrarEstadoFacturasById(MEstadoFactura parametros)
        {
            var lista = new List<MEstadoFactura>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarEstadoFacturaById", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_EstadoFactura", parametros.IdEstadoFactura);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mestadofactura = new MEstadoFactura();
                            mestadofactura.IdEstadoFactura = (int)item["Id_EstadoFactura"];
                            mestadofactura.EstadoFactura = (string)item["Estado_Factura"];
                            lista.Add(mestadofactura);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
