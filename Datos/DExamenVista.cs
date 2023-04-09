using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;
using CentralOpticAPI.Controladores;

namespace CentralOpticAPI.Datos
{
    public class DExamenVista
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MExamenVista>> MostrarExamenVista()
        { 
            var lista = new List<MExamenVista>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarExamenVista", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mExamenVista = new MExamenVista();
                            mExamenVista.NumExamen = (int)item["NumExamen"];
                            mExamenVista.IdFechaExamen = (int)item["IdFechaExamen"];
                            mExamenVista.CodCliente = (int)item["CodCliente"];
                            mExamenVista.OjoIzquierdo = (decimal)item["OjoIzquierdo"];
                            mExamenVista.OjoDerecho = (decimal)item["OjoDerecho"];
                            if (!item.IsDBNull(item.GetOrdinal("DescripLenteIzq")))
                                mExamenVista.DescripLenteIzq = (string)item["DescripLenteIzq"];
                            if (!item.IsDBNull(item.GetOrdinal("DescripLenteDer")))
                                mExamenVista.DescripLenteDer = (string)item["DescripLenteDer"];
                            lista.Add(mExamenVista);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarExamenVista(MExamenVista parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarExamenVista", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CodCliente", parametros.CodCliente);
                    cmd.Parameters.AddWithValue("@IdFechaExamen", parametros.IdFechaExamen);
                    cmd.Parameters.AddWithValue("@OjoIzquierdo", parametros.OjoIzquierdo);
                    cmd.Parameters.AddWithValue("@OjoDerecho", parametros.OjoDerecho);
                    cmd.Parameters.AddWithValue("@DescripLenteIzq", SqlDbType.NVarChar).Value = (object)parametros.DescripLenteIzq ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@DescripLenteDer", SqlDbType.NVarChar).Value = (object)parametros.DescripLenteDer ?? DBNull.Value;

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarExamenVista(MExamenVista parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarExamenVista", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NumExamen", parametros.NumExamen);
                    cmd.Parameters.AddWithValue("@CodCliente", parametros.CodCliente);
                    cmd.Parameters.AddWithValue("@IdFechaExamen", parametros.IdFechaExamen);
                    cmd.Parameters.AddWithValue("@OjoIzquierdo", parametros.OjoIzquierdo);
                    cmd.Parameters.AddWithValue("@OjoDerecho", parametros.OjoDerecho);
                    cmd.Parameters.AddWithValue("@DescripLenteIzq", SqlDbType.NVarChar).Value = (object)parametros.DescripLenteIzq ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@DescripLenteDer", SqlDbType.NVarChar).Value = (object)parametros.DescripLenteDer ?? DBNull.Value;


                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarExamenVista(MExamenVista parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarExamenVista", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NumExamen", parametros.NumExamen);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

    }
}
