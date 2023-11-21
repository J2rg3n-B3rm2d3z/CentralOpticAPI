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
                using (var cmd = new SqlCommand("SP_mostrarExamenes", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mExamenVista = new MExamenVista();
                            mExamenVista.NumExamen = (int)item["Numero_Examen"];
                            mExamenVista.Estado = (bool)item["Estado"];
                            mExamenVista.Empleado = (string)item["Empleado"];
                            mExamenVista.Paciente = (string)item["Paciente"];
                            mExamenVista.Fecha_Realizacion = (DateTime)item["Fecha_Realizacion"];
                            if (!item.IsDBNull(item.GetOrdinal("Observacion")))
                                mExamenVista.Observacion = (string)item["Observacion"];

                            if (!item.IsDBNull(item.GetOrdinal("SPHIz")))
                                mExamenVista.SPHIz = (decimal)item["SPHIz"];
                            if (!item.IsDBNull(item.GetOrdinal("CYLIz")))
                                mExamenVista.CYLIz = (decimal)item["CYLIz"];
                            if (!item.IsDBNull(item.GetOrdinal("ADDIz")))
                                mExamenVista.ADDIz = (decimal)item["ADDIz"];
                            if (!item.IsDBNull(item.GetOrdinal("EJEIz")))
                                mExamenVista.EJEIz = (int)item["EJEIz"];
                            if (!item.IsDBNull(item.GetOrdinal("DPIz")))
                                mExamenVista.DPIz = (int)item["DPIz"];
                            if (!item.IsDBNull(item.GetOrdinal("ALTIz")))
                                mExamenVista.ALTIz = (int)item["ALTIz"];

                            if (!item.IsDBNull(item.GetOrdinal("SPHDe")))
                                mExamenVista.SPHDe = (decimal)item["SPHDe"];
                            if (!item.IsDBNull(item.GetOrdinal("CYLDe")))
                                mExamenVista.CYLDe = (decimal)item["CYLDe"];                       
                            if (!item.IsDBNull(item.GetOrdinal("ADDDe")))
                                mExamenVista.ADDDe = (decimal)item["ADDDe"];
                            if (!item.IsDBNull(item.GetOrdinal("EJEDe")))
                                mExamenVista.EJEDe = (int)item["EJEDe"];
                            if (!item.IsDBNull(item.GetOrdinal("DPDe")))
                                mExamenVista.DPDe = (int)item["DPDe"];
                            if (!item.IsDBNull(item.GetOrdinal("ALTDe")))
                                mExamenVista.ALTDe = (int)item["ALTDe"];

                            lista.Add(mExamenVista);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MExamenVista>> MostrarExamenVistaById(MExamenVista parametros)
        {
            var lista = new List<MExamenVista>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarExamenesById", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Numero_Examen", parametros.NumExamen);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mExamenVista = new MExamenVista();
                            mExamenVista.NumExamen = (int)item["Numero_Examen"];
                            mExamenVista.Estado = (bool)item["Estado"];
                            mExamenVista.Empleado = (string)item["Empleado"];
                            mExamenVista.Paciente = (string)item["Paciente"];
                            mExamenVista.Fecha_Realizacion = (DateTime)item["Fecha_Realizacion"];
                            if (!item.IsDBNull(item.GetOrdinal("Observacion")))
                                mExamenVista.Observacion = (string)item["Observacion"];

                            if (!item.IsDBNull(item.GetOrdinal("SPHIz")))
                                mExamenVista.SPHIz = (decimal)item["SPHIz"];
                            if (!item.IsDBNull(item.GetOrdinal("CYLIz")))
                                mExamenVista.CYLIz = (decimal)item["CYLIz"];
                            if (!item.IsDBNull(item.GetOrdinal("ADDIz")))
                                mExamenVista.ADDIz = (decimal)item["ADDIz"];
                            if (!item.IsDBNull(item.GetOrdinal("EJEIz")))
                                mExamenVista.EJEIz = (int)item["EJEIz"];
                            if (!item.IsDBNull(item.GetOrdinal("DPIz")))
                                mExamenVista.DPIz = (int)item["DPIz"];
                            if (!item.IsDBNull(item.GetOrdinal("ALTIz")))
                                mExamenVista.ALTIz = (int)item["ALTIz"];

                            if (!item.IsDBNull(item.GetOrdinal("SPHDe")))
                                mExamenVista.SPHDe = (decimal)item["SPHDe"];
                            if (!item.IsDBNull(item.GetOrdinal("CYLDe")))
                                mExamenVista.CYLDe = (decimal)item["CYLDe"];
                            if (!item.IsDBNull(item.GetOrdinal("ADDDe")))
                                mExamenVista.ADDDe = (decimal)item["ADDDe"];
                            if (!item.IsDBNull(item.GetOrdinal("EJEDe")))
                                mExamenVista.EJEDe = (int)item["EJEDe"];
                            if (!item.IsDBNull(item.GetOrdinal("DPDe")))
                                mExamenVista.DPDe = (int)item["DPDe"];
                            if (!item.IsDBNull(item.GetOrdinal("ALTDe")))
                                mExamenVista.ALTDe = (int)item["ALTDe"];

                            lista.Add(mExamenVista);
                        }
                    }
                }
            }
            return lista;
        }

        //public async Task InsertarExamenVista(MExamenVista parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_insertarExamenVista", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@CodCliente", parametros.CodCliente);
        //            cmd.Parameters.AddWithValue("@IdFechaExamen", parametros.IdFechaExamen);
        //            cmd.Parameters.AddWithValue("@OjoIzquierdo", parametros.OjoIzquierdo);
        //            cmd.Parameters.AddWithValue("@OjoDerecho", parametros.OjoDerecho);
        //            cmd.Parameters.AddWithValue("@DescripLenteIzq", SqlDbType.NVarChar).Value = (object)parametros.DescripLenteIzq ?? DBNull.Value;
        //            cmd.Parameters.AddWithValue("@DescripLenteDer", SqlDbType.NVarChar).Value = (object)parametros.DescripLenteDer ?? DBNull.Value;

        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

        //public async Task EditarExamenVista(MExamenVista parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_editarExamenVista", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@NumExamen", parametros.NumExamen);
        //            cmd.Parameters.AddWithValue("@CodCliente", parametros.CodCliente);
        //            cmd.Parameters.AddWithValue("@IdFechaExamen", parametros.IdFechaExamen);
        //            cmd.Parameters.AddWithValue("@OjoIzquierdo", parametros.OjoIzquierdo);
        //            cmd.Parameters.AddWithValue("@OjoDerecho", parametros.OjoDerecho);
        //            cmd.Parameters.AddWithValue("@DescripLenteIzq", SqlDbType.NVarChar).Value = (object)parametros.DescripLenteIzq ?? DBNull.Value;
        //            cmd.Parameters.AddWithValue("@DescripLenteDer", SqlDbType.NVarChar).Value = (object)parametros.DescripLenteDer ?? DBNull.Value;


        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

        //public async Task EliminarExamenVista(MExamenVista parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarExamenVista", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@NumExamen", parametros.NumExamen);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

    }
}
