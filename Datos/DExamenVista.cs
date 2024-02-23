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

        public async Task<List<MExamenVista>> MostrarExamenVistaValido(MExamenVista parametros)
        {
            var lista = new List<MExamenVista>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarExamenesValidos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
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

        public async Task InsertarExamenVista(MExamenVistaIngreso parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarExamen", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Numero_Empleado", parametros.NumEmpleado);
                    cmd.Parameters.AddWithValue("@Codigo_Cliente", parametros.Codigo_Cliente);
                    cmd.Parameters.AddWithValue("@Fecha_Realizacion", parametros.Fecha_Realizacion);
                    cmd.Parameters.AddWithValue("@Observacion", SqlDbType.NVarChar).Value = (object)parametros.Observacion ?? DBNull.Value;

                    cmd.Parameters.AddWithValue("@SPHIz", SqlDbType.Decimal).Value = (object)parametros.SPHIz ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@CYLIz", SqlDbType.Decimal).Value = (object)parametros.CYLIz ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@ADDIz", SqlDbType.Decimal).Value = (object)parametros.ADDIz ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@EJEIz", SqlDbType.Int).Value = (object)parametros.EJEIz ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@DPIz", SqlDbType.Int).Value = (object)parametros.DPIz ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@ALTIz", SqlDbType.Int).Value = (object)parametros.ALTIz ?? DBNull.Value;
                    
                    cmd.Parameters.AddWithValue("@SPHDe", SqlDbType.Decimal).Value = (object)parametros.SPHDe ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@CYLDe", SqlDbType.Decimal).Value = (object)parametros.CYLDe ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@ADDDe", SqlDbType.Decimal).Value = (object)parametros.ADDDe ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@EJEDe", SqlDbType.Int).Value = (object)parametros.EJEDe ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@DPDe", SqlDbType.Int).Value = (object)parametros.DPDe ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@ALTDe", SqlDbType.Int).Value = (object)parametros.ALTDe ?? DBNull.Value;

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
        public async Task EditarExamenVista(MExamenVistaIngreso parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarEstadoExamen", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NumeroExamen", parametros.NumExamen);
                    cmd.Parameters.AddWithValue("@Estado", parametros.Estado);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

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
