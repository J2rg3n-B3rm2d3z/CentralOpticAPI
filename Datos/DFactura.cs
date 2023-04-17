using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DFactura
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MFactura>> MostrarFacturas()
        {
            var lista = new List<MFactura>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarFacturas", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mfactura = new MFactura();
                            mfactura.NumFactura = (int)item["NumFactura"];
                            mfactura.IdEstadoFactura = (int)item["IdEstadoFactura"];
                            mfactura.IdFechaFactura = (int)item["IdFechaFactura"];
                            mfactura.NumEmpleado = (int)item["NumEmpleado"];
                            mfactura.CodCliente = (int)item["CodCliente"];
                            mfactura.Impuestos = (decimal)item["Impuestos"];
                            mfactura.Descuento = (decimal)item["Descuento"];
                            lista.Add(mfactura);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarFactura(MFactura parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarFactura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdEstadoFactura", parametros.IdEstadoFactura);
                    cmd.Parameters.AddWithValue("@IdFechaFactura", parametros.IdFechaFactura);
                    cmd.Parameters.AddWithValue("@NumEmpleado", parametros.NumEmpleado);
                    cmd.Parameters.AddWithValue("@CodCliente", parametros.CodCliente);
                    cmd.Parameters.AddWithValue("@Impuestos", parametros.Impuestos);
                    cmd.Parameters.AddWithValue("@Descuento", parametros.Descuento);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarFactura(MFactura parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarFactura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NumFactura", parametros.NumFactura);
                    cmd.Parameters.AddWithValue("@IdEstadoFactura", parametros.IdEstadoFactura);
                    cmd.Parameters.AddWithValue("@IdFechaFactura", parametros.IdFechaFactura);
                    cmd.Parameters.AddWithValue("@NumEmpleado", parametros.NumEmpleado);
                    cmd.Parameters.AddWithValue("@CodCliente", parametros.CodCliente);
                    cmd.Parameters.AddWithValue("@Impuestos", parametros.Impuestos);
                    cmd.Parameters.AddWithValue("@Descuento", parametros.Descuento);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarFactura(MFactura parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_eliminarFactura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NumFactura", parametros.NumFactura);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
