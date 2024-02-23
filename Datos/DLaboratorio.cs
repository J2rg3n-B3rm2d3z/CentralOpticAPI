using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;
using CentralOpticAPI.Controladores;

namespace CentralOpticAPI.Datos
{
    public class DLaboratorio
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MLaboratorio>> MostrarLaboratorios()
        {
            var lista = new List<MLaboratorio>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarLaboratorio", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mlaboratorio = new MLaboratorio();
                            mlaboratorio.Codigo_Laboratorio = (int)item["Codigo_Laboratorio"];
                            mlaboratorio.Estado = (bool)item["Estado"];
                            mlaboratorio.Nombre = (string)item["Nombre"];
                            mlaboratorio.Direccion = (string)item["Direccion"];
                            if (!item.IsDBNull(item.GetOrdinal("Telefono")))
                                mlaboratorio.Telefono = (string)item["Telefono"];
                            if (!item.IsDBNull(item.GetOrdinal("Correo")))
                                mlaboratorio.Correo = (string)item["Correo"];

                            lista.Add(mlaboratorio);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MLaboratorio>> MostrarLaboratoriosById(MLaboratorio parametros)
        {
            var lista = new List<MLaboratorio>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarLaboratorioById", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo_Laboratorio", parametros.Codigo_Laboratorio);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mlaboratorio = new MLaboratorio();
                            mlaboratorio.Codigo_Laboratorio = (int)item["Codigo_Laboratorio"];
                            mlaboratorio.Estado = (bool)item["Estado"];
                            mlaboratorio.Nombre = (string)item["Nombre"];
                            mlaboratorio.Direccion = (string)item["Direccion"];
                            if (!item.IsDBNull(item.GetOrdinal("Telefono")))
                                mlaboratorio.Telefono = (string)item["Telefono"];
                            if (!item.IsDBNull(item.GetOrdinal("Correo")))
                                mlaboratorio.Correo = (string)item["Correo"];

                            lista.Add(mlaboratorio);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MLaboratorio>> MostrarLaboratoriosActivos(MLaboratorio parametros)
        {
            var lista = new List<MLaboratorio>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarLaboratorioActivo", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mlaboratorio = new MLaboratorio();
                            mlaboratorio.Codigo_Laboratorio = (int)item["Codigo_Laboratorio"];
                            mlaboratorio.Estado = (bool)item["Estado"];
                            mlaboratorio.Nombre = (string)item["Nombre"];
                            mlaboratorio.Direccion = (string)item["Direccion"];
                            if (!item.IsDBNull(item.GetOrdinal("Telefono")))
                                mlaboratorio.Telefono = (string)item["Telefono"];
                            if (!item.IsDBNull(item.GetOrdinal("Correo")))
                                mlaboratorio.Correo = (string)item["Correo"];

                            lista.Add(mlaboratorio);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarLaboratorio(MLaboratorio parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarLaboratorio", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", parametros.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", SqlDbType.NChar).Value = (object)parametros.Telefono ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@Correo", SqlDbType.NVarChar).Value = (object)parametros.Correo ?? DBNull.Value;

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarLaboratorio(MLaboratorio parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarLaboratorio", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Codigo_Laboratorio", parametros.Codigo_Laboratorio);
                    cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
                    cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
                    cmd.Parameters.AddWithValue("@Direccion", parametros.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", SqlDbType.NVarChar).Value = (object)parametros.Telefono ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@Correo", SqlDbType.NVarChar).Value = (object)parametros.Correo ?? DBNull.Value;

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        //public async Task EliminarLaboratorio(MLaboratorio parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarLaboratorio", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdLaboratorio", parametros.IdLaboratorio);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}
    }
}
