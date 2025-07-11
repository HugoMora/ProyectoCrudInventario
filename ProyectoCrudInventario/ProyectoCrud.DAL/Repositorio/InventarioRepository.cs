using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoCrud.DAL.DataContext;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Repositorio
{
    public class InventarioRepository : IInventarioRepository<Inventario>
    {
        private readonly DBPRUEBASContext _dbcontext;

        public InventarioRepository(DBPRUEBASContext context)
        {
            _dbcontext = context;
        }

        public async Task<bool> Actualizar(Inventario modelo)
        {
            _dbcontext.Inventarios.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Eliminar(Inventario modelo)
        {
            // Obtiene la conexión
            var connection = _dbcontext.Database.GetDbConnection();

            // Crea el comando para el SP
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "uEliminarMovInventario";
                command.CommandType = CommandType.StoredProcedure;

                // Agrega los parámetros
                command.Parameters.Add(new SqlParameter("@CodCia", SqlDbType.VarChar, 5) { Value = modelo.CodCia });
                command.Parameters.Add(new SqlParameter("@CompaniaVenta3", SqlDbType.VarChar, 5) { Value = modelo.CompaniaVenta3 });
                command.Parameters.Add(new SqlParameter("@AlmacenVenta", SqlDbType.VarChar, 10) { Value = modelo.AlmacenVenta });
                command.Parameters.Add(new SqlParameter("@TipoMovimiento", SqlDbType.VarChar, 2) { Value = modelo.TipoMovimiento });
                command.Parameters.Add(new SqlParameter("@TipoDocumento", SqlDbType.VarChar, 2) { Value = modelo.TipoDocumento });
                command.Parameters.Add(new SqlParameter("@NroDocumento", SqlDbType.VarChar, 50) { Value = modelo.NroDocumento });
                command.Parameters.Add(new SqlParameter("@CodItem2", SqlDbType.VarChar, 50) { Value = modelo.CodItem2 });

                // Abre la conexión si está cerrada
                if (connection.State != ConnectionState.Open)
                    await connection.OpenAsync();

                // Ejecuta el SP
                var rowsAffected = await command.ExecuteNonQueryAsync();

                // Devuelve true si al menos 1 fila fue eliminada
                return rowsAffected > 0;
            }
        }

        public async Task<bool> Insertar(Inventario modelo)
        {
            _dbcontext.Inventarios.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Inventario> Obtener(int id)
        {
            return await _dbcontext.Inventarios.FindAsync(id);
        }

        public async Task<IQueryable<Inventario>> ObtenerTodos()
        {
            IQueryable<Inventario> queryInventarioSQL = _dbcontext.Inventarios;
            return queryInventarioSQL;
        }
    }
}
