using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DTelefonoProveedor
    {
        ConexionBD cn = new ConexionBD();
        //public async Task<List<MTelefonoProveedor>> MostrarTelefonoProveedor()
        //{
        //    var lista = new List<MTelefonoProveedor>();
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_mostrarTelefonoProveedor", sql))
        //        {
        //            await sql.OpenAsync();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            using (var item = await cmd.ExecuteReaderAsync())
        //            {
        //                while (await item.ReadAsync())
        //                {
        //                    var mProveedorTelefonoProveedor = new MTelefonoProveedor();
        //                    mProveedorTelefonoProveedor.IdTelefonoProveedor = (int)item["IdTelefonoProveedor"];
        //                    mProveedorTelefonoProveedor.IdProveedor = (int)item["IdProveedor"];
        //                    mProveedorTelefonoProveedor.Telefono = (string)item["Telefono"];
        //                    lista.Add(mProveedorTelefonoProveedor);
        //                }
        //            }
        //        }
        //    }
        //    return lista;
        //}

        public async Task InsertarTelefonoProveedor(MTelefonoProveedor parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarTelefonoProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre_Empresa", parametros.Nombre_Empresa);
                    cmd.Parameters.AddWithValue("@Telefono", parametros.TelefonoNuevo);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarTelefonoProveedor(MTelefonoProveedor parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarTelefonoProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre_Empresa", parametros.Nombre_Empresa);
                    cmd.Parameters.AddWithValue("@TelefonoAnt", parametros.TelefonoAnterior);
                    cmd.Parameters.AddWithValue("@TelefonoNue", parametros.TelefonoNuevo);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        //public async Task EliminarTelefonoProveedor(MTelefonoProveedor parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarTelefonoProveedor", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdTelefonoProveedor", parametros.IdTelefonoProveedor);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}
    }
}
