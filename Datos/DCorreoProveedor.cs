using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DCorreoProveedor
    {
        ConexionBD cn = new ConexionBD();
        //public async Task<List<MCorreoProveedor>> MostrarCorreoProveedor()
        //{
        //    var lista = new List<MCorreoProveedor>();
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_mostrarCorreoProveedor", sql))
        //        {
        //            await sql.OpenAsync();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            using (var item = await cmd.ExecuteReaderAsync())
        //            {
        //                while (await item.ReadAsync())
        //                {
        //                    var mProveedorCorreoProveedor = new MCorreoProveedor();
        //                    mProveedorCorreoProveedor.IdCorreoProveedor = (int)item["IdCorreoProveedor"];
        //                    mProveedorCorreoProveedor.IdProveedor = (int)item["IdProveedor"];
        //                    mProveedorCorreoProveedor.Correo = (string)item["Correo"];
        //                    lista.Add(mProveedorCorreoProveedor);
        //                }
        //            }
        //        }
        //    }
        //    return lista;
        //}

        public async Task InsertarCorreoProveedor(MCorreoProveedor parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_insertarCorreoProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre_Empresa", parametros.Nombre_Empresa);
                    cmd.Parameters.AddWithValue("@Correo", parametros.CorreoNuevo);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarCorreoProveedor(MCorreoProveedor parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_editarCorreoProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Nombre_Empresa", parametros.Nombre_Empresa);
                    cmd.Parameters.AddWithValue("@CorreoAnt", parametros.CorreoAnterior);
                    cmd.Parameters.AddWithValue("@CorreoNue", parametros.CorreoNuevo);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        //public async Task EliminarCorreoProveedor(MCorreoProveedor parametros)
        //{
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("SP_eliminarCorreoProveedor", sql))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("@IdCorreoProveedor", parametros.IdCorreoProveedor);
        //            await sql.OpenAsync();
        //            await cmd.ExecuteNonQueryAsync();

        //        }
        //    }
        //}
    }
}
