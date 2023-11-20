using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;
using CentralOpticAPI.Controladores;

namespace CentralOpticAPI.Datos
{
    public class DProveedor
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MProveedor>> MostrarProveedor()
        {
            var lista = new List<MProveedor>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarProveedores", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mProveedor = new MProveedor();
                            mProveedor.CodigoProveedor = (int)item["Codigo_Proveedor"];
                            mProveedor.Nombre_Empresa = (string)item["Nombre_Empresa"];
                            if (!item.IsDBNull(item.GetOrdinal("Nombre_Contacto")))
                                mProveedor.Contacto = (string)item["Nombre_Contacto"];
                            if (!item.IsDBNull(item.GetOrdinal("Direccion")))
                                mProveedor.Direccion = (string)item["Direccion"];
                            mProveedor.Estado = (bool)item["Estado"];
                            if (!item.IsDBNull(item.GetOrdinal("Telefonos")))
                                mProveedor.Telefonos = (string)item["Telefonos"];
                            if (!item.IsDBNull(item.GetOrdinal("Correos")))
                                mProveedor.Correos = (string)item["Correos"];
                            lista.Add(mProveedor);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MProveedor>> MostrarProveedorById(MProveedor parametros)
        {
            var lista = new List<MProveedor>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarProveedoresbyId", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Codigo_Proveedor", parametros.CodigoProveedor);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mProveedor = new MProveedor();
                            mProveedor.CodigoProveedor = (int)item["Codigo_Proveedor"];
                            mProveedor.Nombre_Empresa = (string)item["Nombre_Empresa"];
                            if (!item.IsDBNull(item.GetOrdinal("Nombre_Contacto")))
                                mProveedor.Contacto = (string)item["Nombre_Contacto"];
                            if (!item.IsDBNull(item.GetOrdinal("Direccion")))
                                mProveedor.Direccion = (string)item["Direccion"];
                            mProveedor.Estado = (bool)item["Estado"];
                            if (!item.IsDBNull(item.GetOrdinal("Telefonos")))
                                mProveedor.Telefonos = (string)item["Telefonos"];
                            if (!item.IsDBNull(item.GetOrdinal("Correos")))
                                mProveedor.Correos = (string)item["Correos"];
                            lista.Add(mProveedor);
                        }
                    }
                }
            }
            return lista;
        }

        //public async Task InsertarProveedor(MProveedor parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_insertarProveedor", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
        //            cmd.Parameters.AddWithValue("@Propietario", SqlDbType.NVarChar).Value = (object)parametros.Propietario ?? DBNull.Value;
        //            cmd.Parameters.AddWithValue("@Direccion", parametros.Direccion);

        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

        //public async Task EditarProveedor(MProveedor parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_editarProveedor", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdProveedor", parametros.IdProveedor);
        //            cmd.Parameters.AddWithValue("@Nombre", parametros.Nombre);
        //            cmd.Parameters.AddWithValue("@Propietario", SqlDbType.NVarChar).Value = (object)parametros.Propietario ?? DBNull.Value;
        //            cmd.Parameters.AddWithValue("@Direccion", parametros.Direccion);

        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

        //public async Task EliminarProveedor(MProveedor parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarProveedor", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdProveedor", parametros.IdProveedor);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}

    }
}

