using CentralOpticAPI.Conexion;
using CentralOpticAPI.Controladores;
using CentralOpticAPI.Modelos;
using System.Data;
using System.Data.SqlClient;

namespace CentralOpticAPI.Datos
{
    public class DCliente
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MCliente>> MostrarClientes()
        {
            var lista = new List<MCliente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarClientes", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mcliente = new MCliente();
                            mcliente.Codigo_Cliente = (int)item["Codigo_Cliente"];
                            mcliente.Nombres = (string)item["Nombres"];
                            mcliente.Apellidos = (string)item["Apellidos"];
                            mcliente.Empresa_Asociada = (string)item["Empresa_Asociada"];
                            if (!item.IsDBNull(item.GetOrdinal("Cedula")))
                                mcliente.Cedula = (string)item["Cedula"];
                            if (!item.IsDBNull(item.GetOrdinal("Direccion")))
                                mcliente.Direccion = (string)item["Direccion"];
                            if (!item.IsDBNull(item.GetOrdinal("Telefonos")))
                                mcliente.Telefonos = (string)item["Telefonos"];
                            if (!item.IsDBNull(item.GetOrdinal("Correos")))
                                mcliente.Correos = (string)item["Correos"];
                            if (!item.IsDBNull(item.GetOrdinal("Fecha_Nacimiento")))
                                mcliente.FechaNac = (DateTime)item["Fecha_Nacimiento"];
                            if (!item.IsDBNull(item.GetOrdinal("Edad")))
                                mcliente.Edad = (int)item["Edad"];
                            lista.Add(mcliente);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MCliente>> MostrarClientesById(MCliente parametros)
        {
            var lista = new List<MCliente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarClientesbyId", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo_Cliente", parametros.Codigo_Cliente);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mcliente = new MCliente();
                            mcliente.Codigo_Cliente = (int)item["Codigo_Cliente"];
                            mcliente.Nombres = (string)item["Nombres"];
                            mcliente.Apellidos = (string)item["Apellidos"];
                            mcliente.Empresa_Asociada = (string)item["Empresa_Asociada"];
                            if (!item.IsDBNull(item.GetOrdinal("Cedula")))
                                mcliente.Cedula = (string)item["Cedula"];
                            if (!item.IsDBNull(item.GetOrdinal("Direccion")))
                                mcliente.Direccion = (string)item["Direccion"];
                            if (!item.IsDBNull(item.GetOrdinal("Telefonos")))
                                mcliente.Telefonos = (string)item["Telefonos"];
                            if (!item.IsDBNull(item.GetOrdinal("Correos")))
                                mcliente.Correos = (string)item["Correos"];
                            if (!item.IsDBNull(item.GetOrdinal("Fecha_Nacimiento")))
                                mcliente.FechaNac = (DateTime)item["Fecha_Nacimiento"];
                            if (!item.IsDBNull(item.GetOrdinal("Edad")))
                                mcliente.Edad = (int)item["Edad"];
                            lista.Add(mcliente);
                        }
                    }
                }
            }
            return lista;
        }

        //public async Task InsertarCliente(MCliente parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_insertarCliente", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@Cedula", parametros.Cedula);
        //            cmd.Parameters.AddWithValue("@Nombres", parametros.Nombres);
        //            cmd.Parameters.AddWithValue("@Apellidos", parametros.Apellidos);
        //            cmd.Parameters.AddWithValue("@Direccion", SqlDbType.NVarChar).Value = (object)parametros.Direccion ?? DBNull.Value;

        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

        //public async Task EditarCliente(MCliente parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_editarCliente", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@CodCliente", parametros.CodCliente);
        //            cmd.Parameters.AddWithValue("@Cedula", parametros.Cedula);
        //            cmd.Parameters.AddWithValue("@Nombres", parametros.Nombres);
        //            cmd.Parameters.AddWithValue("@Apellidos", parametros.Apellidos);
        //            cmd.Parameters.AddWithValue("@Direccion", SqlDbType.NVarChar).Value = (object)parametros.Direccion ?? DBNull.Value;

        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

        //public async Task EliminarCliente(MCliente parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarCliente", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@CodCliente", parametros.CodCliente);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

    }
}
