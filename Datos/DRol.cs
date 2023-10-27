using CentralOpticAPI.Conexion;
using CentralOpticAPI.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace CentralOpticAPI.Datos
{
    public class DRol
    {
        ConexionBD cn = new ConexionBD();
        public async Task<List<MRol>> MostrarRoles()
        {
            var lista = new List<MRol>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarRoles", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mrol = new MRol();
                            mrol.idRol = (int)item["Id_Rol"];
                            mrol.rol = (string)item["Rol"];
                            mrol.descripcion = (string)item["Descripcion"];

                            lista.Add(mrol);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MRol>> MostrarRolesById(MRol parametros)
        {
            var lista = new List<MRol>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("SP_mostrarRolById", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id_Rol", parametros.idRol);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mrol = new MRol();
                            mrol.idRol = (int)item["Id_Rol"];
                            mrol.rol = (string)item["Rol"];
                            mrol.descripcion = (string)item["Descripcion"];

                            lista.Add(mrol);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
