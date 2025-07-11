using ProyectoCrud.DAL.Repositorio;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{

        public class InventarioService : IIventarioService
        {
            private readonly IInventarioRepository<Inventario> _contacRepo;

            public InventarioService(IInventarioRepository<Inventario> contactRepo)
            {
                _contacRepo = contactRepo;
            }

            public async Task<bool> Actualizar(Inventario modelo)
            {
                return await _contacRepo.Actualizar(modelo);
            }

            public async Task<bool> Eliminar(Inventario modelo)
            {
                return await _contacRepo.Eliminar(modelo);
            }

            public async Task<bool> Insertar(Inventario modelo)
            {
                return await _contacRepo.Insertar(modelo);
            }

            public async Task<Inventario> Obtener(int id)
            {
                return await _contacRepo.Obtener(id);
            }

            //public async Task<Inventario> ObtenerPorNombre(string nombreInventario)
            //{
            //    IQueryable<Inventario> queryInventarioSQL = await _contacRepo.ObtenerTodos();
            //    Inventario Inventario = queryInventarioSQL.Where(c => c.Nombre == nombreInventario).FirstOrDefault();
            //    return Inventario;
            //}

            public async Task<IQueryable<Inventario>> ObtenerTodos()
            {
                return await _contacRepo.ObtenerTodos();
            }
        }
    
}
