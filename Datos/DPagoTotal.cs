using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;
using CentralOpticAPI.Controladores;

namespace CentralOpticAPI.Datos
{
    public class DPagoTotal
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MPagoTotal>> MostrarPagoTotal()
        {
            var lista = new List<MPagoTotal>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarPagoTotal", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mPagoTotal = new MPagoTotal();
                            mPagoTotal.Numero_Factura = (int)item["Numero_Factura"];
                            mPagoTotal.FechaEmision = (DateTime)item["Fecha_Emision"];
                            mPagoTotal.Cliente_Factura = (string)item["Cliente_Factura"];
                            mPagoTotal.Estado_Factura = (string)item["Estado_Factura"];
                            mPagoTotal.Tipo_Factura = (string)item["Tipo_Factura"];
                            mPagoTotal.Subtotal_Factura = (decimal)item["Subtotal_Factura"];
                            mPagoTotal.Total_Factura = (decimal)item["Total_Factura"];
                            mPagoTotal.Total_Pagado = (decimal)item["Total_Pagado"];
                            if (!item.IsDBNull(item.GetOrdinal("Faltante")))
                                mPagoTotal.Faltante = (decimal)item["Faltante"];

                            lista.Add(mPagoTotal);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MPagoTotal>> MostrarPagoTotalByFactura(MPagoTotal parametros)
        {
            var lista = new List<MPagoTotal>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarPagoTotalByFactura", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Numero_Factura", parametros.Numero_Factura);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mPagoTotal = new MPagoTotal();
                            mPagoTotal.Numero_Factura = (int)item["Numero_Factura"];
                            mPagoTotal.FechaEmision = (DateTime)item["Fecha_Emision"];
                            mPagoTotal.Cliente_Factura = (string)item["Cliente_Factura"];
                            mPagoTotal.Estado_Factura = (string)item["Estado_Factura"];
                            mPagoTotal.Tipo_Factura = (string)item["Tipo_Factura"];
                            mPagoTotal.Subtotal_Factura = (decimal)item["Subtotal_Factura"];
                            mPagoTotal.Total_Factura = (decimal)item["Total_Factura"];
                            mPagoTotal.Total_Pagado = (decimal)item["Total_Pagado"];
                            if (!item.IsDBNull(item.GetOrdinal("Faltante")))
                                mPagoTotal.Faltante = (decimal)item["Faltante"];

                            lista.Add(mPagoTotal);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
