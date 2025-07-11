using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public interface IIventarioService
    {
        Task<bool> Insertar(Inventario modelo);
        Task<bool> Actualizar(Inventario modelo);
        Task<bool> Eliminar(Inventario modelo);
        Task<Inventario> Obtener(int id);
        Task<IQueryable<Inventario>> ObtenerTodos();


        //Task<Inventario> ObtenerPorNombre(string nombreInventario);
    }
}
